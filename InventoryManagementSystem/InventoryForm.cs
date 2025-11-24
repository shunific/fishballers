using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace InventoryManagementSystem
{
    public partial class InventoryForm : Form
    {
        private readonly string connectionString = @"Server=SHUN\SQLEXPRESS;Database=InventoryManagementSystem;Trusted_Connection=True;";
        private readonly User currentUser;
        private int selectedItemID = -1;

        public InventoryForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            InitializeUI();
            LoadData();
        }

        private void InitializeUI()
        {
            InitializeImageControls();
            InitializeRoleBasedUI();
            InitializeDataGridView();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeDataGridView()
        {
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.MultiSelect = false;
            dgvItems.ReadOnly = true;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvItems.SelectionChanged -= dgvItems_SelectionChanged;
            dgvItems.SelectionChanged += dgvItems_SelectionChanged;
        }

        private void InitializeImageControls()
        {
            pbInsert.SizeMode = PictureBoxSizeMode.Zoom;
            pbInsert.BorderStyle = BorderStyle.FixedSingle;
            pbInsert.Click += PbInsert_Click;
            pbInsert.Cursor = Cursors.Hand;

            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Upload Image", null, PbInsert_Click);
            contextMenu.Items.Add("Remove Image", null, RemoveImage_Click);
            pbInsert.ContextMenuStrip = contextMenu;

            ShowImagePlaceholder();
        }

        private void InitializeRoleBasedUI()
        {
            if (currentUser.Role == "Staff")
            {
                btnDeleteItem.Enabled = false;
                btnDeleteCategory.Enabled = false;
                btnAddCategory.Enabled = false;
                btnUpdCat.Enabled = false;
            }
        }

        private void LoadData()
        {
            try
            {
                LoadCategories();
                LoadItems();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error loading data: {ex.Message}", "Database Error", MessageBoxIcon.Error);
            }
        }

        private void ShowImagePlaceholder()
        {
            var placeholder = new Bitmap(pbInsert.Width, pbInsert.Height);
            using (var g = Graphics.FromImage(placeholder))
            {
                g.Clear(Color.LightGray);
                var text = "Click to\nUpload Image";
                var font = new Font("Arial", 10, FontStyle.Bold);
                var textSize = g.MeasureString(text, font);
                var textLocation = new PointF(
                    (placeholder.Width - textSize.Width) / 2,
                    (placeholder.Height - textSize.Height) / 2);
                g.DrawString(text, font, Brushes.DarkGray, textLocation);
            }
            pbInsert.Image = placeholder;
        }

        private void PbInsert_Click(object sender, EventArgs e)
        {
            if (!IsItemSelected())
            {
                ShowMessage("Please select an item first to upload an image.", "No Item Selected", MessageBoxIcon.Information);
                return;
            }

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
                openFileDialog.Title = "Select an Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var selectedImage = Image.FromFile(openFileDialog.FileName);
                        pbInsert.Image = selectedImage;
                        SaveImageToDatabase(selectedItemID, openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        ShowMessage($"Error loading image: {ex.Message}", "Error", MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void RemoveImage_Click(object sender, EventArgs e)
        {
            if (!IsItemSelected())
            {
                ShowMessage("Please select an item first.", "No Item Selected", MessageBoxIcon.Information);
                return;
            }

            if (ShowConfirmation("Are you sure you want to remove this image?", "Confirm Remove"))
            {
                try
                {
                    ExecuteQuery("UPDATE Items SET ItemImage = NULL WHERE ItemID = @ItemID",
                        cmd => cmd.Parameters.AddWithValue("@ItemID", selectedItemID));

                    ShowImagePlaceholder();
                    LoadItems();
                    ShowMessage("Image removed successfully.", "Success", MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    ShowMessage($"Error removing image: {ex.Message}", "Error", MessageBoxIcon.Error);
                }
            }
        }

        private void SaveImageToDatabase(int itemID, string imagePath)
        {
            try
            {
                var imageBytes = File.ReadAllBytes(imagePath);

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    if (!HasImageColumn(connection))
                    {
                        ExecuteNonQuery("ALTER TABLE Items ADD ItemImage VARBINARY(MAX) NULL", connection);
                        ShowMessage("Database updated to support images!", "Database Update", MessageBoxIcon.Information);
                    }

                    var query = "UPDATE Items SET ItemImage = @Image WHERE ItemID = @ItemID";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Image", imageBytes);
                        cmd.Parameters.AddWithValue("@ItemID", itemID);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            ShowMessage("Image uploaded successfully.", "Success", MessageBoxIcon.Information);
                            LoadItems();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error saving image: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void LoadImageFromDatabase(int itemID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (!HasImageColumn(connection))
                    {
                        ShowImagePlaceholder();
                        return;
                    }

                    var query = "SELECT ItemImage FROM Items WHERE ItemID = @ItemID";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", itemID);
                        var result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            var imageBytes = (byte[])result;
                            using (var ms = new MemoryStream(imageBytes))
                            {
                                pbInsert.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            ShowImagePlaceholder();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowImagePlaceholder();
                ShowMessage($"Error loading image: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            try
            {              
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();       
                }

                var query = "SELECT CategoryID, CategoryName, Description FROM Categories";
                var dt = ExecuteQuery(query);

                if (dt.Rows.Count == 0)
                {
                    ShowMessage("No categories found. Please add some categories first.", "No Data", MessageBoxIcon.Information);
                }

                cmbCategories.DataSource = dt;
                cmbCategories.DisplayMember = "CategoryName";
                cmbCategories.ValueMember = "CategoryID";
                dgvCategories.DataSource = dt;
                dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (SqlException sqlEx)
            {
                ShowMessage($"Database connection error: {sqlEx.Message}\n\nPlease check:\n1. SQL Server is running\n2. Database exists\n3. Connection string is correct", "Database Error", MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ShowMessage($"Error loading categories: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void LoadItems()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var tableCheckQuery = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES 
                                          WHERE TABLE_NAME IN ('Items', 'Categories')";
                    using (var cmd = new SqlCommand(tableCheckQuery, connection))
                    {
                        var tableCount = (int)cmd.ExecuteScalar();
                        if (tableCount < 2)
                        {
                            ShowMessage("Required tables (Items, Categories) not found in database.", "Database Error", MessageBoxIcon.Error);
                            return;
                        }
                    }

                    var hasImageColumn = HasImageColumn(connection);

                    var query = hasImageColumn
                        ? @"SELECT i.ItemID, i.ItemName, i.Description, c.CategoryName, 
                           i.Quantity, i.MinimumThreshold, i.Price, i.LastUpdated,
                           CASE WHEN i.ItemImage IS NOT NULL THEN 'Yes' ELSE 'No' END AS HasImage
                           FROM Items i 
                           INNER JOIN Categories c ON i.CategoryID = c.CategoryID
                           ORDER BY i.ItemName"
                        : @"SELECT i.ItemID, i.ItemName, i.Description, c.CategoryName, 
                           i.Quantity, i.MinimumThreshold, i.Price, i.LastUpdated
                           FROM Items i 
                           INNER JOIN Categories c ON i.CategoryID = c.CategoryID
                           ORDER BY i.ItemName";

                    var dt = ExecuteQuery(query);

                    if (dt.Rows.Count == 0)
                    {
                        ShowMessage("No items found. The Items table is empty.", "No Data", MessageBoxIcon.Information);
                    }

                    dgvItems.DataSource = dt;
                    if (dgvItems.Columns.Contains("Price"))
                    {
                        dgvItems.Columns["Price"].DefaultCellStyle.Format = "C2";
                    }
                    if (dgvItems.Columns.Contains("LastUpdated"))
                    {
                        dgvItems.Columns["LastUpdated"].DefaultCellStyle.Format = "g";
                    }
                    dgvItems.ClearSelection();
                    selectedItemID = -1;
                    ClearItemFields();
                    ShowImagePlaceholder();
                    dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            catch (SqlException sqlEx)
            {
                ShowMessage($"SQL Error loading items: {sqlEx.Message}\n\nQuery may have failed due to missing data or incorrect table structure.", "SQL Error", MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ShowMessage($"Error loading items: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvItems.SelectedRows.Count > 0)
                {
                    var row = dgvItems.SelectedRows[0];

                    if (row.Cells["ItemID"].Value != null && row.Cells["ItemID"].Value != DBNull.Value)
                    {
                        selectedItemID = Convert.ToInt32(row.Cells["ItemID"].Value);
                        PopulateItemFields(row);
                        LoadImageFromDatabase(selectedItemID);
                    }
                    else
                    {
                        selectedItemID = -1;
                        ClearItemFields();
                        ShowImagePlaceholder();
                    }
                }
                else
                {
                    selectedItemID = -1;
                    ClearItemFields();
                    ShowImagePlaceholder();
                }
            }
            catch (Exception ex)
            {
                selectedItemID = -1;
                ClearItemFields();
                ShowImagePlaceholder();
                ShowMessage($"Error selecting item: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void PopulateItemFields(DataGridViewRow row)
        {
            try
            {
                txtItemName.Text = row.Cells["ItemName"].Value?.ToString() ?? "";
                txtItemDesc.Text = row.Cells["Description"].Value?.ToString() ?? "";
                var categoryName = row.Cells["CategoryName"].Value?.ToString() ?? "";
                cmbCategories.Text = categoryName;

                nudQuantity.Value = Convert.ToDecimal(row.Cells["Quantity"].Value ?? 0);
                nudMinThreshold.Value = Convert.ToDecimal(row.Cells["MinimumThreshold"].Value ?? 0);
                nudPrice.Value = Convert.ToDecimal(row.Cells["Price"].Value ?? 0);
            }
            catch (Exception ex)
            {
                ShowMessage($"Error populating fields: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void btnAddItem_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemName.Text) || cmbCategories.SelectedValue == null)
            {
                ShowMessage("Please enter item name and select category.", "Error", MessageBoxIcon.Error);
                return;
            }

            try
            {
                var duplicateCheckQuery = @"SELECT COUNT(*) FROM Items i 
                                   INNER JOIN Categories c ON i.CategoryID = c.CategoryID
                                   WHERE i.ItemName = @Name 
                                   AND i.Description = @Desc 
                                   AND i.CategoryID = @CatID 
                                   AND i.Quantity = @Qty 
                                   AND i.MinimumThreshold = @Threshold 
                                   AND i.Price = @Price";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var checkCmd = new SqlCommand(duplicateCheckQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@Name", txtItemName.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@Desc", txtItemDesc.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@CatID", cmbCategories.SelectedValue);
                        checkCmd.Parameters.AddWithValue("@Qty", (int)nudQuantity.Value);
                        checkCmd.Parameters.AddWithValue("@Threshold", (int)nudMinThreshold.Value);
                        checkCmd.Parameters.AddWithValue("@Price", nudPrice.Value);

                        int duplicateCount = (int)checkCmd.ExecuteScalar();

                        if (duplicateCount > 0)
                        {
                            var categoryName = cmbCategories.Text;
                            ShowMessage($"An item with identical details already exists:\n\n" +
                                      $"Name: {txtItemName.Text}\n" +
                                      $"Description: {txtItemDesc.Text}\n" +
                                      $"Category: {categoryName}\n" +
                                      $"Quantity: {nudQuantity.Value}\n" +
                                      $"Minimum Threshold: {nudMinThreshold.Value}\n" +
                                      $"Price: {nudPrice.Value:C2}\n\n" +
                                      $"Please modify at least one field to create a unique item.",
                                      "Duplicate Item Found", MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    var insertQuery = @"INSERT INTO Items (ItemName, Description, CategoryID, Quantity, 
                               MinimumThreshold, Price, LastUpdated) 
                               VALUES (@Name, @Desc, @CatID, @Qty, @Threshold, @Price, GETDATE())";

                    using (var insertCmd = new SqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@Name", txtItemName.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@Desc", txtItemDesc.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@CatID", cmbCategories.SelectedValue);
                        insertCmd.Parameters.AddWithValue("@Qty", (int)nudQuantity.Value);
                        insertCmd.Parameters.AddWithValue("@Threshold", (int)nudMinThreshold.Value);
                        insertCmd.Parameters.AddWithValue("@Price", nudPrice.Value);

                        int rowsAffected = insertCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            ShowMessage("Item added successfully.", "Success", MessageBoxIcon.Information);
                            LoadItems();
                            ClearItemFields();
                        }
                        else
                        {
                            ShowMessage("Failed to add item. No rows were affected.", "Error", MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            if (!IsItemSelected())
            {
                ShowMessage("Please select an item to update.", "Error", MessageBoxIcon.Error);
                return;
            }
            try
            {
                var query = @"UPDATE Items SET ItemName = @Name, Description = @Desc, 
                            CategoryID = @CatID, Quantity = @Qty, MinimumThreshold = @Threshold, 
                            Price = @Price, LastUpdated = GETDATE() WHERE ItemID = @ItemID";

                ExecuteQuery(query, cmd =>
                {
                    cmd.Parameters.AddWithValue("@Name", txtItemName.Text);
                    cmd.Parameters.AddWithValue("@Desc", txtItemDesc.Text);
                    cmd.Parameters.AddWithValue("@CatID", cmbCategories.SelectedValue);
                    cmd.Parameters.AddWithValue("@Qty", (int)nudQuantity.Value);
                    cmd.Parameters.AddWithValue("@Threshold", (int)nudMinThreshold.Value);
                    cmd.Parameters.AddWithValue("@Price", nudPrice.Value);
                    cmd.Parameters.AddWithValue("@ItemID", selectedItemID);
                });

                ShowMessage("Item updated successfully.", "Success", MessageBoxIcon.Information);
                LoadItems();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error updating item: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void btnDeleteItem_Click_1(object sender, EventArgs e)
        {
            if (!IsItemSelected())
            {
                ShowMessage("Please select an item to delete.", "Error", MessageBoxIcon.Error);
                return;
            }
            if (ShowConfirmation("Are you sure you want to delete this item?", "Confirm Delete"))
            {
                try
                {
                    ExecuteQuery("DELETE FROM Items WHERE ItemID = @ItemID",
                        cmd => cmd.Parameters.AddWithValue("@ItemID", selectedItemID));

                    ShowMessage("Item deleted successfully.", "Success", MessageBoxIcon.Information);
                    LoadItems();
                    ClearItemFields();
                    ShowImagePlaceholder();
                    selectedItemID = -1;
                }
                catch (Exception ex)
                {
                    ShowMessage($"Error deleting item: {ex.Message}", "Error", MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                ShowMessage("Please enter category name.", "Error", MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Check for duplicate categories first
                var duplicateCheckQuery = @"SELECT COUNT(*) FROM Categories 
                                   WHERE CategoryName = @Name 
                                   AND Description = @Desc";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var checkCmd = new SqlCommand(duplicateCheckQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@Name", txtCategoryName.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@Desc", txtCategoryDesc.Text.Trim());

                        int duplicateCount = (int)checkCmd.ExecuteScalar();

                        if (duplicateCount > 0)
                        {
                            ShowMessage($"A category with identical details already exists:\n\n" +
                                      $"Category Name: {txtCategoryName.Text}\n" +
                                      $"Description: {txtCategoryDesc.Text}\n\n" +
                                      $"Please modify at least one field to create a unique category.",
                                      "Duplicate Category Found", MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // If no duplicate found, proceed with insertion
                    var insertQuery = @"INSERT INTO Categories (CategoryName, Description) 
                               VALUES (@Name, @Desc)";

                    using (var insertCmd = new SqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@Name", txtCategoryName.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@Desc", txtCategoryDesc.Text.Trim());

                        int rowsAffected = insertCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            ShowMessage("Category added successfully.", "Success", MessageBoxIcon.Information);
                            LoadCategories();
                            ClearCategoryFields();
                        }
                        else
                        {
                            ShowMessage("Failed to add category. No rows were affected.", "Error", MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {

            }
            }

        private void btnUpdCat_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0)
            {
                ShowMessage("Please select a category to update.", "Error", MessageBoxIcon.Error);
                return;
            }

            try
            {
                var categoryID = Convert.ToInt32(dgvCategories.SelectedRows[0].Cells["CategoryID"].Value);

                ExecuteQuery("UPDATE Categories SET CategoryName = @Name, Description = @Desc WHERE CategoryID = @CategoryID",
                    cmd =>
                    {
                        cmd.Parameters.AddWithValue("@Name", txtCategoryName.Text);
                        cmd.Parameters.AddWithValue("@Desc", txtCategoryDesc.Text);
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                    });

                ShowMessage("Category updated successfully.", "Success", MessageBoxIcon.Information);
                LoadCategories();
                ClearCategoryFields();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error updating category: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0) return;

            var row = dgvCategories.SelectedRows[0];
            var id = (int)row.Cells["CategoryID"].Value;
            var name = row.Cells["CategoryName"].Value.ToString();

            if (!ShowConfirmation($"Delete '{name}'?", "Confirm")) return;

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var checkCmd = new SqlCommand("SELECT COUNT(*) FROM Items WHERE CategoryID = @id", connection))
                    {
                        checkCmd.Parameters.AddWithValue("@id", id);
                        if ((int)checkCmd.ExecuteScalar() > 0)
                        {
                            ShowMessage("Cannot delete - category contains items", "Error", MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Delete category
                    using (var deleteCmd = new SqlCommand("DELETE FROM Categories WHERE CategoryID = @id", connection))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", id);
                        deleteCmd.ExecuteNonQuery();
                    }

                    LoadCategories();
                    ShowMessage("Category deleted successfully", "Success", MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error deleting category: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void btnItemUpd_Click(object sender, EventArgs e) => btnUpdateItem_Click(sender, e);
        private void btnBack_Click(object sender, EventArgs e) => this.Close();
        private void InventoryForm_Load(object sender, EventArgs e) { /*Leave empty as it is already handled */ }
        private void txtItemName_TextChanged(object sender, EventArgs e) { }

        private bool IsItemSelected()
        {
            return dgvItems.SelectedRows.Count > 0 && selectedItemID != -1 && selectedItemID > 0;
        }

        private bool HasImageColumn(SqlConnection connection)
        {
            var query = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS 
                         WHERE TABLE_NAME = 'Items' AND COLUMN_NAME = 'ItemImage'";
            using (var cmd = new SqlCommand(query, connection))
            {
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private DataTable ExecuteQuery(string query, Action<SqlCommand> parameterAction = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand(query, connection))
                {
                    parameterAction?.Invoke(cmd);
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void ExecuteNonQuery(string query, SqlConnection connection, Action<SqlCommand> parameterAction = null)
        {
            using (var cmd = new SqlCommand(query, connection))
            {
                parameterAction?.Invoke(cmd);
                cmd.ExecuteNonQuery();
            }
        }

        private void ShowMessage(string message, string title, MessageBoxIcon icon) =>
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);

        private bool ShowConfirmation(string message, string title) =>
            MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        private void ClearItemFields()
        {
            txtItemName.Text = "";
            txtItemDesc.Text = "";
            nudQuantity.Value = 0;
            nudMinThreshold.Value = 5;
            nudPrice.Value = 0;
            if (cmbCategories.Items.Count > 0)
                cmbCategories.SelectedIndex = 0;
        }

        private void ClearCategoryFields()
        {
            txtCategoryName.Text = "";
            txtCategoryDesc.Text = "";
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            var searchTerm = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadItems();
                return;
            }

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var hasImageColumn = HasImageColumn(connection);

                    var query = hasImageColumn
                        ? @"SELECT i.ItemID, i.ItemName, i.Description, c.CategoryName, 
                           i.Quantity, i.MinimumThreshold, i.Price, i.LastUpdated,
                           CASE WHEN i.ItemImage IS NOT NULL THEN 'Yes' ELSE 'No' END AS HasImage
                           FROM Items i JOIN Categories c ON i.CategoryID = c.CategoryID
                           WHERE i.ItemName LIKE @Search OR i.Description LIKE @Search OR c.CategoryName LIKE @Search"
                        : @"SELECT i.ItemID, i.ItemName, i.Description, c.CategoryName, 
                           i.Quantity, i.MinimumThreshold, i.Price, i.LastUpdated
                           FROM Items i JOIN Categories c ON i.CategoryID = c.CategoryID
                           WHERE i.ItemName LIKE @Search OR i.Description LIKE @Search OR c.CategoryName LIKE @Search";

                    var dt = ExecuteQuery(query, cmd => cmd.Parameters.AddWithValue("@Search", $"%{searchTerm}%"));
                    dgvItems.DataSource = dt;
                    dgvItems.ClearSelection();
                    selectedItemID = -1;
                    ClearItemFields();
                    ShowImagePlaceholder();
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error searching items: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategories.SelectedRows.Count > 0)
                {
                    var row = dgvCategories.SelectedRows[0];
                    txtCategoryName.Text = row.Cells["CategoryName"].Value?.ToString() ?? "";
                    txtCategoryDesc.Text = row.Cells["Description"].Value?.ToString() ?? "";
                    dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error selecting category: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadItems();
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT i.ItemID, i.ItemName, i.Description, c.CategoryName, 
                            i.Quantity, i.MinimumThreshold, i.Price, i.LastUpdated
                            FROM Items i
                            LEFT JOIN Categories c ON i.CategoryID = c.CategoryID
                            WHERE i.ItemName LIKE @Search OR i.Description LIKE @Search OR c.CategoryName LIKE @Search
                            ORDER BY i.ItemName";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Search", "%" + searchTerm + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvItems.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching items: " + ex.Message);
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}