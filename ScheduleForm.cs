using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class ScheduleForm : Form
    {
        public static int _year, _month;
        public static List<Schedule> schedules = new List<Schedule>();
        private SqlConnection connection = new SqlConnection(@"Server=SHUN\SQLEXPRESS;Database=InventoryManagementSystem;Trusted_Connection=True;");

        public ScheduleForm()
        {
            InitializeComponent();
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            LoadSchedulesFromDatabase();
            showDay(DateTime.Now.Month, DateTime.Now.Year);
        }

        private void LoadSchedulesFromDatabase()
        {
            schedules.Clear();
            try
            {
                connection.Open();
                string query = "SELECT ScheduleID, ScheduleDate, ScheduleName, Description FROM Schedules ORDER BY ScheduleDate";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Schedule schedule = new Schedule(
                        Convert.ToDateTime(reader["ScheduleDate"]),
                        reader["ScheduleName"].ToString(),
                        reader["Description"].ToString()
                    );
                    schedule.ScheduleID = Convert.ToInt32(reader["ScheduleID"]);
                    schedules.Add(schedule);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading schedules: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Next month
            _month += 1;
            if (_month > 12)
            {
                _month = 1;
                _year += 1;
            }
            showDay(_month, _year);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // Previous month
            _month -= 1;
            if (_month < 1)
            {
                _month = 12;
                _year -= 1;
            }
            showDay(_month, _year);
        }

        private void AddSchedBtn_Click(object sender, EventArgs e)
        {
            // Add Schedule
            AddSchedules AddSched = new AddSchedules();
            AddSched.ShowDialog();
            if (AddSched.IsSaved)
            {
                Schedule newSchedule = new Schedule(
                    AddSched.ScheduleDate,
                    AddSched.ScheduleName,
                    AddSched.ScheduleDescription
                );

                // Save to database
                if (SaveScheduleToDatabase(newSchedule))
                {
                    LoadSchedulesFromDatabase(); // Reload from database
                    showDay(_month, _year);
                }
            }
        }

        private bool SaveScheduleToDatabase(Schedule schedule)
        {
            try
            {
                connection.Open();
                string query = @"INSERT INTO Schedules (ScheduleDate, ScheduleName, Description, LastUpdated) 
                                VALUES (@Date, @Name, @Description, @LastUpdated)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Date", schedule.Date);
                cmd.Parameters.AddWithValue("@Name", schedule.Name);
                cmd.Parameters.AddWithValue("@Description", schedule.Description ?? "");
                cmd.Parameters.AddWithValue("@LastUpdated", DateTime.Now);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Schedule saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving schedule: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        private void BckBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateSchedule_Click(object sender, EventArgs e)
        {
            // Update button schedule
            using (Form dateSelector = new Form())
            {
                dateSelector.Text = "Select Date to Update";
                dateSelector.Size = new Size(300, 150);
                dateSelector.StartPosition = FormStartPosition.CenterParent;
                dateSelector.FormBorderStyle = FormBorderStyle.FixedDialog;
                dateSelector.MaximizeBox = false;
                dateSelector.MinimizeBox = false;

                DateTimePicker dtPicker = new DateTimePicker();
                dtPicker.Location = new Point(20, 20);
                dtPicker.Width = 250;
                dtPicker.Value = new DateTime(_year, _month, 1);

                Button okButton = new Button();
                okButton.Text = "OK";
                okButton.Location = new Point(100, 60);
                okButton.DialogResult = DialogResult.OK;

                Button cancelButton = new Button();
                cancelButton.Text = "Cancel";
                cancelButton.Location = new Point(180, 60);
                cancelButton.DialogResult = DialogResult.Cancel;

                dateSelector.Controls.Add(dtPicker);
                dateSelector.Controls.Add(okButton);
                dateSelector.Controls.Add(cancelButton);
                dateSelector.AcceptButton = okButton;
                dateSelector.CancelButton = cancelButton;

                if (dateSelector.ShowDialog() == DialogResult.OK)
                {
                    DateTime selectedDate = dtPicker.Value.Date;
                    UpdateSchedules updateForm = new UpdateSchedules(selectedDate);
                    updateForm.ShowDialog();

                    if (updateForm.IsModified)
                    {
                        LoadSchedulesFromDatabase(); // Reload from database
                        showDay(_month, _year);
                    }
                }
            }
        }

        private void showDay(int month, int year)
        {
            flowLayoutPanel1.Controls.Clear();
            _year = year;
            _month = month;
            string monthName = new DateTimeFormatInfo().GetMonthName(month);
            label8.Text = monthName.ToUpper() + " " + year;
            DateTime startOfMonth = new DateTime(year, month, 1);
            int day = DateTime.DaysInMonth(year, month);
            int week = (int)startOfMonth.DayOfWeek;

            for (int i = 0; i < week; i++)
            {
                ucDays ucDays = new ucDays("");
                flowLayoutPanel1.Controls.Add(ucDays);
            }

            for (int i = 1; i <= day; i++)
            {
                ucDays ucDays = new ucDays(i.ToString());
                DateTime currentDate = new DateTime(year, month, i);
                var daySchedules = schedules.Where(s => s.Date.Date == currentDate.Date).ToList();
                if (daySchedules.Count > 0)
                {
                    ucDays.SetSchedules(daySchedules);
                }
                flowLayoutPanel1.Controls.Add(ucDays);
            }
        }
    }
}