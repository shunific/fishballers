using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class SalesForm : Form
    {
        private SqlConnection connection = new SqlConnection(@"Server=SHUN\SQLEXPRESS;Database=InventoryManagementSystem;Trusted_Connection=True;");
        public static List<Expense> DeletedExpenses = new List<Expense>();

        public SalesForm()
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            comboBox2.Items.AddRange(new string[] {
                "Kwek-Kwek", "Fishball", "Kikiam", "Chicken Balls",
                "Banana Cue", "Siomai", "Turon", "Lumpiang Gulay",
                "Barbecue", "Drinks"
            });

            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "SaleID";
            dataGridView1.Columns[0].Visible = false; // hide SaleID cuz unneeded
            dataGridView1.Columns[1].Name = "Date";
            dataGridView1.Columns[2].Name = "Quantity";
            dataGridView1.Columns[3].Name = "Type";
            dataGridView1.Columns[4].Name = "Amount";
            dataGridView1.Columns[5].Name = "Note";

            dataGridView2.ColumnCount = 3;
            dataGridView2.Columns[0].Name = "Dates";
            dataGridView2.Columns[1].Name = "No. of Sales";
            dataGridView2.Columns[2].Name = "Total Amount";

            LoadSalesFromDatabase();
        }

        private void LoadSalesFromDatabase()
        {
            dataGridView1.Rows.Clear();
            try
            {
                connection.Open();
                string query = "SELECT SaleID, SaleDate, Quantity, Type, Amount, Note FROM Sales ORDER BY SaleDate DESC";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader["SaleID"].ToString(),
                        Convert.ToDateTime(reader["SaleDate"]).ToShortDateString(),
                        reader["Quantity"].ToString(),
                        reader["Type"].ToString(),
                        Convert.ToDecimal(reader["Amount"]).ToString("F2"),
                        reader["Note"].ToString()
                    );
                }
                reader.Close();
                UpdateTotalAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
                e.Handled = true;
        }

        private void ClearFields()
        {
            comboBox2.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void UpdateTotalAmount()
        {
            double total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[4].Value != null &&
                    double.TryParse(row.Cells[4].Value.ToString(), out double amount))
                {
                    total += amount;
                }
            }

            TotalAmount.Text = "₱" + total.ToString("F2");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                dateTimePicker1.Value = DateTime.Parse(row.Cells[1].Value.ToString());
                textBox1.Text = row.Cells[2].Value.ToString();
                comboBox2.Text = row.Cells[3].Value.ToString();
                textBox2.Text = row.Cells[4].Value.ToString();
                textBox3.Text = row.Cells[5].Value.ToString();
            }
        }

        private void addButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                    throw new Exception("Quantity is required.");

                if (string.IsNullOrWhiteSpace(comboBox2.Text))
                    throw new Exception("Type is required.");

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                    throw new Exception("Amount is required.");

                if (!int.TryParse(textBox1.Text, out int qty))
                    throw new Exception("Quantity must be a valid whole number.");

                if (!double.TryParse(textBox2.Text, out double amount))
                    throw new Exception("Amount must be a valid number.");

                connection.Open();
                string query = @"INSERT INTO Sales (SaleDate, Quantity, Type, Amount, Note, LastUpdated) 
                                VALUES (@Date, @Quantity, @Type, @Amount, @Note, @LastUpdated)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@Quantity", qty);
                cmd.Parameters.AddWithValue("@Type", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Note", textBox3.Text ?? "");
                cmd.Parameters.AddWithValue("@LastUpdated", DateTime.Now);

                cmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Successfully Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadSalesFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                    throw new Exception("Quantity is required.");

                if (string.IsNullOrWhiteSpace(comboBox2.Text))
                    throw new Exception("Type is required.");

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                    throw new Exception("Amount is required.");

                if (!int.TryParse(textBox1.Text, out int qty))
                    throw new Exception("Quantity must be a valid whole number.");

                if (!double.TryParse(textBox2.Text, out double amount))
                    throw new Exception("Amount must be a valid number.");

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int saleID = Convert.ToInt32(selectedRow.Cells[0].Value);

                connection.Open();
                string query = @"UPDATE Sales 
                                SET SaleDate = @Date, 
                                    Quantity = @Quantity, 
                                    Type = @Type, 
                                    Amount = @Amount, 
                                    Note = @Note, 
                                    LastUpdated = @LastUpdated 
                                WHERE SaleID = @SaleID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@Quantity", qty);
                cmd.Parameters.AddWithValue("@Type", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Note", textBox3.Text ?? "");
                cmd.Parameters.AddWithValue("@LastUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@SaleID", saleID);

                cmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Successfully Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadSalesFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void DeleteButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this sale?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    int saleID = Convert.ToInt32(row.Cells[0].Value);

                    if (row.Cells[1].Value != null)
                    {
                        Expense deletedExpense = new Expense(
                            DateTime.Parse(row.Cells[1].Value.ToString()),
                            row.Cells[2].Value?.ToString() ?? "",
                            row.Cells[3].Value?.ToString() ?? "",
                            row.Cells[4].Value?.ToString() ?? "0.00",
                            row.Cells[5].Value?.ToString() ?? ""
                        );

                        DeletedExpenses.Add(deletedExpense);
                    }

                    connection.Open();
                    string query = "DELETE FROM Sales WHERE SaleID = @SaleID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@SaleID", saleID);

                    cmd.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Successfully Deleted and moved to history!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadSalesFromDatabase();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting sale: " + ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void chartButton_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();

            DateTime selectedDate = chartDate.Value.Date;

            Dictionary<string, (int count, double total)> salesByDate = new Dictionary<string, (int, double)>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    DateTime expenseDate = DateTime.Parse(row.Cells[1].Value.ToString());

                    if (expenseDate.Date == selectedDate)
                    {
                        string dateKey = expenseDate.ToShortDateString();
                        double amount = 0;

                        if (row.Cells[4].Value != null)
                        {
                            double.TryParse(row.Cells[4].Value.ToString(), out amount);
                        }

                        if (salesByDate.ContainsKey(dateKey))
                        {
                            var current = salesByDate[dateKey];
                            salesByDate[dateKey] = (current.count + 1, current.total + amount);
                        }
                        else
                        {
                            salesByDate[dateKey] = (1, amount);
                        }
                    }
                }
            }

            if (salesByDate.Count == 0)
            {
                MessageBox.Show("No sales found for the selected date.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var entry in salesByDate)
            {
                dataGridView2.Rows.Add(
                    entry.Key,
                    entry.Value.count,
                    "₱" + entry.Value.total.ToString("F2")
                );
            }
        }

        private void chartDate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            History history = new History();
            history.ShowDialog();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
        }
    }

    public class Expense
    {
        public DateTime Date { get; set; }
        public string Quantity { get; set; }
        public string Type { get; set; }
        public string Amount { get; set; }
        public string Note { get; set; }

        public Expense(DateTime date, string quantity, string type, string amount, string note)
        {
            Date = date;
            Quantity = quantity;
            Type = type;
            Amount = amount;
            Note = note;
        }
    }
}