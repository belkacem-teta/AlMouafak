using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class DebtModel : IModel
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int PaymentTypeID { get; set; }
        public int DebtMonth { get;  set; }
        public decimal Amount { get; set; }
    }
    public class Debts
    {
        private static BaseTable<DebtModel> table = new BaseTable<DebtModel>("Debts",
            new string[]{
                "ID",
                "StudentID",
                "PaymentTypeID",
                "DebtMonth",
                "Amount",
            });

        public static int Insert(DebtModel model)
        {
            return table.Insert(model);
        }

        public static int Delete(int id)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string query = "DELETE FROM Debts WHERE ID = @ID";
                var rowsAffected = connection.Execute(query, new {ID = id});
                return rowsAffected;
            }
        }

        public static DebtModel Get(int id)
        {
            return table.Get(id);
        }

        public static List<int> GetDebtMonths(int studentID, int paymentTypeID)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string query = "SELECT DebtMonth FROM Debts WHERE PaymentTypeID = @PaymentTypeID AND StudentID = @StudentID";
                List<int> result = connection.Query<int>(query, new { PaymentTypeID = paymentTypeID, StudentID = studentID }).AsList();
                return result;
            }
        }

        public static DebtModel Get(int studentID, int paymentTypeID)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string query = "SELECT * FROM Debts WHERE PaymentTypeID = @PaymentTypeID AND StudentID = @StudentID;";
                var result = connection.QueryFirstOrDefault<DebtModel>(query, new { PaymentTypeID = paymentTypeID, StudentID = studentID });
                return result;
            }
        }

        public static DebtModel Get(int studentID, int paymentTypeID, int debtMonth)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string query = "SELECT * FROM Debts WHERE PaymentTypeID = @PaymentTypeID AND StudentID = @StudentID AND DebtMonth = @DebtMonth;";
                var result = connection.QueryFirstOrDefault<DebtModel>(query, new { PaymentTypeID = paymentTypeID, StudentID = studentID, DebtMonth = debtMonth });
                return result;
            }
        }


    }
}
