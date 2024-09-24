using Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Core_Logic
{
    public class Debt
    {
        private int _ID;
        private int _StudentID;
        private int _PaymentTypeID;
        private int _DebtMonth;
        private decimal _Amount;
        public int ID
        {
            get { return _ID; }
            private set { _ID = value; }
        }
        public int StudentID 
        {
            get { return _StudentID; }
            private set { _StudentID = value; }
        }
        public int PaymentTypeID
        {
            get { return _PaymentTypeID; }
            private set { _PaymentTypeID = value; }
        }
        public int DebtMonth
        {
            get { return _DebtMonth; }
            private set { _DebtMonth = value; }
        }
        public decimal Amount
        {
            get { return _Amount; }
            private set { _Amount = value; }
        }

        private Debt()
        {
            ID = -1;
        }
        public Debt(int StudentID, int PaymentTypeID, int DebtMonth, decimal Amount) : this()
        {
            this.StudentID = StudentID;
            this.PaymentTypeID = PaymentTypeID;
            this.DebtMonth = DebtMonth;
            this.Amount = Amount;
        }

        //public Debt(Payment payment) : this()
        //{
        //    this.StudentID = payment.StudentID;
        //    this.PaymentTypeID = payment.PaymentTypeID;
        //    this.DebtMonth = payment.PaidMonth.Value;
        //    this.Amount = payment.Amount;
        //}

        private void _ModelToDebt(DebtModel model)
        {
            _ID = model.ID;
            _StudentID = model.StudentID;
            _PaymentTypeID = model.PaymentTypeID;
            _DebtMonth = model.DebtMonth;
            _Amount = model.Amount;
        }
        private DebtModel _DebtToModel()
        {
            DebtModel model = new DebtModel();
            model.ID = _ID;
            model.StudentID = _StudentID;
            model.PaymentTypeID = _PaymentTypeID;
            model.DebtMonth = _DebtMonth;
            model.Amount = _Amount;
            return model;
        }
        private bool Insert()
        {
            DebtModel model = _DebtToModel();
            if (model == null)
                return true;
            return Debts.Insert(model) == 0;
        }
        public bool Delete()
        {
            return Delete(this.ID);
        }

        public bool save()
        {
            if (ID == -1)
                return Insert();
            return true;
        }

        public static bool Delete(int id)
        {
            return Debts.Delete(id) == 0;
        }

        public static Debt Get(int studentID, int paymentTypeID)
        {
            var model = Debts.Get(studentID, paymentTypeID);
            if (model == null)
                return null;
            var debt = new Debt();
            debt._ModelToDebt(model);
            return debt;
        }

        public static Debt Get(int studentID, int paymentTypeID, int debtMonth)
        {
            var model = Debts.Get(studentID, paymentTypeID, debtMonth);
            if (model == null)
                return null;
            var debt = new Debt();
            debt._ModelToDebt(model);
            return debt;
        }


        private static void AddDebt(Student student, int paymentTypeID, int debtMonth)
        {
            if (Payment.Exists(student.ID, paymentTypeID, debtMonth))
                return;

            if (Debt.Get(student.ID, paymentTypeID, debtMonth) != null)
                return;

            Debt debt;
            switch (paymentTypeID)
            {
                case (int)PaymentTypes.REGISTRATION:
                    if (Get(student.ID, paymentTypeID) != null)
                        return;
                    Fee regFee = Fee.Get(MainFees.REGISTRATION);
                    debt = new Debt(student.ID, paymentTypeID, debtMonth, regFee.Amount);
                    break;
                case (int)PaymentTypes.TRANSPORTATION:
                    Fee transportationFee = Fee.Get(MainFees.TRANSPORTATION);
                    debt = new Debt(student.ID, paymentTypeID, debtMonth, transportationFee.Amount);
                    break;
                case (int)PaymentTypes.FEEDING:
                    Fee feedingFee = Fee.Get(MainFees.FEEDING);
                    debt = new Debt(student.ID, paymentTypeID, debtMonth, feedingFee.Amount);
                    break;
                case (int)PaymentTypes.TUITION:
                    Fee tuitionFee = Fee.GetTuition(student.Grade);
                    decimal amount = tuitionFee.Amount * (1 - student.TuitionCoupon);
                    debt = new Debt(student.ID, paymentTypeID, debtMonth, amount);
                    break;
                default:
                    return;
            }
            debt.save();
        }

        public static void AddDebt(Student student, int month)
        {
            if (month > 6 && month < 9)
                return;

            if (!student.IsRegistered)
                AddDebt(student, (int)PaymentTypes.REGISTRATION, month);

            AddDebt(student, (int)PaymentTypes.TUITION, month);
            if (student.IsTransported)
                AddDebt(student, (int)PaymentTypes.TRANSPORTATION, month);
            if (student.IsFed)
                AddDebt(student, (int)PaymentTypes.FEEDING, month);
        }

        public static void AddDebts(int month)
        {
            if (month > 6 && month < 9)
                return;
            DataTable students = Student.Get();
            foreach (DataRow row in students.Rows)
            {
                var student = Student.Get(Convert.ToInt32(row["ID"]));
                AddDebt(student, month);
            }
        }
    }
}
