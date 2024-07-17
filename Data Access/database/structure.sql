
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
	where IsDeleted == 0
;

create VIEW viewFees as 
select ID, Title, Amount, IsDeletable 
from Fees
;
