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
                contextMenuStrip1.Enabled = false;
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


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count < 1)
                return;
            Payment payment = (Payment)dgvPayments.SelectedRows[0].DataBoundItem;
            invoice.RemovePayment(payment);
            RefreshList();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (invoice.Save() == Invoice.Status.SUCCESS)
                this.Close();
            else
                Helper.ShowError();
        }
    }
}
