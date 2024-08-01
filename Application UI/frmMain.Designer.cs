namespace Application_UI
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
            this.التلاميذToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.المستحقاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageFeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInvoicesForStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.التلاميذToolStripMenuItem,
            this.المستحقاتToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // التلاميذToolStripMenuItem
            // 
            this.التلاميذToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManageStudentsToolStripMenuItem,
            this.AddNewStudentToolStripMenuItem});
            this.التلاميذToolStripMenuItem.Name = "التلاميذToolStripMenuItem";
            resources.ApplyResources(this.التلاميذToolStripMenuItem, "التلاميذToolStripMenuItem");
            // 
            // ManageStudentsToolStripMenuItem
            // 
            this.ManageStudentsToolStripMenuItem.Name = "ManageStudentsToolStripMenuItem";
            resources.ApplyResources(this.ManageStudentsToolStripMenuItem, "ManageStudentsToolStripMenuItem");
            this.ManageStudentsToolStripMenuItem.Click += new System.EventHandler(this.ManageStudentsToolStripMenuItem_Click);
            // 
            // AddNewStudentToolStripMenuItem
            // 
            this.AddNewStudentToolStripMenuItem.Name = "AddNewStudentToolStripMenuItem";
            resources.ApplyResources(this.AddNewStudentToolStripMenuItem, "AddNewStudentToolStripMenuItem");
            this.AddNewStudentToolStripMenuItem.Click += new System.EventHandler(this.AddNewStudentToolStripMenuItem_Click);
            // 
            // المستحقاتToolStripMenuItem
            // 
            this.المستحقاتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddInvoiceToolStripMenuItem,
            this.ManageFeesToolStripMenuItem,
            this.showInvoicesForStudentToolStripMenuItem});
            this.المستحقاتToolStripMenuItem.Name = "المستحقاتToolStripMenuItem";
            resources.ApplyResources(this.المستحقاتToolStripMenuItem, "المستحقاتToolStripMenuItem");
            // 
            // AddInvoiceToolStripMenuItem
            // 
            this.AddInvoiceToolStripMenuItem.Name = "AddInvoiceToolStripMenuItem";
            resources.ApplyResources(this.AddInvoiceToolStripMenuItem, "AddInvoiceToolStripMenuItem");
            this.AddInvoiceToolStripMenuItem.Click += new System.EventHandler(this.AddInvoiceToolStripMenuItem_Click);
            // 
            // ManageFeesToolStripMenuItem
            // 
            this.ManageFeesToolStripMenuItem.Name = "ManageFeesToolStripMenuItem";
            resources.ApplyResources(this.ManageFeesToolStripMenuItem, "ManageFeesToolStripMenuItem");
            this.ManageFeesToolStripMenuItem.Click += new System.EventHandler(this.ManageFeesToolStripMenuItem_Click);
            // 
            // showInvoicesForStudentToolStripMenuItem
            // 
            this.showInvoicesForStudentToolStripMenuItem.Name = "showInvoicesForStudentToolStripMenuItem";
            resources.ApplyResources(this.showInvoicesForStudentToolStripMenuItem, "showInvoicesForStudentToolStripMenuItem");
            this.showInvoicesForStudentToolStripMenuItem.Click += new System.EventHandler(this.showInvoicesForStudentToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem التلاميذToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddNewStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem المستحقاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageFeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInvoicesForStudentToolStripMenuItem;
    }
}

