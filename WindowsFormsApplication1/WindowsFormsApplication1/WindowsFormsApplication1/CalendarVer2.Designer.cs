namespace WindowsFormsApplication1
{
    partial class CalendarVer2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Today = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowAllBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SearchByLabel = new System.Windows.Forms.Label();
            this.SearchByBox = new System.Windows.Forms.ComboBox();
            this.InputLbl = new System.Windows.Forms.Label();
            this.inputField = new System.Windows.Forms.TextBox();
            this.endDateLbl = new System.Windows.Forms.Label();
            this.startDateLbl = new System.Windows.Forms.Label();
            this.from_date = new System.Windows.Forms.DateTimePicker();
            this.to_date = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.date_lbl = new System.Windows.Forms.Label();
            this.start_timelbl = new System.Windows.Forms.Label();
            this.end_timelbl = new System.Windows.Forms.Label();
            this.status_lbl = new System.Windows.Forms.Label();
            this.date_text = new System.Windows.Forms.DateTimePicker();
            this.sHour = new System.Windows.Forms.ComboBox();
            this.sMin = new System.Windows.Forms.ComboBox();
            this.sDay = new System.Windows.Forms.ComboBox();
            this.eHour = new System.Windows.Forms.ComboBox();
            this.eMin = new System.Windows.Forms.ComboBox();
            this.eDay = new System.Windows.Forms.ComboBox();
            this.status = new System.Windows.Forms.TextBox();
            this.edit_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button9 = new System.Windows.Forms.Button();
            this.Lname_lbl = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(891, 370);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Today
            // 
            this.Today.Location = new System.Drawing.Point(927, 93);
            this.Today.Name = "Today";
            this.Today.Size = new System.Drawing.Size(186, 45);
            this.Today.TabIndex = 1;
            this.Today.Text = "Show Today";
            this.Today.UseVisualStyleBackColor = true;
            this.Today.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(346, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "Staff Schedule";
            // 
            // ShowAllBtn
            // 
            this.ShowAllBtn.Location = new System.Drawing.Point(927, 144);
            this.ShowAllBtn.Name = "ShowAllBtn";
            this.ShowAllBtn.Size = new System.Drawing.Size(186, 45);
            this.ShowAllBtn.TabIndex = 3;
            this.ShowAllBtn.Text = "Show All";
            this.ShowAllBtn.UseVisualStyleBackColor = true;
            this.ShowAllBtn.Click += new System.EventHandler(this.ShowAllBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(927, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SearchByLabel
            // 
            this.SearchByLabel.AutoSize = true;
            this.SearchByLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchByLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SearchByLabel.Location = new System.Drawing.Point(927, 345);
            this.SearchByLabel.Name = "SearchByLabel";
            this.SearchByLabel.Size = new System.Drawing.Size(127, 29);
            this.SearchByLabel.TabIndex = 5;
            this.SearchByLabel.Text = "Search by";
            this.SearchByLabel.Visible = false;
            // 
            // SearchByBox
            // 
            this.SearchByBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchByBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchByBox.FormattingEnabled = true;
            this.SearchByBox.Items.AddRange(new object[] {
            "Name",
            "Last Name",
            "First Name",
            "Date",
            "Shift"});
            this.SearchByBox.Location = new System.Drawing.Point(932, 377);
            this.SearchByBox.Name = "SearchByBox";
            this.SearchByBox.Size = new System.Drawing.Size(181, 28);
            this.SearchByBox.TabIndex = 6;
            this.SearchByBox.Visible = false;
            this.SearchByBox.SelectedIndexChanged += new System.EventHandler(this.SearchByBox_SelectedIndexChanged);
            // 
            // InputLbl
            // 
            this.InputLbl.AutoSize = true;
            this.InputLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.InputLbl.Location = new System.Drawing.Point(927, 408);
            this.InputLbl.Name = "InputLbl";
            this.InputLbl.Size = new System.Drawing.Size(71, 26);
            this.InputLbl.TabIndex = 7;
            this.InputLbl.Text = "Name";
            this.InputLbl.Visible = false;
            // 
            // inputField
            // 
            this.inputField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputField.Location = new System.Drawing.Point(932, 437);
            this.inputField.Name = "inputField";
            this.inputField.Size = new System.Drawing.Size(181, 26);
            this.inputField.TabIndex = 8;
            this.inputField.Visible = false;
            this.inputField.TextChanged += new System.EventHandler(this.inputField_TextChanged);
            this.inputField.KeyUp += new System.Windows.Forms.KeyEventHandler(this.inputField_KeyUp_1);
            // 
            // endDateLbl
            // 
            this.endDateLbl.AutoSize = true;
            this.endDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDateLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.endDateLbl.Location = new System.Drawing.Point(927, 502);
            this.endDateLbl.Name = "endDateLbl";
            this.endDateLbl.Size = new System.Drawing.Size(36, 26);
            this.endDateLbl.TabIndex = 9;
            this.endDateLbl.Text = "To";
            this.endDateLbl.Visible = false;
            // 
            // startDateLbl
            // 
            this.startDateLbl.AutoSize = true;
            this.startDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.startDateLbl.Location = new System.Drawing.Point(927, 440);
            this.startDateLbl.Name = "startDateLbl";
            this.startDateLbl.Size = new System.Drawing.Size(63, 26);
            this.startDateLbl.TabIndex = 11;
            this.startDateLbl.Text = "From";
            this.startDateLbl.Visible = false;
            this.startDateLbl.Click += new System.EventHandler(this.label2_Click);
            // 
            // from_date
            // 
            this.from_date.CustomFormat = "yyyy/MM/dd";
            this.from_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.from_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.from_date.Location = new System.Drawing.Point(932, 469);
            this.from_date.Name = "from_date";
            this.from_date.Size = new System.Drawing.Size(181, 30);
            this.from_date.TabIndex = 52;
            this.from_date.Value = new System.DateTime(2018, 7, 18, 0, 0, 0, 0);
            this.from_date.Visible = false;
            this.from_date.ValueChanged += new System.EventHandler(this.from_date_ValueChanged);
            // 
            // to_date
            // 
            this.to_date.CustomFormat = "yyyy/MM/dd";
            this.to_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.to_date.Location = new System.Drawing.Point(932, 531);
            this.to_date.Name = "to_date";
            this.to_date.Size = new System.Drawing.Size(181, 30);
            this.to_date.TabIndex = 53;
            this.to_date.Value = new System.DateTime(2018, 7, 18, 0, 0, 0, 0);
            this.to_date.Visible = false;
            this.to_date.ValueChanged += new System.EventHandler(this.to_date_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(927, 693);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(186, 45);
            this.button2.TabIndex = 54;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(927, 195);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(186, 45);
            this.button3.TabIndex = 55;
            this.button3.Text = "Show Past Sched";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(927, 246);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(186, 45);
            this.button4.TabIndex = 56;
            this.button4.Text = "Show Incoming Sched";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(927, 629);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(186, 45);
            this.button5.TabIndex = 57;
            this.button5.Text = "Print";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(268, 693);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(146, 45);
            this.button6.TabIndex = 58;
            this.button6.Text = "UPDATE";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(452, 693);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(146, 45);
            this.button7.TabIndex = 59;
            this.button7.Text = "DELETE";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // date_lbl
            // 
            this.date_lbl.AutoSize = true;
            this.date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_lbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.date_lbl.Location = new System.Drawing.Point(12, 565);
            this.date_lbl.Name = "date_lbl";
            this.date_lbl.Size = new System.Drawing.Size(58, 26);
            this.date_lbl.TabIndex = 60;
            this.date_lbl.Text = "Date";
            // 
            // start_timelbl
            // 
            this.start_timelbl.AutoSize = true;
            this.start_timelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_timelbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.start_timelbl.Location = new System.Drawing.Point(447, 478);
            this.start_timelbl.Name = "start_timelbl";
            this.start_timelbl.Size = new System.Drawing.Size(112, 26);
            this.start_timelbl.TabIndex = 61;
            this.start_timelbl.Text = "Start Time";
            // 
            // end_timelbl
            // 
            this.end_timelbl.AutoSize = true;
            this.end_timelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.end_timelbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.end_timelbl.Location = new System.Drawing.Point(447, 565);
            this.end_timelbl.Name = "end_timelbl";
            this.end_timelbl.Size = new System.Drawing.Size(105, 26);
            this.end_timelbl.TabIndex = 62;
            this.end_timelbl.Text = "End Time";
            // 
            // status_lbl
            // 
            this.status_lbl.AutoSize = true;
            this.status_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status_lbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.status_lbl.Location = new System.Drawing.Point(711, 473);
            this.status_lbl.Name = "status_lbl";
            this.status_lbl.Size = new System.Drawing.Size(56, 26);
            this.status_lbl.TabIndex = 63;
            this.status_lbl.Text = "Shift";
            // 
            // date_text
            // 
            this.date_text.CustomFormat = "yyyy-MM-dd";
            this.date_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_text.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_text.Location = new System.Drawing.Point(17, 604);
            this.date_text.Name = "date_text";
            this.date_text.Size = new System.Drawing.Size(135, 27);
            this.date_text.TabIndex = 64;
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
            this.sHour.Location = new System.Drawing.Point(452, 517);
            this.sHour.Name = "sHour";
            this.sHour.Size = new System.Drawing.Size(47, 24);
            this.sHour.TabIndex = 65;
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
            this.sMin.Location = new System.Drawing.Point(524, 517);
            this.sMin.Name = "sMin";
            this.sMin.Size = new System.Drawing.Size(57, 24);
            this.sMin.TabIndex = 66;
            // 
            // sDay
            // 
            this.sDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sDay.FormattingEnabled = true;
            this.sDay.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.sDay.Location = new System.Drawing.Point(610, 517);
            this.sDay.Name = "sDay";
            this.sDay.Size = new System.Drawing.Size(60, 24);
            this.sDay.TabIndex = 67;
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
            this.eHour.Location = new System.Drawing.Point(450, 604);
            this.eHour.Name = "eHour";
            this.eHour.Size = new System.Drawing.Size(47, 24);
            this.eHour.TabIndex = 68;
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
            this.eMin.Location = new System.Drawing.Point(522, 604);
            this.eMin.Name = "eMin";
            this.eMin.Size = new System.Drawing.Size(57, 24);
            this.eMin.TabIndex = 69;
            // 
            // eDay
            // 
            this.eDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eDay.FormattingEnabled = true;
            this.eDay.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.eDay.Location = new System.Drawing.Point(608, 604);
            this.eDay.Name = "eDay";
            this.eDay.Size = new System.Drawing.Size(61, 24);
            this.eDay.TabIndex = 70;
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Location = new System.Drawing.Point(716, 509);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(118, 30);
            this.status.TabIndex = 71;
            // 
            // edit_btn
            // 
            this.edit_btn.Location = new System.Drawing.Point(840, 509);
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.Size = new System.Drawing.Size(63, 30);
            this.edit_btn.TabIndex = 72;
            this.edit_btn.Text = "EDIT";
            this.edit_btn.UseVisualStyleBackColor = true;
            this.edit_btn.Click += new System.EventHandler(this.button8_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Location = new System.Drawing.Point(716, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 359);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 21);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(188, 298);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(70, 325);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 0;
            this.button9.Text = "DONE";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Lname_lbl
            // 
            this.Lname_lbl.AutoSize = true;
            this.Lname_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lname_lbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Lname_lbl.Location = new System.Drawing.Point(12, 478);
            this.Lname_lbl.Name = "Lname_lbl";
            this.Lname_lbl.Size = new System.Drawing.Size(57, 26);
            this.Lname_lbl.TabIndex = 74;
            this.Lname_lbl.Text = "Staff";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(351, 511);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(63, 30);
            this.button10.TabIndex = 76;
            this.button10.Text = "EDIT";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(17, 511);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(328, 30);
            this.textBox1.TabIndex = 75;
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
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(157, 325);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 0;
            this.button11.Text = "DONE";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView3);
            this.groupBox2.Controls.Add(this.button11);
            this.groupBox2.Location = new System.Drawing.Point(17, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 359);
            this.groupBox2.TabIndex = 77;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Scheduled",
            "IN",
            "OUT"});
            this.comboBox1.Location = new System.Drawing.Point(716, 594);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 33);
            this.comboBox1.TabIndex = 78;
            this.comboBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(711, 565);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 26);
            this.label2.TabIndex = 79;
            this.label2.Text = "Status";
            this.label2.Visible = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(639, 693);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(146, 45);
            this.button8.TabIndex = 80;
            this.button8.Text = "LOG OUT";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // CalendarVer2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1135, 750);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Lname_lbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.edit_btn);
            this.Controls.Add(this.status);
            this.Controls.Add(this.eDay);
            this.Controls.Add(this.eMin);
            this.Controls.Add(this.eHour);
            this.Controls.Add(this.sDay);
            this.Controls.Add(this.sMin);
            this.Controls.Add(this.sHour);
            this.Controls.Add(this.date_text);
            this.Controls.Add(this.status_lbl);
            this.Controls.Add(this.end_timelbl);
            this.Controls.Add(this.start_timelbl);
            this.Controls.Add(this.date_lbl);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
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
            this.Controls.Add(this.Today);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CalendarVer2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff Schedule";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Shown += new System.EventHandler(this.CalendarVer2_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Today;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ShowAllBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label SearchByLabel;
        private System.Windows.Forms.ComboBox SearchByBox;
        private System.Windows.Forms.Label InputLbl;
        private System.Windows.Forms.TextBox inputField;
        private System.Windows.Forms.Label endDateLbl;
        private System.Windows.Forms.Label startDateLbl;
        private System.Windows.Forms.DateTimePicker from_date;
        private System.Windows.Forms.DateTimePicker to_date;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label date_lbl;
        private System.Windows.Forms.Label start_timelbl;
        private System.Windows.Forms.Label end_timelbl;
        private System.Windows.Forms.Label status_lbl;
        private System.Windows.Forms.DateTimePicker date_text;
        private System.Windows.Forms.ComboBox sHour;
        private System.Windows.Forms.ComboBox sMin;
        private System.Windows.Forms.ComboBox sDay;
        private System.Windows.Forms.ComboBox eHour;
        private System.Windows.Forms.ComboBox eMin;
        private System.Windows.Forms.ComboBox eDay;
        private System.Windows.Forms.TextBox status;
        private System.Windows.Forms.Button edit_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label Lname_lbl;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button8;
    }
}