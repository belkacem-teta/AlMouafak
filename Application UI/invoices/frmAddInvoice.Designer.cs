namespace Application_UI.invoices
{
    partial class frmAddInvoice
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStudent = new System.Windows.Forms.TabPage();
            this.ctrlFilteredStudentCard1 = new Application_UI.controls.ctrlFilteredStudentCard();
            this.tabManagement = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblOtherPayments = new System.Windows.Forms.Label();
            this.btnAddOtherPayment = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRegistration = new System.Windows.Forms.CheckBox();
            this.grpTransportation = new System.Windows.Forms.GroupBox();
            this.checkBox21 = new System.Windows.Forms.CheckBox();
            this.checkBox22 = new System.Windows.Forms.CheckBox();
            this.checkBox23 = new System.Windows.Forms.CheckBox();
            this.checkBox24 = new System.Windows.Forms.CheckBox();
            this.checkBox25 = new System.Windows.Forms.CheckBox();
            this.checkBox26 = new System.Windows.Forms.CheckBox();
            this.checkBox27 = new System.Windows.Forms.CheckBox();
            this.checkBox28 = new System.Windows.Forms.CheckBox();
            this.checkBox29 = new System.Windows.Forms.CheckBox();
            this.checkBox30 = new System.Windows.Forms.CheckBox();
            this.grpFeeding = new System.Windows.Forms.GroupBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.checkBox20 = new System.Windows.Forms.CheckBox();
            this.grpTuition = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.chkTuition9 = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.إضافةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.tuitionPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.feedingPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.tranportPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.otherPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePaymentTooltip = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabStudent.SuspendLayout();
            this.tabManagement.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpTransportation.SuspendLayout();
            this.grpFeeding.SuspendLayout();
            this.grpTuition.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStudent);
            this.tabControl1.Controls.Add(this.tabManagement);
            this.tabControl1.Location = new System.Drawing.Point(16, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(747, 502);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabStudent
            // 
            this.tabStudent.Controls.Add(this.ctrlFilteredStudentCard1);
            this.tabStudent.Location = new System.Drawing.Point(4, 25);
            this.tabStudent.Margin = new System.Windows.Forms.Padding(4);
            this.tabStudent.Name = "tabStudent";
            this.tabStudent.Padding = new System.Windows.Forms.Padding(4);
            this.tabStudent.Size = new System.Drawing.Size(739, 473);
            this.tabStudent.TabIndex = 0;
            this.tabStudent.Text = "معلومات التلميذ";
            this.tabStudent.UseVisualStyleBackColor = true;
            // 
            // ctrlFilteredStudentCard1
            // 
            this.ctrlFilteredStudentCard1.Location = new System.Drawing.Point(37, 4);
            this.ctrlFilteredStudentCard1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlFilteredStudentCard1.Name = "ctrlFilteredStudentCard1";
            this.ctrlFilteredStudentCard1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlFilteredStudentCard1.Size = new System.Drawing.Size(667, 462);
            this.ctrlFilteredStudentCard1.student = null;
            this.ctrlFilteredStudentCard1.TabIndex = 0;
            // 
            // tabManagement
            // 
            this.tabManagement.Controls.Add(this.groupBox4);
            this.tabManagement.Controls.Add(this.groupBox3);
            this.tabManagement.Controls.Add(this.groupBox1);
            this.tabManagement.Controls.Add(this.grpTransportation);
            this.tabManagement.Controls.Add(this.grpFeeding);
            this.tabManagement.Controls.Add(this.grpTuition);
            this.tabManagement.Location = new System.Drawing.Point(4, 25);
            this.tabManagement.Name = "tabManagement";
            this.tabManagement.Size = new System.Drawing.Size(739, 473);
            this.tabManagement.TabIndex = 2;
            this.tabManagement.Text = "تحديد المستحقات";
            this.tabManagement.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNotes);
            this.groupBox4.Location = new System.Drawing.Point(3, 397);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(733, 73);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ملاحظات";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(6, 20);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(721, 47);
            this.txtNotes.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblOtherPayments);
            this.groupBox3.Controls.Add(this.btnAddOtherPayment);
            this.groupBox3.Location = new System.Drawing.Point(161, 288);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(575, 103);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "حقوق أخرى";
            // 
            // lblOtherPayments
            // 
            this.lblOtherPayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOtherPayments.Location = new System.Drawing.Point(6, 18);
            this.lblOtherPayments.Name = "lblOtherPayments";
            this.lblOtherPayments.Size = new System.Drawing.Size(456, 75);
            this.lblOtherPayments.TabIndex = 1;
            // 
            // btnAddOtherPayment
            // 
            this.btnAddOtherPayment.Location = new System.Drawing.Point(478, 35);
            this.btnAddOtherPayment.Name = "btnAddOtherPayment";
            this.btnAddOtherPayment.Size = new System.Drawing.Size(75, 39);
            this.btnAddOtherPayment.TabIndex = 0;
            this.btnAddOtherPayment.Text = "إضافة";
            this.btnAddOtherPayment.UseVisualStyleBackColor = true;
            this.btnAddOtherPayment.Click += new System.EventHandler(this.btnAddOtherPayment_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRegistration);
            this.groupBox1.Location = new System.Drawing.Point(3, 288);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 103);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "حقوق التسجيل";
            // 
            // chkRegistration
            // 
            this.chkRegistration.BackColor = System.Drawing.Color.Transparent;
            this.chkRegistration.Location = new System.Drawing.Point(18, 25);
            this.chkRegistration.Name = "chkRegistration";
            this.chkRegistration.Size = new System.Drawing.Size(115, 68);
            this.chkRegistration.TabIndex = 7;
            this.chkRegistration.Text = "غير مدفوعة";
            this.chkRegistration.UseVisualStyleBackColor = false;
            // 
            // grpTransportation
            // 
            this.grpTransportation.Controls.Add(this.checkBox21);
            this.grpTransportation.Controls.Add(this.checkBox22);
            this.grpTransportation.Controls.Add(this.checkBox23);
            this.grpTransportation.Controls.Add(this.checkBox24);
            this.grpTransportation.Controls.Add(this.checkBox25);
            this.grpTransportation.Controls.Add(this.checkBox26);
            this.grpTransportation.Controls.Add(this.checkBox27);
            this.grpTransportation.Controls.Add(this.checkBox28);
            this.grpTransportation.Controls.Add(this.checkBox29);
            this.grpTransportation.Controls.Add(this.checkBox30);
            this.grpTransportation.Location = new System.Drawing.Point(3, 193);
            this.grpTransportation.Name = "grpTransportation";
            this.grpTransportation.Size = new System.Drawing.Size(733, 89);
            this.grpTransportation.TabIndex = 11;
            this.grpTransportation.TabStop = false;
            this.grpTransportation.Text = "حقوق النقل";
            // 
            // checkBox21
            // 
            this.checkBox21.BackColor = System.Drawing.Color.Transparent;
            this.checkBox21.Location = new System.Drawing.Point(228, 30);
            this.checkBox21.Name = "checkBox21";
            this.checkBox21.Size = new System.Drawing.Size(63, 33);
            this.checkBox21.TabIndex = 9;
            this.checkBox21.Tag = "3";
            this.checkBox21.Text = "مارس";
            this.checkBox21.UseVisualStyleBackColor = false;
            // 
            // checkBox22
            // 
            this.checkBox22.BackColor = System.Drawing.Color.Transparent;
            this.checkBox22.Location = new System.Drawing.Point(158, 30);
            this.checkBox22.Name = "checkBox22";
            this.checkBox22.Size = new System.Drawing.Size(63, 33);
            this.checkBox22.TabIndex = 8;
            this.checkBox22.Tag = "4";
            this.checkBox22.Text = "أفريل";
            this.checkBox22.UseVisualStyleBackColor = false;
            // 
            // checkBox23
            // 
            this.checkBox23.BackColor = System.Drawing.Color.Transparent;
            this.checkBox23.Location = new System.Drawing.Point(88, 30);
            this.checkBox23.Name = "checkBox23";
            this.checkBox23.Size = new System.Drawing.Size(63, 33);
            this.checkBox23.TabIndex = 7;
            this.checkBox23.Tag = "5";
            this.checkBox23.Text = "ماي";
            this.checkBox23.UseVisualStyleBackColor = false;
            // 
            // checkBox24
            // 
            this.checkBox24.BackColor = System.Drawing.Color.Transparent;
            this.checkBox24.Location = new System.Drawing.Point(18, 30);
            this.checkBox24.Name = "checkBox24";
            this.checkBox24.Size = new System.Drawing.Size(63, 33);
            this.checkBox24.TabIndex = 6;
            this.checkBox24.Tag = "6";
            this.checkBox24.Text = "جوان";
            this.checkBox24.UseVisualStyleBackColor = false;
            // 
            // checkBox25
            // 
            this.checkBox25.BackColor = System.Drawing.Color.Transparent;
            this.checkBox25.Location = new System.Drawing.Point(298, 30);
            this.checkBox25.Name = "checkBox25";
            this.checkBox25.Size = new System.Drawing.Size(63, 33);
            this.checkBox25.TabIndex = 5;
            this.checkBox25.Tag = "2";
            this.checkBox25.Text = "فيفري";
            this.checkBox25.UseVisualStyleBackColor = false;
            // 
            // checkBox26
            // 
            this.checkBox26.BackColor = System.Drawing.Color.Transparent;
            this.checkBox26.Location = new System.Drawing.Point(578, 30);
            this.checkBox26.Name = "checkBox26";
            this.checkBox26.Size = new System.Drawing.Size(63, 33);
            this.checkBox26.TabIndex = 4;
            this.checkBox26.Tag = "10";
            this.checkBox26.Text = "أكتوبر";
            this.checkBox26.UseVisualStyleBackColor = false;
            // 
            // checkBox27
            // 
            this.checkBox27.BackColor = System.Drawing.Color.Transparent;
            this.checkBox27.Location = new System.Drawing.Point(508, 30);
            this.checkBox27.Name = "checkBox27";
            this.checkBox27.Size = new System.Drawing.Size(63, 33);
            this.checkBox27.TabIndex = 3;
            this.checkBox27.Tag = "11";
            this.checkBox27.Text = "نوفمبر";
            this.checkBox27.UseVisualStyleBackColor = false;
            // 
            // checkBox28
            // 
            this.checkBox28.BackColor = System.Drawing.Color.Transparent;
            this.checkBox28.Location = new System.Drawing.Point(438, 30);
            this.checkBox28.Name = "checkBox28";
            this.checkBox28.Size = new System.Drawing.Size(63, 33);
            this.checkBox28.TabIndex = 2;
            this.checkBox28.Tag = "12";
            this.checkBox28.Text = "ديسمبر";
            this.checkBox28.UseVisualStyleBackColor = false;
            // 
            // checkBox29
            // 
            this.checkBox29.BackColor = System.Drawing.Color.Transparent;
            this.checkBox29.Location = new System.Drawing.Point(368, 30);
            this.checkBox29.Name = "checkBox29";
            this.checkBox29.Size = new System.Drawing.Size(63, 33);
            this.checkBox29.TabIndex = 1;
            this.checkBox29.Tag = "1";
            this.checkBox29.Text = "جانفي";
            this.checkBox29.UseVisualStyleBackColor = false;
            // 
            // checkBox30
            // 
            this.checkBox30.BackColor = System.Drawing.Color.Transparent;
            this.checkBox30.Location = new System.Drawing.Point(648, 30);
            this.checkBox30.Name = "checkBox30";
            this.checkBox30.Size = new System.Drawing.Size(63, 33);
            this.checkBox30.TabIndex = 0;
            this.checkBox30.Tag = "9";
            this.checkBox30.Text = "سبتمبر";
            this.checkBox30.UseVisualStyleBackColor = false;
            // 
            // grpFeeding
            // 
            this.grpFeeding.Controls.Add(this.checkBox11);
            this.grpFeeding.Controls.Add(this.checkBox12);
            this.grpFeeding.Controls.Add(this.checkBox13);
            this.grpFeeding.Controls.Add(this.checkBox14);
            this.grpFeeding.Controls.Add(this.checkBox15);
            this.grpFeeding.Controls.Add(this.checkBox16);
            this.grpFeeding.Controls.Add(this.checkBox17);
            this.grpFeeding.Controls.Add(this.checkBox18);
            this.grpFeeding.Controls.Add(this.checkBox19);
            this.grpFeeding.Controls.Add(this.checkBox20);
            this.grpFeeding.Location = new System.Drawing.Point(3, 98);
            this.grpFeeding.Name = "grpFeeding";
            this.grpFeeding.Size = new System.Drawing.Size(733, 89);
            this.grpFeeding.TabIndex = 10;
            this.grpFeeding.TabStop = false;
            this.grpFeeding.Text = "حقوق الإطعام";
            // 
            // checkBox11
            // 
            this.checkBox11.BackColor = System.Drawing.Color.Transparent;
            this.checkBox11.Location = new System.Drawing.Point(228, 30);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(63, 33);
            this.checkBox11.TabIndex = 9;
            this.checkBox11.Tag = "3";
            this.checkBox11.Text = "مارس";
            this.checkBox11.UseVisualStyleBackColor = false;
            // 
            // checkBox12
            // 
            this.checkBox12.BackColor = System.Drawing.Color.Transparent;
            this.checkBox12.Location = new System.Drawing.Point(158, 30);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(63, 33);
            this.checkBox12.TabIndex = 8;
            this.checkBox12.Tag = "4";
            this.checkBox12.Text = "أفريل";
            this.checkBox12.UseVisualStyleBackColor = false;
            // 
            // checkBox13
            // 
            this.checkBox13.BackColor = System.Drawing.Color.Transparent;
            this.checkBox13.Location = new System.Drawing.Point(88, 30);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(63, 33);
            this.checkBox13.TabIndex = 7;
            this.checkBox13.Tag = "5";
            this.checkBox13.Text = "ماي";
            this.checkBox13.UseVisualStyleBackColor = false;
            // 
            // checkBox14
            // 
            this.checkBox14.BackColor = System.Drawing.Color.Transparent;
            this.checkBox14.Location = new System.Drawing.Point(18, 30);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(63, 33);
            this.checkBox14.TabIndex = 6;
            this.checkBox14.Tag = "6";
            this.checkBox14.Text = "جوان";
            this.checkBox14.UseVisualStyleBackColor = false;
            // 
            // checkBox15
            // 
            this.checkBox15.BackColor = System.Drawing.Color.Transparent;
            this.checkBox15.Location = new System.Drawing.Point(298, 30);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(63, 33);
            this.checkBox15.TabIndex = 5;
            this.checkBox15.Tag = "2";
            this.checkBox15.Text = "فيفري";
            this.checkBox15.UseVisualStyleBackColor = false;
            // 
            // checkBox16
            // 
            this.checkBox16.BackColor = System.Drawing.Color.Transparent;
            this.checkBox16.Location = new System.Drawing.Point(578, 30);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(63, 33);
            this.checkBox16.TabIndex = 4;
            this.checkBox16.Tag = "10";
            this.checkBox16.Text = "أكتوبر";
            this.checkBox16.UseVisualStyleBackColor = false;
            // 
            // checkBox17
            // 
            this.checkBox17.BackColor = System.Drawing.Color.Transparent;
            this.checkBox17.Location = new System.Drawing.Point(508, 30);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(63, 33);
            this.checkBox17.TabIndex = 3;
            this.checkBox17.Tag = "11";
            this.checkBox17.Text = "نوفمبر";
            this.checkBox17.UseVisualStyleBackColor = false;
            // 
            // checkBox18
            // 
            this.checkBox18.BackColor = System.Drawing.Color.Transparent;
            this.checkBox18.Location = new System.Drawing.Point(438, 30);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(63, 33);
            this.checkBox18.TabIndex = 2;
            this.checkBox18.Tag = "12";
            this.checkBox18.Text = "ديسمبر";
            this.checkBox18.UseVisualStyleBackColor = false;
            // 
            // checkBox19
            // 
            this.checkBox19.BackColor = System.Drawing.Color.Transparent;
            this.checkBox19.Location = new System.Drawing.Point(368, 30);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(63, 33);
            this.checkBox19.TabIndex = 1;
            this.checkBox19.Tag = "1";
            this.checkBox19.Text = "جانفي";
            this.checkBox19.UseVisualStyleBackColor = false;
            // 
            // checkBox20
            // 
            this.checkBox20.BackColor = System.Drawing.Color.Transparent;
            this.checkBox20.Location = new System.Drawing.Point(648, 30);
            this.checkBox20.Name = "checkBox20";
            this.checkBox20.Size = new System.Drawing.Size(63, 33);
            this.checkBox20.TabIndex = 0;
            this.checkBox20.Tag = "9";
            this.checkBox20.Text = "سبتمبر";
            this.checkBox20.UseVisualStyleBackColor = false;
            // 
            // grpTuition
            // 
            this.grpTuition.Controls.Add(this.checkBox6);
            this.grpTuition.Controls.Add(this.checkBox7);
            this.grpTuition.Controls.Add(this.checkBox8);
            this.grpTuition.Controls.Add(this.checkBox9);
            this.grpTuition.Controls.Add(this.checkBox10);
            this.grpTuition.Controls.Add(this.checkBox5);
            this.grpTuition.Controls.Add(this.checkBox4);
            this.grpTuition.Controls.Add(this.checkBox3);
            this.grpTuition.Controls.Add(this.checkBox2);
            this.grpTuition.Controls.Add(this.chkTuition9);
            this.grpTuition.Location = new System.Drawing.Point(3, 3);
            this.grpTuition.Name = "grpTuition";
            this.grpTuition.Size = new System.Drawing.Size(733, 89);
            this.grpTuition.TabIndex = 0;
            this.grpTuition.TabStop = false;
            this.grpTuition.Text = "حقوق التمدرس";
            // 
            // checkBox6
            // 
            this.checkBox6.BackColor = System.Drawing.Color.Transparent;
            this.checkBox6.Location = new System.Drawing.Point(228, 30);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(63, 33);
            this.checkBox6.TabIndex = 9;
            this.checkBox6.Tag = "3";
            this.checkBox6.Text = "مارس";
            this.checkBox6.UseVisualStyleBackColor = false;
            // 
            // checkBox7
            // 
            this.checkBox7.BackColor = System.Drawing.Color.Transparent;
            this.checkBox7.Location = new System.Drawing.Point(158, 30);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(63, 33);
            this.checkBox7.TabIndex = 8;
            this.checkBox7.Tag = "4";
            this.checkBox7.Text = "أفريل";
            this.checkBox7.UseVisualStyleBackColor = false;
            // 
            // checkBox8
            // 
            this.checkBox8.BackColor = System.Drawing.Color.Transparent;
            this.checkBox8.Location = new System.Drawing.Point(88, 30);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(63, 33);
            this.checkBox8.TabIndex = 7;
            this.checkBox8.Tag = "5";
            this.checkBox8.Text = "ماي";
            this.checkBox8.UseVisualStyleBackColor = false;
            // 
            // checkBox9
            // 
            this.checkBox9.BackColor = System.Drawing.Color.Transparent;
            this.checkBox9.Location = new System.Drawing.Point(18, 30);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(63, 33);
            this.checkBox9.TabIndex = 6;
            this.checkBox9.Tag = "6";
            this.checkBox9.Text = "جوان";
            this.checkBox9.UseVisualStyleBackColor = false;
            // 
            // checkBox10
            // 
            this.checkBox10.BackColor = System.Drawing.Color.Transparent;
            this.checkBox10.Location = new System.Drawing.Point(298, 30);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(63, 33);
            this.checkBox10.TabIndex = 5;
            this.checkBox10.Tag = "2";
            this.checkBox10.Text = "فيفري";
            this.checkBox10.UseVisualStyleBackColor = false;
            // 
            // checkBox5
            // 
            this.checkBox5.BackColor = System.Drawing.Color.Transparent;
            this.checkBox5.Location = new System.Drawing.Point(578, 30);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(63, 33);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Tag = "10";
            this.checkBox5.Text = "أكتوبر";
            this.checkBox5.UseVisualStyleBackColor = false;
            // 
            // checkBox4
            // 
            this.checkBox4.BackColor = System.Drawing.Color.Transparent;
            this.checkBox4.Location = new System.Drawing.Point(508, 30);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(63, 33);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Tag = "11";
            this.checkBox4.Text = "نوفمبر";
            this.checkBox4.UseVisualStyleBackColor = false;
            // 
            // checkBox3
            // 
            this.checkBox3.BackColor = System.Drawing.Color.Transparent;
            this.checkBox3.Location = new System.Drawing.Point(438, 30);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(63, 33);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Tag = "12";
            this.checkBox3.Text = "ديسمبر";
            this.checkBox3.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.Location = new System.Drawing.Point(368, 30);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(63, 33);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Tag = "1";
            this.checkBox2.Text = "جانفي";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // chkTuition9
            // 
            this.chkTuition9.BackColor = System.Drawing.Color.Transparent;
            this.chkTuition9.Location = new System.Drawing.Point(648, 30);
            this.chkTuition9.Name = "chkTuition9";
            this.chkTuition9.Size = new System.Drawing.Size(63, 33);
            this.chkTuition9.TabIndex = 0;
            this.chkTuition9.Tag = "9";
            this.chkTuition9.Text = "سبتمبر";
            this.chkTuition9.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.إضافةToolStripMenuItem,
            this.deletePaymentTooltip});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 52);
            // 
            // إضافةToolStripMenuItem
            // 
            this.إضافةToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regPayment,
            this.tuitionPayment,
            this.feedingPayment,
            this.tranportPayment,
            this.otherPayment});
            this.إضافةToolStripMenuItem.Name = "إضافةToolStripMenuItem";
            this.إضافةToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.إضافةToolStripMenuItem.Text = "إضافة";
            // 
            // regPayment
            // 
            this.regPayment.Name = "regPayment";
            this.regPayment.Size = new System.Drawing.Size(186, 26);
            this.regPayment.Text = "حقوق التسجيل";
            // 
            // tuitionPayment
            // 
            this.tuitionPayment.Name = "tuitionPayment";
            this.tuitionPayment.Size = new System.Drawing.Size(186, 26);
            this.tuitionPayment.Text = "حقوق التمدرس";
            // 
            // feedingPayment
            // 
            this.feedingPayment.Name = "feedingPayment";
            this.feedingPayment.Size = new System.Drawing.Size(186, 26);
            this.feedingPayment.Text = "حقوق الإطعام";
            // 
            // tranportPayment
            // 
            this.tranportPayment.Name = "tranportPayment";
            this.tranportPayment.Size = new System.Drawing.Size(186, 26);
            this.tranportPayment.Text = "حقوق النقل";
            // 
            // otherPayment
            // 
            this.otherPayment.Name = "otherPayment";
            this.otherPayment.Size = new System.Drawing.Size(186, 26);
            this.otherPayment.Text = "حقوق أخرى";
            // 
            // deletePaymentTooltip
            // 
            this.deletePaymentTooltip.Name = "deletePaymentTooltip";
            this.deletePaymentTooltip.Size = new System.Drawing.Size(117, 24);
            this.deletePaymentTooltip.Text = "حذف";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(663, 524);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(555, 524);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "إلغاء";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 567);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddInvoice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إنشاء بيان مستحقات";
            this.tabControl1.ResumeLayout(false);
            this.tabStudent.ResumeLayout(false);
            this.tabManagement.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grpTransportation.ResumeLayout(false);
            this.grpFeeding.ResumeLayout(false);
            this.grpTuition.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStudent;
        private controls.ctrlFilteredStudentCard ctrlFilteredStudentCard1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem إضافةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regPayment;
        private System.Windows.Forms.ToolStripMenuItem tuitionPayment;
        private System.Windows.Forms.ToolStripMenuItem feedingPayment;
        private System.Windows.Forms.ToolStripMenuItem tranportPayment;
        private System.Windows.Forms.ToolStripMenuItem otherPayment;
        private System.Windows.Forms.ToolStripMenuItem deletePaymentTooltip;
        private System.Windows.Forms.TabPage tabManagement;
        private System.Windows.Forms.GroupBox grpTuition;
        private System.Windows.Forms.CheckBox chkTuition9;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.GroupBox grpTransportation;
        private System.Windows.Forms.CheckBox checkBox21;
        private System.Windows.Forms.CheckBox checkBox22;
        private System.Windows.Forms.CheckBox checkBox23;
        private System.Windows.Forms.CheckBox checkBox24;
        private System.Windows.Forms.CheckBox checkBox25;
        private System.Windows.Forms.CheckBox checkBox26;
        private System.Windows.Forms.CheckBox checkBox27;
        private System.Windows.Forms.CheckBox checkBox28;
        private System.Windows.Forms.CheckBox checkBox29;
        private System.Windows.Forms.CheckBox checkBox30;
        private System.Windows.Forms.GroupBox grpFeeding;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.CheckBox checkBox17;
        private System.Windows.Forms.CheckBox checkBox18;
        private System.Windows.Forms.CheckBox checkBox19;
        private System.Windows.Forms.CheckBox checkBox20;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkRegistration;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnAddOtherPayment;
        private System.Windows.Forms.Label lblOtherPayments;
    }
}