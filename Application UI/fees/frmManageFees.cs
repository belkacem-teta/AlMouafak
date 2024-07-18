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
    public partial class frmManageFees : Form
    {
        DataTable list;
        readonly Dictionary<string, string> ColumnNamesMapping = new Dictionary<string, string>
        {
            {"ID", "الرقم" },
            {"Title", "نوع المستحقات" },
            {"Amount", "المبلغ" },
        };
        public frmManageFees()
        {
            InitializeComponent();
        }

        private void frmManageFees_Load(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void RefreshList()
        {
            this.list = Fee.Get();
            dgvList.DataSource = list.DefaultView;
            RenameColumns();
            dgvList.ClearSelection();
        }

        private void RenameColumns()
        {
            dgvList.Columns["IsDeletable"].Visible = false;
            foreach (var item in ColumnNamesMapping)
            {
                dgvList.Columns[item.Key].HeaderText = item.Value;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _Add()
        {
            new frmAddEditFees(new Fee()).ShowDialog();
            RefreshList();
        }
        private void _Edit(int id)
        {
            new frmAddEditFees(Fee.Get(id)).ShowDialog();
            RefreshList();
        }
        private void _Delete(int id)
        {
            if (Helper.ShowDeleteConfirmation())
            {
                if (Fee.Delete(id))
                    Helper.ShowError();
                RefreshList();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _Add();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Edit(Convert.ToInt32(dgvList.CurrentRow.Cells[0].Value));
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Delete(Convert.ToInt32(dgvList.CurrentRow.Cells[0].Value));
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Add();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            deleteToolStripMenuItem.Enabled = Convert.ToInt32(dgvList.CurrentRow.Cells["IsDeletable"].Value) > 0;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _Edit(Convert.ToInt32(dgvList.CurrentRow.Cells[0].Value));
        }
    }
}
