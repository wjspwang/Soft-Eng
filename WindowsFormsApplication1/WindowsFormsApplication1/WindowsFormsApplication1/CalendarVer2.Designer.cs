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
            this.ClearBtn = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(719, 596);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(737, 93);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(114, 45);
            this.ClearBtn.TabIndex = 1;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
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
            this.ShowAllBtn.Location = new System.Drawing.Point(737, 144);
            this.ShowAllBtn.Name = "ShowAllBtn";
            this.ShowAllBtn.Size = new System.Drawing.Size(114, 45);
            this.ShowAllBtn.TabIndex = 3;
            this.ShowAllBtn.Text = "Show All";
            this.ShowAllBtn.UseVisualStyleBackColor = true;
            this.ShowAllBtn.Click += new System.EventHandler(this.ShowAllBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(737, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 45);
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
            this.SearchByLabel.Location = new System.Drawing.Point(737, 243);
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
            this.SearchByBox.Location = new System.Drawing.Point(742, 275);
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
            this.InputLbl.Location = new System.Drawing.Point(737, 306);
            this.InputLbl.Name = "InputLbl";
            this.InputLbl.Size = new System.Drawing.Size(71, 26);
            this.InputLbl.TabIndex = 7;
            this.InputLbl.Text = "Name";
            this.InputLbl.Visible = false;
            // 
            // inputField
            // 
            this.inputField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputField.Location = new System.Drawing.Point(742, 335);
            this.inputField.Name = "inputField";
            this.inputField.Size = new System.Drawing.Size(159, 26);
            this.inputField.TabIndex = 8;
            this.inputField.Visible = false;
            this.inputField.TextChanged += new System.EventHandler(this.inputField_TextChanged);
            this.inputField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputField_KeyDown);
            this.inputField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputField_KeyPress);
            this.inputField.KeyUp += new System.Windows.Forms.KeyEventHandler(this.inputField_KeyUp);
            // 
            // endDateLbl
            // 
            this.endDateLbl.AutoSize = true;
            this.endDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDateLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.endDateLbl.Location = new System.Drawing.Point(737, 400);
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
            this.startDateLbl.Location = new System.Drawing.Point(737, 338);
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
            this.from_date.Location = new System.Drawing.Point(742, 367);
            this.from_date.Name = "from_date";
            this.from_date.Size = new System.Drawing.Size(166, 30);
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
            this.to_date.Location = new System.Drawing.Point(742, 429);
            this.to_date.Name = "to_date";
            this.to_date.Size = new System.Drawing.Size(166, 30);
            this.to_date.TabIndex = 53;
            this.to_date.Value = new System.DateTime(2018, 7, 18, 0, 0, 0, 0);
            this.to_date.Visible = false;
            this.to_date.ValueChanged += new System.EventHandler(this.to_date_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(737, 644);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 45);
            this.button2.TabIndex = 54;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CalendarVer2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(969, 701);
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
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CalendarVer2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ClearBtn;
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
    }
}