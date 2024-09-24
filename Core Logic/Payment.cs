using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Logic
{
    public class Payment
    {
        internal event Action OnAmountUpdate;

        private int _ID;
        private string _Title;
        private decimal _Amount;
        private int _InvoiceID;
        private int _PaymentTypeID;
        private int? _PaidMonth;
        private int _StudentID;

        private Student _student;
        private Debt _debt;

        public int ID
        {
            get { return _ID; }
            private set { _ID = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public decimal Amount
        {
            get { return _Amount; }
            set
            {
                if (PaymentTypeID == (int)PaymentTypes.OTHER)
                {
                    _Amount = value;
                    OnAmountUpdate?.Invoke();
                }
            }
        }
        public int InvoiceID
        {
            get { return _InvoiceID; }
            internal set { _InvoiceID = value; }
        }
        public int PaymentTypeID
        {
            get { return _PaymentTypeID;  }
            private set { _PaymentTypeID = value; }
        }
        public int? PaidMonth
        {
            get { return _PaidMonth; }
            set 
            {
                if (value == null)
                {
                    _PaidMonth = null;
                    return;
                }
                if (student.GetPaidMonths((PaymentTypes)PaymentTypeID).Contains(value.Value))
                    return;
                _PaidMonth = value;
                debt = Debt.Get(StudentID, PaymentTypeID, _PaidMonth.Value);
            }
        }
        public int StudentID
        {
            get { return _StudentID; }
            set { _StudentID = value; }
        }

        public Student student
        {
            get { return _student; }
            set
            {
                _student = value;
                StudentID = value.ID;
            }
        }

        public Debt debt
        {
            get { return _debt; }
            set 
            {
                _debt = value;
                if (value != null)
                    _Amount = value.Amount;
            }
        }

        private Payment()
        {
            ID = -1;
        }
        private void _ModelToPayment(PaymentModel model)
        {
            _ID = model.ID;
            _Title = model.Title;
            _Amount = model.Amount;
            _InvoiceID = model.InvoiceID;
            _PaymentTypeID = model.PaymentTypeID;
            _PaidMonth = model.PaidMonth;
            _StudentID = model.StudentID;
        }
        private PaymentModel _PaymentToModel()
        {
            PaymentModel model = new PaymentModel();
            model.ID = _ID;
            model.Title = _Title;
            model.Amount = _Amount;
            model.InvoiceID =  _InvoiceID;
            model.PaymentTypeID = _PaymentTypeID;
            model.PaidMonth = _PaidMonth;
            model.StudentID = _StudentID;
            return model;
        }

        private void _AutoFill(Fee fee)
        {
            _Title = fee.Title;
            _Amount = fee.Amount;
            _PaymentTypeID = fee.PaymentTypeID;
        }
        public void AutoFill(Fee fee)
        {
            if (fee?.PaymentTypeID == (int)PaymentTypes.OTHER)
            {
                _AutoFill(fee);
            }
        }

        public static Payment NewRegistrationPayment(Student std)
        {
            Payment payment = new Payment();
            payment._AutoFill(Fee.Get(MainFees.REGISTRATION));
            payment.student = std;

            payment.debt = Debt.Get(std.ID, (int)PaymentTypes.REGISTRATION);

            return payment;
        }
        public static Payment NewFeedingPayment(Student std)
        {
            Payment payment = new Payment();
            payment._AutoFill(Fee.Get(MainFees.FEEDING));
            payment.student = std;
            return payment;
        }
        public static Payment NewTransportationPayment(Student std)
        {
            Payment payment = new Payment();
            payment._AutoFill(Fee.Get(MainFees.TRANSPORTATION));
            payment.student = std;
            return payment;
        }
        public static Payment NewTuitionPayment(Student std)
        {
            Fee fee = Fee.GetTuition(std.Grade);
            Payment payment = new Payment()
            {
                _Title = fee.Title,
                _Amount = fee.Amount - (fee.Amount * std.TuitionCoupon),
                _PaymentTypeID = fee.PaymentTypeID,
                student = std,
            };
            return payment;
        }
        public static Payment NewPayment(Student std, Fee fee = null)
        {
            Payment payment = new Payment()
            {
                PaymentTypeID = (int)PaymentTypes.OTHER,
                student = std
            };
            payment.AutoFill(fee);
            return payment;
        }
        internal bool Insert()
        {
            PaymentModel model = _PaymentToModel();

            int result = Payments.Insert(model);
            if (result == 0)
                return true;

            if (debt != null)
                debt.Delete();

            _ID = model.ID;
            return false;
        }

        public static List<Payment> GetByInvoice(int invoiceID)
        {
            List<Payment> result = new List<Payment>();
            List<PaymentModel> models = Payments.GetByInvoice(invoiceID);
            foreach (var model in models)
            {
                Payment payment = new Payment();
                payment._ModelToPayment(model);
                result.Add(payment);
            }
            return result;
        }

        public static bool Exists(int studentID, int paymentTypeID, int paidMonth)
        {
            return Payments.Exists(studentID, paymentTypeID, paidMonth);
        }
    }
}
