﻿namespace WindowsFormsApplication1
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
            this.addClinic = new System.Windows.Forms.Button();
            this.clinic_grid = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.clinic_text = new System.Windows.Forms.TextBox();
            this.dog_id = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.vacc_Text = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.Medication_box = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dog_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinic_grid)).BeginInit();
            this.Medication_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // createStaff
            // 
            this.createStaff.Location = new System.Drawing.Point(32, 55);
            this.createStaff.Name = "createStaff";
            this.createStaff.Size = new System.Drawing.Size(94, 30);
            this.createStaff.TabIndex = 95;
            this.createStaff.Text = "Create";
            this.createStaff.UseVisualStyleBackColor = true;
            this.createStaff.Click += new System.EventHandler(this.createStaff_Click);
            // 
            // eday
            // 
            this.eday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eday.FormattingEnabled = true;
            this.eday.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.eday.Location = new System.Drawing.Point(731, 529);
            this.eday.Name = "eday";
            this.eday.Size = new System.Drawing.Size(61, 24);
            this.eday.TabIndex = 94;
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
            this.eMin.Location = new System.Drawing.Point(637, 529);
            this.eMin.Name = "eMin";
            this.eMin.Size = new System.Drawing.Size(62, 24);
            this.eMin.TabIndex = 93;
            // 
            // eHour
            // 
            this.eHour.FormattingEnabled = true;
            this.eHour.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.eHour.Location = new System.Drawing.Point(547, 529);
            this.eHour.Name = "eHour";
            this.eHour.Size = new System.Drawing.Size(58, 24);
            this.eHour.TabIndex = 92;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(706, 529);
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
            this.label10.Location = new System.Drawing.Point(706, 478);
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
            this.label9.Location = new System.Drawing.Point(612, 529);
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
            this.label8.Location = new System.Drawing.Point(612, 478);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 24);
            this.label8.TabIndex = 88;
            this.label8.Text = ":";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sday
            // 
            this.sday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sday.FormattingEnabled = true;
            this.sday.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.sday.Location = new System.Drawing.Point(731, 478);
            this.sday.Name = "sday";
            this.sday.Size = new System.Drawing.Size(61, 24);
            this.sday.TabIndex = 87;
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
            this.sMin.Location = new System.Drawing.Point(637, 478);
            this.sMin.Name = "sMin";
            this.sMin.Size = new System.Drawing.Size(62, 24);
            this.sMin.TabIndex = 86;
            // 
            // sHour
            // 
            this.sHour.FormattingEnabled = true;
            this.sHour.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.sHour.Location = new System.Drawing.Point(546, 478);
            this.sHour.Name = "sHour";
            this.sHour.Size = new System.Drawing.Size(59, 24);
            this.sHour.TabIndex = 85;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(381, 529);
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
            this.label2.Location = new System.Drawing.Point(380, 470);
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
            this.date.Location = new System.Drawing.Point(548, 421);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(262, 34);
            this.date.TabIndex = 82;
            this.date.Value = new System.DateTime(2018, 7, 18, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(379, 425);
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
            this.dog_grid.Location = new System.Drawing.Point(32, 102);
            this.dog_grid.Margin = new System.Windows.Forms.Padding(4);
            this.dog_grid.Name = "dog_grid";
            this.dog_grid.Size = new System.Drawing.Size(320, 593);
            this.dog_grid.TabIndex = 78;
            this.dog_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.staff_grid_CellContentClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1422, 66);
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
            this.label5.Location = new System.Drawing.Point(416, 20);
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
            this.dog_breed.Location = new System.Drawing.Point(547, 253);
            this.dog_breed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dog_breed.Name = "dog_breed";
            this.dog_breed.Size = new System.Drawing.Size(261, 33);
            this.dog_breed.TabIndex = 75;
            // 
            // dog_name
            // 
            this.dog_name.BackColor = System.Drawing.SystemColors.Window;
            this.dog_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dog_name.Enabled = false;
            this.dog_name.Font = new System.Drawing.Font("Verdana", 15.8F);
            this.dog_name.ForeColor = System.Drawing.Color.Black;
            this.dog_name.Location = new System.Drawing.Point(546, 198);
            this.dog_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dog_name.Name = "dog_name";
            this.dog_name.Size = new System.Drawing.Size(262, 33);
            this.dog_name.TabIndex = 74;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // addClinic
            // 
            this.addClinic.Location = new System.Drawing.Point(1292, 67);
            this.addClinic.Name = "addClinic";
            this.addClinic.Size = new System.Drawing.Size(111, 28);
            this.addClinic.TabIndex = 80;
            this.addClinic.Text = "Create";
            this.addClinic.UseVisualStyleBackColor = true;
            this.addClinic.Click += new System.EventHandler(this.button4_Click);
            // 
            // clinic_grid
            // 
            this.clinic_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clinic_grid.Location = new System.Drawing.Point(866, 102);
            this.clinic_grid.Margin = new System.Windows.Forms.Padding(4);
            this.clinic_grid.Name = "clinic_grid";
            this.clinic_grid.ReadOnly = true;
            this.clinic_grid.Size = new System.Drawing.Size(674, 593);
            this.clinic_grid.TabIndex = 73;
            this.clinic_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clinic_grid_CellContentClick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(615, 642);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(193, 42);
            this.button2.TabIndex = 72;
            this.button2.Text = "Medical Schedule";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(383, 642);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 42);
            this.button1.TabIndex = 71;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(8, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 35);
            this.label4.TabIndex = 70;
            this.label4.Text = "Clinic";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(379, 256);
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
            this.label1.Location = new System.Drawing.Point(379, 201);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 32);
            this.label1.TabIndex = 68;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Taken",
            "To Be Taken"});
            this.comboBox1.Location = new System.Drawing.Point(546, 581);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(263, 37);
            this.comboBox1.TabIndex = 97;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(380, 581);
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
            this.clinic_text.Location = new System.Drawing.Point(174, 20);
            this.clinic_text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clinic_text.Name = "clinic_text";
            this.clinic_text.Size = new System.Drawing.Size(195, 33);
            this.clinic_text.TabIndex = 98;
            this.clinic_text.TextChanged += new System.EventHandler(this.clinic_text_TextChanged);
            // 
            // dog_id
            // 
            this.dog_id.BackColor = System.Drawing.SystemColors.Window;
            this.dog_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dog_id.Font = new System.Drawing.Font("Verdana", 15.8F);
            this.dog_id.ForeColor = System.Drawing.Color.Black;
            this.dog_id.Location = new System.Drawing.Point(1168, 20);
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
            this.label13.Location = new System.Drawing.Point(1001, 23);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(165, 32);
            this.label13.TabIndex = 101;
            this.label13.Text = "No.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Visible = false;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label14.Location = new System.Drawing.Point(8, 70);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(135, 37);
            this.label14.TabIndex = 104;
            this.label14.Text = "Medication";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vacc_Text
            // 
            this.vacc_Text.BackColor = System.Drawing.SystemColors.Window;
            this.vacc_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vacc_Text.Font = new System.Drawing.Font("Verdana", 15.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vacc_Text.ForeColor = System.Drawing.Color.Black;
            this.vacc_Text.Location = new System.Drawing.Point(173, 69);
            this.vacc_Text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vacc_Text.Name = "vacc_Text";
            this.vacc_Text.Size = new System.Drawing.Size(264, 33);
            this.vacc_Text.TabIndex = 105;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(375, 20);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(62, 30);
            this.button7.TabIndex = 106;
            this.button7.Text = "...";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Medication_box
            // 
            this.Medication_box.Controls.Add(this.label4);
            this.Medication_box.Controls.Add(this.button7);
            this.Medication_box.Controls.Add(this.clinic_text);
            this.Medication_box.Controls.Add(this.vacc_Text);
            this.Medication_box.Controls.Add(this.label14);
            this.Medication_box.Location = new System.Drawing.Point(371, 291);
            this.Medication_box.Name = "Medication_box";
            this.Medication_box.Size = new System.Drawing.Size(456, 124);
            this.Medication_box.TabIndex = 107;
            this.Medication_box.TabStop = false;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(866, 58);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(266, 37);
            this.button5.TabIndex = 108;
            this.button5.Text = "Dog Scheduling";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(861, 20);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(148, 32);
            this.label15.TabIndex = 109;
            this.label15.Text = "Switch To:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1553, 758);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.Medication_box);
            this.Controls.Add(this.label13);
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
            this.Controls.Add(this.addClinic);
            this.Controls.Add(this.clinic_grid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dog_id);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dog Management";
            this.Activated += new System.EventHandler(this.Form2_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dog_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinic_grid)).EndInit();
            this.Medication_box.ResumeLayout(false);
            this.Medication_box.PerformLayout();
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
        private System.Windows.Forms.Button addClinic;
        private System.Windows.Forms.DataGridView clinic_grid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox clinic_text;
        private System.Windows.Forms.TextBox dog_id;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox vacc_Text;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox Medication_box;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label15;
    }
}