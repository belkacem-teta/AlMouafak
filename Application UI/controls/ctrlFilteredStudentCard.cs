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

namespace Application_UI.controls
{
    public partial class ctrlFilteredStudentCard : UserControl
    {
        public Student student
        {
            get { return ctrlStudentCard1.student; }
            set
            {
                ctrlStudentCard1.student = value;
            }
        }
        public bool IsStudentSet
        {
            get { return student != null; }
        }
        public bool Locked
        {
            get { return !grpSearch.Enabled; }
            set
            {
                if (value && !IsStudentSet)
                    return;
                grpSearch.Enabled = !value;
            }
        }
        public ctrlFilteredStudentCard()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) && string.IsNullOrWhiteSpace(txtLastName.Text))
                return;

            student = Student.Get(txtFirstName.Text, txtLastName.Text);
        }
    }
}
