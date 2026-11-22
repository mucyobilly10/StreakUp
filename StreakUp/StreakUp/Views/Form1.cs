using System;
using System.Windows.Forms;
using StreakUp.Controllers;
using StreakUp.Models;

namespace StreakUp.Views;

public partial class Form1 : Form
{
    private readonly AuthController _authController;

    public Form1()
    {
        InitializeComponent();
        AppTheme.Apply(this);
        // Connect View to Controller
        var repo = new UserRepository(AppConfig.ConnectionString);
        _authController = new AuthController(repo);
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            var loggedInUser = _authController.Login(txtEmail.Text, txtPassword.Text);

            if (loggedInUser == null)
            {
                MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtEmail.Clear();
            txtPassword.Clear();

            using var dashboardForm = new DashboardForm(loggedInUser);
            dashboardForm.ShowDialog(this);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnGoToRegister_Click(object sender, EventArgs e)
    {
        // Open the Register form
        var registerForm = new RegisterForm();
        registerForm.ShowDialog(); // ShowDialog pauses this form until Register closes
    }
}