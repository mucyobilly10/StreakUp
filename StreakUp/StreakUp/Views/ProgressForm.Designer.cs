namespace StreakUp.Views;

partial class ProgressForm
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
        lblHabits = new Label();
        lblWeekly = new Label();
        lblHistory = new Label();
        lblWeeklySummary = new Label();
        dgvHabits = new DataGridView();
        dgvWeekly = new DataGridView();
        dgvHistory = new DataGridView();
        btnBack = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvHabits).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvWeekly).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitle.Location = new Point(24, 18);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(181, 32);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Streaks & Progress";
        // 
        // lblHabits
        // 
        lblHabits.AutoSize = true;
        lblHabits.Location = new Point(27, 62);
        lblHabits.Name = "lblHabits";
        lblHabits.Size = new Size(44, 15);
        lblHabits.TabIndex = 1;
        lblHabits.Text = "Habits";
        // 
        // dgvHabits
        // 
        dgvHabits.AllowUserToAddRows = false;
        dgvHabits.AllowUserToDeleteRows = false;
        dgvHabits.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        dgvHabits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvHabits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvHabits.Location = new Point(27, 84);
        dgvHabits.MultiSelect = false;
        dgvHabits.Name = "dgvHabits";
        dgvHabits.ReadOnly = true;
        dgvHabits.RowHeadersWidth = 51;
        dgvHabits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvHabits.Size = new Size(930, 170);
        dgvHabits.TabIndex = 2;
        // 
        // lblWeekly
        // 
        lblWeekly.AutoSize = true;
        lblWeekly.Location = new Point(27, 273);
        lblWeekly.Name = "lblWeekly";
        lblWeekly.Size = new Size(85, 15);
        lblWeekly.TabIndex = 3;
        lblWeekly.Text = "Weekly Progress";
        // 
        // dgvWeekly
        // 
        dgvWeekly.AllowUserToAddRows = false;
        dgvWeekly.AllowUserToDeleteRows = false;
        dgvWeekly.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        dgvWeekly.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvWeekly.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvWeekly.Location = new Point(27, 296);
        dgvWeekly.MultiSelect = false;
        dgvWeekly.Name = "dgvWeekly";
        dgvWeekly.ReadOnly = true;
        dgvWeekly.RowHeadersWidth = 51;
        dgvWeekly.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvWeekly.Size = new Size(450, 270);
        dgvWeekly.TabIndex = 4;
        // 
        // lblHistory
        // 
        lblHistory.AutoSize = true;
        lblHistory.Location = new Point(500, 273);
        lblHistory.Name = "lblHistory";
        lblHistory.Size = new Size(85, 15);
        lblHistory.TabIndex = 5;
        lblHistory.Text = "Completed History";
        // 
        // dgvHistory
        // 
        dgvHistory.AllowUserToAddRows = false;
        dgvHistory.AllowUserToDeleteRows = false;
        dgvHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvHistory.Location = new Point(500, 296);
        dgvHistory.MultiSelect = false;
        dgvHistory.Name = "dgvHistory";
        dgvHistory.ReadOnly = true;
        dgvHistory.RowHeadersWidth = 51;
        dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvHistory.Size = new Size(457, 270);
        dgvHistory.TabIndex = 6;
        // 
        // lblWeeklySummary
        // 
        lblWeeklySummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblWeeklySummary.AutoSize = true;
        lblWeeklySummary.Location = new Point(27, 582);
        lblWeeklySummary.Name = "lblWeeklySummary";
        lblWeeklySummary.Size = new Size(0, 15);
        lblWeeklySummary.TabIndex = 7;
        // 
        // btnBack
        // 
        btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnBack.Location = new Point(832, 574);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(125, 36);
        btnBack.TabIndex = 8;
        btnBack.Text = "Back";
        btnBack.UseVisualStyleBackColor = true;
        btnBack.Click += btnBack_Click;
        // 
        // ProgressForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        ClientSize = new Size(984, 631);
        Controls.Add(btnBack);
        Controls.Add(lblWeeklySummary);
        Controls.Add(dgvHistory);
        Controls.Add(lblHistory);
        Controls.Add(dgvWeekly);
        Controls.Add(lblWeekly);
        Controls.Add(dgvHabits);
        Controls.Add(lblHabits);
        Controls.Add(lblTitle);
        MinimumSize = new Size(850, 600);
        Name = "ProgressForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "StreakUp - Streaks & Progress";
        ((System.ComponentModel.ISupportInitialize)dgvHabits).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvWeekly).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Label lblHabits;
    private Label lblWeekly;
    private Label lblHistory;
    private Label lblWeeklySummary;
    private DataGridView dgvHabits;
    private DataGridView dgvWeekly;
    private DataGridView dgvHistory;
    private Button btnBack;
}
