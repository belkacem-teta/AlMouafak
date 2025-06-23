using Core_Logic;
using System;
using System.Collections.Generic;
using System.IO;
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
                btnPrint.Text = "طباعة";
                btnDelete.Visible = true;
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
            txtNotes.Text = invoice.Notes;
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
            if (invoice.ID == -1)
            {
                if (invoice.Save() != Invoice.Status.SUCCESS)
                {
                    Helper.ShowError();
                    return;
                }
            }
            string filePath = Helper.SaveExcelFile($"بيان المستحقات رقم {invoice.ID}");
            Task.Run(() => Report.MakeExcelInvoice(invoice, filePath));
            OnExit?.Invoke("SAVE");
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (invoice.ID == -1)
            {
                if (invoice.Save() != Invoice.Status.SUCCESS)
                {
                    Helper.ShowError();
                    return;
                }
            }
            string filePath = Path.Combine(Application.StartupPath, $"invoices/بيان المستحقات رقم {invoice.ID}.xlsx");
            Task.Run(() => SaveAndPrint(filePath));
            OnExit?.Invoke("SAVE");
            this.Close();
        }

        private void SaveAndPrint(string filePath)
        {
            if (!File.Exists(filePath))
                Report.MakeExcelInvoice(invoice, filePath);
            Report.PrintExcelFile(filePath);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Helper.ShowDeleteConfirmation())
                return;

            invoice.Delete();
            OnExit?.Invoke("DELETE");
            this.Close();
        }
    }
}
