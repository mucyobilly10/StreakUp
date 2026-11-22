namespace StreakUp.Views;

partial class AddHabitForm
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
        lblDescription = new Label();
        lblCategory = new Label();
        lblReminder = new Label();
        txtName = new TextBox();
        txtDescription = new TextBox();
        txtCategory = new TextBox();
        dtpReminder = new DateTimePicker();
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
        lblTitle.Size = new Size(144, 32);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Add a habit";
        // 
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.Location = new Point(35, 78);
        lblName.Name = "lblName";
        lblName.Size = new Size(42, 15);
        lblName.TabIndex = 1;
        lblName.Text = "Name:";
        // 
        // txtName
        // 
        txtName.Location = new Point(35, 99);
        txtName.Name = "txtName";
        txtName.Size = new Size(370, 23);
        txtName.TabIndex = 2;
        // 
        // lblDescription
        // 
        lblDescription.AutoSize = true;
        lblDescription.Location = new Point(35, 137);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(70, 15);
        lblDescription.TabIndex = 3;
        lblDescription.Text = "Description:";
        // 
        // txtDescription
        // 
        txtDescription.Location = new Point(35, 158);
        txtDescription.Multiline = true;
        txtDescription.Name = "txtDescription";
        txtDescription.ScrollBars = ScrollBars.Vertical;
        txtDescription.Size = new Size(370, 88);
        txtDescription.TabIndex = 4;
        // 
        // lblCategory
        // 
        lblCategory.AutoSize = true;
        lblCategory.Location = new Point(35, 263);
        lblCategory.Name = "lblCategory";
        lblCategory.Size = new Size(58, 15);
        lblCategory.TabIndex = 5;
        lblCategory.Text = "Category:";
        // 
        // txtCategory
        // 
        txtCategory.Location = new Point(35, 284);
        txtCategory.Name = "txtCategory";
        txtCategory.Size = new Size(370, 23);
        txtCategory.TabIndex = 6;
        // 
        // lblReminder
        // 
        lblReminder.AutoSize = true;
        lblReminder.Location = new Point(35, 322);
        lblReminder.Name = "lblReminder";
        lblReminder.Size = new Size(91, 15);
        lblReminder.TabIndex = 7;
        lblReminder.Text = "Reminder Time:";
        // 
        // dtpReminder
        // 
        dtpReminder.Format = DateTimePickerFormat.Time;
        dtpReminder.Location = new Point(35, 343);
        dtpReminder.Name = "dtpReminder";
        dtpReminder.ShowUpDown = true;
        dtpReminder.Size = new Size(180, 23);
        dtpReminder.TabIndex = 8;
        // 
        // btnSave
        // 
        btnSave.Location = new Point(35, 394);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(140, 36);
        btnSave.TabIndex = 9;
        btnSave.Text = "Save Habit";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(195, 394);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(140, 36);
        btnCancel.TabIndex = 10;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // AddHabitForm
        // 
        AcceptButton = btnSave;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        CancelButton = btnCancel;
        ClientSize = new Size(444, 462);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(dtpReminder);
        Controls.Add(lblReminder);
        Controls.Add(txtCategory);
        Controls.Add(lblCategory);
        Controls.Add(txtDescription);
        Controls.Add(lblDescription);
        Controls.Add(txtName);
        Controls.Add(lblName);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AddHabitForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "StreakUp - Add Habit";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Label lblName;
    private Label lblDescription;
    private Label lblCategory;
    private Label lblReminder;
    private TextBox txtName;
    private TextBox txtDescription;
    private TextBox txtCategory;
    private DateTimePicker dtpReminder;
    private Button btnSave;
    private Button btnCancel;
}
