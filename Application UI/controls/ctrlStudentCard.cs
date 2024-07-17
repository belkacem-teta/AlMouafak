using Application_UI.students;
using Core_Logic;
using System.Windows.Forms;

namespace Application_UI.controls
{
    public partial class ctrlStudentCard : UserControl
    {
        private Student _student;
        public Student student
        {
            get { return _student; }
            set
            {
                if (value != null)
                {
                    _student = value;
                    FillCard();
                    linkLabel1.Visible = true;
                }
            }
        }

        public ctrlStudentCard()
        {
            InitializeComponent();
        }

        private void FillCard()
        {
            lblRegNumber.Text = student.RegNumber;
            lblFirstName.Text = student.FirstName;
            lblLastName.Text = student.LastName;
            lblGender.Text =  student.Gender;
            lblEntryDate.Text = student.EntryDate.ToString("yyyy-MM-dd");
            lblBirthDate.Text = student.BirthDate.ToString("yyyy-MM-dd");
            lblGrade.Text = student.GradeString;
            lblGroup.Text = student.Group.ToString();
            lblTuitionCoupon.Text = ((int)(student.TuitionCoupon * 100)).ToString();
            lblIsRegistered.Text = student.IsRegistered ? "مدفوعة" : "غير مدفوعة";
            lblIsFed.Text = student.IsFed ? "مشترك" : "غير مشترك";
            lblIsTransported.Text = student.IsTransported ? "مشترك" : "غير مشترك";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmAddEditStudent(student).ShowDialog();
            FillCard();
        }
    }
}
