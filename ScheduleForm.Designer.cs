namespace InventoryManagementSystem
{
    partial class ScheduleForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.AddSchedBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BckBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 87);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1291, 939);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sunday";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 12F);
            this.label2.Location = new System.Drawing.Point(235, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Monday";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 12F);
            this.label3.Location = new System.Drawing.Point(405, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 36);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tuesday";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 12F);
            this.label4.Location = new System.Drawing.Point(571, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 36);
            this.label4.TabIndex = 4;
            this.label4.Text = "Wednesday";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 12F);
            this.label5.Location = new System.Drawing.Point(753, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 36);
            this.label5.TabIndex = 5;
            this.label5.Text = "Thursday";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins", 12F);
            this.label6.Location = new System.Drawing.Point(951, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 36);
            this.label6.TabIndex = 6;
            this.label6.Text = "Friday";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins", 12F);
            this.label7.Location = new System.Drawing.Point(1112, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 36);
            this.label7.TabIndex = 7;
            this.label7.Text = "Saturday";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Poppins", 12F);
            this.label8.Location = new System.Drawing.Point(15, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 36);
            this.label8.TabIndex = 8;
            this.label8.Text = "Month";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(1193, 14);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(39, 30);
            this.btnPrevious.TabIndex = 9;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1235, 14);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(41, 30);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // AddSchedBtn
            // 
            this.AddSchedBtn.Location = new System.Drawing.Point(980, 12);
            this.AddSchedBtn.Name = "AddSchedBtn";
            this.AddSchedBtn.Size = new System.Drawing.Size(154, 32);
            this.AddSchedBtn.TabIndex = 11;
            this.AddSchedBtn.Text = "Add Schedule";
            this.AddSchedBtn.UseVisualStyleBackColor = true;
            this.AddSchedBtn.Click += new System.EventHandler(this.AddSchedBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(820, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 32);
            this.button1.TabIndex = 12;
            this.button1.Text = "Update Schedule";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnUpdateSchedule_Click);
            // 
            // BckBtn
            // 
            this.BckBtn.Location = new System.Drawing.Point(715, 12);
            this.BckBtn.Name = "BckBtn";
            this.BckBtn.Size = new System.Drawing.Size(99, 32);
            this.BckBtn.TabIndex = 13;
            this.BckBtn.Text = "Back";
            this.BckBtn.UseVisualStyleBackColor = true;
            this.BckBtn.Click += new System.EventHandler(this.BckBtn_Click);
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 1040);
            this.Controls.Add(this.BckBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddSchedBtn);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ScheduleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Calendar";
            this.Load += new System.EventHandler(this.ScheduleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button AddSchedBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BckBtn;
    }
}