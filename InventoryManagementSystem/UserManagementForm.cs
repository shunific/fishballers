using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class UserManagementForm : Form
    {
        private User currentUser;
        private readonly string connectionString = (@"Server=SHUN\SQLEXPRESS;Database=InventoryManagementSystem;Trusted_Connection=True;");

        public UserManagementForm(User user)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            currentUser = user;
        }

        private void LoadUsers()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT UserID, Username, Password, FullName, Role, LastLogin FROM Users WHERE IsActive = 1 OR IsActive IS NULL";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvUsers.DataSource = dt;
                    dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.SelectedRows.Count > 0)
                {
                    var row = dgvUsers.SelectedRows[0];
                    if (row.Cells["UserID"].Value != null && row.Cells["UserID"].Value != DBNull.Value)
                    {
                        PopulateUserFields(row);
                    }
                    else
                    {
                        ClearUserFields();
                    }
                }
            }
            catch (Exception ex)
            {
                ClearUserFields();
                MessageBox.Show($"Error selecting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateUserFields(DataGridViewRow row)
        {
            try
            {
                txtUsername.Text = row.Cells["Username"].Value?.ToString() ?? "";
                txtFullName.Text = row.Cells["FullName"].Value?.ToString() ?? "";
                txtPassword.Text = row.Cells["Password"].Value?.ToString() ?? "";

                var roleValue = row.Cells["Role"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(roleValue))
                {
                    for (int i = 0; i < cmbRole.Items.Count; i++)
                    {
                        if (cmbRole.Items[i].ToString().Equals(roleValue, StringComparison.OrdinalIgnoreCase))
                        {
                            cmbRole.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    if (cmbRole.Items.Count > 0)
                        cmbRole.SelectedIndex = 0;
                    else
                        cmbRole.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error populating user fields: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearUserFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtFullName.Text = "";
            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            lblCurrentUser.Text = $"Hello, {currentUser.FullName} ({currentUser.Role})";

            LoadRoles();
            LoadUsers();
        }

        private void LoadRoles()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Staff");

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT DISTINCT Role FROM Users WHERE Role IS NOT NULL";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string role = reader["Role"].ToString();
                                if (!string.IsNullOrEmpty(role) && !cmbRole.Items.Contains(role))
                                {
                                    cmbRole.Items.Add(role);
                                }
                            }
                        }
                    }

                    cmbRole.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbRole.SelectedIndex = 0;
                }
            }
        }

        private void btnAddUser_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                try
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        int userCount = (int)checkCmd.ExecuteScalar();

                        if (userCount > 0)
                        {
                            MessageBox.Show("Username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string query = @"INSERT INTO Users (Username, Password, FullName, Role, IsActive)
                                    VALUES (@Username, @Password, @FullName, @Role, 1)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                    ClearUserFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdateUser_Click_1(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = dgvUsers.SelectedRows[0];
            int userID = Convert.ToInt32(row.Cells["UserID"].Value);
            string originalUsername = row.Cells["Username"].Value.ToString();
            string newUsername = txtUsername.Text;
            if (originalUsername.ToLower() != newUsername.ToLower())
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    try
                    {
                        connection.Open();
                        string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND UserID <> @UserID";
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                        {
                            checkCmd.Parameters.AddWithValue("@Username", newUsername);
                            checkCmd.Parameters.AddWithValue("@UserID", userID);
                            int userCount = (int)checkCmd.ExecuteScalar();

                            if (userCount > 0)
                            {
                                MessageBox.Show("Username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error checking username: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                try
                {
                    connection.Open();
                    string query;
                    if (!string.IsNullOrEmpty(txtPassword.Text))
                    {
                        query = @"UPDATE Users SET 
                                Username = @Username,
                                FullName = @FullName,
                                Role = @Role,
                                Password = @Password
                                WHERE UserID = @UserID";
                    }
                    else
                    {
                        query = @"UPDATE Users SET 
                                Username = @Username,
                                FullName = @FullName,
                                Role = @Role
                                WHERE UserID = @UserID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", newUsername);
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        if (!string.IsNullOrEmpty(txtPassword.Text))
                        {
                            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUsers();
                            ClearUserFields();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = dgvUsers.SelectedRows[0];
            int userID = Convert.ToInt32(row.Cells["UserID"].Value);
            string username = row.Cells["Username"].Value.ToString();

            if (username.ToLower() == "admin")
            {
                MessageBox.Show("Cannot delete the default admin user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete user '{username}'?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "UPDATE Users SET IsActive = 0 WHERE UserID = @UserID";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@UserID", userID);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadUsers();
                                ClearUserFields();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnBackk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}