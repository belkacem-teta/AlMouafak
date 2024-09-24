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
        
        public static DataTable GetFinancesView()
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string sql = @"
                    SELECT 
                        s.RegNumber as 'رقم التسجيل',
                        s.FirstName as 'الإسم',
                        s.LastName as 'اللقب',
                        IFNULL(TotalRegisteration, 0) as 'إجمالي تسديد حقوق التسجيل',
                        IFNULL(TotalTuition, 0) as 'إجمالي تسديد حقوق التمدرس',
                        IFNULL(TotalFeeding, 0) as 'إجمالي تسديد حقوق الإطعام',
                        IFNULL(TotalTransportation, 0) as 'إجمالي تسديد حقوق النقل',
                        IFNULL(TotalOthers, 0) as 'إجمالي تسديد حقوق أخرى',
                        IFNULL(p.TotalPaid, 0) AS 'إجمالي التسديد', 
                        IFNULL(TotalRegisterationDebt, 0) as 'باقي تسديد حقوق التسجيل', 
                        IFNULL(TotalTuitionDebt, 0) as 'باقي تسديد حقوق التمدرس', 
                        IFNULL(TotalFeedingDebt, 0) as 'باقي تسديد حقوق الإطعام', 
                        IFNULL(TotalTransportationDebt, 0) as 'باقي تسديد حقوق النقل', 
                        IFNULL(d.TotalDebt, 0) AS 'باقي التسديد'
                    FROM 
                        Students s
                    LEFT JOIN 
                        (SELECT StudentID, Sum(Amount) AS TotalRegisteration
                         FROM Payments
                         WHERE PaymentTypeID = 1
                         GROUP BY StudentID) reg ON s.ID = reg.StudentID
                    LEFT JOIN 
                        (SELECT StudentID, Sum(Amount) AS TotalTuition
                         FROM Payments
                         WHERE PaymentTypeID = 2
                         GROUP BY StudentID) tuition ON s.ID = tuition.StudentID
                    LEFT JOIN 
                        (SELECT StudentID, Sum(Amount) AS TotalFeeding
                         FROM Payments
                         WHERE PaymentTypeID = 3
                         GROUP BY StudentID) feeding ON s.ID = feeding.StudentID
                    LEFT JOIN 
                        (SELECT StudentID, Sum(Amount) AS TotalTransportation
                         FROM Payments
                         WHERE PaymentTypeID = 4
                         GROUP BY StudentID) transp ON s.ID = transp.StudentID
                    LEFT JOIN 
                        (SELECT StudentID, Sum(Amount) AS TotalOthers
                         FROM Payments
                         WHERE PaymentTypeID = 5
                         GROUP BY StudentID) others ON s.ID = others.StudentID
                    LEFT JOIN 
                        (SELECT StudentID, SUM(Amount) AS TotalPaid
                         FROM Payments
                         GROUP BY StudentID) p ON s.ID = p.StudentID
                    LEFT JOIN 
                        (SELECT StudentID, SUM(Amount) AS TotalRegisterationDebt
                         FROM Debts
                         WHERE PaymentTypeID = 1
                         GROUP BY StudentID) regdebt ON s.ID = regdebt.StudentID
                    LEFT JOIN 
                        (SELECT StudentID, SUM(Amount) AS TotalTuitionDebt
                         FROM Debts
                         WHERE PaymentTypeID = 2
                         GROUP BY StudentID) tuitionDebt ON s.ID = tuitionDebt.StudentID
                    LEFT JOIN 
                        (SELECT StudentID, SUM(Amount) AS TotalFeedingDebt
                         FROM Debts
                         WHERE PaymentTypeID = 3
                         GROUP BY StudentID) feedingDebt ON s.ID = feedingDebt.StudentID
                    LEFT JOIN 
                        (SELECT StudentID, SUM(Amount) AS TotalTransportationDebt
                         FROM Debts
                         WHERE PaymentTypeID = 4
                         GROUP BY StudentID) transpDebt ON s.ID = transpDebt.StudentID
                    LEFT JOIN 
                        (SELECT StudentID, SUM(Amount) AS TotalDebt
                         FROM Debts
                         GROUP BY StudentID) d ON s.ID = d.StudentID
                ";
                var reader = connection.ExecuteReader(sql);
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }
        
        public static DataTable GetFinancesView(int month)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string sql = @"
                    SELECT 
                        s.RegNumber as 'رقم التسجيل',
                        s.FirstName as 'الإسم',
                        s.LastName as 'اللقب',
                        IFNULL(TotalTuition, 0) as 'تسديد حقوق التمدرس',
                        IFNULL(TotalFeeding, 0) as 'تسديد حقوق الإطعام',
                        IFNULL(TotalTransportation, 0) as 'تسديد حقوق النقل',
                        IFNULL(p.TotalPaid, 0) AS 'إجمالي التسديد', 
                        IFNULL(TotalTuitionDebt, 0) as 'باقي تسديد حقوق التمدرس', 
                        IFNULL(TotalFeedingDebt, 0) as 'باقي تسديد حقوق الإطعام', 
                        IFNULL(TotalTransportationDebt, 0) as 'باقي تسديد حقوق النقل', 
                        IFNULL(d.TotalDebt, 0) AS 'باقي التسديد'
                    FROM 
                        Students s
                    LEFT JOIN 
                        (SELECT Payments.StudentID, Sum(Amount) AS TotalTuition
                         FROM Payments 
                         WHERE PaymentTypeID = 2 AND PaidMonth = @month
                         GROUP BY Payments.StudentID) tuition ON s.ID = tuition.StudentID
                    LEFT JOIN 
                        (SELECT Payments.StudentID, Sum(Amount) AS TotalFeeding
                         FROM Payments 
                         WHERE PaymentTypeID = 3 AND PaidMonth = @month
                         GROUP BY Payments.StudentID) feeding ON s.ID = feeding.StudentID
                    LEFT JOIN 
                        (SELECT Payments.StudentID, Sum(Amount) AS TotalTransportation
                         FROM Payments 
                         WHERE PaymentTypeID = 4 AND PaidMonth = @month
                         GROUP BY Payments.StudentID) transp ON s.ID = transp.StudentID
                    LEFT JOIN 
                        (SELECT Payments.StudentID, SUM(Amount) AS TotalPaid
                         FROM Payments
                         WHERE PaidMonth = @month
                         GROUP BY Payments.StudentID) p ON s.ID = p.StudentID
                    LEFT JOIN 
                        (SELECT StudentID, SUM(Amount) AS TotalTuitionDebt
                         FROM Debts
                         WHERE PaymentTypeID = 2 AND DebtMonth = @month
                         GROUP BY StudentID) tuitionDebt ON s.ID = tuitionDebt.StudentID
                    LEFT JOIN 
                        (SELECT StudentID, SUM(Amount) AS TotalFeedingDebt
                         FROM Debts
                         WHERE PaymentTypeID = 3 AND DebtMonth = @month
                         GROUP BY StudentID) feedingDebt ON s.ID = feedingDebt.StudentID
                    LEFT JOIN 
                        (SELECT StudentID, SUM(Amount) AS TotalTransportationDebt
                         FROM Debts
                         WHERE PaymentTypeID = 4 AND DebtMonth = @month
                         GROUP BY StudentID) transpDebt ON s.ID = transpDebt.StudentID
                    LEFT JOIN 
                        (SELECT StudentID, SUM(Amount) AS TotalDebt
                         FROM Debts
                         WHERE DebtMonth = @month
                         GROUP BY StudentID) d ON s.ID = d.StudentID
                ";
                var reader = connection.ExecuteReader(sql, new
                {
                    month
                });
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }
        
        public static DataTable GetFinancesView(DateTime date)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string sql = @"
                    SELECT 
                        s.RegNumber as 'رقم التسجيل',
                        s.FirstName as 'الإسم',
                        s.LastName as 'اللقب',
                        IFNULL(TotalRegisteration, 0) as 'تسديد حقوق التسجيل',
                        IFNULL(TotalTuition, 0) as 'تسديد حقوق التمدرس',
                        IFNULL(TotalFeeding, 0) as 'تسديد حقوق الإطعام',
                        IFNULL(TotalTransportation, 0) as 'تسديد حقوق النقل',
                        IFNULL(TotalOthers, 0) as 'تسديد حقوق أخرى',
                        IFNULL(p.TotalPaid, 0) AS 'إجمالي التسديد'
                    FROM 
                        Students s
                    LEFT JOIN 
                        (SELECT Payments.StudentID, Sum(Amount) AS TotalRegisteration
                         FROM Payments left join Invoices ON payments.InvoiceID = Invoices.ID 
                         WHERE PaymentTypeID = 1 AND strftime('%Y-%m-%d', Invoices.IssueDate) = @fday
                         GROUP BY Payments.StudentID) reg ON s.ID = reg.StudentID
                    LEFT  JOIN 
                        (SELECT Payments.StudentID, Sum(Amount) AS TotalTuition
                         FROM Payments left join Invoices ON payments.InvoiceID = Invoices.ID 
                         WHERE PaymentTypeID = 2 AND strftime('%Y-%m-%d', Invoices.IssueDate) = @fday
                         GROUP BY Payments.StudentID) tuition ON s.ID = tuition.StudentID
                    LEFT  JOIN 
                        (SELECT Payments.StudentID, Sum(Amount) AS TotalFeeding
                         FROM Payments left join Invoices ON payments.InvoiceID = Invoices.ID 
                         WHERE PaymentTypeID = 3 AND strftime('%Y-%m-%d', Invoices.IssueDate) = @fday
                         GROUP BY Payments.StudentID) feeding ON s.ID = feeding.StudentID
                    LEFT  JOIN 
                        (SELECT Payments.StudentID, Sum(Amount) AS TotalTransportation
                         FROM Payments left join Invoices ON payments.InvoiceID = Invoices.ID 
                         WHERE PaymentTypeID = 4 AND strftime('%Y-%m-%d', Invoices.IssueDate) = @fday
                         GROUP BY Payments.StudentID) transp ON s.ID = transp.StudentID
                    LEFT  JOIN 
                        (SELECT Payments.StudentID, Sum(Amount) AS TotalOthers
                         FROM Payments left join Invoices ON payments.InvoiceID = Invoices.ID 
                         WHERE PaymentTypeID = 5 AND strftime('%Y-%m-%d', Invoices.IssueDate) = @fday
                         GROUP BY Payments.StudentID) others ON s.ID = others.StudentID
                    LEFT  JOIN 
                        (SELECT StudentID, SUM(TotalAmount) AS TotalPaid
                         FROM Invoices
                         WHERE strftime('%Y-%m-%d', Invoices.IssueDate) = @fday
                         GROUP BY StudentID) p ON s.ID = p.StudentID
                    WHERE p.TotalPaid > 0
                ";
                var reader = connection.ExecuteReader(sql, new
                {
                    fday = date.ToString("yyyy-MM-dd")
                });
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }

        public static DataTable GetExpensesView(int month)
        {
            using (var connection = new SQLiteConnection(Helper.defaultConnectionString))
            {
                string sql = @"
                    Select 
                        strftime('%Y-%m-%d', Expenses.IssueDate) as 'التاريخ', 
                        IFNULL(reg.amountSum, 0) as 'إيرادات حقوق التسجيل', 
                        IFNULL(tuition.amountSum, 0) as 'إيرادات حقوق التمدرس',
                        IFNULL(feeding.amountSum, 0) as 'إيرادات حقوق الإطعام',
                        IFNULL(transp.amountSum, 0) as 'إيرادات حقوق النقل',
                        IFNULL(other.amountSum, 0) as 'إيرادات حقوق أخرى',
                        IFNULL(inv.amountSum, 0) as 'مجموع الإيرادات',
                        IFNULL(Expenses.Amount, 0) as 'مجموع النفقات'
                    FROM Expenses 
                        LEFT JOIN 
                            (	select strftime('%Y-%m-%d', IssueDate) as day, SUM(Amount) as amountSum
                                from Payments LEFT JOIN Invoices ON Payments.InvoiceID = Invoices.ID
                                where PaymentTypeID = 1
                                group by strftime('%Y-%m-%d', IssueDate)
                            ) reg ON strftime('%Y-%m-%d', Expenses.IssueDate) = reg.day
                        LEFT JOIN 
                            (	select strftime('%Y-%m-%d', IssueDate) as day, SUM(Amount) as amountSum
                                from Payments LEFT JOIN Invoices ON Payments.InvoiceID = Invoices.ID
                                where PaymentTypeID = 2
                                group by strftime('%Y-%m-%d', IssueDate)
                            ) tuition ON strftime('%Y-%m-%d', Expenses.IssueDate) = tuition.day
                        LEFT JOIN 
                            (	select strftime('%Y-%m-%d', IssueDate) as day, SUM(Amount) as amountSum
                                from Payments LEFT JOIN Invoices ON Payments.InvoiceID = Invoices.ID
                                where PaymentTypeID = 3
                                group by strftime('%Y-%m-%d', IssueDate)
                            ) feeding ON strftime('%Y-%m-%d', Expenses.IssueDate) = feeding.day
                        LEFT JOIN 
                            (	select strftime('%Y-%m-%d', IssueDate) as day, SUM(Amount) as amountSum
                                from Payments LEFT JOIN Invoices ON Payments.InvoiceID = Invoices.ID
                                where PaymentTypeID = 4
                                group by strftime('%Y-%m-%d', IssueDate)
                            ) transp ON strftime('%Y-%m-%d', Expenses.IssueDate) = transp.day
                        LEFT JOIN 
                            (	select strftime('%Y-%m-%d', IssueDate) as day, SUM(Amount) as amountSum
                                from Payments LEFT JOIN Invoices ON Payments.InvoiceID = Invoices.ID
                                where PaymentTypeID = 5
                                group by strftime('%Y-%m-%d', IssueDate)
                            ) other ON strftime('%Y-%m-%d', Expenses.IssueDate) = other.day
                        LEFT JOIN 
                            (	select strftime('%Y-%m-%d', IssueDate) as day, SUM(TotalAmount) as amountSum
                                from Invoices
                                group by strftime('%Y-%m-%d', IssueDate)
                            ) inv ON strftime('%Y-%m-%d', Expenses.IssueDate) = inv.day
                    where strftime('%m', Expenses.IssueDate) = @monthStr
                    order by strftime('%Y-%m-%d', Expenses.IssueDate)
                ";
                var reader = connection.ExecuteReader(sql, new
                {
                    monthStr = month.ToString("00")
                });
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }

    }
}
