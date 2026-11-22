namespace StreakUp.Views
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblWelcome = new Label();
            lblProgress = new Label();
            lblProgressValue = new Label();
            lblReminder = new Label();
            txtSearch = new TextBox();
            cmbFilter = new ComboBox();
            btnSearch = new Button();
            dgvDashboard = new DataGridView();
            btnMarkDone = new Button();
            btnUndo = new Button();
            btnAddHabit = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnArchive = new Button();
            btnViewProgress = new Button();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblWelcome.ForeColor = SystemColors.Desktop;
            lblWelcome.Location = new Point(46, 40);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(308, 48);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, [User]!";
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Font = new Font("Segoe UI", 11F);
            lblProgress.ForeColor = SystemColors.Desktop;
            lblProgress.Location = new Point(50, 120);
            lblProgress.Margin = new Padding(4, 0, 4, 0);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(216, 30);
            lblProgress.TabIndex = 1;
            lblProgress.Text = "Today's Progress:";
            // 
            // lblProgressValue
            // 
            lblProgressValue.AutoSize = true;
            lblProgressValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblProgressValue.Location = new Point(230, 120);
            lblProgressValue.Margin = new Padding(4, 0, 4, 0);
            lblProgressValue.Name = "lblProgressValue";
            lblProgressValue.Size = new Size(45, 30);
            lblProgressValue.TabIndex = 2;
            lblProgressValue.Text = "0%";
            // 
            // lblReminder
            // 
            lblReminder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblReminder.Location = new Point(357, 127);
            lblReminder.Margin = new Padding(4, 0, 4, 0);
            lblReminder.Name = "lblReminder";
            lblReminder.Size = new Size(600, 33);
            lblReminder.TabIndex = 1;
            lblReminder.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(50, 177);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search habits";
            txtSearch.Size = new Size(341, 31);
            txtSearch.TabIndex = 2;
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Items.AddRange(new object[] { "All Active", "Archived" });
            cmbFilter.Location = new Point(543, 175);
            cmbFilter.Margin = new Padding(4, 5, 4, 5);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(213, 33);
            cmbFilter.TabIndex = 4;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.ImageKey = "(none)";
            btnSearch.Location = new Point(404, 168);
            btnSearch.Margin = new Padding(4, 5, 4, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(121, 53);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvDashboard
            // 
            dgvDashboard.AllowUserToAddRows = false;
            dgvDashboard.AllowUserToDeleteRows = false;
            dgvDashboard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDashboard.Location = new Point(50, 242);
            dgvDashboard.Margin = new Padding(4, 5, 4, 5);
            dgvDashboard.MultiSelect = false;
            dgvDashboard.Name = "dgvDashboard";
            dgvDashboard.ReadOnly = true;
            dgvDashboard.RowHeadersWidth = 51;
            dgvDashboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDashboard.Size = new Size(1163, 500);
            dgvDashboard.TabIndex = 2;
            // 
            // btnMarkDone
            // 
            btnMarkDone.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnMarkDone.Location = new Point(50, 777);
            btnMarkDone.Margin = new Padding(4, 5, 4, 5);
            btnMarkDone.Name = "btnMarkDone";
            btnMarkDone.Size = new Size(157, 63);
            btnMarkDone.TabIndex = 3;
            btnMarkDone.Text = "Mark Done";
            btnMarkDone.UseVisualStyleBackColor = true;
            btnMarkDone.Click += btnMarkDone_Click;
            // 
            // btnUndo
            // 
            btnUndo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUndo.Location = new Point(219, 777);
            btnUndo.Margin = new Padding(4, 5, 4, 5);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(107, 63);
            btnUndo.TabIndex = 4;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // btnAddHabit
            // 
            btnAddHabit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddHabit.Location = new Point(337, 777);
            btnAddHabit.Margin = new Padding(4, 5, 4, 5);
            btnAddHabit.Name = "btnAddHabit";
            btnAddHabit.Size = new Size(143, 63);
            btnAddHabit.TabIndex = 5;
            btnAddHabit.Text = "Add Habit";
            btnAddHabit.UseVisualStyleBackColor = true;
            btnAddHabit.Click += btnAddHabit_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEdit.Location = new Point(491, 777);
            btnEdit.Margin = new Padding(4, 5, 4, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(129, 63);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Edit Habit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Location = new Point(631, 777);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(143, 63);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete Habit";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnArchive
            // 
            btnArchive.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnArchive.Location = new Point(786, 777);
            btnArchive.Margin = new Padding(4, 5, 4, 5);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new Size(200, 63);
            btnArchive.TabIndex = 8;
            btnArchive.Text = "Archive / Restore";
            btnArchive.UseVisualStyleBackColor = true;
            btnArchive.Click += btnArchive_Click;
            // 
            // btnViewProgress
            // 
            btnViewProgress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewProgress.Location = new Point(1000, 53);
            btnViewProgress.Margin = new Padding(4, 5, 4, 5);
            btnViewProgress.Name = "btnViewProgress";
            btnViewProgress.Size = new Size(213, 63);
            btnViewProgress.TabIndex = 9;
            btnViewProgress.Text = "View Progress";
            btnViewProgress.UseVisualStyleBackColor = true;
            btnViewProgress.Click += btnViewProgress_Click;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogout.Location = new Point(1063, 777);
            btnLogout.Margin = new Padding(4, 5, 4, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(150, 63);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1263, 885);
            Controls.Add(btnLogout);
            Controls.Add(cmbFilter);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblReminder);
            Controls.Add(btnViewProgress);
            Controls.Add(btnArchive);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAddHabit);
            Controls.Add(btnUndo);
            Controls.Add(btnMarkDone);
            Controls.Add(dgvDashboard);
            Controls.Add(lblProgressValue);
            Controls.Add(lblProgress);
            Controls.Add(lblWelcome);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(991, 796);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StreakUp - Dashboard";
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Label lblProgress;
        private Label lblProgressValue;
        private Label lblReminder;
        private TextBox txtSearch;
        private ComboBox cmbFilter;
        private Button btnSearch;
        private DataGridView dgvDashboard;
        private Button btnMarkDone;
        private Button btnUndo;
        private Button btnAddHabit;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnArchive;
        private Button btnViewProgress;
        private Button btnLogout;
    }
}