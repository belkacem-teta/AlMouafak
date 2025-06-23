using Core_Logic;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_UI.reports
{
    public partial class frmDailyReport : Form
    {
        public frmDailyReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Helper.SaveExcelFile($"تقرير الإيرادات ليوم {dateTimePicker1.Value.ToString("yyyy-MM-dd")} ");
            if (path != "")
                Task.Run(() => Report.MakeDailyReport(path, dateTimePicker1.Value));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
