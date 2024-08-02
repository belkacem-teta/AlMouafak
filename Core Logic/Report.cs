﻿using ClosedXML.Excel;
using Data_Access;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Logic
{
    public class Report
    {
        static CultureInfo dz = new CultureInfo("ar-DZ");
        private static List<Payment> GetOrderedPaymentsList(List<Payment> payments, PaymentTypes type)
        {
            List<Payment> result = payments
                .Where(payment => payment.PaymentTypeID == (int)type && payment.PaidMonth > 7)
                .OrderBy(payment => payment.PaidMonth)
                .ToList();
            result.AddRange(payments
                .Where(payment => payment.PaymentTypeID == (int)type && payment.PaidMonth < 7)
                .OrderBy(payment => payment.PaidMonth)
                .ToList()
                );
            return result;
        }
        public static void MakeExcelInvoice(Invoice invoice, string savePath)
        {
            string templatePath = ConfigurationManager.AppSettings["PathToInvoiceTemplate"];
            string excelOutputPath = Path.Combine(savePath, $"Invoice{invoice.ID}.xlsx");
            string pdfOutputPath = Path.Combine(savePath, $"Invoice{invoice.ID}.pdf");

            using (var workbook = new XLWorkbook(templatePath))
            {
                var worksheet = workbook.Worksheet(1);
                worksheet.Cell("A5").Value = invoice.ID;
                worksheet.Cell("A7").Value = invoice.IssueDate.ToString("g", dz);
                worksheet.Cell("D5").Value = invoice.student.RegNumber;
                worksheet.Cell("D6").Value = invoice.student.FullName;
                worksheet.Cell("D7").Value = invoice.student.GradeString;
                worksheet.Cell("A10").Value = invoice.Notes;
                worksheet.Cell("C18").Value = invoice.TotalAmount.ToString("C", dz);
                worksheet.Cell("C19").Value = Tafqit.Arabic.Money(Convert.ToInt32(invoice.TotalAmount), "دينار جزائري");

                var tuitionPayments = GetOrderedPaymentsList(invoice.Payments, PaymentTypes.TUITION);
                var feedingPayments = GetOrderedPaymentsList(invoice.Payments, PaymentTypes.FEEDING);
                var transportationPayments = GetOrderedPaymentsList(invoice.Payments, PaymentTypes.TRANSPORTATION);
                var otherPayments = invoice.Payments
                    .Where(p => p.PaymentTypeID == (int)PaymentTypes.REGISTRATION)
                    .ToList();
                otherPayments.AddRange(invoice.Payments
                        .Where(p => p.PaymentTypeID == (int)PaymentTypes.OTHER)
                        .ToList()
                    );

                if (tuitionPayments.Count > 0)
                {
                    worksheet.Cell("E10").Value = Months.NAMES[tuitionPayments.First().PaidMonth.Value];
                    worksheet.Cell("D10").Value = Months.NAMES[tuitionPayments.Last().PaidMonth.Value];
                    worksheet.Cell("C10").Value = tuitionPayments.Sum(payment => payment.Amount).ToString("C", dz);
                }
                if (feedingPayments.Count > 0)
                {
                    worksheet.Cell("E11").Value = Months.NAMES[feedingPayments.First().PaidMonth.Value];
                    worksheet.Cell("D11").Value = Months.NAMES[feedingPayments.Last().PaidMonth.Value];
                    worksheet.Cell("C11").Value = feedingPayments.Sum(payment => payment.Amount).ToString("C", dz);
                }
                if (transportationPayments.Count > 0)
                {
                    worksheet.Cell("E12").Value = Months.NAMES[transportationPayments.First().PaidMonth.Value];
                    worksheet.Cell("D12").Value = Months.NAMES[transportationPayments.Last().PaidMonth.Value];
                    worksheet.Cell("C12").Value = transportationPayments.Sum(payment => payment.Amount).ToString("C", dz);
                }
                short counter = 14;
                foreach (Payment p in otherPayments)
                {
                    worksheet.Cell($"D{counter}").Value = p.Title;
                    worksheet.Cell($"C{counter}").Value = p.Amount.ToString("C", dz);
                    if (counter == 16)
                        break;
                    counter++;
                }


                // filling the second invoice
                worksheet.Cell("A26").Value = worksheet.Cell("A5").Value;
                worksheet.Cell("A28").Value = worksheet.Cell("A7").Value;
                worksheet.Cell("D26").Value = worksheet.Cell("D5").Value;
                worksheet.Cell("D27").Value = worksheet.Cell("D6").Value;
                worksheet.Cell("D28").Value = worksheet.Cell("D7").Value;
                worksheet.Cell("A31").Value = worksheet.Cell("A10").Value;
                worksheet.Cell("C39").Value = worksheet.Cell("C18").Value;
                worksheet.Cell("C40").Value = worksheet.Cell("C19").Value;

                worksheet.Cell("C31").Value = worksheet.Cell("C10").Value;
                worksheet.Cell("D31").Value = worksheet.Cell("D10").Value;
                worksheet.Cell("E31").Value = worksheet.Cell("E10").Value;
                worksheet.Cell("C32").Value = worksheet.Cell("C11").Value;
                worksheet.Cell("D32").Value = worksheet.Cell("D11").Value;
                worksheet.Cell("E32").Value = worksheet.Cell("E11").Value;
                worksheet.Cell("C33").Value = worksheet.Cell("C12").Value;
                worksheet.Cell("D33").Value = worksheet.Cell("D12").Value;
                worksheet.Cell("E33").Value = worksheet.Cell("E12").Value;

                worksheet.Cell("C35").Value = worksheet.Cell("C14").Value;
                worksheet.Cell("D35").Value = worksheet.Cell("D14").Value;
                worksheet.Cell("C36").Value = worksheet.Cell("C15").Value;
                worksheet.Cell("D36").Value = worksheet.Cell("D15").Value;
                worksheet.Cell("C37").Value = worksheet.Cell("C16").Value;
                worksheet.Cell("D37").Value = worksheet.Cell("D16").Value;

                workbook.SaveAs(excelOutputPath);
            }
        }


        public static void MakeReport(string filePath, string title, DataTable data)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.AddWorksheet();

                worksheet.Cell("A1").Value = title;

                short counter = 1;
                foreach (DataColumn col in data.Columns)
                {
                    worksheet.Cell(2, counter).Value = col.ColumnName;
                    counter++;
                }

                worksheet.Cell("A3").InsertData(data);
                worksheet.Range(2, 1, data.Rows.Count + 2, data.Columns.Count).CreateTable();
                workbook.SaveAs(filePath);
            }
        }

        public static void MakeFinancesReport(string filePath)
        {
            string title = $"التقرير المالي من شهر سبتمبر إلى شهر {Months.NAMES[DateTime.Now.Month]}";
            var dt = Reports.GetFinancesView();
            MakeReport(filePath, title, dt);
        }

        public static void MakeFedStudentsReport(string filePath)
        {
            string title = $"قائمة الإطعام لشهر {Months.NAMES[DateTime.Now.Month]}";
            var dt = Reports.GetFedStudents();
            MakeReport(filePath, title, dt);
        }

        public static void MakeTransportedStudentsReport(string filePath)
        {
            string title = $"قائمة النقل لشهر {Months.NAMES[DateTime.Now.Month]}";
            var dt = Reports.GetTransportedStudents();
            MakeReport(filePath, title, dt);
        }

        public static void MakeStudentsReport(string filePath)
        {
            string title = $"قائمة التلاميذ لشهر {Months.NAMES[DateTime.Now.Month]}";
            var dt = Reports.GetStudents();
            MakeReport(filePath, title, dt);
        }

    }
}
