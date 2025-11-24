namespace InventoryManagementSystem
{
    partial class AddSchedules
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
            this.dateTimePickerAddSched = new System.Windows.Forms.DateTimePicker();
            this.TxtBoxAddSched = new System.Windows.Forms.TextBox();
            this.CmbAddSched = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveBtnAddSched = new System.Windows.Forms.Button();
            this.CancelBtnAddSchedClick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePickerAddSched
            // 
            this.dateTimePickerAddSched.Location = new System.Drawing.Point(45, 96);
            this.dateTimePickerAddSched.Name = "dateTimePickerAddSched";
            this.dateTimePickerAddSched.Size = new System.Drawing.Size(232, 22);
            this.dateTimePickerAddSched.TabIndex = 1;
            this.dateTimePickerAddSched.ValueChanged += new System.EventHandler(this.dateTimePickerAddSched_ValueChanged);
            // 
            // TxtBoxAddSched
            // 
            this.TxtBoxAddSched.Location = new System.Drawing.Point(45, 163);
            this.TxtBoxAddSched.Multiline = true;
            this.TxtBoxAddSched.Name = "TxtBoxAddSched";
            this.TxtBoxAddSched.Size = new System.Drawing.Size(403, 207);
            this.TxtBoxAddSched.TabIndex = 2;
            this.TxtBoxAddSched.TextChanged += new System.EventHandler(this.TxtBoxAddSched_TextChanged);
            // 
            // CmbAddSched
            // 
            this.CmbAddSched.FormattingEnabled = true;
            this.CmbAddSched.Location = new System.Drawing.Point(45, 32);
            this.CmbAddSched.Name = "CmbAddSched";
            this.CmbAddSched.Size = new System.Drawing.Size(232, 24);
            this.CmbAddSched.TabIndex = 3;
            this.CmbAddSched.SelectedIndexChanged += new System.EventHandler(this.CmbAddSched_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name of the schedule";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Description";
            // 
            // SaveBtnAddSched
            // 
            this.SaveBtnAddSched.Location = new System.Drawing.Point(366, 391);
            this.SaveBtnAddSched.Name = "SaveBtnAddSched";
            this.SaveBtnAddSched.Size = new System.Drawing.Size(82, 35);
            this.SaveBtnAddSched.TabIndex = 7;
            this.SaveBtnAddSched.Text = "Save";
            this.SaveBtnAddSched.UseVisualStyleBackColor = true;
            this.SaveBtnAddSched.Click += new System.EventHandler(this.SaveBtnAddSched_Click);
            // 
            // CancelBtnAddSchedClick
            // 
            this.CancelBtnAddSchedClick.Location = new System.Drawing.Point(45, 391);
            this.CancelBtnAddSchedClick.Name = "CancelBtnAddSchedClick";
            this.CancelBtnAddSchedClick.Size = new System.Drawing.Size(82, 35);
            this.CancelBtnAddSchedClick.TabIndex = 8;
            this.CancelBtnAddSchedClick.Text = "Cancel";
            this.CancelBtnAddSchedClick.UseVisualStyleBackColor = true;
            this.CancelBtnAddSchedClick.Click += new System.EventHandler(this.CancelBtnAddSched_Click);
            // 
            // AddSchedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 450);
            this.Controls.Add(this.CancelBtnAddSchedClick);
            this.Controls.Add(this.SaveBtnAddSched);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbAddSched);
            this.Controls.Add(this.TxtBoxAddSched);
            this.Controls.Add(this.dateTimePickerAddSched);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddSchedules";
            this.Text = "AddSchedules";
            this.Load += new System.EventHandler(this.AddSchedules_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePickerAddSched;
        private System.Windows.Forms.TextBox TxtBoxAddSched;
        private System.Windows.Forms.ComboBox CmbAddSched;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveBtnAddSched;
        private System.Windows.Forms.Button CancelBtnAddSchedClick;
    }
}