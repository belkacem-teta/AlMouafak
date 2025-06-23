using Data_Access;
using System;
using System.Data;

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


        internal static void AddDebt(Student student, int paymentTypeID, int debtMonth)
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

        public static void AddDebt(Student student)
        {
            if ((DateTime.Now > TuitionYear.END) || (DateTime.Now < TuitionYear.START))
                return;

            int currentMonth = DateTime.Now.Month;

            if (!student.IsRegistered)
                AddDebt(student, (int)PaymentTypes.REGISTRATION, currentMonth);

            int firstMonth = (student.EntryDate < TuitionYear.START) ? TuitionYear.START.Month : student.EntryDate.Month;

            AddDebt(student, (int)PaymentTypes.TUITION, firstMonth);
            int counter = firstMonth;
            while (counter != currentMonth)
            {
                counter = (counter == 12) ? 1 : counter + 1;
                AddDebt(student, (int)PaymentTypes.TUITION, counter);
            }
            if (student.IsTransported)
                AddDebt(student, (int)PaymentTypes.TRANSPORTATION, currentMonth);
            if (student.IsFed)
                AddDebt(student, (int)PaymentTypes.FEEDING, currentMonth);

        }

        public static void AddDebts()
        {
            if ((DateTime.Now > TuitionYear.END) || (DateTime.Now < TuitionYear.START))
                return;
            DataTable students = Student.Get();
            foreach (DataRow row in students.Rows)
            {
                var student = Student.Get(Convert.ToInt32(row["ID"]));
                AddDebt(student);
            }
        }
    }
}
