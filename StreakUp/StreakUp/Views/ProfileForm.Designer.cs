namespace StreakUp.Views;

partial class ProfileForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblName = new Label();
        lblNewPassword = new Label();
        lblConfirmPassword = new Label();
        txtName = new TextBox();
        txtNewPassword = new TextBox();
        txtConfirmPassword = new TextBox();
        btnSave = new Button();
        btnCancel = new Button();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitle.Location = new Point(32, 24);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(160, 32);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Your profile";
        // 
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.Location = new Point(35, 78);
        lblName.Name = "lblName";
        lblName.Size = new Size(42, 15);
        lblName.TabIndex = 1;
        lblName.Text = "Name";
        // 
        // txtName
        // 
        txtName.Location = new Point(35, 99);
        txtName.Name = "txtName";
        txtName.PlaceholderText = "Enter your name";
        txtName.Size = new Size(370, 23);
        txtName.TabIndex = 2;
        // 
        // lblNewPassword
        // 
        lblNewPassword.AutoSize = true;
        lblNewPassword.Location = new Point(35, 145);
        lblNewPassword.Name = "lblNewPassword";
        lblNewPassword.Size = new Size(81, 15);
        lblNewPassword.TabIndex = 3;
        lblNewPassword.Text = "New password";
        // 
        // txtNewPassword
        // 
        txtNewPassword.Location = new Point(35, 166);
        txtNewPassword.Name = "txtNewPassword";
        txtNewPassword.PasswordChar = '*';
        txtNewPassword.PlaceholderText = "Leave blank to keep current password";
        txtNewPassword.Size = new Size(370, 23);
        txtNewPassword.TabIndex = 4;
        // 
        // lblConfirmPassword
        // 
        lblConfirmPassword.AutoSize = true;
        lblConfirmPassword.Location = new Point(35, 212);
        lblConfirmPassword.Name = "lblConfirmPassword";
        lblConfirmPassword.Size = new Size(107, 15);
        lblConfirmPassword.TabIndex = 5;
        lblConfirmPassword.Text = "Confirm password";
        // 
        // txtConfirmPassword
        // 
        txtConfirmPassword.Location = new Point(35, 233);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.PasswordChar = '*';
        txtConfirmPassword.PlaceholderText = "Re-enter new password";
        txtConfirmPassword.Size = new Size(370, 23);
        txtConfirmPassword.TabIndex = 6;
        // 
        // btnSave
        // 
        btnSave.Location = new Point(35, 286);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(150, 38);
        btnSave.TabIndex = 7;
        btnSave.Text = "Save Changes";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(205, 286);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(150, 38);
        btnCancel.TabIndex = 8;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // ProfileForm
        // 
        AcceptButton = btnSave;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        CancelButton = btnCancel;
        ClientSize = new Size(444, 358);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(txtConfirmPassword);
        Controls.Add(lblConfirmPassword);
        Controls.Add(txtNewPassword);
        Controls.Add(lblNewPassword);
        Controls.Add(txtName);
        Controls.Add(lblName);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ProfileForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "StreakUp - Profile";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Label lblName;
    private Label lblNewPassword;
    private Label lblConfirmPassword;
    private TextBox txtName;
    private TextBox txtNewPassword;
    private TextBox txtConfirmPassword;
    private Button btnSave;
    private Button btnCancel;
}
