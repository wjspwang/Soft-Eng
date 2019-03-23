namespace WindowsFormsApplication1
{
    partial class dogMedSched
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
            this.button2 = new System.Windows.Forms.Button();
            this.to_date = new System.Windows.Forms.DateTimePicker();
            this.from_date = new System.Windows.Forms.DateTimePicker();
            this.startDateLbl = new System.Windows.Forms.Label();
            this.endDateLbl = new System.Windows.Forms.Label();
            this.inputField = new System.Windows.Forms.TextBox();
            this.InputLbl = new System.Windows.Forms.Label();
            this.SearchByBox = new System.Windows.Forms.ComboBox();
            this.SearchByLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ShowAllBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.status_text = new System.Windows.Forms.ComboBox();
            this.vacc_Text = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.clinic_text = new System.Windows.Forms.TextBox();
            this.clinic = new System.Windows.Forms.Label();
            this.date_text = new System.Windows.Forms.DateTimePicker();
            this.date_lbl = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.eDay = new System.Windows.Forms.ComboBox();
            this.eMin = new System.Windows.Forms.ComboBox();
            this.eHour = new System.Windows.Forms.ComboBox();
            this.sDay = new System.Windows.Forms.ComboBox();
            this.sMin = new System.Windows.Forms.ComboBox();
            this.sHour = new System.Windows.Forms.ComboBox();
            this.end_timelbl = new System.Windows.Forms.Label();
            this.start_timelbl = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.button13 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clinic_grid = new System.Windows.Forms.DataGridView();
            this.button15 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clinic_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(933, 774);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(205, 45);
            this.button2.TabIndex = 68;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // to_date
            // 
            this.to_date.CustomFormat = "yyyy/MM/dd";
            this.to_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.to_date.Location = new System.Drawing.Point(933, 533);
            this.to_date.Name = "to_date";
            this.to_date.Size = new System.Drawing.Size(205, 30);
            this.to_date.TabIndex = 67;
            this.to_date.Value = new System.DateTime(2018, 7, 18, 0, 0, 0, 0);
            this.to_date.Visible = false;
            this.to_date.ValueChanged += new System.EventHandler(this.to_date_ValueChanged);
            // 
            // from_date
            // 
            this.from_date.CustomFormat = "yyyy/MM/dd";
            this.from_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.from_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.from_date.Location = new System.Drawing.Point(933, 471);
            this.from_date.Name = "from_date";
            this.from_date.Size = new System.Drawing.Size(205, 30);
            this.from_date.TabIndex = 66;
            this.from_date.Value = new System.DateTime(2018, 7, 18, 0, 0, 0, 0);
            this.from_date.Visible = false;
            this.from_date.ValueChanged += new System.EventHandler(this.from_date_ValueChanged);
            // 
            // startDateLbl
            // 
            this.startDateLbl.AutoSize = true;
            this.startDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.startDateLbl.Location = new System.Drawing.Point(928, 442);
            this.startDateLbl.Name = "startDateLbl";
            this.startDateLbl.Size = new System.Drawing.Size(63, 26);
            this.startDateLbl.TabIndex = 65;
            this.startDateLbl.Text = "From";
            this.startDateLbl.Visible = false;
            // 
            // endDateLbl
            // 
            this.endDateLbl.AutoSize = true;
            this.endDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDateLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.endDateLbl.Location = new System.Drawing.Point(928, 504);
            this.endDateLbl.Name = "endDateLbl";
            this.endDateLbl.Size = new System.Drawing.Size(36, 26);
            this.endDateLbl.TabIndex = 64;
            this.endDateLbl.Text = "To";
            this.endDateLbl.Visible = false;
            // 
            // inputField
            // 
            this.inputField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputField.Location = new System.Drawing.Point(933, 439);
            this.inputField.Name = "inputField";
            this.inputField.Size = new System.Drawing.Size(205, 26);
            this.inputField.TabIndex = 63;
            this.inputField.Visible = false;
            this.inputField.TextChanged += new System.EventHandler(this.inputField_TextChanged);
            this.inputField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputField_KeyPress);
            // 
            // InputLbl
            // 
            this.InputLbl.AutoSize = true;
            this.InputLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.InputLbl.Location = new System.Drawing.Point(928, 410);
            this.InputLbl.Name = "InputLbl";
            this.InputLbl.Size = new System.Drawing.Size(71, 26);
            this.InputLbl.TabIndex = 62;
            this.InputLbl.Text = "Name";
            this.InputLbl.Visible = false;
            // 
            // SearchByBox
            // 
            this.SearchByBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchByBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchByBox.FormattingEnabled = true;
            this.SearchByBox.Items.AddRange(new object[] {
            "Dog Name",
            "Breed",
            "Date",
            "Status"});
            this.SearchByBox.Location = new System.Drawing.Point(933, 379);
            this.SearchByBox.Name = "SearchByBox";
            this.SearchByBox.Size = new System.Drawing.Size(205, 28);
            this.SearchByBox.TabIndex = 61;
            this.SearchByBox.Visible = false;
            this.SearchByBox.SelectedIndexChanged += new System.EventHandler(this.SearchByBox_SelectedIndexChanged);
            // 
            // SearchByLabel
            // 
            this.SearchByLabel.AutoSize = true;
            this.SearchByLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchByLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SearchByLabel.Location = new System.Drawing.Point(928, 347);
            this.SearchByLabel.Name = "SearchByLabel";
            this.SearchByLabel.Size = new System.Drawing.Size(127, 29);
            this.SearchByLabel.TabIndex = 60;
            this.SearchByLabel.Text = "Search by";
            this.SearchByLabel.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(933, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 45);
            this.button1.TabIndex = 59;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShowAllBtn
            // 
            this.ShowAllBtn.Location = new System.Drawing.Point(933, 85);
            this.ShowAllBtn.Name = "ShowAllBtn";
            this.ShowAllBtn.Size = new System.Drawing.Size(205, 45);
            this.ShowAllBtn.TabIndex = 58;
            this.ShowAllBtn.Text = "Show All";
            this.ShowAllBtn.UseVisualStyleBackColor = true;
            this.ShowAllBtn.Click += new System.EventHandler(this.ShowAllBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(422, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 48);
            this.label1.TabIndex = 57;
            this.label1.Text = "Clinic Schedule";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(49, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(861, 405);
            this.dataGridView1.TabIndex = 55;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(933, 136);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(205, 45);
            this.button3.TabIndex = 69;
            this.button3.Text = "Show Today";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(933, 187);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(205, 45);
            this.button4.TabIndex = 70;
            this.button4.Text = "Show Past Sched";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(933, 238);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(205, 45);
            this.button5.TabIndex = 71;
            this.button5.Text = "Show Incoming Sched";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(631, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 26);
            this.label2.TabIndex = 73;
            this.label2.Text = "Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(23, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 26);
            this.label4.TabIndex = 78;
            this.label4.Text = "Dog Name";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Controls.Add(this.status_text);
            this.groupBox1.Controls.Add(this.vacc_Text);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button14);
            this.groupBox1.Controls.Add(this.clinic_text);
            this.groupBox1.Controls.Add(this.clinic);
            this.groupBox1.Controls.Add(this.date_text);
            this.groupBox1.Controls.Add(this.date_lbl);
            this.groupBox1.Controls.Add(this.button12);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.eDay);
            this.groupBox1.Controls.Add(this.eMin);
            this.groupBox1.Controls.Add(this.eHour);
            this.groupBox1.Controls.Add(this.sDay);
            this.groupBox1.Controls.Add(this.sMin);
            this.groupBox1.Controls.Add(this.sHour);
            this.groupBox1.Controls.Add(this.end_timelbl);
            this.groupBox1.Controls.Add(this.start_timelbl);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(49, 497);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(861, 328);
            this.groupBox1.TabIndex = 80;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // status_text
            // 
            this.status_text.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.status_text.FormattingEnabled = true;
            this.status_text.Location = new System.Drawing.Point(636, 59);
            this.status_text.Name = "status_text";
            this.status_text.Size = new System.Drawing.Size(131, 24);
            this.status_text.TabIndex = 102;
            // 
            // vacc_Text
            // 
            this.vacc_Text.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.vacc_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vacc_Text.Location = new System.Drawing.Point(28, 221);
            this.vacc_Text.Name = "vacc_Text";
            this.vacc_Text.Size = new System.Drawing.Size(326, 30);
            this.vacc_Text.TabIndex = 101;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(23, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 26);
            this.label3.TabIndex = 100;
            this.label3.Text = "Medication";
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(291, 144);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(63, 30);
            this.button14.TabIndex = 99;
            this.button14.Text = "EDIT";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // clinic_text
            // 
            this.clinic_text.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.clinic_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clinic_text.Location = new System.Drawing.Point(28, 144);
            this.clinic_text.Name = "clinic_text";
            this.clinic_text.Size = new System.Drawing.Size(257, 30);
            this.clinic_text.TabIndex = 98;
            // 
            // clinic
            // 
            this.clinic.AutoSize = true;
            this.clinic.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clinic.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clinic.Location = new System.Drawing.Point(28, 104);
            this.clinic.Name = "clinic";
            this.clinic.Size = new System.Drawing.Size(131, 26);
            this.clinic.TabIndex = 97;
            this.clinic.Text = "Clinic Name";
            // 
            // date_text
            // 
            this.date_text.CustomFormat = "yyyy-MM-dd";
            this.date_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_text.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_text.Location = new System.Drawing.Point(636, 144);
            this.date_text.Name = "date_text";
            this.date_text.Size = new System.Drawing.Size(131, 27);
            this.date_text.TabIndex = 96;
            // 
            // date_lbl
            // 
            this.date_lbl.AutoSize = true;
            this.date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_lbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.date_lbl.Location = new System.Drawing.Point(631, 104);
            this.date_lbl.Name = "date_lbl";
            this.date_lbl.Size = new System.Drawing.Size(58, 26);
            this.date_lbl.TabIndex = 95;
            this.date_lbl.Text = "Date";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(291, 60);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(63, 30);
            this.button12.TabIndex = 94;
            this.button12.Text = "EDIT";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(28, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(257, 30);
            this.textBox1.TabIndex = 93;
            // 
            // eDay
            // 
            this.eDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eDay.FormattingEnabled = true;
            this.eDay.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.eDay.Location = new System.Drawing.Point(539, 144);
            this.eDay.Name = "eDay";
            this.eDay.Size = new System.Drawing.Size(60, 24);
            this.eDay.TabIndex = 90;
            // 
            // eMin
            // 
            this.eMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.eMin.Location = new System.Drawing.Point(453, 144);
            this.eMin.Name = "eMin";
            this.eMin.Size = new System.Drawing.Size(57, 24);
            this.eMin.TabIndex = 89;
            // 
            // eHour
            // 
            this.eHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.eHour.Location = new System.Drawing.Point(381, 144);
            this.eHour.Name = "eHour";
            this.eHour.Size = new System.Drawing.Size(47, 24);
            this.eHour.TabIndex = 88;
            // 
            // sDay
            // 
            this.sDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sDay.FormattingEnabled = true;
            this.sDay.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.sDay.Location = new System.Drawing.Point(539, 59);
            this.sDay.Name = "sDay";
            this.sDay.Size = new System.Drawing.Size(60, 24);
            this.sDay.TabIndex = 87;
            // 
            // sMin
            // 
            this.sMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.sMin.Location = new System.Drawing.Point(453, 59);
            this.sMin.Name = "sMin";
            this.sMin.Size = new System.Drawing.Size(57, 24);
            this.sMin.TabIndex = 86;
            // 
            // sHour
            // 
            this.sHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.sHour.Location = new System.Drawing.Point(381, 59);
            this.sHour.Name = "sHour";
            this.sHour.Size = new System.Drawing.Size(47, 24);
            this.sHour.TabIndex = 85;
            // 
            // end_timelbl
            // 
            this.end_timelbl.AutoSize = true;
            this.end_timelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.end_timelbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.end_timelbl.Location = new System.Drawing.Point(376, 104);
            this.end_timelbl.Name = "end_timelbl";
            this.end_timelbl.Size = new System.Drawing.Size(105, 26);
            this.end_timelbl.TabIndex = 84;
            this.end_timelbl.Text = "End Time";
            // 
            // start_timelbl
            // 
            this.start_timelbl.AutoSize = true;
            this.start_timelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_timelbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.start_timelbl.Location = new System.Drawing.Point(376, 20);
            this.start_timelbl.Name = "start_timelbl";
            this.start_timelbl.Size = new System.Drawing.Size(112, 26);
            this.start_timelbl.TabIndex = 83;
            this.start_timelbl.Text = "Start Time";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(344, 271);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(201, 51);
            this.button10.TabIndex = 81;
            this.button10.Text = "Delete";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(120, 271);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(201, 51);
            this.button8.TabIndex = 80;
            this.button8.Text = "Update";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(933, 714);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(205, 45);
            this.button9.TabIndex = 81;
            this.button9.Text = "Print";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(6, 21);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(385, 298);
            this.dataGridView3.TabIndex = 1;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(157, 325);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 0;
            this.button13.Text = "DONE";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView3);
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Location = new System.Drawing.Point(12, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 359);
            this.groupBox2.TabIndex = 97;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.clinic_grid);
            this.groupBox3.Controls.Add(this.button15);
            this.groupBox3.Location = new System.Drawing.Point(6, 276);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(397, 359);
            this.groupBox3.TabIndex = 98;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // clinic_grid
            // 
            this.clinic_grid.AllowUserToAddRows = false;
            this.clinic_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clinic_grid.Location = new System.Drawing.Point(6, 21);
            this.clinic_grid.Name = "clinic_grid";
            this.clinic_grid.ReadOnly = true;
            this.clinic_grid.RowTemplate.Height = 24;
            this.clinic_grid.Size = new System.Drawing.Size(385, 298);
            this.clinic_grid.TabIndex = 1;
            this.clinic_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clinic_grid_CellContentClick);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(157, 325);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 23);
            this.button15.TabIndex = 0;
            this.button15.Text = "DONE";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // dogMedSched
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1150, 837);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.to_date);
            this.Controls.Add(this.from_date);
            this.Controls.Add(this.startDateLbl);
            this.Controls.Add(this.endDateLbl);
            this.Controls.Add(this.inputField);
            this.Controls.Add(this.InputLbl);
            this.Controls.Add(this.SearchByBox);
            this.Controls.Add(this.SearchByLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ShowAllBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "dogMedSched";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clinic Schedule";
            this.Load += new System.EventHandler(this.dogMedSched_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clinic_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker to_date;
        private System.Windows.Forms.DateTimePicker from_date;
        private System.Windows.Forms.Label startDateLbl;
        private System.Windows.Forms.Label endDateLbl;
        private System.Windows.Forms.TextBox inputField;
        private System.Windows.Forms.Label InputLbl;
        private System.Windows.Forms.ComboBox SearchByBox;
        private System.Windows.Forms.Label SearchByLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ShowAllBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ComboBox eDay;
        private System.Windows.Forms.ComboBox eMin;
        private System.Windows.Forms.ComboBox eHour;
        private System.Windows.Forms.ComboBox sDay;
        private System.Windows.Forms.ComboBox sMin;
        private System.Windows.Forms.ComboBox sHour;
        private System.Windows.Forms.Label end_timelbl;
        private System.Windows.Forms.Label start_timelbl;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker date_text;
        private System.Windows.Forms.Label date_lbl;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.TextBox clinic_text;
        private System.Windows.Forms.Label clinic;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView clinic_grid;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.TextBox vacc_Text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox status_text;
    }
}