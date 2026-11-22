using System;
using System.Windows.Forms;
using StreakUp.Controllers;
using StreakUp.Models;

namespace StreakUp.Views;

public partial class EditHabitForm : Form
{
    private readonly HabitController _habitController;
    private readonly Habit _habit;

    public EditHabitForm(Habit habit, HabitController habitController)
    {
        ArgumentNullException.ThrowIfNull(habit);
        ArgumentNullException.ThrowIfNull(habitController);
        InitializeComponent();
        AppTheme.Apply(this);
        _habit = habit;
        _habitController = habitController;
        txtName.Text = habit.Name;
        txtDescription.Text = habit.Description ?? string.Empty;
        txtCategory.Text = habit.Category ?? string.Empty;
        if (habit.ReminderTime.HasValue)
        {
            dtpReminder.Value = DateTime.Today.Add(habit.ReminderTime.Value);
        }
        btnSave.Click += btnSave_Click;
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        try
        {
            _habit.Name = txtName.Text;
            _habit.Description = txtDescription.Text;
            _habit.Category = txtCategory.Text;
            _habit.ReminderTime = dtpReminder.Value.TimeOfDay;
            _habitController.EditHabit(_habit);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Could Not Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
