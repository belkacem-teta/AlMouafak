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

namespace Application_UI.students
{
    public partial class frmShowStudent : Form
    {
        public frmShowStudent(Student student)
        {
            InitializeComponent();
            ctrlStudentCard1.student = student;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
