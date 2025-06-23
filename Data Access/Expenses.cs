using Dapper;
using System;
using System.Data.SQLite;

namespace Data_Access
{
    public class ExpenseModel : IModel
    {
        public int ID { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal Amount { get; set; }
    }
    public class Expenses
    {
        private static BaseTable<ExpenseModel> table = new BaseTable<ExpenseModel>("Expenses",
            new string[]{
                "ID",
                "IssueDate",
                "Amount",
            });

        public static ExpenseModel Get(DateTime issueDate)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string query = "select * from Expenses where strftime('%Y-%m-%d', IssueDate) = @IssueDate;";
                var result = connection.QueryFirstOrDefault<ExpenseModel>(query, new
                {
                    IssueDate = issueDate.ToString("yyyy-MM-dd")
                });
                return result;
            }
        }

        public static int Insert(ExpenseModel model)
        {
            return table.Insert(model);
        }

        public static int Update(ExpenseModel model)
        {
            return table.Update(model);
        }
    }
}
