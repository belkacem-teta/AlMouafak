using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class InvoiceModel : IModel
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Notes { get; set; }
    }
    public class Invoices
    {
        private static BaseTable<InvoiceModel> table = new BaseTable<InvoiceModel>("Invoices",
            new string[]{
                "ID",
                "StudentID",
                "IssueDate",
                "TotalAmount",
                "Notes",
            });
        public static int Insert(InvoiceModel model)
        {
            return table.Insert(model);
        }
        public static InvoiceModel Get(int id)
        {
            return table.Get(id);
        }
    }
}
