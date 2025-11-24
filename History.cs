using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
            SetupHistoryGrid();
            DisplayHistory();
        }

        private void SetupHistoryGrid()
        {
            if (historyGridView.ColumnCount == 0)
            {
                historyGridView.ColumnCount = 5;
                historyGridView.Columns[0].Name = "Date";
                historyGridView.Columns[1].Name = "Quantity";
                historyGridView.Columns[2].Name = "Type";
                historyGridView.Columns[3].Name = "Amount";
                historyGridView.Columns[4].Name = "Note";

                historyGridView.ReadOnly = true;
                historyGridView.AllowUserToAddRows = false;
                historyGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        public void DisplayHistory()
        {
            historyGridView.Rows.Clear();

            if (SalesForm.DeletedExpenses.Count == 0)
            {
                return;
            }

            foreach (Expense expense in SalesForm.DeletedExpenses)
            {
                historyGridView.Rows.Add(
                    expense.Date.ToShortDateString(),
                    expense.Quantity,
                    expense.Type,
                    expense.Amount,
                    expense.Note
                );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void historyGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && historyGridView.Rows[e.RowIndex].Cells[0].Value != null)
            {
                DataGridViewRow row = historyGridView.Rows[e.RowIndex];
                string details = $"Deleted Item Details:\n\n" +
                               $"Date: {row.Cells[0].Value}\n" +
                               $"Quantity: {row.Cells[1].Value}\n" +
                               $"Type: {row.Cells[2].Value}\n" +
                               $"Amount: {row.Cells[3].Value}\n" +
                               $"Note: {row.Cells[4].Value}";

                MessageBox.Show(details, "History Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}