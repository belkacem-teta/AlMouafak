using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class PaymentModel : IModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public int InvoiceID { get; set; }
        public int PaymentTypeID { get; set; }
        public int? PaidMonth { get; set; }
        public int StudentID { get; set; }
    }
    public class Payments
    {
        private static BaseTable<PaymentModel> table = new BaseTable<PaymentModel>("Payments",
            new string[]{
                "ID",
                "Title",
                "Amount",
                "InvoiceID",
                "PaymentTypeID",
                "PaidMonth",
                "StudentID"
            });
        public static int Insert(PaymentModel model)
        {
            return table.Insert(model);
        }
        public static PaymentModel Get(int id)
        {
            return table.Get(id);
        }

        public static List<int> GetPaidMonths(int studentID, int paymentTypeID)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string query = "SELECT PaidMonth FROM Payments WHERE PaymentTypeID = @PaymentTypeID AND StudentID = @StudentID";
                List<int> result = connection.Query<int>(query, new { PaymentTypeID = paymentTypeID, StudentID = studentID }).AsList();
                return result;
            }
        }

        public static List<PaymentModel> GetByInvoice(int invoiceID)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string query = "SELECT * FROM Payments WHERE InvoiceID = @InvoiceID;";
                List<PaymentModel> result = connection.Query<PaymentModel>(query, new { InvoiceID = invoiceID }).AsList();
                return result;
            }
        }
        public static bool Exists(int studentID, int paymentTypeID, int paidMonth)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Payments WHERE PaymentTypeID = @PaymentTypeID AND StudentID = @StudentID AND PaidMonth = @PaidMonth;";
                var result = connection.ExecuteScalar<bool>(query, new { PaymentTypeID = paymentTypeID, StudentID = studentID, PaidMonth = paidMonth });
                return result;
            }
        }

    }
}
