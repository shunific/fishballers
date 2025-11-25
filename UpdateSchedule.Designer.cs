namespace InventoryManagementSystem
{
    partial class UpdateSchedules
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
            this.txtBoxUpdSched = new System.Windows.Forms.TextBox();
            this.CmbTypeOfSchedUpd = new System.Windows.Forms.ComboBox();
            this.SaveBtnUpdSchedClick = new System.Windows.Forms.Button();
            this.BckBtn = new System.Windows.Forms.Button();
            this.DelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxUpdSched
            // 
            this.txtBoxUpdSched.Location = new System.Drawing.Point(28, 28);
            this.txtBoxUpdSched.Multiline = true;
            this.txtBoxUpdSched.Name = "txtBoxUpdSched";
            this.txtBoxUpdSched.Size = new System.Drawing.Size(482, 178);
            this.txtBoxUpdSched.TabIndex = 1;
            this.txtBoxUpdSched.TextChanged += new System.EventHandler(this.TxtBoxUpdSched_TextChanged);
            // 
            // CmbTypeOfSchedUpd
            // 
            this.CmbTypeOfSchedUpd.FormattingEnabled = true;
            this.CmbTypeOfSchedUpd.Location = new System.Drawing.Point(28, 242);
            this.CmbTypeOfSchedUpd.Name = "CmbTypeOfSchedUpd";
            this.CmbTypeOfSchedUpd.Size = new System.Drawing.Size(246, 24);
            this.CmbTypeOfSchedUpd.TabIndex = 2;
            this.CmbTypeOfSchedUpd.SelectedIndexChanged += new System.EventHandler(this.CmbTypeOfSchedUpd_SelectedIndexChanged);
            // 
            // SaveBtnUpdSchedClick
            // 
            this.SaveBtnUpdSchedClick.Location = new System.Drawing.Point(407, 389);
            this.SaveBtnUpdSchedClick.Name = "SaveBtnUpdSchedClick";
            this.SaveBtnUpdSchedClick.Size = new System.Drawing.Size(103, 35);
            this.SaveBtnUpdSchedClick.TabIndex = 3;
            this.SaveBtnUpdSchedClick.Text = "Save";
            this.SaveBtnUpdSchedClick.UseVisualStyleBackColor = true;
            this.SaveBtnUpdSchedClick.Click += new System.EventHandler(this.SaveBtnUpdSched_Click);
            // 
            // BckBtn
            // 
            this.BckBtn.Location = new System.Drawing.Point(28, 389);
            this.BckBtn.Name = "BckBtn";
            this.BckBtn.Size = new System.Drawing.Size(98, 35);
            this.BckBtn.TabIndex = 4;
            this.BckBtn.Text = "Back";
            this.BckBtn.UseVisualStyleBackColor = true;
            this.BckBtn.Click += new System.EventHandler(this.BckBtn_Click);
            // 
            // DelBtn
            // 
            this.DelBtn.Location = new System.Drawing.Point(207, 389);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(116, 35);
            this.DelBtn.TabIndex = 5;
            this.DelBtn.Text = "Delete";
            this.DelBtn.UseVisualStyleBackColor = true;
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Type of schedule";
            // 
            // UpdateSchedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DelBtn);
            this.Controls.Add(this.BckBtn);
            this.Controls.Add(this.SaveBtnUpdSchedClick);
            this.Controls.Add(this.CmbTypeOfSchedUpd);
            this.Controls.Add(this.txtBoxUpdSched);
            this.Name = "UpdateSchedules";
            this.Text = "UpdateSchedule";
            this.Load += new System.EventHandler(this.UpdateSchedule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBoxUpdSched;
        private System.Windows.Forms.ComboBox CmbTypeOfSchedUpd;
        private System.Windows.Forms.Button SaveBtnUpdSchedClick;
        private System.Windows.Forms.Button BckBtn;
        private System.Windows.Forms.Button DelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}