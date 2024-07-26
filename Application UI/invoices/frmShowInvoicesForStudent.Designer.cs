namespace Application_UI.invoices
{
    partial class frmShowInvoicesForStudent
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
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStudent = new System.Windows.Forms.TabPage();
            this.tabInvoices = new System.Windows.Forms.TabPage();
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.ctrlFilteredStudentCard1 = new Application_UI.controls.ctrlFilteredStudentCard();
            this.tabControl1.SuspendLayout();
            this.tabStudent.SuspendLayout();
            this.tabInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(659, 526);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStudent);
            this.tabControl1.Controls.Add(this.tabInvoices);
            this.tabControl1.Location = new System.Drawing.Point(16, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(747, 502);
            this.tabControl1.TabIndex = 3;
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
            // tabInvoices
            // 
            this.tabInvoices.Controls.Add(this.dgvInvoices);
            this.tabInvoices.Location = new System.Drawing.Point(4, 25);
            this.tabInvoices.Name = "tabInvoices";
            this.tabInvoices.Size = new System.Drawing.Size(739, 473);
            this.tabInvoices.TabIndex = 2;
            this.tabInvoices.Text = "الفواتير";
            this.tabInvoices.UseVisualStyleBackColor = true;
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.AllowUserToAddRows = false;
            this.dgvInvoices.AllowUserToDeleteRows = false;
            this.dgvInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoices.Location = new System.Drawing.Point(0, 0);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.ReadOnly = true;
            this.dgvInvoices.RowHeadersWidth = 51;
            this.dgvInvoices.RowTemplate.Height = 24;
            this.dgvInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoices.Size = new System.Drawing.Size(739, 473);
            this.dgvInvoices.TabIndex = 0;
            this.dgvInvoices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoices_CellDoubleClick);
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
            // frmShowInvoicesForStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 567);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowInvoicesForStudent";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "عرض فواتير التلميذ";
            this.tabControl1.ResumeLayout(false);
            this.tabStudent.ResumeLayout(false);
            this.tabInvoices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStudent;
        private controls.ctrlFilteredStudentCard ctrlFilteredStudentCard1;
        private System.Windows.Forms.TabPage tabInvoices;
        private System.Windows.Forms.DataGridView dgvInvoices;
    }
}