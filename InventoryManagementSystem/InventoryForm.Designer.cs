namespace InventoryManagementSystem
{
    partial class InventoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.txtCategoryDesc = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.nudMinThreshold = new System.Windows.Forms.NumericUpDown();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnItemUpd = new System.Windows.Forms.Button();
            this.btnUpdCat = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pBDisplayImg = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pbInsert = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBDisplayImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInsert)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.BackColor = System.Drawing.Color.White;
            this.btnDeleteItem.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItem.ForeColor = System.Drawing.Color.Tomato;
            this.btnDeleteItem.Location = new System.Drawing.Point(250, 913);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(136, 50);
            this.btnDeleteItem.TabIndex = 0;
            this.btnDeleteItem.Text = "Delete Item";
            this.btnDeleteItem.UseVisualStyleBackColor = false;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click_1);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCategory.ForeColor = System.Drawing.Color.Tomato;
            this.btnDeleteCategory.Location = new System.Drawing.Point(250, 389);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(135, 53);
            this.btnDeleteCategory.TabIndex = 1;
            this.btnDeleteCategory.Text = "Delete Category";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // cmbCategories
            // 
            this.cmbCategories.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategories.ForeColor = System.Drawing.Color.Tomato;
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(63, 853);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(322, 37);
            this.cmbCategories.TabIndex = 2;
            this.cmbCategories.Text = "Categories";
            // 
            // dgvCategories
            // 
            this.dgvCategories.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.GridColor = System.Drawing.Color.Tomato;
            this.dgvCategories.Location = new System.Drawing.Point(504, 437);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.Size = new System.Drawing.Size(1364, 228);
            this.dgvCategories.TabIndex = 3;
            // 
            // dgvItems
            // 
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.GridColor = System.Drawing.Color.Tomato;
            this.dgvItems.Location = new System.Drawing.Point(504, 802);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(1364, 228);
            this.dgvItems.TabIndex = 4;
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryName.ForeColor = System.Drawing.Color.Tomato;
            this.txtCategoryName.Location = new System.Drawing.Point(63, 250);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(322, 37);
            this.txtCategoryName.TabIndex = 5;
            // 
            // txtCategoryDesc
            // 
            this.txtCategoryDesc.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryDesc.ForeColor = System.Drawing.Color.Tomato;
            this.txtCategoryDesc.Location = new System.Drawing.Point(63, 336);
            this.txtCategoryDesc.Name = "txtCategoryDesc";
            this.txtCategoryDesc.Size = new System.Drawing.Size(320, 37);
            this.txtCategoryDesc.TabIndex = 6;
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.ForeColor = System.Drawing.Color.Tomato;
            this.txtItemName.Location = new System.Drawing.Point(63, 675);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(322, 37);
            this.txtItemName.TabIndex = 7;
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemDesc.ForeColor = System.Drawing.Color.Tomato;
            this.txtItemDesc.Location = new System.Drawing.Point(63, 762);
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.Size = new System.Drawing.Size(322, 37);
            this.txtItemDesc.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightCyan;
            this.label1.Location = new System.Drawing.Point(57, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 34);
            this.label1.TabIndex = 9;
            this.label1.Text = "Category Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightCyan;
            this.label2.Location = new System.Drawing.Point(57, 638);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 34);
            this.label2.TabIndex = 10;
            this.label2.Text = "Item Name:";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQuantity.ForeColor = System.Drawing.Color.Tomato;
            this.nudQuantity.Location = new System.Drawing.Point(922, 103);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 40);
            this.nudQuantity.TabIndex = 11;
            // 
            // nudMinThreshold
            // 
            this.nudMinThreshold.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMinThreshold.ForeColor = System.Drawing.Color.Tomato;
            this.nudMinThreshold.Location = new System.Drawing.Point(922, 162);
            this.nudMinThreshold.Name = "nudMinThreshold";
            this.nudMinThreshold.Size = new System.Drawing.Size(120, 40);
            this.nudMinThreshold.TabIndex = 12;
            // 
            // nudPrice
            // 
            this.nudPrice.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPrice.ForeColor = System.Drawing.Color.Tomato;
            this.nudPrice.Location = new System.Drawing.Point(922, 221);
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(120, 40);
            this.nudPrice.TabIndex = 13;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Tomato;
            this.txtSearch.Location = new System.Drawing.Point(1225, 106);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(322, 40);
            this.txtSearch.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Tomato;
            this.label3.Location = new System.Drawing.Point(1218, 64);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(116, 39);
            this.label3.TabIndex = 15;
            this.label3.Text = "Search:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightCyan;
            this.label4.Location = new System.Drawing.Point(58, 816);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(121, 34);
            this.label4.TabIndex = 16;
            this.label4.Text = "Category:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LightCyan;
            this.label5.Location = new System.Drawing.Point(57, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 34);
            this.label5.TabIndex = 17;
            this.label5.Text = "Category Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Tomato;
            this.label6.Location = new System.Drawing.Point(497, 730);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 39);
            this.label6.TabIndex = 18;
            this.label6.Text = "Items:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Tomato;
            this.label7.Location = new System.Drawing.Point(497, 367);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 39);
            this.label7.TabIndex = 19;
            this.label7.Text = "Categories:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Tomato;
            this.label8.Location = new System.Drawing.Point(615, 222);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(90, 39);
            this.label8.TabIndex = 20;
            this.label8.Text = "Price:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Tomato;
            this.label9.Location = new System.Drawing.Point(615, 163);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label9.Size = new System.Drawing.Size(278, 39);
            this.label9.TabIndex = 21;
            this.label9.Text = "Minimum Threshold";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Tomato;
            this.label10.Location = new System.Drawing.Point(615, 104);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label10.Size = new System.Drawing.Size(127, 39);
            this.label10.TabIndex = 22;
            this.label10.Text = "Quantity";
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.BackColor = System.Drawing.Color.White;
            this.btnAddCategory.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCategory.ForeColor = System.Drawing.Color.Tomato;
            this.btnAddCategory.Location = new System.Drawing.Point(63, 389);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(140, 53);
            this.btnAddCategory.TabIndex = 23;
            this.btnAddCategory.Text = "Add Category";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.White;
            this.btnAddItem.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.ForeColor = System.Drawing.Color.Tomato;
            this.btnAddItem.Location = new System.Drawing.Point(64, 913);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(139, 50);
            this.btnAddItem.TabIndex = 24;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.LightCyan;
            this.label11.Location = new System.Drawing.Point(57, 725);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(205, 34);
            this.label11.TabIndex = 25;
            this.label11.Text = "Item Description:";
            // 
            // btnItemUpd
            // 
            this.btnItemUpd.BackColor = System.Drawing.Color.White;
            this.btnItemUpd.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemUpd.ForeColor = System.Drawing.Color.Tomato;
            this.btnItemUpd.Location = new System.Drawing.Point(66, 521);
            this.btnItemUpd.Name = "btnItemUpd";
            this.btnItemUpd.Size = new System.Drawing.Size(139, 49);
            this.btnItemUpd.TabIndex = 26;
            this.btnItemUpd.Text = "Update Item";
            this.btnItemUpd.UseVisualStyleBackColor = false;
            this.btnItemUpd.Click += new System.EventHandler(this.btnItemUpd_Click);
            // 
            // btnUpdCat
            // 
            this.btnUpdCat.BackColor = System.Drawing.Color.White;
            this.btnUpdCat.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdCat.ForeColor = System.Drawing.Color.Tomato;
            this.btnUpdCat.Location = new System.Drawing.Point(252, 521);
            this.btnUpdCat.Name = "btnUpdCat";
            this.btnUpdCat.Size = new System.Drawing.Size(133, 49);
            this.btnUpdCat.TabIndex = 27;
            this.btnUpdCat.Text = "Update Category";
            this.btnUpdCat.UseVisualStyleBackColor = false;
            this.btnUpdCat.Click += new System.EventHandler(this.btnUpdCat_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.LightCyan;
            this.label12.Location = new System.Drawing.Point(57, 590);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(170, 39);
            this.label12.TabIndex = 28;
            this.label12.Text = "Create Item";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.LightCyan;
            this.label13.Location = new System.Drawing.Point(56, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(229, 39);
            this.label13.TabIndex = 29;
            this.label13.Text = "Create Category";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.LightCyan;
            this.label14.Location = new System.Drawing.Point(59, 470);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(241, 39);
            this.label14.TabIndex = 30;
            this.label14.Text = "Update Selection";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Tomato;
            this.btnBack.Location = new System.Drawing.Point(63, 29);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(139, 50);
            this.btnBack.TabIndex = 38;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1593, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 243);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // pBDisplayImg
            // 
            this.pBDisplayImg.Location = new System.Drawing.Point(1593, 68);
            this.pBDisplayImg.Name = "pBDisplayImg";
            this.pBDisplayImg.Size = new System.Drawing.Size(275, 243);
            this.pBDisplayImg.TabIndex = 44;
            this.pBDisplayImg.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Tomato;
            this.btnSearch.Location = new System.Drawing.Point(1225, 168);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(139, 50);
            this.btnSearch.TabIndex = 37;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pbInsert
            // 
            this.pbInsert.Location = new System.Drawing.Point(1593, 68);
            this.pbInsert.Name = "pbInsert";
            this.pbInsert.Size = new System.Drawing.Size(275, 243);
            this.pbInsert.TabIndex = 0;
            this.pbInsert.TabStop = false;
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InventoryManagementSystem.Properties.Resources.inventory_bg;
            this.ClientSize = new System.Drawing.Size(1920, 974);
            this.Controls.Add(this.pbInsert);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pBDisplayImg);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnUpdCat);
            this.Controls.Add(this.btnItemUpd);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.nudMinThreshold);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtItemDesc);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.txtCategoryDesc);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.dgvCategories);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.btnDeleteItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InventoryForm";
            this.Load += new System.EventHandler(this.InventoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBDisplayImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInsert)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.TextBox txtCategoryDesc;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.NumericUpDown nudMinThreshold;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnItemUpd;
        private System.Windows.Forms.Button btnUpdCat;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pBDisplayImg;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pbInsert;
    }
}