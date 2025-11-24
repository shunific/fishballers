namespace InventoryManagementSystem
{
    partial class MainForm
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.dgvRecentItems = new System.Windows.Forms.DataGridView();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.lblLowStockItems = new System.Windows.Forms.Label();
            this.lblTotalCategories = new System.Windows.Forms.Label();
            this.btnInventory_Click = new System.Windows.Forms.Button();
            this.btnLogout_Click = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clbTasks = new System.Windows.Forms.CheckedListBox();
            this.btnRemoveCompleted = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.txtNewTask = new System.Windows.Forms.TextBox();
            this.ToDoList = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Tomato;
            this.lblWelcome.Location = new System.Drawing.Point(463, 116);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(143, 60);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "label1";
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.BackColor = System.Drawing.Color.White;
            this.btnUserManagement.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserManagement.ForeColor = System.Drawing.Color.Tomato;
            this.btnUserManagement.Location = new System.Drawing.Point(46, 595);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(287, 63);
            this.btnUserManagement.TabIndex = 1;
            this.btnUserManagement.Text = "Manage Users";
            this.btnUserManagement.UseVisualStyleBackColor = false;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click_1);
            // 
            // dgvRecentItems
            // 
            this.dgvRecentItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentItems.GridColor = System.Drawing.Color.Tomato;
            this.dgvRecentItems.Location = new System.Drawing.Point(1417, 78);
            this.dgvRecentItems.Name = "dgvRecentItems";
            this.dgvRecentItems.Size = new System.Drawing.Size(411, 915);
            this.dgvRecentItems.TabIndex = 2;
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalItems.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItems.ForeColor = System.Drawing.Color.Tomato;
            this.lblTotalItems.Location = new System.Drawing.Point(484, 816);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(94, 39);
            this.lblTotalItems.TabIndex = 3;
            this.lblTotalItems.Text = "label1";
            // 
            // lblLowStockItems
            // 
            this.lblLowStockItems.AutoSize = true;
            this.lblLowStockItems.BackColor = System.Drawing.Color.Transparent;
            this.lblLowStockItems.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStockItems.ForeColor = System.Drawing.Color.Tomato;
            this.lblLowStockItems.Location = new System.Drawing.Point(955, 816);
            this.lblLowStockItems.Name = "lblLowStockItems";
            this.lblLowStockItems.Size = new System.Drawing.Size(220, 39);
            this.lblLowStockItems.TabIndex = 4;
            this.lblLowStockItems.Text = "low stock items";
            // 
            // lblTotalCategories
            // 
            this.lblTotalCategories.AutoSize = true;
            this.lblTotalCategories.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCategories.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCategories.ForeColor = System.Drawing.Color.Tomato;
            this.lblTotalCategories.Location = new System.Drawing.Point(485, 954);
            this.lblTotalCategories.Name = "lblTotalCategories";
            this.lblTotalCategories.Size = new System.Drawing.Size(224, 39);
            this.lblTotalCategories.TabIndex = 5;
            this.lblTotalCategories.Text = "total categories";
            // 
            // btnInventory_Click
            // 
            this.btnInventory_Click.BackColor = System.Drawing.Color.White;
            this.btnInventory_Click.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory_Click.ForeColor = System.Drawing.Color.Tomato;
            this.btnInventory_Click.Location = new System.Drawing.Point(46, 514);
            this.btnInventory_Click.Name = "btnInventory_Click";
            this.btnInventory_Click.Size = new System.Drawing.Size(287, 62);
            this.btnInventory_Click.TabIndex = 6;
            this.btnInventory_Click.Text = "Manage Inventory";
            this.btnInventory_Click.UseVisualStyleBackColor = false;
            this.btnInventory_Click.Click += new System.EventHandler(this.btnInventory_Click_Click);
            // 
            // btnLogout_Click
            // 
            this.btnLogout_Click.BackColor = System.Drawing.Color.White;
            this.btnLogout_Click.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout_Click.ForeColor = System.Drawing.Color.Tomato;
            this.btnLogout_Click.Location = new System.Drawing.Point(89, 928);
            this.btnLogout_Click.Name = "btnLogout_Click";
            this.btnLogout_Click.Size = new System.Drawing.Size(207, 65);
            this.btnLogout_Click.TabIndex = 7;
            this.btnLogout_Click.Text = "Log Out";
            this.btnLogout_Click.UseVisualStyleBackColor = false;
            this.btnLogout_Click.Click += new System.EventHandler(this.btnLogout_Click_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(955, 768);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 39);
            this.label1.TabIndex = 8;
            this.label1.Text = "Items Low in Stock:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Tomato;
            this.label2.Location = new System.Drawing.Point(485, 904);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 39);
            this.label2.TabIndex = 9;
            this.label2.Text = "Total Categories:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Tomato;
            this.label3.Location = new System.Drawing.Point(484, 768);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 39);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total Items:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // clbTasks
            // 
            this.clbTasks.BackColor = System.Drawing.Color.White;
            this.clbTasks.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbTasks.ForeColor = System.Drawing.Color.Tomato;
            this.clbTasks.FormattingEnabled = true;
            this.clbTasks.Location = new System.Drawing.Point(492, 422);
            this.clbTasks.Name = "clbTasks";
            this.clbTasks.Size = new System.Drawing.Size(763, 200);
            this.clbTasks.TabIndex = 25;
            this.clbTasks.SelectedIndexChanged += new System.EventHandler(this.clbTasks_SelectedIndexChanged);
            // 
            // btnRemoveCompleted
            // 
            this.btnRemoveCompleted.BackColor = System.Drawing.Color.White;
            this.btnRemoveCompleted.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveCompleted.ForeColor = System.Drawing.Color.Tomato;
            this.btnRemoveCompleted.Location = new System.Drawing.Point(694, 646);
            this.btnRemoveCompleted.Name = "btnRemoveCompleted";
            this.btnRemoveCompleted.Size = new System.Drawing.Size(338, 43);
            this.btnRemoveCompleted.TabIndex = 24;
            this.btnRemoveCompleted.Text = "Remove completed";
            this.btnRemoveCompleted.UseVisualStyleBackColor = false;
            // 
            // btnAddTask
            // 
            this.btnAddTask.BackColor = System.Drawing.Color.White;
            this.btnAddTask.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTask.ForeColor = System.Drawing.Color.Tomato;
            this.btnAddTask.Location = new System.Drawing.Point(962, 363);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(146, 43);
            this.btnAddTask.TabIndex = 23;
            this.btnAddTask.Text = "Add task";
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // txtNewTask
            // 
            this.txtNewTask.Font = new System.Drawing.Font("Impact", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewTask.ForeColor = System.Drawing.Color.Tomato;
            this.txtNewTask.Location = new System.Drawing.Point(491, 363);
            this.txtNewTask.Name = "txtNewTask";
            this.txtNewTask.Size = new System.Drawing.Size(455, 43);
            this.txtNewTask.TabIndex = 22;
            // 
            // ToDoList
            // 
            this.ToDoList.AutoSize = true;
            this.ToDoList.BackColor = System.Drawing.Color.Transparent;
            this.ToDoList.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToDoList.ForeColor = System.Drawing.Color.Tomato;
            this.ToDoList.Location = new System.Drawing.Point(483, 317);
            this.ToDoList.Name = "ToDoList";
            this.ToDoList.Size = new System.Drawing.Size(102, 43);
            this.ToDoList.TabIndex = 21;
            this.ToDoList.Text = "To do:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::InventoryManagementSystem.Properties.Resources.Untitled__320_x_320_px___5_;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(46, 160);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 276);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightCyan;
            this.label7.Location = new System.Drawing.Point(1, 450);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(379, 43);
            this.label7.TabIndex = 27;
            this.label7.Text = "------------------------------------";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InventoryManagementSystem.Properties.Resources.bg_updated_1;
            this.ClientSize = new System.Drawing.Size(1920, 1020);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.clbTasks);
            this.Controls.Add(this.btnRemoveCompleted);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.txtNewTask);
            this.Controls.Add(this.ToDoList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout_Click);
            this.Controls.Add(this.btnInventory_Click);
            this.Controls.Add(this.lblTotalCategories);
            this.Controls.Add(this.lblLowStockItems);
            this.Controls.Add(this.lblTotalItems);
            this.Controls.Add(this.dgvRecentItems);
            this.Controls.Add(this.btnUserManagement);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome Screen (Main Form)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.DataGridView dgvRecentItems;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Label lblLowStockItems;
        private System.Windows.Forms.Label lblTotalCategories;
        private System.Windows.Forms.Button btnInventory_Click;
        private System.Windows.Forms.Button btnLogout_Click;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox clbTasks;
        private System.Windows.Forms.Button btnRemoveCompleted;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.TextBox txtNewTask;
        private System.Windows.Forms.Label ToDoList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
    }
}

