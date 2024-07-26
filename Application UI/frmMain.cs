using Application_UI.fees;
using Application_UI.invoices;
using Application_UI.students;
using Core_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void ManageStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmManageStudents()
            {
                MdiParent = this,
            }.Show();
        }

        private void AddNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditStudent form = new frmAddEditStudent(new Student());
            form.MdiParent = this;
            form.Show();
        }

        private void AddInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAddInvoice()
            {
                MdiParent = this
            }.Show();
        }

        private void ManageFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmManageFees()
            {
                MdiParent = this
            }.Show();
        }

        private void showInvoicesForStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmShowInvoicesForStudent()
            {
                MdiParent = this
            }.Show();
        }
    }
}
