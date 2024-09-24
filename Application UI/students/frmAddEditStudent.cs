using Core_Logic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Application_UI.students
{
    public partial class frmAddEditStudent : Form
    {
        Student student;
        List<string> regNumbers;
        public frmAddEditStudent(Student student)
        {
            InitializeComponent();
            this.student = student;

            this.regNumbers = Student.GetRegNumbers();
            if (student.ID > 0)
                regNumbers.Remove(student.RegNumber);
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

        private bool ValidateRegNumber()
        {
            if (!Helper.ValidateEmptyTextBox(txtRegNumber, errorProvider1))
            {
                if (regNumbers.Contains(txtRegNumber.Text))
                {
                    errorProvider1.SetError(txtRegNumber, "يوجد تلميذ مسجل بهذا الرقم");
                    return true;
                }
                return false;
            }
            return true;
        }

        private bool ValidateForm()
        {
            return ValidateRegNumber() |
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
            // Canceled for reg numbers can now have letters
            //Helper.NumericTextBox_KeyPress(sender, e);
        }

        private void txtRegNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateRegNumber();
        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Helper.ValidateEmptyTextBox((TextBox)sender, errorProvider1);
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Helper.ValidateEmptyTextBox((TextBox)sender, errorProvider1);
        }
    }
}
