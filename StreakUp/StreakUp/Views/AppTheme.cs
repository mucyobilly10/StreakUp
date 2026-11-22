using System.Drawing;
using System.Windows.Forms;

namespace StreakUp.Views;

internal static class AppTheme
{
    private static readonly Color Canvas = Color.FromArgb(244, 248, 253);
    private static readonly Color Ink = Color.FromArgb(35, 55, 78);
    private static readonly Color MutedInk = Color.FromArgb(95, 116, 140);
    private static readonly Color Blue = Color.FromArgb(38, 112, 218);
    private static readonly Color BlueHover = Color.FromArgb(28, 91, 184);
    private static readonly Color Border = Color.FromArgb(218, 228, 240);
    private static readonly Color PaleBlue = Color.FromArgb(232, 241, 252);

    public static void Apply(Form form)
    {
        form.BackColor = Canvas;
        form.ForeColor = Ink;
        form.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        ApplyToControls(form.Controls);
    }

    private static void ApplyToControls(Control.ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            switch (control)
            {
                case Label label:
                    label.ForeColor = label.Name is "lblTitle" or "lblWelcome" ? Ink : MutedInk;
                    if (label.Name is "lblTitle" or "lblWelcome")
                    {
                        label.Font = new Font("Segoe UI", 19F, FontStyle.Bold, GraphicsUnit.Point);
                    }
                    else if (label.Name == "lblReminder")
                    {
                        label.ForeColor = BlueHover;
                        label.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
                    }
                    break;

                case TextBox textBox:
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Ink;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    break;

                case ComboBox comboBox:
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = Ink;
                    break;

                case DateTimePicker dateTimePicker:
                    dateTimePicker.CalendarMonthBackground = Color.White;
                    dateTimePicker.CalendarTitleBackColor = Blue;
                    dateTimePicker.CalendarTitleForeColor = Color.White;
                    dateTimePicker.CalendarForeColor = Ink;
                    break;

                case Button button:
                    StyleButton(button);
                    break;

                case DataGridView grid:
                    StyleGrid(grid);
                    break;
            }

            ApplyToControls(control.Controls);
        }
    }

    private static void StyleButton(Button button)
    {
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 1;
        button.FlatAppearance.BorderColor = Border;
        button.Cursor = Cursors.Hand;
        button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        button.UseVisualStyleBackColor = false;

        if (button.Name is "btnLogin" or "btnRegister" or "btnSave" or "btnMarkDone" or "btnSearch" or "btnViewProgress" or "btnAddHabit")
        {
            button.BackColor = Blue;
            button.ForeColor = Color.White;
            button.FlatAppearance.BorderColor = Blue;
            button.FlatAppearance.MouseOverBackColor = BlueHover;
            button.FlatAppearance.MouseDownBackColor = BlueHover;
        }
        else if (button.Name == "btnDelete")
        {
            button.BackColor = Color.FromArgb(255, 242, 242);
            button.ForeColor = Color.FromArgb(177, 52, 52);
            button.FlatAppearance.BorderColor = Color.FromArgb(241, 202, 202);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 228, 228);
        }
        else
        {
            button.BackColor = Color.White;
            button.ForeColor = Ink;
            button.FlatAppearance.MouseOverBackColor = PaleBlue;
        }
    }

    private static void StyleGrid(DataGridView grid)
    {
        grid.BackgroundColor = Color.White;
        grid.BorderStyle = BorderStyle.None;
        grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        grid.GridColor = Border;
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersDefaultCellStyle.BackColor = Blue;
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Blue;
        grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
        grid.ColumnHeadersHeight = 38;
        grid.DefaultCellStyle.BackColor = Color.White;
        grid.DefaultCellStyle.ForeColor = Ink;
        grid.DefaultCellStyle.SelectionBackColor = PaleBlue;
        grid.DefaultCellStyle.SelectionForeColor = Ink;
        grid.DefaultCellStyle.Padding = new Padding(6, 3, 6, 3);
        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 251, 255);
        grid.RowTemplate.Height = 34;
        grid.RowHeadersVisible = false;
    }
}
