using System;

namespace Core_Logic
{
    public struct TuitionYear
    {
        public static readonly DateTime START = new DateTime(2025, 09, 01);
        public static readonly DateTime END = new DateTime(2026, 05, 31);
    }
    public enum PaymentTypes
    {
        REGISTRATION = 1,
        TUITION,
        FEEDING,
        TRANSPORTATION,
        OTHER
    }

    public enum MainFees
    {
        REGISTRATION = 1,
        TUITION_PREP_GRADE,
        TUITION_FIRST_GRADE,
        TUITION_SECOND_GRADE,
        TUITION_THIRD_GRADE,
        TUITION_FOURTH_GRADE,
        TUITION_FIFTH_GRADE,
        FEEDING,
        TRANSPORTATION,
    }

    public enum TuitionMonths
    {
        JAN = 1,
        FEB,
        MAR,
        APR,
        MAY,
        JUN,
        SEP = 9,
        OCT,
        NOV,
        DEC,
    }
    public struct Months
    {
        public static readonly string[] NAMES =
        {
            "",
            "جانفي",
            "فيفري",
            "مارس",
            "أفريل",
            "ماي",
            "جوان",
            "جويلية",
            "أوت",
            "سبتمبر",
            "أكتوبر",
            "نوفمبر",
            "ديسمبر",
        };
    }

    public struct Grades
    {
        public static readonly string[] NAMES = { "تحضيري", "أولى", "ثانية", "ثالثة", "رابعة", "خامسة" };
    }

}
