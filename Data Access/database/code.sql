
CREATE TABLE "PaymentTypes" (
	"ID"	INTEGER,
	"Title"	TEXT NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT)
);

CREATE TABLE "Students" (
	"ID"	INTEGER,
	"RegNumber"	TEXT,
	"FirstName"	TEXT NOT NULL,
	"LastName"	TEXT NOT NULL,
	"IsMale"	INTEGER DEFAULT 0,
	"BirthDate"	TEXT NOT NULL,
	"Grade"	INTEGER NOT NULL,
	"Group"	INTEGER DEFAULT 1,
	"EntryDate"	TEXT NOT NULL,
	"IsRegistered"	INTEGER DEFAULT 0,
	"IsFed"	INTEGER DEFAULT 0,
	"IsTransported"	INTEGER DEFAULT 0,
	"TuitionCoupon"	NUMERIC DEFAULT 0.00,
	"IsDeleted"	INTEGER DEFAULT 0,
	PRIMARY KEY("ID" AUTOINCREMENT)
);

CREATE TABLE "Invoices" (
	"ID"	INTEGER,
	"StudentID"	INTEGER NOT NULL,
	"IssueDate"	TEXT NOT NULL,
	"TotalAmount"	NUMERIC NOT NULL,
	"Notes"	TEXT,
	PRIMARY KEY("ID" AUTOINCREMENT),
	FOREIGN KEY("StudentID") REFERENCES "Students"("ID")
);

CREATE TABLE "Payments" (
	"ID"	INTEGER,
	"Title"	TEXT NOT NULL,
	"Amount"	NUMERIC NOT NULL,
	"InvoiceID"	INTEGER NOT NULL,
	"PaymentTypeID"	INTEGER NOT NULL,
	"PaidMonth"	INTEGER,
	"StudentID"	INTEGER NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT),
	FOREIGN KEY("PaymentTypeID") REFERENCES "PaymentTypes"("ID"),
	FOREIGN KEY("InvoiceID") REFERENCES "Invoices"("ID")
);

CREATE TABLE "Fees" (
	"ID"	INTEGER,
	"Title"	TEXT NOT NULL,
	"PaymentTypeID"	INTEGER DEFAULT 5,
	"Grade"	INTEGER DEFAULT NULL,
	"Amount"	NUMERIC NOT NULL,
	"IsDeletable"	INTEGER DEFAULT 1,
	FOREIGN KEY("PaymentTypeID") REFERENCES "PaymentTypes"("ID"),
	PRIMARY KEY("ID" AUTOINCREMENT)
);

CREATE TABLE "Debts" (
	"ID"	INTEGER,
	"StudentID"	INTEGER NOT NULL,
	"PaymentTypeID"	INTEGER NOT NULL,
	"DebtMonth"	INTEGER NOT NULL,
	"Amount"	NUMERIC NOT NULL,
	FOREIGN KEY("StudentID") REFERENCES "Students"("ID"),
	FOREIGN KEY("PaymentTypeID") REFERENCES "PaymentTypes"("ID"),
	PRIMARY KEY("ID" AUTOINCREMENT)
);

CREATE TABLE "Expenses" (
	"ID"	INTEGER,
	"IssueDate"	TEXT NOT NULL,
	"Amount"	NUMERIC NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT)
);



CREATE VIEW viewStudentsList
AS
	select 
		ID,
		RegNumber,
		FirstName,
		LastName,
		CASE IsMale
			WHEN 0 THEN 'أنثى'
			ELSE 'ذكر'
		END as Gender,
		CASE Grade
			WHEN 0 THEN 'تحضيري'
			WHEN 1 THEN 'أولى'
			WHEN 2 THEN 'ثانية'
			WHEN 3 THEN 'ثالثة'
			WHEN 4 THEN 'رابعة'
			WHEN 5 THEN 'خامسة'
			ELSE 'غير محدد'
		END as GradeString,
		EntryDate,
		CASE IsFed
			WHEN 0 THEN 'غير مشترك'
			Else 'مشترك'
		END as IsFed,
		CASE IsTransported
			WHEN 0 THEN 'غير مشترك'
			Else 'مشترك'
		END as IsTransported,
		TuitionCoupon * 100 as TuitionCoupon
	from Students
	where IsDeleted = 0
;

CREATE VIEW viewStudentsArabic AS
SELECT
	RegNumber as 'رقم التسجيل',
	FirstName as 'الإسم',
	LastName as 'اللقب',
	CASE IsMale
		WHEN 0 THEN 'أنثى'
		ELSE 'ذكر'
	END as 'الجنس',
	CASE Grade
		WHEN 1 THEN 'أولى'
		WHEN 2 THEN 'ثانية'
		WHEN 3 THEN 'ثالثة'
		WHEN 4 THEN 'رابعة'
		WHEN 5 THEN 'خامسة'
		ELSE 'تحضيري'
	END as 'المستوى',
	"Group" as 'المجموعة',
	BirthDate as 'تاريخ الميلاد',
	EntryDate as 'تاريخ الدخول',
	CASE IsFed
		WHEN 0 THEN 'غير مشترك'
		Else 'مشترك'
	END as 'خدمة الإطعام',
	CASE IsTransported
		WHEN 0 THEN 'غير مشترك'
		Else 'مشترك'
	END as 'خدمة النقل',
	TuitionCoupon * 100 as 'نسبة الخصم'
FROM Students
where IsDeleted = 0
;

create VIEW viewFees as 
select ID, Title, Amount, IsDeletable 
from Fees
;

CREATE VIEW viewFinances AS
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
;


CREATE VIEW viewFedStudents AS
SELECT
	RegNumber as 'رقم التسجيل',
	FirstName as 'الإسم',
	LastName as 'اللقب',
	CASE IsMale
		WHEN 0 THEN 'أنثى'
		ELSE 'ذكر'
	END as 'الجنس',
	CASE Grade
		WHEN 1 THEN 'أولى'
		WHEN 2 THEN 'ثانية'
		WHEN 3 THEN 'ثالثة'
		WHEN 4 THEN 'رابعة'
		WHEN 5 THEN 'خامسة'
		ELSE 'تحضيري'
	END as 'المستوى',
	"Group" as 'المجموعة',
	BirthDate as 'تاريخ الميلاد',
	EntryDate as 'تاريخ الدخول'
FROM Students
WHERE IsFed = 1 AND IsDeleted = 0
;


CREATE VIEW viewTransportedStudents AS
SELECT
	RegNumber as 'رقم التسجيل',
	FirstName as 'الإسم',
	LastName as 'اللقب',
	CASE IsMale
		WHEN 0 THEN 'أنثى'
		ELSE 'ذكر'
	END as 'الجنس',
	CASE Grade
		WHEN 1 THEN 'أولى'
		WHEN 2 THEN 'ثانية'
		WHEN 3 THEN 'ثالثة'
		WHEN 4 THEN 'رابعة'
		WHEN 5 THEN 'خامسة'
		ELSE 'تحضيري'
	END as 'المستوى',
	"Group" as 'المجموعة',
	BirthDate as 'تاريخ الميلاد',
	EntryDate as 'تاريخ الدخول'
FROM Students
WHERE IsTransported = 1 AND IsDeleted = 0
;
			




insert into PaymentTypes( "Title" ) values 
('التسجيل'),
('التمدرس'),
('الإطعام'),
('النقل'),
('أخرى')
;

INSERT into Fees 
(Title, PaymentTypeID, Grade, Amount, IsDeletable) 
VALUES
('حقوق التسجيل', 1, NULL, 10000, 0),
('حقوق التمدرس للسنة التحضيرية', 2, 0, 10000, 0),
('حقوق التمدرس للسنة الأولى', 2, 1, 10000, 0),
('حقوق التمدرس للسنة الثانية', 2, 2, 10000, 0),
('حقوق التمدرس للسنة الثالثة', 2, 3, 10000, 0),
('حقوق التمدرس للسنة الرابعة', 2, 4, 10000, 0),
('حقوق التمدرس للسنة الخامسة', 2, 5, 10000, 0),
('حقوق الإطعام', 3, NULL, 2500, 0),
('حقوق  النقل', 4, NULL, 1500, 0)
;

