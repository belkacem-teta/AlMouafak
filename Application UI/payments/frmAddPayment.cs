using Core_Logic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Application_UI.payments
{
    public partial class frmAddPayment : Form
    {
        public event Action<Payment> onSave;
        private Payment payment;
        public frmAddPayment(Student student)
        {
            InitializeComponent();

            this.payment = Payment.NewPayment(student);
            List<Fee> feeList = Fee.GetOthers();
            cbPayments.DataSource = feeList;
            cbPayments.DisplayMember = "Title";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            payment.Title = txtTitle.Text;
            decimal.TryParse(txtAmount.Text, out decimal amount);
            payment.Amount = amount;
            onSave?.Invoke(payment);
            this.Close();
        }

        private void cbPayments_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fee fee = (Fee)cbPayments.SelectedItem;
            txtTitle.Text = fee.Title;
            txtAmount.Text = fee.Amount.ToString();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.NumericTextBox_KeyPress(sender, e);
        }
    }
}
