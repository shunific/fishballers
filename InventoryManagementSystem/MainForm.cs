using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class MainForm : Form
    {
        private User currentUser;
        private SqlConnection connection = new SqlConnection(@"Server=SHUN\SQLEXPRESS;Database=InventoryManagementSystem;Trusted_Connection=True;");
        private readonly string _tasksFile = "tasks.txt";

        public MainForm(User user)
        {
            InitializeComponent();

            txtNewTask.UseSystemPasswordChar = false;

            this.FormBorderStyle = FormBorderStyle.None;


            btnAddTask.Click += btnAddTask_Click;
            btnRemoveCompleted.Click += btnRemoveCompleted_Click;

            currentUser = user;
            InitializeUIBasedOnRole();
            LoadDashboard();
            DisplayLowStockItems();
        }

        private void InitializeUIBasedOnRole()
        {
            lblWelcome.Text = $"Welcome, {currentUser.FullName} ({currentUser.Role})";

            if (currentUser.Role == "Staff")
            {
                btnUserManagement.Enabled = false;
                btnUserManagement.Visible = false;
            }
        }

        private void LoadDashboard()
        {
            try
            {
                connection.Open();
                string query = "SELECT TOP 10 ItemName, Quantity, LastUpdated FROM Items ORDER BY LastUpdated DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvRecentItems.DataSource = dt;

                query = "SELECT COUNT(*) FROM Items";
                SqlCommand cmd = new SqlCommand(query, connection);
                lblTotalItems.Text = cmd.ExecuteScalar().ToString();

                query = "SELECT COUNT(*) FROM Items WHERE Quantity <= MinimumThreshold";
                lblLowStockItems.Text = cmd.ExecuteScalar().ToString();


                query = "SELECT COUNT(*) FROM Categories";
                lblTotalCategories.Text = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void DisplayLowStockItems()
        {
            connection.Open();
            string query = "SELECT ItemName, Quantity, MinimumThreshold FROM Items WHERE Quantity <= MinimumThreshold ORDER BY Quantity ASC";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            int yPosition = 30;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string itemName = reader["ItemName"].ToString();
                    int quantity = Convert.ToInt32(reader["Quantity"]);
                    int threshold = Convert.ToInt32(reader["MinimumThreshold"]);

                    Label lblItem = new Label();
                    lblItem.Text = $"{itemName} - {quantity}/{threshold}";
                    lblItem.Location = new Point(10, yPosition);
                    lblItem.AutoSize = true;

                    if (quantity < threshold / 2)
                    {
                        lblItem.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblItem.ForeColor = Color.Black;
                    }

                    yPosition += 25;
                }
            }
            else
            {
                Label lblNoItems = new Label();
                lblNoItems.Text = "No items are low on stock";
                lblNoItems.Location = new Point(10, yPosition);
                lblNoItems.AutoSize = true;

            }
            reader.Close();
            connection.Close();
        }

        private void btnLogout_Click_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInventory_Click_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryForm = new InventoryForm(currentUser);
            inventoryForm.ShowDialog();
            LoadDashboard();
            DisplayLowStockItems();
            this.BringToFront();
        }

        private void btnUserManagement_Click_1(object sender, EventArgs e)
        {
            UserManagementForm userForm = new UserManagementForm(currentUser);
            userForm.ShowDialog();
            this.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void pnlLowStockItems_Paint(object sender, PaintEventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            clbTasks.Items.Clear();

            if (System.IO.File.Exists(_tasksFile))
            {
                string[] saved = System.IO.File.ReadAllLines(_tasksFile);
                foreach (var line in saved)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        clbTasks.Items.Add(line);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var lines = new List<string>();
            foreach (var item in clbTasks.Items)
            {
                lines.Add(item.ToString());
            }
            System.IO.File.WriteAllLines(_tasksFile, lines);
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string newTask = txtNewTask.Text.Trim();
            if (string.IsNullOrEmpty(newTask))
                return;

            clbTasks.Items.Add(newTask);
            txtNewTask.Clear();
            txtNewTask.Focus();
        }

        private void btnRemoveCompleted_Click(object sender, EventArgs e)
        {
            for (int i = clbTasks.Items.Count - 1; i >= 0; i--)
            {
                if (clbTasks.GetItemChecked(i))
                    clbTasks.Items.RemoveAt(i);
            }
        }

        private void clbTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            ScheduleForm scheduleForm = new ScheduleForm(); // open form of zej
            scheduleForm.ShowDialog();
            this.BringToFront();
        }

        private void btnTrackSales_Click(object sender, EventArgs e)
        {
            SalesForm salesForm = new SalesForm();
                salesForm.ShowDialog();
            this.BringToFront();
        }

    }
}
