using Core_Logic;
using System;
using System.Windows.Forms;

namespace Application_UI.students
{
    public partial class frmAddEditStudent : Form
    {
        Student student;
        public frmAddEditStudent(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void frmAddEditStudent_Load(object sender, EventArgs e)
        {
            ResetForm();
            if (student.ID == -1)
            {
                lblTitle.Text = "إضافة تلميذ جديد";
            }
            else
            {
                lblTitle.Text = "تعديل بيانات التلميذ";
                FillForm();
            }
        }
        
        private void ResetForm()
        {
            cbGrade.Items.AddRange(Grades.NAMES);
            dtBrithDate.MinDate = DateTime.Now.AddYears(-15);
            dtBrithDate.MaxDate = DateTime.Now.AddYears(-3);
            dtEntryDate.MinDate = DateTime.Now.AddMonths(-9);
            dtEntryDate.MaxDate = DateTime.Now;
            rdIsMale.Checked = true;
            cbGrade.SelectedIndex = 0;
        }

        private void FillForm()
        {
            txtRegNumber.Text = student.RegNumber;
            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;
            if (student.IsMale)
                rdIsMale.Checked = true;
            else
                rdIsFemale.Checked = true;
            dtEntryDate.Value = student.EntryDate;
            dtBrithDate.Value = student.BirthDate;
            cbGrade.SelectedIndex = student.Grade;
            numGroup.Value = student.Group;
            numTuitionCoupon.Value = (int)(student.TuitionCoupon * 100);
            chkIsFed.Checked = student.IsFed;
            chkIsTransported.Checked = student.IsTransported;
        }

        private void PopulateStudent()
        {
            student.RegNumber = txtRegNumber.Text;
            student.FirstName = txtFirstName.Text;
            student.LastName = txtLastName.Text;
            student.IsMale = rdIsMale.Checked;
            student.EntryDate = dtEntryDate.Value.Date;
            student.BirthDate = dtBrithDate.Value.Date;
            student.Grade = (byte)cbGrade.SelectedIndex;
            student.Group = (byte)numGroup.Value;
            student.TuitionCoupon = numTuitionCoupon.Value / 100;
            student.IsFed = chkIsFed.Checked;
            student.IsTransported = chkIsTransported.Checked;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateForm()
        {
            return Helper.ValidateEmptyTextBox(txtRegNumber, errorProvider1) |
                Helper.ValidateEmptyTextBox(txtFirstName, errorProvider1) |
                Helper.ValidateEmptyTextBox(txtLastName, errorProvider1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
                return;

            PopulateStudent();
            if (student.Save())
                Helper.ShowError();
            else
                this.Close();
        }

        private void txtRegNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.NumericTextBox_KeyPress(sender, e);
        }
    }
}
