namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.createStaff = new System.Windows.Forms.Button();
            this.eday = new System.Windows.Forms.ComboBox();
            this.eMin = new System.Windows.Forms.ComboBox();
            this.eHour = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sday = new System.Windows.Forms.ComboBox();
            this.sMin = new System.Windows.Forms.ComboBox();
            this.sHour = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dog_grid = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dog_breed = new System.Windows.Forms.TextBox();
            this.dog_name = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.clinic_grid = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.clinic_text = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.dog_id = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dog_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinic_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // createStaff
            // 
            this.createStaff.Location = new System.Drawing.Point(32, 57);
            this.createStaff.Name = "createStaff";
            this.createStaff.Size = new System.Drawing.Size(94, 23);
            this.createStaff.TabIndex = 95;
            this.createStaff.Text = "Create";
            this.createStaff.UseVisualStyleBackColor = true;
            this.createStaff.Click += new System.EventHandler(this.createStaff_Click);
            // 
            // eday
            // 
            this.eday.FormattingEnabled = true;
            this.eday.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.eday.Location = new System.Drawing.Point(750, 426);
            this.eday.Name = "eday";
            this.eday.Size = new System.Drawing.Size(61, 24);
            this.eday.TabIndex = 94;
            this.eday.Text = "AM";
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
            this.eMin.Location = new System.Drawing.Point(656, 426);
            this.eMin.Name = "eMin";
            this.eMin.Size = new System.Drawing.Size(62, 24);
            this.eMin.TabIndex = 93;
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
            this.eHour.Location = new System.Drawing.Point(566, 426);
            this.eHour.Name = "eHour";
            this.eHour.Size = new System.Drawing.Size(58, 24);
            this.eHour.TabIndex = 92;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(725, 426);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 24);
            this.label11.TabIndex = 91;
            this.label11.Text = ":";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(725, 375);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 24);
            this.label10.TabIndex = 90;
            this.label10.Text = ":";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(631, 426);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 24);
            this.label9.TabIndex = 89;
            this.label9.Text = ":";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(631, 375);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 24);
            this.label8.TabIndex = 88;
            this.label8.Text = ":";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sday
            // 
            this.sday.FormattingEnabled = true;
            this.sday.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.sday.Location = new System.Drawing.Point(750, 375);
            this.sday.Name = "sday";
            this.sday.Size = new System.Drawing.Size(61, 24);
            this.sday.TabIndex = 87;
            this.sday.Text = "AM";
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
            this.sMin.Location = new System.Drawing.Point(656, 375);
            this.sMin.Name = "sMin";
            this.sMin.Size = new System.Drawing.Size(62, 24);
            this.sMin.TabIndex = 86;
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
            this.sHour.Location = new System.Drawing.Point(565, 375);
            this.sHour.Name = "sHour";
            this.sHour.Size = new System.Drawing.Size(59, 24);
            this.sHour.TabIndex = 85;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(400, 426);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 32);
            this.label6.TabIndex = 84;
            this.label6.Text = "End Time";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(399, 367);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 32);
            this.label2.TabIndex = 83;
            this.label2.Text = "Start Time";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // date
            // 
            this.date.CustomFormat = "yyyy/MM/dd";
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(567, 318);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(176, 34);
            this.date.TabIndex = 82;
            this.date.Value = new System.DateTime(2018, 7, 18, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(398, 322);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 32);
            this.label7.TabIndex = 81;
            this.label7.Text = "Date";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dog_grid
            // 
            this.dog_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dog_grid.Location = new System.Drawing.Point(32, 87);
            this.dog_grid.Margin = new System.Windows.Forms.Padding(4);
            this.dog_grid.Name = "dog_grid";
            this.dog_grid.Size = new System.Drawing.Size(320, 520);
            this.dog_grid.TabIndex = 78;
            this.dog_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.staff_grid_CellContentClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1178, 66);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 77;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(445, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(394, 49);
            this.label5.TabIndex = 76;
            this.label5.Text = "Dog Medication";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dog_breed
            // 
            this.dog_breed.BackColor = System.Drawing.SystemColors.Window;
            this.dog_breed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dog_breed.Enabled = false;
            this.dog_breed.Font = new System.Drawing.Font("Verdana", 15.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dog_breed.ForeColor = System.Drawing.Color.Black;
            this.dog_breed.Location = new System.Drawing.Point(568, 217);
            this.dog_breed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dog_breed.Name = "dog_breed";
            this.dog_breed.Size = new System.Drawing.Size(175, 33);
            this.dog_breed.TabIndex = 75;
            // 
            // dog_name
            // 
            this.dog_name.BackColor = System.Drawing.SystemColors.Window;
            this.dog_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dog_name.Enabled = false;
            this.dog_name.Font = new System.Drawing.Font("Verdana", 15.8F);
            this.dog_name.ForeColor = System.Drawing.Color.Black;
            this.dog_name.Location = new System.Drawing.Point(567, 162);
            this.dog_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dog_name.Name = "dog_name";
            this.dog_name.Size = new System.Drawing.Size(176, 33);
            this.dog_name.TabIndex = 74;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1046, 66);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 28);
            this.button4.TabIndex = 80;
            this.button4.Text = "Create";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // clinic_grid
            // 
            this.clinic_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clinic_grid.Location = new System.Drawing.Point(858, 102);
            this.clinic_grid.Margin = new System.Windows.Forms.Padding(4);
            this.clinic_grid.Name = "clinic_grid";
            this.clinic_grid.Size = new System.Drawing.Size(420, 505);
            this.clinic_grid.TabIndex = 73;
            this.clinic_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clinic_grid_CellContentClick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(730, 565);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 42);
            this.button2.TabIndex = 72;
            this.button2.Text = "Medical History";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(405, 565);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 42);
            this.button1.TabIndex = 71;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(400, 264);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 37);
            this.label4.TabIndex = 70;
            this.label4.Text = "Clinic";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(400, 220);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 32);
            this.label3.TabIndex = 69;
            this.label3.Text = "Breed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(400, 165);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 32);
            this.label1.TabIndex = 68;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Kitchen",
            "Dog Care",
            "Cashier"});
            this.comboBox1.Location = new System.Drawing.Point(565, 477);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(178, 37);
            this.comboBox1.TabIndex = 97;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(399, 477);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 37);
            this.label12.TabIndex = 96;
            this.label12.Text = "Status";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clinic_text
            // 
            this.clinic_text.BackColor = System.Drawing.SystemColors.Window;
            this.clinic_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clinic_text.Enabled = false;
            this.clinic_text.Font = new System.Drawing.Font("Verdana", 15.8F);
            this.clinic_text.ForeColor = System.Drawing.Color.Black;
            this.clinic_text.Location = new System.Drawing.Point(566, 268);
            this.clinic_text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clinic_text.Name = "clinic_text";
            this.clinic_text.Size = new System.Drawing.Size(177, 33);
            this.clinic_text.TabIndex = 98;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button6.Location = new System.Drawing.Point(565, 565);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(107, 42);
            this.button6.TabIndex = 100;
            this.button6.Text = "Update";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // dog_id
            // 
            this.dog_id.BackColor = System.Drawing.SystemColors.Window;
            this.dog_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dog_id.Font = new System.Drawing.Font("Verdana", 15.8F);
            this.dog_id.ForeColor = System.Drawing.Color.Black;
            this.dog_id.Location = new System.Drawing.Point(567, 114);
            this.dog_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dog_id.Name = "dog_id";
            this.dog_id.Size = new System.Drawing.Size(176, 33);
            this.dog_id.TabIndex = 102;
            this.dog_id.Visible = false;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(400, 117);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(165, 32);
            this.label13.TabIndex = 101;
            this.label13.Text = "No.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1307, 665);
            this.Controls.Add(this.dog_id);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.clinic_text);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label12);
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
            this.Controls.Add(this.dog_grid);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dog_breed);
            this.Controls.Add(this.dog_name);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.clinic_grid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Activated += new System.EventHandler(this.Form2_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dog_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinic_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createStaff;
        private System.Windows.Forms.ComboBox eday;
        private System.Windows.Forms.ComboBox eMin;
        private System.Windows.Forms.ComboBox eHour;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox sday;
        private System.Windows.Forms.ComboBox sMin;
        private System.Windows.Forms.ComboBox sHour;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dog_grid;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dog_breed;
        private System.Windows.Forms.TextBox dog_name;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView clinic_grid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox clinic_text;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox dog_id;
        private System.Windows.Forms.Label label13;
    }
}