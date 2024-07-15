using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    internal class Helper
    {
        public static readonly string defaultConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
    }
}
