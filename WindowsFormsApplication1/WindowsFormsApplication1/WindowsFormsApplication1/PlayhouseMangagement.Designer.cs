namespace WindowsFormsApplication1
{
    partial class PlayhouseManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.lblFN = new System.Windows.Forms.Label();
            this.lblLN = new System.Windows.Forms.Label();
            this.fname = new System.Windows.Forms.TextBox();
            this.lname = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.sHour = new System.Windows.Forms.ComboBox();
            this.sMin = new System.Windows.Forms.ComboBox();
            this.sDay = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.eHour = new System.Windows.Forms.ComboBox();
            this.eMin = new System.Windows.Forms.ComboBox();
            this.eDay = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.Extend = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cust_id = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = "-1";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.Location = new System.Drawing.Point(668, 63);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView2.Size = new System.Drawing.Size(799, 506);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_RowEnter);
            // 
            // lblFN
            // 
            this.lblFN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFN.ForeColor = System.Drawing.Color.Black;
            this.lblFN.Location = new System.Drawing.Point(7, 50);
            this.lblFN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFN.Name = "lblFN";
            this.lblFN.Size = new System.Drawing.Size(133, 32);
            this.lblFN.TabIndex = 22;
            this.lblFN.Text = "First Name:";
            this.lblFN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLN
            // 
            this.lblLN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLN.ForeColor = System.Drawing.Color.Black;
            this.lblLN.Location = new System.Drawing.Point(7, 92);
            this.lblLN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLN.Name = "lblLN";
            this.lblLN.Size = new System.Drawing.Size(133, 32);
            this.lblLN.TabIndex = 22;
            this.lblLN.Text = "Last Name:";
            this.lblLN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fname
            // 
            this.fname.AccessibleName = "fname";
            this.fname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fname.Location = new System.Drawing.Point(147, 47);
            this.fname.Name = "fname";
            this.fname.Size = new System.Drawing.Size(183, 36);
            this.fname.TabIndex = 1;
            // 
            // lname
            // 
            this.lname.AccessibleName = "fname";
            this.lname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lname.Location = new System.Drawing.Point(147, 89);
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(183, 36);
            this.lname.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(7, 133);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(64, 32);
            this.lblDate.TabIndex = 22;
            this.lblDate.Text = "Date:";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // date
            // 
            this.date.CustomFormat = "yyyy-MM-dd";
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(147, 133);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(183, 36);
            this.date.TabIndex = 3;
            // 
            // lblStart
            // 
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.ForeColor = System.Drawing.Color.Black;
            this.lblStart.Location = new System.Drawing.Point(54, 2);
            this.lblStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(70, 32);
            this.lblStart.TabIndex = 22;
            this.lblStart.Text = "Start:";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sHour
            // 
            this.sHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.sHour.Location = new System.Drawing.Point(59, 47);
            this.sHour.Name = "sHour";
            this.sHour.Size = new System.Drawing.Size(65, 37);
            this.sHour.TabIndex = 4;
            // 
            // sMin
            // 
            this.sMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.sMin.Location = new System.Drawing.Point(157, 47);
            this.sMin.Name = "sMin";
            this.sMin.Size = new System.Drawing.Size(65, 37);
            this.sMin.TabIndex = 5;
            // 
            // sDay
            // 
            this.sDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sDay.FormattingEnabled = true;
            this.sDay.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.sDay.Location = new System.Drawing.Point(271, 47);
            this.sDay.Name = "sDay";
            this.sDay.Size = new System.Drawing.Size(65, 37);
            this.sDay.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(132, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 32);
            this.label1.TabIndex = 22;
            this.label1.Text = ":";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(246, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 32);
            this.label2.TabIndex = 22;
            this.label2.Text = ":";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(54, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 32);
            this.label3.TabIndex = 22;
            this.label3.Text = "End:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(132, 124);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 32);
            this.label4.TabIndex = 22;
            this.label4.Text = ":";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(246, 124);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 32);
            this.label5.TabIndex = 22;
            this.label5.Text = ":";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Visible = false;
            // 
            // eHour
            // 
            this.eHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.eHour.Location = new System.Drawing.Point(59, 132);
            this.eHour.Name = "eHour";
            this.eHour.Size = new System.Drawing.Size(65, 37);
            this.eHour.TabIndex = 7;
            // 
            // eMin
            // 
            this.eMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.eMin.Location = new System.Drawing.Point(157, 132);
            this.eMin.Name = "eMin";
            this.eMin.Size = new System.Drawing.Size(65, 37);
            this.eMin.TabIndex = 8;
            // 
            // eDay
            // 
            this.eDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eDay.FormattingEnabled = true;
            this.eDay.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.eDay.Location = new System.Drawing.Point(271, 132);
            this.eDay.Name = "eDay";
            this.eDay.Size = new System.Drawing.Size(65, 37);
            this.eDay.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(28, 198);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 32);
            this.label6.TabIndex = 22;
            this.label6.Text = "Status:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(27, 21);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 39);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Extend
            // 
            this.Extend.Location = new System.Drawing.Point(231, 21);
            this.Extend.Name = "Extend";
            this.Extend.Size = new System.Drawing.Size(75, 39);
            this.Extend.TabIndex = 12;
            this.Extend.Text = "Extend";
            this.Extend.UseVisualStyleBackColor = true;
            this.Extend.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(338, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 39);
            this.button2.TabIndex = 13;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(450, 21);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 39);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(478, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(499, 47);
            this.lblTitle.TabIndex = 22;
            this.lblTitle.Text = "Playhouse Management Module";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cust_id
            // 
            this.cust_id.BackColor = System.Drawing.SystemColors.Window;
            this.cust_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cust_id.Font = new System.Drawing.Font("Verdana", 15.8F);
            this.cust_id.ForeColor = System.Drawing.Color.Black;
            this.cust_id.Location = new System.Drawing.Point(956, -13);
            this.cust_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cust_id.Name = "cust_id";
            this.cust_id.Size = new System.Drawing.Size(176, 33);
            this.cust_id.TabIndex = 103;
            this.cust_id.Visible = false;
            this.cust_id.TextChanged += new System.EventHandler(this.cust_id_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(127, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 39);
            this.button3.TabIndex = 106;
            this.button3.Text = "Login";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 39);
            this.button1.TabIndex = 107;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(22, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(163, 39);
            this.button4.TabIndex = 108;
            this.button4.Text = "Show All";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(22, 237);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(163, 39);
            this.button5.TabIndex = 109;
            this.button5.Text = "Show IN";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(22, 91);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(163, 39);
            this.button6.TabIndex = 110;
            this.button6.Text = "Show All Today";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(22, 142);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(163, 39);
            this.button7.TabIndex = 111;
            this.button7.Text = "Show Expired";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(22, 189);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(163, 39);
            this.button8.TabIndex = 112;
            this.button8.Text = "Show Expired Today";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // status
            // 
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.FormattingEnabled = true;
            this.status.Items.AddRange(new object[] {
            "IN",
            "Expired"});
            this.status.Location = new System.Drawing.Point(168, 198);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(183, 37);
            this.status.TabIndex = 113;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.status);
            this.groupBox1.Controls.Add(this.lblStart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.sHour);
            this.groupBox1.Controls.Add(this.eHour);
            this.groupBox1.Controls.Add(this.sMin);
            this.groupBox1.Controls.Add(this.eMin);
            this.groupBox1.Controls.Add(this.sDay);
            this.groupBox1.Controls.Add(this.eDay);
            this.groupBox1.Location = new System.Drawing.Point(12, 293);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 253);
            this.groupBox1.TabIndex = 114;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnBack);
            this.groupBox2.Controls.Add(this.Extend);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(12, 551);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(635, 76);
            this.groupBox2.TabIndex = 115;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Location = new System.Drawing.Point(462, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 301);
            this.groupBox3.TabIndex = 116;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblDate);
            this.groupBox4.Controls.Add(this.lblFN);
            this.groupBox4.Controls.Add(this.lblLN);
            this.groupBox4.Controls.Add(this.fname);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.lname);
            this.groupBox4.Controls.Add(this.date);
            this.groupBox4.Location = new System.Drawing.Point(12, 63);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(434, 224);
            this.groupBox4.TabIndex = 117;
            this.groupBox4.TabStop = false;
            // 
            // PlayhouseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1479, 639);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cust_id);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dataGridView2);
            this.Name = "PlayhouseManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlayhouseMangagement";
            this.Activated += new System.EventHandler(this.PlayhouseManagement_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlayhouseManagement_FormClosed);
            this.Load += new System.EventHandler(this.btnSave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lblFN;
        private System.Windows.Forms.Label lblLN;
        private System.Windows.Forms.TextBox fname;
        private System.Windows.Forms.TextBox lname;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.ComboBox sHour;
        private System.Windows.Forms.ComboBox sMin;
        private System.Windows.Forms.ComboBox sDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox eHour;
        private System.Windows.Forms.ComboBox eMin;
        private System.Windows.Forms.ComboBox eDay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button Extend;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox cust_id;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ComboBox status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}