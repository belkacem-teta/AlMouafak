namespace Application_UI.students
{
    partial class frmAddEditStudent
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
            this.txtRegNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.rdIsMale = new System.Windows.Forms.RadioButton();
            this.rdIsFemale = new System.Windows.Forms.RadioButton();
            this.dtEntryDate = new System.Windows.Forms.DateTimePicker();
            this.dtBrithDate = new System.Windows.Forms.DateTimePicker();
            this.cbGrade = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkIsFed = new System.Windows.Forms.CheckBox();
            this.chkIsTransported = new System.Windows.Forms.CheckBox();
            this.numTuitionCoupon = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.numGroup = new System.Windows.Forms.NumericUpDown();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numTuitionCoupon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "رقم التسجيل: ";
            // 
            // txtRegNumber
            // 
            this.txtRegNumber.Location = new System.Drawing.Point(87, 71);
            this.txtRegNumber.Name = "txtRegNumber";
            this.txtRegNumber.Size = new System.Drawing.Size(196, 20);
            this.txtRegNumber.TabIndex = 1;
            this.txtRegNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegNumber_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "اللقب:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "الإسم:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "نسبة الخصم من حقوق التمدرس %";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(318, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "المستوى:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(318, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "تاريخ التسجيل: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(318, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "تاريخ الميلاد: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "الجنس: ";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(87, 106);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(196, 20);
            this.txtFirstName.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(87, 141);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(196, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // rdIsMale
            // 
            this.rdIsMale.AutoSize = true;
            this.rdIsMale.Location = new System.Drawing.Point(87, 177);
            this.rdIsMale.Name = "rdIsMale";
            this.rdIsMale.Size = new System.Drawing.Size(42, 17);
            this.rdIsMale.TabIndex = 4;
            this.rdIsMale.TabStop = true;
            this.rdIsMale.Text = "ذكر";
            this.rdIsMale.UseVisualStyleBackColor = true;
            // 
            // rdIsFemale
            // 
            this.rdIsFemale.AutoSize = true;
            this.rdIsFemale.Location = new System.Drawing.Point(135, 177);
            this.rdIsFemale.Name = "rdIsFemale";
            this.rdIsFemale.Size = new System.Drawing.Size(48, 17);
            this.rdIsFemale.TabIndex = 5;
            this.rdIsFemale.TabStop = true;
            this.rdIsFemale.Text = "أنثى";
            this.rdIsFemale.UseVisualStyleBackColor = true;
            // 
            // dtEntryDate
            // 
            this.dtEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEntryDate.Location = new System.Drawing.Point(402, 71);
            this.dtEntryDate.Name = "dtEntryDate";
            this.dtEntryDate.RightToLeftLayout = true;
            this.dtEntryDate.Size = new System.Drawing.Size(170, 20);
            this.dtEntryDate.TabIndex = 6;
            // 
            // dtBrithDate
            // 
            this.dtBrithDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBrithDate.Location = new System.Drawing.Point(402, 106);
            this.dtBrithDate.Name = "dtBrithDate";
            this.dtBrithDate.RightToLeftLayout = true;
            this.dtBrithDate.Size = new System.Drawing.Size(170, 20);
            this.dtBrithDate.TabIndex = 7;
            // 
            // cbGrade
            // 
            this.cbGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrade.FormattingEnabled = true;
            this.cbGrade.Location = new System.Drawing.Point(402, 141);
            this.cbGrade.Name = "cbGrade";
            this.cbGrade.Size = new System.Drawing.Size(170, 21);
            this.cbGrade.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(318, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "المجموعة:";
            // 
            // chkIsFed
            // 
            this.chkIsFed.AutoSize = true;
            this.chkIsFed.Location = new System.Drawing.Point(15, 263);
            this.chkIsFed.Name = "chkIsFed";
            this.chkIsFed.Size = new System.Drawing.Size(145, 17);
            this.chkIsFed.TabIndex = 11;
            this.chkIsFed.Text = "الإستفادة من خدمة الإطعام.";
            this.chkIsFed.UseVisualStyleBackColor = true;
            // 
            // chkIsTransported
            // 
            this.chkIsTransported.AutoSize = true;
            this.chkIsTransported.Location = new System.Drawing.Point(15, 286);
            this.chkIsTransported.Name = "chkIsTransported";
            this.chkIsTransported.Size = new System.Drawing.Size(136, 17);
            this.chkIsTransported.TabIndex = 12;
            this.chkIsTransported.Text = "الإستفادة من خدمة النقل.";
            this.chkIsTransported.UseVisualStyleBackColor = true;
            // 
            // numTuitionCoupon
            // 
            this.numTuitionCoupon.Location = new System.Drawing.Point(169, 232);
            this.numTuitionCoupon.Name = "numTuitionCoupon";
            this.numTuitionCoupon.Size = new System.Drawing.Size(120, 20);
            this.numTuitionCoupon.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(497, 326);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(416, 326);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "تراجع";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Teal;
            this.lblTitle.Location = new System.Drawing.Point(12, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(560, 31);
            this.lblTitle.TabIndex = 26;
            this.lblTitle.Text = "إضافة تلميذ جديد";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numGroup
            // 
            this.numGroup.Location = new System.Drawing.Point(402, 174);
            this.numGroup.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGroup.Name = "numGroup";
            this.numGroup.Size = new System.Drawing.Size(170, 20);
            this.numGroup.TabIndex = 9;
            this.numGroup.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditStudent
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.numGroup);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numTuitionCoupon);
            this.Controls.Add(this.chkIsTransported);
            this.Controls.Add(this.chkIsFed);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbGrade);
            this.Controls.Add(this.dtBrithDate);
            this.Controls.Add(this.dtEntryDate);
            this.Controls.Add(this.rdIsFemale);
            this.Controls.Add(this.rdIsMale);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRegNumber);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditStudent";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدارة التلميذ";
            this.Load += new System.EventHandler(this.frmAddEditStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTuitionCoupon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRegNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.RadioButton rdIsMale;
        private System.Windows.Forms.RadioButton rdIsFemale;
        private System.Windows.Forms.DateTimePicker dtEntryDate;
        private System.Windows.Forms.DateTimePicker dtBrithDate;
        private System.Windows.Forms.ComboBox cbGrade;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkIsFed;
        private System.Windows.Forms.CheckBox chkIsTransported;
        private System.Windows.Forms.NumericUpDown numTuitionCoupon;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.NumericUpDown numGroup;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}