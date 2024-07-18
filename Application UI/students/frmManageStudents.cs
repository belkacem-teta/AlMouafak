﻿using Core_Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Application_UI.students
{
    public partial class frmManageStudents : Form
    {
        DataTable list;
        readonly Dictionary<string, string> ColumnNamesMapping = new Dictionary<string, string>
        {
            {"ID", "الرقم" },
            {"RegNumber", "رقم التسجيل" },
            {"FirstName", "الإسم" },
            {"LastName", "اللقب" },
            {"EntryDate", "تاريخ الدخول" },
            {"Gender", "الجنس" },
            {"GradeString", "المستوى" },
            {"IsFed", "خدمة الإطعام" },
            {"IsTransported", "خدمة النقل" },
            {"TuitionCoupon", "نسبة خصم التمدرس %" },
        };
        public frmManageStudents()
        {
            InitializeComponent();
        }

        private void frmManageStudents_Load(object sender, EventArgs e)
        {
            RefreshList();

            cbFilter.Items.AddRange(new string[]
                {
                    ColumnNamesMapping["ID"],
                    ColumnNamesMapping["FirstName"],
                    ColumnNamesMapping["LastName"],
                    ColumnNamesMapping["GradeString"],
                }
            );
            HideFilters();
        }

        private void RefreshList()
        {
            this.list = Student.Get();
            LoadList(list.DefaultView);
        }
        private void LoadList(DataView dv)
        {
            dgvList.DataSource = dv;
            RenameColumns();
            dgvList.ClearSelection();
        }
        private void RenameColumns()
        {
            foreach (var item in ColumnNamesMapping)
            {
                dgvList.Columns[item.Key].HeaderText = item.Value;
            }
        }
        private void HideFilters()
        {
            txtSearch.Visible = false;
            cbSearch.Visible = false;
        }
        private void PrepareFilter()
        {
            HideFilters();
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                    txtSearch.Visible = true;
                    break;
                case 3:
                    cbSearch.Visible = true;
                    cbSearch.Items.Clear();
                    cbSearch.Items.Add("الكل");
                    cbSearch.Items.AddRange(Grades.NAMES);
                    break;
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrepareFilter();
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = list.DefaultView;

            if (cbSearch.Text == "الكل")
                dv.RowFilter = "";
            else
            {
                string columnName = ColumnNamesMapping.FirstOrDefault(x => x.Value == cbFilter.Text).Key;
                dv.RowFilter = $"{columnName} LIKE '{cbSearch.Text}'";
            }

            LoadList(dv);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = list.DefaultView;
            var columnKey = ColumnNamesMapping.FirstOrDefault(x => x.Value == cbFilter.Text).Key;
            if (columnKey == "ID")
            {
                if (int.TryParse(txtSearch.Text, out int id))
                    dv.RowFilter = $"{columnKey} = {id}";
                else
                    dv.RowFilter = "";
            }
            else
                dv.RowFilter = $"{columnKey} LIKE '%{txtSearch.Text}%'";

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _AddNew();
        }

        private void _AddNew()
        {
            new frmAddEditStudent(new Student()).ShowDialog();
            RefreshList();
        }
        private void _Update(int id)
        {
            Student student = Student.Get(id);
            if (student != null)
            {
                new frmAddEditStudent(student).ShowDialog();
                RefreshList();
            }
        }
        private void _Delete(int id)
        {
            if (Helper.ShowDeleteConfirmation())
            {
                if (Student.Delete(id))
                    Helper.ShowError();
                RefreshList();
            }
        }
        private void _Show(int id)
        {
            new frmShowStudent(Student.Get(id)).Show();
            RefreshList();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _AddNew();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            _Update(Convert.ToInt32(dgvList.CurrentRow.Cells[0].Value));
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Delete(Convert.ToInt32(dgvList.CurrentRow.Cells[0].Value));
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Show(Convert.ToInt32(dgvList.CurrentRow.Cells[0].Value));
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _Show(Convert.ToInt32(dgvList.CurrentRow.Cells[0].Value));
        }

        private void addInvoice_Click(object sender, EventArgs e)
        {
            //Student student = Student.Get(Convert.ToInt32(dgvList.CurrentRow.Cells[0].Value));
            //new frmAddInvoice(student).Show();
        }
    }
}