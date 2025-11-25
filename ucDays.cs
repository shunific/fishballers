using InventoryManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace InventoryManagementSystem
{
    //user control za for panels
    public partial class ucDays : UserControl
    {
        string _day, date, weekday;
        private List<Schedule> daySchedules = new List<Schedule>();

        public ucDays(string day)
        {
            InitializeComponent();
            _day = day;
            label1.Text = day;
            checkBox1.Hide();

            if (!string.IsNullOrEmpty(day))
            {
                date = day + "/" + ScheduleForm._month + "/" + ScheduleForm._year;
            }
            else
            {
                date = "";
            }
        }

        public void SetSchedules(List<Schedule> schedules)
        {
            daySchedules = schedules;
            UpdateScheduleDisplay();
        }

        private void UpdateScheduleDisplay()
        {
            if (daySchedules.Count > 0)
            {

                this.BackColor = Color.FromArgb(255, 176, 156);


                if (panel1 != null)
                {
                    panel1.BackColor = Color.FromArgb(255, 176, 156);
                }


                label1.ForeColor = Color.FromArgb(0, 0, 139);
            }
        }

        public void Sundays()
        {
            if (string.IsNullOrEmpty(date))
            {
                return;
            }

            try
            {
                DateTime day = DateTime.Parse(date);
                weekday = day.ToString("ddd");

                if (weekday != "Sun" && daySchedules.Count == 0)
                {
                    label1.ForeColor = Color.FromArgb(64, 64, 64);
                }
            }
            catch (Exception)
            {
                //empty catch for errors
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(_day))
            {
                return;
            }

            if (daySchedules.Count > 0)
            {
                ShowScheduleDetails();
            }
        }

        private void ShowScheduleDetails()
        {
            StringBuilder details = new StringBuilder();
            details.AppendLine("Schedules for " + date + ":\n");

            foreach (var schedule in daySchedules)
            {
                details.AppendLine("Schedule Name: " + schedule.Name);
                details.AppendLine("Schedule Description:");
                details.AppendLine(schedule.Description);
                details.AppendLine();
            }

            MessageBox.Show(details.ToString(), "Schedule Details",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DateTime FullDate;

        private void ucDays_Click(object sender, EventArgs e)
        {
            panel1_Click(sender, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel1_Click(sender, e);
        }

        private void ucDays_Load(object sender, EventArgs e)
        {
            Sundays();
        }
    }
}