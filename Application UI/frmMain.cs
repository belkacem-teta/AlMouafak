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

            this.Text += $" v{Helper.GetVersionNumber()}";
            pictureBox1.ImageLocation = ConfigurationManager.AppSettings["PathToBackImage"];
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
            new frmManageStudents().ShowDialog();
        }

        private void AddInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAddInvoice().ShowDialog();
        }

        private void ManageFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmManageFees().ShowDialog();
        }

        private void showInvoicesForStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmShowInvoicesForStudent().ShowDialog();
        }

        private void financesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Helper.SaveExcelFile($"التقرير المالي لشهر {Months.NAMES[DateTime.Now.Month]}");
            if (path != "")
                Task.Run(() => Report.MakeFinancesReport(path));
        }

        private void studentsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Helper.SaveExcelFile($"قائمة التلاميذ لشهر {Months.NAMES[DateTime.Now.Month]}");
            if (path != "")
                Task.Run(() => Report.MakeStudentsReport(path));
        }

        private void feedingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Helper.SaveExcelFile($"قائمة المستفيدين من الإطعام لشهر {Months.NAMES[DateTime.Now.Month]}");
            if (path != "")
                Task.Run(() => Report.MakeFedStudentsReport(path));
        }

        private void TransportationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Helper.SaveExcelFile($"قائمة المستفيدين من النقل لشهر {Months.NAMES[DateTime.Now.Month]}");
            if (path != "")
                Task.Run(() => Report.MakeTransportedStudentsReport(path));
        }
    }
}
