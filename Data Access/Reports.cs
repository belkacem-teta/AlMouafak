using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class Reports
    {
        public static DataTable GetFinancesView()
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string sql = "SELECT * FROM viewFinances;";
                var reader = connection.ExecuteReader(sql);
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }
        public static DataTable GetFedStudents()
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string sql = "SELECT * FROM viewFedStudents;";
                var reader = connection.ExecuteReader(sql);
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }
        public static DataTable GetTransportedStudents()
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string sql = "SELECT * FROM viewTransportedStudents;";
                var reader = connection.ExecuteReader(sql);
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }
        public static DataTable GetStudents()
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string sql = "SELECT * FROM viewStudentsArabic;";
                var reader = connection.ExecuteReader(sql);
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }
    }
}
