using System.Data;
using System.Windows.Forms;
using StreakUp.Controllers;
using StreakUp.Models;

namespace StreakUp.Views;

public partial class ProgressForm : Form
{
    private readonly int _userId;
    private readonly HabitRepository _habitRepository;
    private readonly ProgressController _progressController;

    public ProgressForm(int userId)
    {
        if (userId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(userId), "A valid user is required to view progress.");
        }

        InitializeComponent();
        AppTheme.Apply(this);
        _userId = userId;
        _habitRepository = new HabitRepository(AppConfig.ConnectionString);
        _progressController = new ProgressController(
            new HabitLogRepository(AppConfig.ConnectionString),
            _habitRepository);
        dgvHabits.CellClick += dgvHabits_CellClick;
        LoadHabits();
    }

    private void LoadHabits()
    {
        var table = new DataTable();
        table.Columns.Add("HabitId", typeof(int));
        table.Columns.Add("Habit Name", typeof(string));
        table.Columns.Add("Current Streak", typeof(int));
        table.Columns.Add("Longest Streak", typeof(int));

        foreach (Habit habit in _habitRepository.GetAllByUser(_userId))
        {
            table.Rows.Add(
                habit.HabitId,
                habit.Name,
                _progressController.GetCurrentStreak(habit.HabitId),
                _progressController.GetLongestStreak(habit.HabitId));
        }

        dgvHabits.DataSource = table;
        var habitIdColumn = dgvHabits.Columns["HabitId"];
        if (habitIdColumn != null)
        {
            habitIdColumn.Visible = false;
        }

        if (dgvHabits.Rows.Count > 0)
        {
            dgvHabits.Rows[0].Selected = true;
            LoadSelectedHabit(dgvHabits.Rows[0]);
        }
    }

    private void dgvHabits_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }

        try
        {
            LoadSelectedHabit(dgvHabits.Rows[e.RowIndex]);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Could Not Load Habit Progress", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadSelectedHabit(DataGridViewRow row)
    {
        int habitId = Convert.ToInt32(row.Cells["HabitId"].Value);
        DataTable weeklyData = _progressController.GetWeeklyProgressByDay(habitId);
        var visibleWeeklyData = weeklyData.DefaultView.ToTable(false, "Day", "Date", "Status");
        dgvWeekly.DataSource = visibleWeeklyData;

        var historyTable = new DataTable();
        historyTable.Columns.Add("Completed Date", typeof(DateTime));
        foreach (var log in _progressController.GetHistory(habitId))
        {
            historyTable.Rows.Add(log.LogDate.Date);
        }
        dgvHistory.DataSource = historyTable;

        var weeklyProgress = _progressController.GetWeeklyProgress(habitId);
        lblWeeklySummary.Text = $"This week: {weeklyProgress.completedDays}/{weeklyProgress.totalDays} days ({weeklyProgress.percentage:F0}%)";
    }

    private void btnBack_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
