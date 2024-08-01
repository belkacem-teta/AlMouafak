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

namespace Application_UI.invoices
{
    public partial class frmShowInvoice : Form
    {
        public event Action<string> OnExit;
        Invoice invoice;
        readonly Dictionary<string, string> ColumnNamesMapping = new Dictionary<string, string>
        {
            {"Title", "نوع المستحقات" },
            {"Amount", "المبلغ" },
        };
        public frmShowInvoice(Invoice invoice)
        {
            InitializeComponent();

            if (invoice.ID > 0)
            {
                btnSave.Visible = false;
                btnClose.Visible = false;
            }

            this.invoice = invoice;
            RefreshList();
        }

        private void RefreshList()
        {
            dgvPayments.DataSource = null;
            dgvPayments.DataSource = invoice.Payments;
            RenameColumns();
            dgvPayments.ClearSelection();
            lblTotal.Text = invoice.TotalAmount.ToString();
        }
        private void RenameColumns()
        {
            foreach (var item in ColumnNamesMapping)
            {
                dgvPayments.Columns[item.Key].HeaderText = item.Value;
            }
            dgvPayments.Columns["ID"].Visible = false;
            dgvPayments.Columns["InvoiceID"].Visible = false;
            dgvPayments.Columns["PaidMonth"].Visible = false;
            dgvPayments.Columns["student"].Visible = false;
            dgvPayments.Columns["StudentID"].Visible = false;
            dgvPayments.Columns["PaymentTypeID"].Visible = false;
            dgvPayments.Columns["debt"].Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnExit?.Invoke("CANCEL");
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (invoice.Save() == Invoice.Status.SUCCESS)
            {
                OnExit?.Invoke("SAVE");
                this.Close();
            }
            else
                Helper.ShowError();
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Select a folder";
            folderBrowserDialog1.ShowNewFolderButton = true;
            
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                if (invoice.ID == -1)
                {
                    if (invoice.Save() != Invoice.Status.SUCCESS)
                    {
                        Helper.ShowError();
                        return;
                    }
                }
                string folderPath = folderBrowserDialog1.SelectedPath;
                Report.MakeExcelInvoice(invoice, folderPath);
                OnExit?.Invoke("SAVE");
                this.Close();
            }
        }
    }
}
