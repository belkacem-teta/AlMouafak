using Dapper;
using System;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Data_Access
{
    internal interface IModel
    {
        int ID { get; set; }
    }
    internal class BaseTable<Model> where Model : IModel
    {
        public string TableName { get; set; }
        public string[] attr { get; set; }
        internal BaseTable(string tableName, string[] attr)
        {
            TableName = tableName;
            this.attr = attr;
        }
        private string _GetInsertQuery()
        {
            StringBuilder sb = new StringBuilder($"Insert INTO {TableName} (");
            for (int i = 1; i < attr.Length; i++)
            {
                sb.Append("\"");
                sb.Append(attr[i]);
                sb.Append("\"");
                if (i != attr.Length - 1)
                    sb.Append(", ");
            }
            sb.Append(") VALUES (");
            for (int i = 1; i < attr.Length; i++)
            {
                sb.Append("@");
                sb.Append(attr[i]);
                if (i != attr.Length - 1)
                    sb.Append(", ");
            }
            sb.Append(");");
            return sb.ToString();
        }
        private string _GetUpdateQuery()
        {
            StringBuilder sb = new StringBuilder($"UPDATE {TableName} SET ");
            for (int i = 1; i < attr.Length; i++)
            {
                sb.Append($"\"{attr[i]}\" = @{attr[i]}");
                if (i != attr.Length - 1)
                    sb.Append(", ");
            }
            sb.Append(" WHERE ID = @ID;");
            return sb.ToString();
        }
        public int Insert(Model model)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string query = _GetInsertQuery();
                int rowsAffected = connection.Execute(query, model);
                if (rowsAffected > 0)
                {
                    var newID = Convert.ToInt32(connection.ExecuteScalar($"SELECT seq from sqlite_sequence WHERE name = '{TableName}';"));
                    model.ID = newID;
                }
                return rowsAffected;
            }

        }
        public int Update(Model model)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string query = _GetUpdateQuery();
                var rowsAffected = connection.Execute(query, model);
                return rowsAffected;
            }
        }
        public Model Get(int id)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string sql = $"SELECT * FROM {TableName} where ID = @ID;";
                return connection.QuerySingleOrDefault<Model>(sql, new { ID = id });
            }
        }
        public DataTable Get()
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string sql = $"SELECT * FROM {TableName} WHERE IsDeleted = 0;";
                var reader = connection.ExecuteReader(sql);
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }
        public int Delete(int id)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string query = $"DELETE FROM {TableName} WHERE ID = @ID";
                var rowsAffected = connection.Execute(query, new { ID = id });
                return rowsAffected;
            }
        }
    }
}
