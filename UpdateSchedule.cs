using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class UpdateSchedules : Form
    {
        private DateTime selectedDate;
        private List<Schedule> daySchedules;
        private Schedule currentSchedule;
        public bool IsModified { get; private set; }
        private SqlConnection connection = new SqlConnection(@"Server=SHUN\SQLEXPRESS;Database=InventoryManagementSystem;Trusted_Connection=True;");

        public UpdateSchedules(DateTime date)
        {
            InitializeComponent();
            selectedDate = date;
            IsModified = false;
        }

        private void UpdateSchedule_Load(object sender, EventArgs e)
        {
            daySchedules = ScheduleForm.schedules.Where(s => s.Date.Date == selectedDate.Date).ToList();

            if (daySchedules.Count == 0)
            {
                MessageBox.Show("No schedule set.", "No Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            CmbTypeOfSchedUpd.Items.Clear();
            CmbTypeOfSchedUpd.Items.Add("Open");
            CmbTypeOfSchedUpd.Items.Add("Close");
            CmbTypeOfSchedUpd.Items.Add("Restock");
            CmbTypeOfSchedUpd.Items.Add("Clean");

            if (daySchedules.Count > 0)
            {
                currentSchedule = daySchedules[0];
                CmbTypeOfSchedUpd.SelectedItem = currentSchedule.Name;
                txtBoxUpdSched.Text = currentSchedule.Description;
            }
        }

        private void CmbTypeOfSchedUpd_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = CmbTypeOfSchedUpd.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedName))
            {
                var schedule = daySchedules.FirstOrDefault(s => s.Name == selectedName);
                if (schedule != null)
                {
                    currentSchedule = schedule;
                    txtBoxUpdSched.Text = currentSchedule.Description;
                }
            }
        }

        private void SaveBtnUpdSched_Click(object sender, EventArgs e)
        {
            if (currentSchedule == null)
            {
                MessageBox.Show("Please select a schedule to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CmbTypeOfSchedUpd.SelectedItem == null)
            {
                MessageBox.Show("Please select a schedule type.", "No Type Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update in database
            try
            {
                connection.Open();
                string query = @"UPDATE Schedules 
                                SET ScheduleName = @Name, 
                                    Description = @Description, 
                                    LastUpdated = @LastUpdated 
                                WHERE ScheduleID = @ScheduleID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", CmbTypeOfSchedUpd.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Description", txtBoxUpdSched.Text);
                cmd.Parameters.AddWithValue("@LastUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@ScheduleID", currentSchedule.ScheduleID);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Schedule updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsModified = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating schedule: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (currentSchedule == null)
            {
                MessageBox.Show("Please select a schedule to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete the schedule '{currentSchedule.Name}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Schedules WHERE ScheduleID = @ScheduleID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ScheduleID", currentSchedule.ScheduleID);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Schedule deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IsModified = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting schedule: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void BckBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtBoxUpdSched_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}