namespace Application_UI.reports
{
    partial class frmMonthlyReport
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
            this.btnExpensesReport = new System.Windows.Forms.Button();
            this.btnStudentsReport = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(343, 242);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 38);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExpensesReport
            // 
            this.btnExpensesReport.Location = new System.Drawing.Point(83, 161);
            this.btnExpensesReport.Name = "btnExpensesReport";
            this.btnExpensesReport.Size = new System.Drawing.Size(289, 38);
            this.btnExpensesReport.TabIndex = 1;
            this.btnExpensesReport.Text = "استخراج تقرير النفقات";
            this.btnExpensesReport.UseVisualStyleBackColor = true;
            this.btnExpensesReport.Click += new System.EventHandler(this.btnExpensesReport_Click);
            // 
            // btnStudentsReport
            // 
            this.btnStudentsReport.Location = new System.Drawing.Point(83, 106);
            this.btnStudentsReport.Name = "btnStudentsReport";
            this.btnStudentsReport.Size = new System.Drawing.Size(289, 38);
            this.btnStudentsReport.TabIndex = 2;
            this.btnStudentsReport.Text = "استخراج تقرير المستحقات الشهرية";
            this.btnStudentsReport.UseVisualStyleBackColor = true;
            this.btnStudentsReport.Click += new System.EventHandler(this.btnStudentsReport_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(83, 55);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(289, 28);
            this.comboBox1.TabIndex = 3;
            // 
            // frmMonthlyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 292);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnStudentsReport);
            this.Controls.Add(this.btnExpensesReport);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMonthlyReport";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "استخراج التقرير الشهري";
            this.Load += new System.EventHandler(this.frmMonthlyReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExpensesReport;
        private System.Windows.Forms.Button btnStudentsReport;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}