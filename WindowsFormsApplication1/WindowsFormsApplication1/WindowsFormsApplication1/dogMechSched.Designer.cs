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
            this.ClearBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(933, 637);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 45);
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
            this.to_date.Location = new System.Drawing.Point(938, 422);
            this.to_date.Name = "to_date";
            this.to_date.Size = new System.Drawing.Size(166, 30);
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
            this.from_date.Location = new System.Drawing.Point(938, 360);
            this.from_date.Name = "from_date";
            this.from_date.Size = new System.Drawing.Size(166, 30);
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
            this.startDateLbl.Location = new System.Drawing.Point(933, 331);
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
            this.endDateLbl.Location = new System.Drawing.Point(933, 393);
            this.endDateLbl.Name = "endDateLbl";
            this.endDateLbl.Size = new System.Drawing.Size(36, 26);
            this.endDateLbl.TabIndex = 64;
            this.endDateLbl.Text = "To";
            this.endDateLbl.Visible = false;
            // 
            // inputField
            // 
            this.inputField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputField.Location = new System.Drawing.Point(938, 328);
            this.inputField.Name = "inputField";
            this.inputField.Size = new System.Drawing.Size(159, 26);
            this.inputField.TabIndex = 63;
            this.inputField.Visible = false;
            this.inputField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputField_KeyPress);
            // 
            // InputLbl
            // 
            this.InputLbl.AutoSize = true;
            this.InputLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.InputLbl.Location = new System.Drawing.Point(933, 299);
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
            "Date"});
            this.SearchByBox.Location = new System.Drawing.Point(938, 268);
            this.SearchByBox.Name = "SearchByBox";
            this.SearchByBox.Size = new System.Drawing.Size(181, 28);
            this.SearchByBox.TabIndex = 61;
            this.SearchByBox.Visible = false;
            // 
            // SearchByLabel
            // 
            this.SearchByLabel.AutoSize = true;
            this.SearchByLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchByLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SearchByLabel.Location = new System.Drawing.Point(933, 236);
            this.SearchByLabel.Name = "SearchByLabel";
            this.SearchByLabel.Size = new System.Drawing.Size(127, 29);
            this.SearchByLabel.TabIndex = 60;
            this.SearchByLabel.Text = "Search by";
            this.SearchByLabel.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(933, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 45);
            this.button1.TabIndex = 59;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShowAllBtn
            // 
            this.ShowAllBtn.Location = new System.Drawing.Point(933, 137);
            this.ShowAllBtn.Name = "ShowAllBtn";
            this.ShowAllBtn.Size = new System.Drawing.Size(114, 45);
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
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(933, 86);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(114, 45);
            this.ClearBtn.TabIndex = 56;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
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
            this.dataGridView1.Size = new System.Drawing.Size(861, 596);
            this.dataGridView1.TabIndex = 55;
            // 
            // dogMedSched
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1150, 698);
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
            this.Name = "dogMedSched";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.dogMedSched_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}