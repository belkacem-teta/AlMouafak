using Core_Logic;
using System;
using System.Windows.Forms;

namespace Application_UI.expenses
{
    public partial class frmManageExpenses : Form
    {
        private Expense expense = null;
        decimal totalPayments = 0;

        public frmManageExpenses()
        {
            InitializeComponent();
        }

        private void frmManageExpenses_Load(object sender, EventArgs e)
        {
            dateTimePicker1_ValueChanged(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            expense = Expense.Get(dateTimePicker1.Value.Date);

            if (expense == null)
            {
                expense = new Expense();
                expense.IssueDate = dateTimePicker1.Value;
                expense.Amount = 0;
            }

            totalPayments = Invoice.GetTotalAmountPerDay(expense.IssueDate);
            txtAmount.Text = expense.Amount.ToString();
            txtTotalPayments.Text = totalPayments.ToString();
            txtNetAmount.Text = (totalPayments - expense.Amount).ToString();

            lblSave.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal.TryParse(txtAmount.Text, out decimal newAmount);
            if (expense.ID > 0 && expense.Amount > 0 && expense.Amount != newAmount)
            {
                if (MessageBox.Show($"نفقات يوم {expense.IssueDate.ToString("yyyy-MM-dd")} مسجلة بقيمة {expense.Amount}د.ج \n هل تريد تغييرها إلى {newAmount}د.ج؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }

            expense.Amount = newAmount;
            if (expense.Save())
                Helper.ShowError();
            else
                lblSave.Visible = true;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.NumericTextBox_KeyPress(sender, e);

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            decimal.TryParse(txtAmount.Text, out decimal amount);
            txtNetAmount.Text = (totalPayments - amount).ToString();
            lblSave.Visible = false;
        }
    }
}
