using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Data_Access
{
    public class FeeModel : IModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int PaymentTypeID { get; set; }
        public int? Grade { get; set; }
        public decimal Amount { get; set; }
        public bool IsDeletable { get; set; }
    }
    public class Fees
    {
        private static BaseTable<FeeModel> table = new BaseTable<FeeModel>("Fees",
            new string[]
            {
                "ID",
                "Title",
                "PaymentTypeID",
                "Grade",
                "Amount",
                "IsDeletable"
            });
        public static int Insert(FeeModel model)
        {
            return table.Insert(model);
        }
        public static int Update(FeeModel model)
        {
            return table.Update(model);
        }
        public static int Delete(int id)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string query = $"DELETE FROM Fees WHERE ID = @ID AND IsDeletable = 1";
                var rowsAffected = connection.Execute(query, new { ID = id });
                return rowsAffected;
            }
        }
        public static FeeModel Get(int id)
        {
            return table.Get(id);
        }
        public static DataTable Get()
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string sql = "SELECT * FROM viewFees;";
                var reader = connection.ExecuteReader(sql);
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }

        public static List<int> GetOthersIds()
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string query = $"SELECT ID FROM Fees WHERE PaymentTypeID = 5;";
                return connection.Query<int>(query).AsList();
            }
        }

    }
}
