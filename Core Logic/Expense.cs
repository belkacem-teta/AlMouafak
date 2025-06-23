using Data_Access;
using System;

namespace Core_Logic
{
    public class Expense
    {
        private int _ID;
        private DateTime _IssueDate;
        private decimal _Amount;

        public int ID { get { return _ID; } private set { _ID = value; } }
        public DateTime IssueDate { get { return _IssueDate; } set { _IssueDate = value; } }
        public decimal Amount { get { return _Amount; } set { _Amount = value; } }

        public Expense()
        {
            ID = -1;
        }

        private ExpenseModel _ObjToModel()
        {
            ExpenseModel model = new ExpenseModel();
            model.ID = _ID;
            model.IssueDate = _IssueDate.Date;
            model.Amount = _Amount;
            return model;
        }
        private void _ModelToObj(ExpenseModel model)
        {
            _ID = model.ID;
            _IssueDate = model.IssueDate;
            _Amount = model.Amount;
        }

        private bool Insert()
        {
            return Expenses.Insert(this._ObjToModel()) == 0;
        }

        private bool Update()
        {
            return Expenses.Update(this._ObjToModel()) == 0;
        }

        public bool Save()
        {
            if (ID == -1)
                return Insert();
            else
                return Update();
        }

        public static Expense Get(DateTime issueDate)
        {
            ExpenseModel model = Expenses.Get(issueDate);
            if (model == null)
                return null;

            Expense obj = new Expense();
            obj._ModelToObj(model);
            return obj;
        }

    }
}
