namespace WindowsFormsApplication1
{
    partial class StaffScheduler
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.sched_grid = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.staff_id = new System.Windows.Forms.TextBox();
            this.staff_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.staff_grid = new System.Windows.Forms.DataGridView();
            this.act_box = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sHour = new System.Windows.Forms.ComboBox();
            this.sMin = new System.Windows.Forms.ComboBox();
            this.sday = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.eHour = new System.Windows.Forms.ComboBox();
            this.eMin = new System.Windows.Forms.ComboBox();
            this.eday = new System.Windows.Forms.ComboBox();
            this.createStaff = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sched_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staff_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(395, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 32);
            this.label1.TabIndex = 21;
            this.label1.Text = "No.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(395, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 32);
            this.label3.TabIndex = 23;
            this.label3.Text = "Staff";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(396, 340);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 37);
            this.label4.TabIndex = 25;
            this.label4.Text = "Activity";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(400, 399);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 42);
            this.button1.TabIndex = 26;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(563, 399);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 42);
            this.button2.TabIndex = 27;
            this.button2.Text = "Calendar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // sched_grid
            // 
            this.sched_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sched_grid.Location = new System.Drawing.Point(838, 56);
            this.sched_grid.Margin = new System.Windows.Forms.Padding(4);
            this.sched_grid.Name = "sched_grid";
            this.sched_grid.Size = new System.Drawing.Size(420, 505);
            this.sched_grid.TabIndex = 28;
            this.sched_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // staff_id
            // 
            this.staff_id.BackColor = System.Drawing.SystemColors.Window;
            this.staff_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.staff_id.Font = new System.Drawing.Font("Verdana", 15.8F);
            this.staff_id.ForeColor = System.Drawing.Color.Black;
            this.staff_id.Location = new System.Drawing.Point(562, 62);
            this.staff_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.staff_id.Name = "staff_id";
            this.staff_id.Size = new System.Drawing.Size(176, 33);
            this.staff_id.TabIndex = 33;
            this.staff_id.Visible = false;
            this.staff_id.TextChanged += new System.EventHandler(this.user_TextChanged);
            // 
            // staff_name
            // 
            this.staff_name.BackColor = System.Drawing.SystemColors.Window;
            this.staff_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.staff_name.Enabled = false;
            this.staff_name.Font = new System.Drawing.Font("Verdana", 15.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staff_name.ForeColor = System.Drawing.Color.Black;
            this.staff_name.Location = new System.Drawing.Point(561, 117);
            this.staff_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.staff_name.Name = "staff_name";
            this.staff_name.Size = new System.Drawing.Size(234, 33);
            this.staff_name.TabIndex = 34;
            this.staff_name.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(393, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(394, 49);
            this.label5.TabIndex = 37;
            this.label5.Text = "Staff Scheduling";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1167, 20);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 38;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // staff_grid
            // 
            this.staff_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.staff_grid.Location = new System.Drawing.Point(21, 41);
            this.staff_grid.Margin = new System.Windows.Forms.Padding(4);
            this.staff_grid.Name = "staff_grid";
            this.staff_grid.Size = new System.Drawing.Size(320, 520);
            this.staff_grid.TabIndex = 39;
            this.staff_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.staff_grid_CellContentClick);
            // 
            // act_box
            // 
            this.act_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.act_box.FormattingEnabled = true;
            this.act_box.Items.AddRange(new object[] {
            "Kitchen",
            "Dog Care",
            "Cashier"});
            this.act_box.Location = new System.Drawing.Point(562, 340);
            this.act_box.Name = "act_box";
            this.act_box.Size = new System.Drawing.Size(166, 37);
            this.act_box.TabIndex = 45;
            this.act_box.SelectedIndexChanged += new System.EventHandler(this.act_box_SelectedIndexChanged);
            this.act_box.TextChanged += new System.EventHandler(this.act_box_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1035, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 28);
            this.button4.TabIndex = 48;
            this.button4.Text = "Create";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // date
            // 
            this.date.CustomFormat = "yyyy/MM/dd";
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(562, 170);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(166, 34);
            this.date.TabIndex = 51;
            this.date.Value = new System.DateTime(2018, 7, 18, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(393, 174);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 32);
            this.label7.TabIndex = 50;
            this.label7.Text = "Date";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(395, 228);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 32);
            this.label2.TabIndex = 52;
            this.label2.Text = "Start Time";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(396, 287);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 32);
            this.label6.TabIndex = 53;
            this.label6.Text = "End Time";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sHour
            // 
            this.sHour.FormattingEnabled = true;
            this.sHour.Items.AddRange(new object[] {
            "12",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.sHour.Location = new System.Drawing.Point(561, 236);
            this.sHour.Name = "sHour";
            this.sHour.Size = new System.Drawing.Size(59, 24);
            this.sHour.TabIndex = 54;
            // 
            // sMin
            // 
            this.sMin.FormattingEnabled = true;
            this.sMin.Items.AddRange(new object[] {
            "00",
            "05",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.sMin.Location = new System.Drawing.Point(652, 236);
            this.sMin.Name = "sMin";
            this.sMin.Size = new System.Drawing.Size(62, 24);
            this.sMin.TabIndex = 55;
            // 
            // sday
            // 
            this.sday.Enabled = false;
            this.sday.FormattingEnabled = true;
            this.sday.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.sday.Location = new System.Drawing.Point(746, 236);
            this.sday.Name = "sday";
            this.sday.Size = new System.Drawing.Size(52, 24);
            this.sday.TabIndex = 56;
            this.sday.Text = "PM";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(627, 236);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 24);
            this.label8.TabIndex = 60;
            this.label8.Text = ":";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(627, 287);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 24);
            this.label9.TabIndex = 61;
            this.label9.Text = ":";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(721, 236);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 24);
            this.label10.TabIndex = 62;
            this.label10.Text = ":";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(721, 287);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 24);
            this.label11.TabIndex = 63;
            this.label11.Text = ":";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // eHour
            // 
            this.eHour.FormattingEnabled = true;
            this.eHour.Items.AddRange(new object[] {
            "12",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.eHour.Location = new System.Drawing.Point(562, 287);
            this.eHour.Name = "eHour";
            this.eHour.Size = new System.Drawing.Size(58, 24);
            this.eHour.TabIndex = 64;
            // 
            // eMin
            // 
            this.eMin.FormattingEnabled = true;
            this.eMin.Items.AddRange(new object[] {
            "00",
            "05",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.eMin.Location = new System.Drawing.Point(652, 287);
            this.eMin.Name = "eMin";
            this.eMin.Size = new System.Drawing.Size(62, 24);
            this.eMin.TabIndex = 65;
            // 
            // eday
            // 
            this.eday.Enabled = false;
            this.eday.FormattingEnabled = true;
            this.eday.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.eday.Location = new System.Drawing.Point(746, 287);
            this.eday.Name = "eday";
            this.eday.Size = new System.Drawing.Size(52, 24);
            this.eday.TabIndex = 66;
            this.eday.Text = "PM";
            // 
            // createStaff
            // 
            this.createStaff.Location = new System.Drawing.Point(21, 11);
            this.createStaff.Name = "createStaff";
            this.createStaff.Size = new System.Drawing.Size(94, 23);
            this.createStaff.TabIndex = 67;
            this.createStaff.Text = "Create";
            this.createStaff.UseVisualStyleBackColor = true;
            this.createStaff.Click += new System.EventHandler(this.createStaff_Click);
            // 
            // StaffScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1285, 619);
            this.Controls.Add(this.createStaff);
            this.Controls.Add(this.eday);
            this.Controls.Add(this.eMin);
            this.Controls.Add(this.eHour);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sday);
            this.Controls.Add(this.sMin);
            this.Controls.Add(this.sHour);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.act_box);
            this.Controls.Add(this.staff_grid);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.staff_name);
            this.Controls.Add(this.staff_id);
            this.Controls.Add(this.sched_grid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StaffScheduler";
            this.Text = "Form9";
            this.Activated += new System.EventHandler(this.Form9_Activated);
            this.Load += new System.EventHandler(this.Form9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sched_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staff_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView sched_grid;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox staff_id;
        private System.Windows.Forms.TextBox staff_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView staff_grid;
        private System.Windows.Forms.ComboBox act_box;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox sHour;
        private System.Windows.Forms.ComboBox sMin;
        private System.Windows.Forms.ComboBox sday;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox eHour;
        private System.Windows.Forms.ComboBox eMin;
        private System.Windows.Forms.ComboBox eday;
        private System.Windows.Forms.Button createStaff;
    }
}