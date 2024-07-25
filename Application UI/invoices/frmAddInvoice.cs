using Application_UI.payments;
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
    public partial class frmAddInvoice : Form
    {
        Invoice invoice;
        public frmAddInvoice()
        {
            InitializeComponent();
        }
        public frmAddInvoice(Student student) : this()
        {
            if (student != null)
            {
                if (student.ID > 0)
                {
                    ctrlFilteredStudentCard1.student = student;
                    ctrlFilteredStudentCard1.Locked = true;
                    tabControl1.SelectedIndex = 1;
                    tabControl1_SelectedIndexChanged(null, null);
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex > 0)
            {
                if (!ctrlFilteredStudentCard1.IsStudentSet)
                {
                    MessageBox.Show("الرجاء إختيار التلميذ قبل الانتقال إلى المستحقات");
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    ctrlFilteredStudentCard1.Locked = true;
                    if (invoice  == null)
                        invoice = new Invoice(ctrlFilteredStudentCard1.student);
                    InitPaymentsForm();
                }
            }
        }
        private void MarkMonthAsPaid(CheckBox checkBox)
        {
            checkBox.Checked = true;
            checkBox.Enabled = false;
            checkBox.BackColor = Color.LightSeaGreen;
        }
        private void MarkPaidMonths(Control parent, PaymentTypes paymentType)
        {
            List<int> paidMonths = invoice.student.GetPaidMonths(paymentType);
            foreach (Control c in parent.Controls)
            {
                int tag = Convert.ToInt32(c.Tag);
                if (paidMonths.Contains(tag))
                {
                    MarkMonthAsPaid((CheckBox)c);
                }
            }
        }
        private void InitPaymentsForm()
        {
            MarkPaidMonths(grpTuition, PaymentTypes.TUITION);
            MarkPaidMonths(grpTransportation, PaymentTypes.TRANSPORTATION);
            MarkPaidMonths(grpFeeding, PaymentTypes.FEEDING);
            
            grpFeeding.Enabled = invoice.student.IsFed;
            grpTransportation.Enabled = invoice.student.IsTransported;

            if (invoice.student.IsRegistered)
            {
                MarkMonthAsPaid(chkRegistration);
                chkRegistration.Text = "مدفوعة";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PopulateInvoice();
            frmShowInvoice form = new frmShowInvoice(invoice);
            form.ShowDialog();
            this.Close();
        }

        private void PopulateInvoice()
        {
            invoice.Notes = txtNotes.Text;
            if (chkRegistration.Checked && chkRegistration.Checked)
            {
                Payment payment = Payment.NewRegistrationPayment(invoice.student);
                invoice.AddPayment(payment);
            }
            foreach (Control c in grpTuition.Controls)
            {
                CheckBox chk = (CheckBox)c;
                if (chk.Enabled && chk.Checked)
                {
                    Payment payment = Payment.NewTuitionPayment(invoice.student);
                    payment.PaidMonth = Convert.ToInt32(chk.Tag);
                    invoice.AddPayment(payment);
                }
            }
            foreach (Control c in grpFeeding.Controls)
            {
                CheckBox chk = (CheckBox)c;
                if (chk.Enabled && chk.Checked)
                {
                    Payment payment = Payment.NewFeedingPayment(invoice.student);
                    payment.PaidMonth = Convert.ToInt32(chk.Tag);
                    invoice.AddPayment(payment);
                }
            }
            foreach (Control c in grpTransportation.Controls)
            {
                CheckBox chk = (CheckBox)c;
                if (chk.Enabled && chk.Checked)
                {
                    Payment payment = Payment.NewTransportationPayment(invoice.student);
                    payment.PaidMonth = Convert.ToInt32(chk.Tag);
                    invoice.AddPayment(payment);
                }
            }
        }

        private void onOtherPaymentSave(Payment payment)
        {
            lblOtherPayments.Text += $"{payment.Title} - {payment.Amount} د.ج \n";
            invoice.AddPayment(payment);
        }

        private void btnAddOtherPayment_Click(object sender, EventArgs e)
        {
            frmAddPayment form = new frmAddPayment(invoice.student);
            form.onSave += onOtherPaymentSave;
            form.ShowDialog();
        }
    }
}
