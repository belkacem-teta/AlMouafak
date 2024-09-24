﻿namespace Application_UI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.المستحقاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInvoicesForStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageFeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageExpensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.إستخراجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.financesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TransportationReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentsToolStripMenuItem,
            this.المستحقاتToolStripMenuItem,
            this.ManageExpensesToolStripMenuItem,
            this.إستخراجToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // studentsToolStripMenuItem
            // 
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            resources.ApplyResources(this.studentsToolStripMenuItem, "studentsToolStripMenuItem");
            this.studentsToolStripMenuItem.Click += new System.EventHandler(this.studentsToolStripMenuItem_Click);
            // 
            // المستحقاتToolStripMenuItem
            // 
            this.المستحقاتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddInvoiceToolStripMenuItem,
            this.showInvoicesForStudentToolStripMenuItem,
            this.ManageFeesToolStripMenuItem});
            this.المستحقاتToolStripMenuItem.Name = "المستحقاتToolStripMenuItem";
            resources.ApplyResources(this.المستحقاتToolStripMenuItem, "المستحقاتToolStripMenuItem");
            // 
            // AddInvoiceToolStripMenuItem
            // 
            this.AddInvoiceToolStripMenuItem.Name = "AddInvoiceToolStripMenuItem";
            resources.ApplyResources(this.AddInvoiceToolStripMenuItem, "AddInvoiceToolStripMenuItem");
            this.AddInvoiceToolStripMenuItem.Click += new System.EventHandler(this.AddInvoiceToolStripMenuItem_Click);
            // 
            // showInvoicesForStudentToolStripMenuItem
            // 
            this.showInvoicesForStudentToolStripMenuItem.Name = "showInvoicesForStudentToolStripMenuItem";
            resources.ApplyResources(this.showInvoicesForStudentToolStripMenuItem, "showInvoicesForStudentToolStripMenuItem");
            this.showInvoicesForStudentToolStripMenuItem.Click += new System.EventHandler(this.showInvoicesForStudentToolStripMenuItem_Click);
            // 
            // ManageFeesToolStripMenuItem
            // 
            this.ManageFeesToolStripMenuItem.Name = "ManageFeesToolStripMenuItem";
            resources.ApplyResources(this.ManageFeesToolStripMenuItem, "ManageFeesToolStripMenuItem");
            this.ManageFeesToolStripMenuItem.Click += new System.EventHandler(this.ManageFeesToolStripMenuItem_Click);
            // 
            // ManageExpensesToolStripMenuItem
            // 
            this.ManageExpensesToolStripMenuItem.Name = "ManageExpensesToolStripMenuItem";
            resources.ApplyResources(this.ManageExpensesToolStripMenuItem, "ManageExpensesToolStripMenuItem");
            this.ManageExpensesToolStripMenuItem.Click += new System.EventHandler(this.ManageExpensesToolStripMenuItem_Click);
            // 
            // إستخراجToolStripMenuItem
            // 
            this.إستخراجToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.financesToolStripMenuItem,
            this.studentsReportToolStripMenuItem,
            this.feedingReportToolStripMenuItem,
            this.TransportationReportToolStripMenuItem});
            this.إستخراجToolStripMenuItem.Name = "إستخراجToolStripMenuItem";
            resources.ApplyResources(this.إستخراجToolStripMenuItem, "إستخراجToolStripMenuItem");
            // 
            // financesToolStripMenuItem
            // 
            this.financesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.annualToolStripMenuItem,
            this.monthlyToolStripMenuItem,
            this.dailyToolStripMenuItem});
            this.financesToolStripMenuItem.Name = "financesToolStripMenuItem";
            resources.ApplyResources(this.financesToolStripMenuItem, "financesToolStripMenuItem");
            this.financesToolStripMenuItem.Click += new System.EventHandler(this.financesToolStripMenuItem_Click);
            // 
            // annualToolStripMenuItem
            // 
            this.annualToolStripMenuItem.Name = "annualToolStripMenuItem";
            resources.ApplyResources(this.annualToolStripMenuItem, "annualToolStripMenuItem");
            this.annualToolStripMenuItem.Click += new System.EventHandler(this.annualToolStripMenuItem_Click);
            // 
            // monthlyToolStripMenuItem
            // 
            this.monthlyToolStripMenuItem.Name = "monthlyToolStripMenuItem";
            resources.ApplyResources(this.monthlyToolStripMenuItem, "monthlyToolStripMenuItem");
            this.monthlyToolStripMenuItem.Click += new System.EventHandler(this.monthlyToolStripMenuItem_Click);
            // 
            // dailyToolStripMenuItem
            // 
            this.dailyToolStripMenuItem.Name = "dailyToolStripMenuItem";
            resources.ApplyResources(this.dailyToolStripMenuItem, "dailyToolStripMenuItem");
            this.dailyToolStripMenuItem.Click += new System.EventHandler(this.dailyToolStripMenuItem_Click);
            // 
            // studentsReportToolStripMenuItem
            // 
            this.studentsReportToolStripMenuItem.Name = "studentsReportToolStripMenuItem";
            resources.ApplyResources(this.studentsReportToolStripMenuItem, "studentsReportToolStripMenuItem");
            // 
            // feedingReportToolStripMenuItem
            // 
            this.feedingReportToolStripMenuItem.Name = "feedingReportToolStripMenuItem";
            resources.ApplyResources(this.feedingReportToolStripMenuItem, "feedingReportToolStripMenuItem");
            this.feedingReportToolStripMenuItem.Click += new System.EventHandler(this.feedingReportToolStripMenuItem_Click);
            // 
            // TransportationReportToolStripMenuItem
            // 
            this.TransportationReportToolStripMenuItem.Name = "TransportationReportToolStripMenuItem";
            resources.ApplyResources(this.TransportationReportToolStripMenuItem, "TransportationReportToolStripMenuItem");
            this.TransportationReportToolStripMenuItem.Click += new System.EventHandler(this.TransportationReportToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem المستحقاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageFeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInvoicesForStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem إستخراجToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem financesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feedingReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TransportationReportToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem ManageExpensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem annualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyToolStripMenuItem;
    }
}

