using Dapper;
using System;
using System.Data;
using System.Data.SQLite;

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
        public static int Delete(int id)
        {
            return table.Delete(id);
        }
        public static DataTable GetByStudent(int studentID)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string sql = "SELECT * FROM Invoices WHERE StudentID = @StudentID ORDER BY IssueDate DESC;";
                var reader = connection.ExecuteReader(sql, new { StudentID = studentID });
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }

        public static decimal GetTotalAmountPerDay(DateTime date)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string query = "SELECT SUM(TotalAmount) FROM Invoices where strftime('%Y', IssueDate) = @y AND strftime('%m', IssueDate) = @m AND strftime('%d', IssueDate) = @d;";
                var result = connection.ExecuteScalar<decimal>(query, new
                {
                    y = date.ToString("yyyy"),
                    m = date.ToString("MM"),
                    d = date.ToString("dd"),
                });
                return result;
            }
        }
    }
}
