using Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Logic
{
    public class Fee
    {
        private int _ID;
        private string _Title;
        public int _PaymentTypeID;
        public int? _Grade;
        public decimal _Amount; 

        public int ID 
        { 
            get { return _ID; }
            private set { _ID = value; }
        }
        public string Title
        {
            get { return _Title; }
            set
            {
                if (PaymentTypeID == (int)PaymentTypes.OTHER)
                    _Title = value;
            }
        }
        public int PaymentTypeID
        {
            get { return _PaymentTypeID; }
        }
        public int? Grade
        {
            get { return _Grade; }
            set { _Grade = value; }
        }
        public decimal Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        public Fee()
        {
            _ID = -1;
            _PaymentTypeID = (int)PaymentTypes.OTHER;
            _Grade = null;
        }
        private void _ModelToFee(FeeModel model)
        {
            _ID = model.ID;
            _Title = model.Title;
            _PaymentTypeID = model.PaymentTypeID;
            _Grade = model.Grade;
            _Amount = model.Amount;
        }
        private FeeModel _FeeToModel()
        {
            FeeModel model = new FeeModel();
            model.ID = _ID;
            model.Title = _Title;
            model.PaymentTypeID = _PaymentTypeID;
            model.Grade = _Grade;
            model.Amount = _Amount;
            model.IsDeletable = (PaymentTypeID == (int)PaymentTypes.OTHER);
            return model;
        }
        private bool _Insert()
        {
            FeeModel model = _FeeToModel();
            int result = Fees.Insert(model);
            if (result != 0)
                this.ID = model.ID;
            return result == 0;
        }
        private bool _Update()
        {
            FeeModel model = _FeeToModel();
            return Fees.Update(model) == 0;
        }
        public bool Save()
        {
            if (ID == -1)
                return _Insert();
            else
                return _Update();
        }
        
        public static bool Delete(int id)
        {
            return Fees.Delete(id) == 0;
        }
        public static Fee Get(int id)
        {
            var model = Fees.Get(id);
            if (model == null)
                return null;

            Fee fee = new Fee();
            fee._ModelToFee(model);
            return fee;
        }
        public static DataTable Get()
        {
            return Fees.Get();
        }
    }
}
