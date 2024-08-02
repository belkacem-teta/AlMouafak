using Application_UI.fees;
using Application_UI.invoices;
using Application_UI.students;
using Core_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
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
            CheckDebts();
        }

        private void CheckDebts()
        {
            string filePath = ConfigurationManager.AppSettings["PathToMonthFile"];
            try
            {
                int currentMonth = DateTime.Now.Month;
                int oldMonth = 0;
                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    int.TryParse(content, out oldMonth);
                }

                if (oldMonth != currentMonth) 
                    Debt.AddDebts(currentMonth);
                File.WriteAllText(filePath, currentMonth.ToString());
            }
            catch
            {
                Helper.ShowError();
            }
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmManageStudents()
            {
                MdiParent = this,
            }.Show();
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

        private string GetFilePath(string fileName)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "حفظ ملف";
                saveFileDialog.FileName = $"{fileName}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
                return "";
            }
        }

        private void financesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = GetFilePath($"التقرير المالي لشهر {Months.NAMES[DateTime.Now.Month]}");
            if (path != "")
                Report.MakeFinancesReport(path);
        }

        private void studentsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = GetFilePath($"قائمة التلاميذ لشهر {Months.NAMES[DateTime.Now.Month]}");
            if (path != "")
                Report.MakeStudentsReport(path);
        }

        private void feedingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = GetFilePath($"قائمة المستفيدين من الإطعام لشهر {Months.NAMES[DateTime.Now.Month]}");
            if (path != "")
                Report.MakeFedStudentsReport(path);
        }

        private void TransportationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = GetFilePath($"قائمة المستفيدين من النقل لشهر {Months.NAMES[DateTime.Now.Month]}");
            if (path != "")
                Report.MakeTransportedStudentsReport(path);
        }
    }
}
