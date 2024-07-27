using Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core_Logic
{
    public class Student
    {
        public int ID { get; private set; }
        public string RegNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private bool _IsMale;
        public bool IsMale
        {
            get { return _IsMale; }
            set
            {
                _IsMale = value;
                Gender = value ? "ذكر" : "أنثى";
            }
        }
        public DateTime BirthDate { get; set; }
        private byte _Grade;
        public byte Grade 
        {
            get { return _Grade; }
            set
            {
                if (value >= 0 && value < 6)
                {
                    _Grade = value;
                    GradeString = Core_Logic.Grades.NAMES[value];
                }
            }
        }
        public byte Group { get; set; }
        public DateTime EntryDate { get; set; }
        public bool IsRegistered { get; internal set; }
        public bool IsFed { get; set; }
        public bool IsTransported { get; set; }
        public decimal TuitionCoupon { get; set; }
        public bool IsDeleted { get; private set; }

        public string Gender { get; private set; }
        public string GradeString { get; private set; }

        public Student()
        {
            ID = -1;
            IsRegistered = false;
            IsFed = false;
            IsTransported = false;
            TuitionCoupon = 0.00M;
        }
        private void _ModelToStudent(StudentModel model)
        {
            ID = model.ID;
            RegNumber = model.RegNumber;
            FirstName = model.FirstName;
            LastName = model.LastName;
            IsMale = model.IsMale;
            BirthDate = model.BirthDate;
            Grade = model.Grade;
            Group = model.Group;
            EntryDate = model.EntryDate;
            IsRegistered = model.IsRegistered;
            IsFed = model.IsFed;
            IsTransported = model.IsTransported;
            TuitionCoupon = model.TuitionCoupon;
            IsDeleted = model.IsDeleted;
        }
        private StudentModel _StudentToModel()
        {
            StudentModel model = new StudentModel();
            model.ID = ID;
            model.RegNumber = RegNumber;
            model.FirstName = FirstName;
            model.LastName = LastName;
            model.IsMale = IsMale;
            model.BirthDate = BirthDate;
            model.Grade = Grade;
            model.Group = Group;
            model.EntryDate = EntryDate;
            model.IsRegistered = IsRegistered;
            model.IsFed = IsFed;
            model.IsTransported = IsTransported;
            model.TuitionCoupon = TuitionCoupon;
            model.IsDeleted = IsDeleted;
            return model;
        }
        private bool _Insert()
        {
            StudentModel model = _StudentToModel();
            int result = Students.Insert(model);
            if (result != 0)
                this.ID = model.ID;
            return result == 0;
        }
        private bool _Update()
        {
            StudentModel model = _StudentToModel();
            int result = Students.Update(model);
            return result == 0;
        }
        public bool Save()
        {
            if (ID == -1)
            {
                var result = _Insert();
                if (!result && DateTime.Now.Day < 15)
                    Debt.AddDebt(this, DateTime.Now.Month);
                return result;
            }
            else
                return _Update();
        }
        
        public List<int> GetPaidMonths(PaymentTypes type)
        {
            return Payments.GetPaidMonths(this.ID, (int)type);
        }
        public List<int> GetDebtMonths(PaymentTypes type)
        {
            return Debts.GetDebtMonths(ID, (int)type);
        }

        public static Student Get(int id)
        {
            StudentModel model = Students.Get(id);
            if (model == null)
                return null;

            Student student = new Student();
            student._ModelToStudent(model);
            return student;
        }
        public static Student Get(string firstName, string lastName)
        {
            StudentModel model = Students.Get(firstName, lastName);
            if (model == null)
                return null;

            Student student = new Student();
            student._ModelToStudent(model);
            return student;
        }
        public static DataTable Get()
        {
            return Students.Get();
        }
        public static bool Delete(int id)
        {
            return Students.Delete(id) == 0;
        }
    }
}
