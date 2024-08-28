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

namespace Application_UI.fees
{
    public partial class frmAddEditFees : Form
    {
        private Fee fee;
        public frmAddEditFees(Fee fee)
        {
            InitializeComponent();

            this.fee = fee ?? new Fee();
        }

        private void frmAddEditFees_Load(object sender, EventArgs e)
        {
            if (fee.ID < 1)
                return;

            if (fee.PaymentTypeID != (int)PaymentTypes.OTHER)
                txtTitle.Enabled = false;

            txtTitle.Text = fee.Title;
            txtAmount.Text = fee.Amount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Helper.ValidateEmptyTextBox(txtTitle, errorProvider1))
                return;

            fee.Title = txtTitle.Text;

            try
            {
                fee.Amount = Convert.ToDecimal(txtAmount.Text);
            } catch (Exception)
            {
                MessageBox.Show("قيمة المبلغ المدخلة غير صحيحة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (fee.Save())
                Helper.ShowError();
            else
                this.Close();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.NumericTextBox_KeyPress(sender, e);
        }
    }
}
