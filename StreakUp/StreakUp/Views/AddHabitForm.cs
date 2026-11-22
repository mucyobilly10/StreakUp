using System;
using System.Windows.Forms;
using StreakUp.Controllers;
using StreakUp.Models;

namespace StreakUp.Views;

public partial class AddHabitForm : Form
{
    private readonly int _userId;
    private readonly HabitController? _habitController;

    public AddHabitForm()
    {
        InitializeComponent();
        AppTheme.Apply(this);
    }

    public AddHabitForm(int userId) : this()
    {
        if (userId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(userId), "A valid user is required to add a habit.");
        }

        _userId = userId;
        _habitController = new HabitController(new HabitRepository(AppConfig.ConnectionString));
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (_habitController == null)
        {
            MessageBox.Show("Sign in before adding a habit.", "Add Habit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            _habitController.AddHabit(
                _userId,
                txtName.Text,
                txtDescription.Text,
                txtCategory.Text,
                dtpReminder.Value.TimeOfDay);

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Could Not Save Habit", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
