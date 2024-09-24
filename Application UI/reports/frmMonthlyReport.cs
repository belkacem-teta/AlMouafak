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

namespace Application_UI.reports
{
    public partial class frmMonthlyReport : Form
    {
        private Dictionary<string, int> months = new Dictionary<string, int>()
        {
            {"سبتمبر", 9 },
            {"أكتوبر", 10 },
            {"نوفمبر", 11 },
            {"ديسمبر", 12 },
            { "جانفي", 1 },
            {"فيفري", 2},
            {"مارس", 3 },
            {"أفريل", 4 },
            {"ماي", 5 },
            {"جوان", 6 },
        };
        public frmMonthlyReport()
        {
            InitializeComponent();
        }

        private void frmMonthlyReport_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(months.Keys.ToArray());
            comboBox1.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStudentsReport_Click(object sender, EventArgs e)
        {
            string monthStr = comboBox1.SelectedItem.ToString();
            string path = Helper.SaveExcelFile($"وضعية المستحقات الشهرية للتلاميذ لشهر {monthStr} {DateTime.Now.ToString("yyyy-MM-dd")} ");
            if (path != "")
                Task.Run(() => Report.MakeMonthlyReport(path, months[monthStr]));
        }

        private void btnExpensesReport_Click(object sender, EventArgs e)
        {
            string monthStr = comboBox1.SelectedItem.ToString();
            string path = Helper.SaveExcelFile($"تقرير النفقات لشهر {monthStr} {DateTime.Now.ToString("yyyy-MM-dd")} ");
            if (path != "")
                Task.Run(() => Report.MakeMonthlyExpensesReport(path, months[monthStr]));
        }
    }
}
