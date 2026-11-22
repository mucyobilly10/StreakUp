using System;
using System.Windows.Forms;
using StreakUp.Controllers;
using StreakUp.Models;

namespace StreakUp.Views;

public partial class ProfileForm : Form
{
    private readonly User _loggedInUser;
    private readonly AuthController _authController;

    public string UpdatedName => _loggedInUser.Name;

    public ProfileForm(User loggedInUser)
    {
        ArgumentNullException.ThrowIfNull(loggedInUser);
        _loggedInUser = loggedInUser;
        InitializeComponent();
        AppTheme.Apply(this);
        _authController = new AuthController(new UserRepository(AppConfig.ConnectionString));
        Load += ProfileForm_Load;
    }

    private void ProfileForm_Load(object? sender, EventArgs e)
    {
        try
        {
            txtName.Text = _loggedInUser.Name;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Could Not Load Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        try
        {
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("The new password and confirmation do not match.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _authController.UpdateName(_loggedInUser.UserId, txtName.Text);
            _loggedInUser.Name = txtName.Text.Trim();

            if (!string.IsNullOrEmpty(txtNewPassword.Text))
            {
                _authController.UpdatePassword(_loggedInUser.UserId, txtNewPassword.Text);
            }

            MessageBox.Show("Your profile has been updated.", "Profile Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Could Not Save Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        try
        {
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Could Not Close Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
