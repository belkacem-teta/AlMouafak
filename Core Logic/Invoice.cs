using Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Logic
{
    public class Invoice
    {
        public enum Status { 
            SUCCESS, 
            FAIL, 
            FAIL_NO_PAYMENTS, 
            FAIL_UPDATE_ATTEMPT, 
            FAIL_TO_INSERT_PAYMENTS, 
            FAIL_DUPLICATE_REGISTRATION,
            FAIL_MONTH_ALREADY_PAID,
            FAIL_INVALID_PAYMENT
        }

        private int _ID;
        private int _StudentID;
        private DateTime _IssueDate;
        private decimal _TotalAmount;
        private string _Notes;

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
        public DateTime IssueDate
        {
            get { return _IssueDate; }
            private set { _IssueDate = value; }
        }
        public decimal TotalAmount
        {
            get { return _TotalAmount; }
            private set { _TotalAmount = value; }
        }
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }

        private Student _student;
        public Student student
        {
            get { return _student; }
            set
            {
                _student = value;
                _StudentID = value.ID; 
            }
        }
        public List<Payment> Payments { get; private set; }
        private Invoice()
        {
            ID = -1;
            TotalAmount = 0;
        }
        public Invoice(Student student) : this()
        {
            this.Payments = new List<Payment>();
            this.student = student;
        }
        private void _ModelToInvoice(InvoiceModel model)
        {
            _ID = model.ID;
            _StudentID = model.StudentID;
            _IssueDate = model.IssueDate;
            _TotalAmount = model.TotalAmount;
            _Notes = model.Notes;
        }
        private InvoiceModel _InvoiceToModel()
        {
            InvoiceModel model = new InvoiceModel();
            model.ID = _ID;
            model.StudentID = _StudentID;
            model.IssueDate = _IssueDate;
            model.TotalAmount = _TotalAmount;
            model.Notes = _Notes;
            return model;
        }
        public void UpdateTotalAmount()
        {
            TotalAmount = 0;
            foreach (Payment payment in this.Payments)
                TotalAmount += payment.Amount;
        }
        public Status AddPayment(Payment payment)
        {
            switch ((PaymentTypes)payment.PaymentTypeID)
            {
                case PaymentTypes.REGISTRATION:
                    if (GetRegistrationCount() > 0)
                        return Status.FAIL_DUPLICATE_REGISTRATION;
                    break;
                case PaymentTypes.TUITION:
                    if (payment.PaidMonth == null)
                        return Status.FAIL_INVALID_PAYMENT;
                    if (GetPaidMonths(PaymentTypes.TUITION).Contains(payment.PaidMonth.Value))
                        return Status.FAIL_MONTH_ALREADY_PAID;
                    break;
                case PaymentTypes.FEEDING:
                    if (payment.PaidMonth == null)
                        return Status.FAIL_INVALID_PAYMENT;
                    if (GetPaidMonths(PaymentTypes.FEEDING).Contains(payment.PaidMonth.Value))
                        return Status.FAIL_MONTH_ALREADY_PAID;
                    break;
                case PaymentTypes.TRANSPORTATION:
                    if (payment.PaidMonth == null)
                        return Status.FAIL_INVALID_PAYMENT;
                    if (GetPaidMonths(PaymentTypes.TRANSPORTATION).Contains(payment.PaidMonth.Value))
                        return Status.FAIL_MONTH_ALREADY_PAID;
                    break;
            }
            if (payment.PaidMonth != null)
            {
                payment.Title += $" شهر {Months.NAMES[payment.PaidMonth.Value]}";
            }
            payment.StudentID = student.ID;
            payment.OnAmountUpdate += UpdateTotalAmount;
            this.Payments.Add(payment);
            UpdateTotalAmount();
            return Status.SUCCESS;
        }
        public Status ValidatePayments()
        {
            if (Payments.Count == 0)
                return Status.FAIL_NO_PAYMENTS;

            if (GetRegistrationCount() > 1)
                return Status.FAIL_DUPLICATE_REGISTRATION;

            return Status.SUCCESS;
        }
        public int GetRegistrationCount()
        {
            short regCount = 0;
            if (student.IsRegistered)
                regCount++;

            foreach (Payment payment in this.Payments)
            {
                if (payment.PaymentTypeID == (int)PaymentTypes.REGISTRATION)
                    regCount++;
            }

            return regCount;
        }
        public List<int> GetPaidMonths(PaymentTypes type)
        {
            List<int> result = student.GetPaidMonths(type);
            foreach (Payment payment in this.Payments)
            {
                if (payment.PaymentTypeID == (int)type)
                    result.Add(payment.PaidMonth.Value);
            }
            return result;
        }
        public bool RemovePayment(Payment payment)
        {
            bool res = !Payments.Remove(payment);
            UpdateTotalAmount();
            return res;
        }
        public void ClearPayments()
        {
            if (ID != -1)
                return;
            Payments.Clear();
        }
        private bool Insert()
        {
            InvoiceModel model = _InvoiceToModel();
            int res = Invoices.Insert(model);
            if (res > 0)
                _ID = model.ID;
            return res == 0;
        }
        public Status Save()
        {
            if (ID != -1)
                return Status.FAIL_UPDATE_ATTEMPT;

            if (Payments.Count == 0)
                return Status.FAIL_NO_PAYMENTS;

            IssueDate = DateTime.Now;
            if (Insert())
                return Status.FAIL;

            foreach (Payment payment in Payments)
            {
                payment.InvoiceID = ID;
                payment.Insert();
                if (payment.PaymentTypeID == (int)PaymentTypes.REGISTRATION)
                {
                    student.IsRegistered = true;
                    student.Save();
                }
            }

            return Status.SUCCESS;
        }

        public static Invoice Get(int id)
        {
            InvoiceModel model = Invoices.Get(id);
            if (model == null)
                return null;

            Invoice invoice = new Invoice();
            invoice._ModelToInvoice(model);
            invoice.student = Student.Get(invoice.StudentID);

            invoice.Payments = Payment.GetByInvoice(invoice.ID);

            return invoice;
        }
        public static DataTable GetByStudent(int StudentID)
        {
            return Invoices.GetByStudent(StudentID);
        }

        public static decimal GetTotalAmountPerDay(DateTime date)
        {
            return Invoices.GetTotalAmountPerDay(date);
        }
    }
}
