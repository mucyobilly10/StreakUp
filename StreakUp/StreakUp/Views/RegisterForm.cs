using System;
using System.Windows.Forms;
using StreakUp.Controllers;
using StreakUp.Models;

namespace StreakUp.Views;

public partial class RegisterForm : Form
{
    private readonly AuthController _authController;

    public RegisterForm()
    {
        InitializeComponent();
        AppTheme.Apply(this);
        // Connect View to Controller
        var repo = new UserRepository(AppConfig.ConnectionString);
        _authController = new AuthController(repo);
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            // 1. Check if passwords match
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Call the Controller to register
            _authController.Register(
                txtName.Text,
                txtEmail.Text,
                txtPassword.Text
            );

            // 3. Success message
            MessageBox.Show("Registration successful! Please log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 4. Close this form to go back to login
            this.Close();
        }
        catch (Exception ex)
        {
            // Show error if email exists or fields are empty
            MessageBox.Show(ex.Message, "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnBackToLogin_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}