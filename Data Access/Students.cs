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
    public class StudentModel : IModel
    {
        public int ID { get; set; }
        public string RegNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMale { get; set; }
        public DateTime BirthDate { get; set; }
        public byte Grade { get; set; }
        public byte Group { get; set; }
        public DateTime EntryDate { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsFed { get; set; }
        public bool IsTransported { get; set; }
        public decimal TuitionCoupon { get; set; }
        public bool IsDeleted { get; set; }
    }
    public static class Students
    {
        internal static BaseTable<StudentModel> table = new BaseTable<StudentModel>("Students",
            new string[]{
            "ID",
            "RegNumber",
            "FirstName",
            "LastName",
            "IsMale",
            "BirthDate",
            "Grade",
            "Group",
            "EntryDate",
            "IsRegistered",
            "IsFed",
            "IsTransported",
            "TuitionCoupon",
            "IsDeleted"
            });
        public static int Insert(StudentModel student)
        {
            return table.Insert(student);
        }
        public static int Update(StudentModel student)
        {
            return table.Update(student);
        }
        public static int Delete(int id)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string query = $"UPDATE Students SET IsDeleted = 1 WHERE ID = @ID";
                var rowsAffected = connection.Execute(query, new {ID = id});
                return rowsAffected;
            }
        }
        public static StudentModel Get(int id)
        {
            return table.Get(id);
        }
        public static StudentModel Get(string firstName, string lastName)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string sql = "SELECT * FROM Students where " +
                    "FirstName LIKE '%' || @FirstName || '%' " +
                    "AND LastName LIKE '%' || @LastName || '%';";
                var student = connection.QueryFirstOrDefault<StudentModel>(sql, new 
                { 
                    FirstName = firstName,
                    LastName = lastName
                });
                return student;
            }
        }
        public static DataTable Get()
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string sql = "SELECT * FROM viewStudentsList;";
                var reader = connection.ExecuteReader(sql);
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }
    }

}
