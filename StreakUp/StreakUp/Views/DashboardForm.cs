using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StreakUp.Controllers;
using StreakUp.Models;

namespace StreakUp.Views
{
    public partial class DashboardForm : Form
    {
        private HabitController? _habitController;
        private HabitLogRepository? _habitLogRepository;
        private HabitLogController? _logController;
        private ProgressController? _progressController;
        private int _userId;

        public DashboardForm()
        {
            InitializeComponent();
            AppTheme.Apply(this);
        }

        public DashboardForm(User user) : this()
        {
            ArgumentNullException.ThrowIfNull(user);
            _userId = user.UserId;
            var habitRepository = new HabitRepository(AppConfig.ConnectionString);
            _habitController = new HabitController(habitRepository);
            _habitLogRepository = new HabitLogRepository(AppConfig.ConnectionString);
            _logController = new HabitLogController(_habitLogRepository);
            _progressController = new ProgressController(_habitLogRepository, habitRepository);
            lblWelcome.Text = $"Welcome, {user.Name}!";
            RefreshDashboard();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_habitController == null)
            {
                return;
            }

            try
            {
                UpdateGridFromList(_habitController.SearchHabits(_userId, txtSearch.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_habitController == null)
            {
                return;
            }

            try
            {
                if (string.Equals(Convert.ToString(cmbFilter.SelectedItem), "Archived", StringComparison.OrdinalIgnoreCase))
                {
                    UpdateGridFromList(_habitController.FilterByStatus(_userId, true));
                }
                else
                {
                    RefreshDashboard();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateGridFromList(List<Habit> habits)
        {
            var table = new DataTable();
            table.Columns.Add("HabitId", typeof(int));
            table.Columns.Add("HabitName", typeof(string));
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("Status", typeof(string));

            foreach (Habit habit in habits)
            {
                string status = habit.IsArchived
                    ? "Archived"
                    : (_logController?.IsDoneOnDate(habit.HabitId, DateTime.Today) == true ? "Done" : "Not Done");
                table.Rows.Add(habit.HabitId, habit.Name, habit.Category ?? string.Empty, status);
            }

            dgvDashboard.DataSource = table;
            var habitIdColumn = dgvDashboard.Columns["HabitId"];
            if (habitIdColumn != null)
            {
                habitIdColumn.Visible = false;
            }

            var nameColumn = dgvDashboard.Columns["HabitName"];
            if (nameColumn != null)
            {
                nameColumn.HeaderText = "Habit";
            }
        }

        private void CheckReminders()
        {
            if (_habitController == null || _logController == null)
            {
                lblReminder.Text = string.Empty;
                return;
            }

            var dueHabits = new List<string>();
            DateTime now = DateTime.Now;
            foreach (Habit habit in _habitController.GetUserHabits(_userId))
            {
                if (habit.ReminderTime is not TimeSpan reminderTime ||
                    _logController.IsDoneOnDate(habit.HabitId, DateTime.Today))
                {
                    continue;
                }

                DateTime reminderDateTime = DateTime.Today.Add(reminderTime);
                double minutesUntilReminder = (reminderDateTime - now).TotalMinutes;
                if (minutesUntilReminder >= 0 && minutesUntilReminder <= 15)
                {
                    dueHabits.Add(habit.Name);
                }
            }

            lblReminder.Text = dueHabits.Count > 0
                ? $"⏰ Reminder: You have {dueHabits.Count} habit(s) due soon! ({string.Join(", ", dueHabits)})"
                : string.Empty;
        }

        private void btnMarkDone_Click(object sender, EventArgs e)
        {
            UpdateSelectedHabitCompletion(isDone: true);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            UpdateSelectedHabitCompletion(isDone: false);
        }

        private void UpdateSelectedHabitCompletion(bool isDone)
        {
            if (!TryGetSelectedHabit(out var habit))
            {
                return;
            }

            if (habit.IsArchived)
            {
                MessageBox.Show("Archived habits cannot be marked complete or undone.", "Habit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (isDone)
                {
                    _habitLogRepository!.MarkDone(habit.HabitId, DateTime.Today);
                }
                else
                {
                    _habitLogRepository!.MarkUndone(habit.HabitId, DateTime.Today);
                }

                RefreshDashboard();
            }
            catch (Exception ex)
            {
                string action = isDone ? "mark the habit done" : "undo today's completion";
                MessageBox.Show($"Could not {action}: {ex.Message}", "Habit Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnViewProgress_Click(object sender, EventArgs e)
        {
            if (_habitController == null)
            {
                MessageBox.Show("Sign in before viewing progress.", "Progress", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var progressForm = new ProgressForm(_userId);
                progressForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could Not Load Progress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddHabit_Click(object sender, EventArgs e)
        {
            if (_habitController == null)
            {
                MessageBox.Show("Sign in before adding a habit.", "Add Habit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var addHabitForm = new AddHabitForm(_userId);
            if (addHabitForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshDashboard();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedHabit(out var habit))
            {
                return;
            }

            using var editHabitForm = new EditHabitForm(habit, _habitController!);
            if (editHabitForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshDashboard();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedHabit(out var habit))
            {
                return;
            }

            var result = MessageBox.Show(
                $"Delete '{habit.Name}'? Its completion history will also be deleted.",
                "Delete Habit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _habitController!.DeleteHabit(_userId, habit.HabitId);
                RefreshDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could Not Delete Habit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedHabit(out var habit))
            {
                return;
            }

            bool archive = !habit.IsArchived;
            string action = archive ? "archive" : "restore";
            try
            {
                _habitController!.ArchiveHabit(_userId, habit.HabitId, archive);
                RefreshDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not {action} the habit: {ex.Message}", "Habit Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool TryGetSelectedHabit(out Habit habit)
        {
            habit = null!;
            if (_habitController == null)
            {
                MessageBox.Show("Sign in before managing habits.", "Habit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var row = dgvDashboard.CurrentRow;
            if (row == null || row.IsNewRow)
            {
                MessageBox.Show("Select a habit first.", "Habit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            string status = Convert.ToString(GetCellValue(row, "Status")) ?? string.Empty;
            object? archivedValue = GetCellValue(row, "IsArchived");
            habit = new Habit
            {
                HabitId = Convert.ToInt32(GetCellValue(row, "HabitId")),
                UserId = _userId,
                Name = Convert.ToString(GetCellValue(row, "HabitName")) ?? string.Empty,
                Description = Convert.ToString(GetCellValue(row, "Description")),
                Category = Convert.ToString(GetCellValue(row, "Category")),
                ReminderTime = GetCellValue(row, "ReminderTime") is TimeSpan reminderTime ? reminderTime : null,
                IsArchived = archivedValue != null && archivedValue != DBNull.Value
                    ? Convert.ToBoolean(archivedValue)
                    : string.Equals(status, "Archived", StringComparison.OrdinalIgnoreCase)
            };
            return true;
        }

        private static object? GetCellValue(DataGridViewRow row, string columnName)
        {
            return row.DataGridView?.Columns.Contains(columnName) == true
                ? row.Cells[columnName].Value
                : null;
        }

        private void RefreshDashboard()
        {
            if (_habitController != null)
            {
                dgvDashboard.DataSource = _habitController.GetTodayDashboard(_userId);
                if (_progressController != null)
                {
                    double percentage = _progressController.GetTodayCompletionPercentage(_userId);
                    lblProgressValue.Text = $"{percentage:F0}%";
                    lblProgressValue.ForeColor = percentage < 50
                        ? Color.FromArgb(196, 55, 55)
                        : percentage == 50
                            ? Color.FromArgb(38, 112, 218)
                            : Color.FromArgb(35, 145, 85);
                }

                var habitIdColumn = dgvDashboard.Columns["HabitId"];
                if (habitIdColumn != null)
                {
                    habitIdColumn.Visible = false;
                }

                var habitNameColumn = dgvDashboard.Columns["HabitName"];
                if (habitNameColumn != null)
                {
                    habitNameColumn.HeaderText = "Habit";
                }

                var reminderTimeColumn = dgvDashboard.Columns["ReminderTime"];
                if (reminderTimeColumn != null)
                {
                    reminderTimeColumn.HeaderText = "Reminder Time";
                }

                var archivedColumn = dgvDashboard.Columns["IsArchived"];
                if (archivedColumn != null)
                {
                    archivedColumn.HeaderText = "Archived";
                }
            }

            CheckReminders();
        }
    }
}
