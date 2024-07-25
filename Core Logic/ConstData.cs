using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Logic
{
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
        JAN =1,
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
        public static readonly string[] NAMES = {"تحضيري", "أولى", "ثانية", "ثالثة", "رابعة", "خامسة"};
    }

}
