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
    public class Grades
    {
        public static readonly string[] NAMES = {"تحضيري", "أولى", "ثانية", "ثالثة", "رابعة", "خامسة"};
    }
}
