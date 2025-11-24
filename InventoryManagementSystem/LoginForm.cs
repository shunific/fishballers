using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagementSystem
{

    public partial class LoginForm : Form
    {
        private SqlConnection connection = new SqlConnection(@"Server=SHUN\SQLEXPRESS;Database=InventoryManagementSystem;Trusted_Connection=True;");

        private readonly Color _normalBackColor = Color.White;
        private readonly Color _hoverBackColor = Color.Tomato;
        private readonly Color _normalBackColor2 = Color.Tomato;
        private readonly Color _hoverBackColor2 = Color.White;

        public LoginForm()
        {
            InitializeComponent();

            txtPassword.UseSystemPasswordChar = true;


            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;

            txtUsername.BackColor = _normalBackColor;
            txtPassword.BackColor = _normalBackColor;
            btnLugin.BackColor = _normalBackColor;
            btnLugin.ForeColor = _normalBackColor2;


            txtUsername.BackColor = _hoverBackColor;
            txtPassword.BackColor = _hoverBackColor;
            btnLugin.BackColor = _hoverBackColor;
            btnLugin.ForeColor = _hoverBackColor2;

            txtUsername.MouseEnter += TxtUsername_MouseEnter;
            txtUsername.MouseLeave += TxtUsername_MouseLeave;

            txtPassword.MouseEnter += TxtPassword_MouseEnter;
            txtPassword.MouseLeave += TxtPassword_MouseLeave;

            btnLugin.MouseEnter += BtnLugin_MouseEnter;
            btnLugin.MouseLeave += BtnLugin_MouseLeave;


        }

        private void TxtUsername_MouseEnter(object sender, EventArgs e)
        {
            txtUsername.BackColor = _hoverBackColor;
        }

        private void TxtUsername_MouseLeave(object sender, EventArgs e)
        {
            txtUsername.BackColor = _normalBackColor;
        }

        private void TxtPassword_MouseEnter(object sender, EventArgs e)
        {
            txtPassword.BackColor = _hoverBackColor;
        }

        private void TxtPassword_MouseLeave(object sender, EventArgs e)
        {
            txtPassword.BackColor = _normalBackColor;
        }

        private void BtnLugin_MouseEnter(object sender, EventArgs e)
        {
            btnLugin.BackColor = _hoverBackColor;
            btnLugin.ForeColor = _hoverBackColor2;
        }

        private void BtnLugin_MouseLeave(object sender, EventArgs e)
        {
            btnLugin.BackColor = _normalBackColor;
            btnLugin.ForeColor = _normalBackColor2;
        }

        private void btnLugin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();
                string query = "SELECT UserID, Username, FullName, Role FROM Users WHERE Username = @Username AND Password = @Password AND IsActive = 1";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    User user = new User
                    {
                        UserID = Convert.ToInt32(reader["UserID"]),
                        Username = reader["Username"].ToString(),
                        FullName = reader["FullName"].ToString(),
                        Role = reader["Role"].ToString()
                    };

                    reader.Close();
                    query = "UPDATE Users SET LastLogin = GETDATE() WHERE UserID = @UserID";
                    cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.ExecuteNonQuery();

                    MainForm mainForm = new MainForm(user);
                    mainForm.ShowDialog();
                    ClearItemFields();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private void ClearItemFields()
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}