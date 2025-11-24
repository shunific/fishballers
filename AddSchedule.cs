using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventoryManagementSystem
{
    public partial class AddSchedules : Form
    {

        public DateTime ScheduleDate { get; private set; }
        public string ScheduleName { get; private set; }
        public string ScheduleDescription { get; private set; }
        public bool IsSaved { get; private set; }



        public AddSchedules()
        {
            InitializeComponent();
            IsSaved = false;
            if (dateTimePickerAddSched != null)
            {
                dateTimePickerAddSched.Value = DateTime.Now;
            }
        }

        private void CmbAddSched_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Type of schedule selected

        }

        private void dateTimePickerAddSched_ValueChanged(object sender, EventArgs e)
        {
        }

        private void TxtBoxAddSched_TextChanged(object sender, EventArgs e)
        {

        }

        private void CancelBtnAddSched_Click(object sender, EventArgs e)
        {
            //cancel button
            this.Close();
        }

        private void SaveBtnAddSched_Click(object sender, EventArgs e)
        {
            //save button 
            if (string.IsNullOrWhiteSpace(CmbAddSched.Text))
            {
                MessageBox.Show("Please enter a schedule name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ScheduleDate = dateTimePickerAddSched.Value.Date;
            ScheduleName = CmbAddSched.Text.Trim();
            ScheduleDescription = TxtBoxAddSched.Text.Trim();
            IsSaved = true;

            MessageBox.Show("Schedule added successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void AddSchedules_Load(object sender, EventArgs e)
        {
            CmbAddSched.Items.Add("Checking");
            CmbAddSched.Items.Add("Open");
            CmbAddSched.Items.Add("Close");
            CmbAddSched.Items.Add("Restock");
            CmbAddSched.Items.Add("Clean");
        }
    }
}