using Core_Logic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Application_UI.invoices
{
    public partial class frmShowInvoicesForStudent : Form
    {
        readonly Dictionary<string, string> ColumnNamesMapping = new Dictionary<string, string>
        {
            {"IssueDate", "التاريخ" },
            {"TotalAmount", "المبلغ الإجمالي" },
            {"Notes", "ملاحظات" },
        };
        public frmShowInvoicesForStudent()
        {
            InitializeComponent();

            ctrlFilteredStudentCard1.onStudentSelected += RefreshList;
        }
        public frmShowInvoicesForStudent(Student student) : this()
        {
            if (student != null)
            {
                if (student.ID > 0)
                {
                    ctrlFilteredStudentCard1.student = student;
                    tabControl1.SelectedIndex = 1;
                    RefreshList();
                }
            }
        }

        private void RefreshList()
        {
            dgvInvoices.DataSource = null;
            dgvInvoices.DataSource = Invoice.GetByStudent(ctrlFilteredStudentCard1.student.ID);
            RenameColumns();
        }
        private void RenameColumns()
        {
            foreach (var item in ColumnNamesMapping)
            {
                dgvInvoices.Columns[item.Key].HeaderText = item.Value;
            }
            dgvInvoices.Columns["ID"].Visible = false;
            dgvInvoices.Columns["StudentID"].Visible = false;
        }

        private void dgvInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvInvoices.SelectedRows[0].Cells[0].Value);
            Invoice invoice = Invoice.Get(id);
            frmShowInvoice frm = new frmShowInvoice(invoice);
            frm.OnExit += OnInvoiceExit;
            frm.ShowDialog();
        }

        private void OnInvoiceExit(string state)
        {
            if (state == "DELETE")
                RefreshList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
