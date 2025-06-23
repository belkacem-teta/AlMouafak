using System.Configuration;

namespace Data_Access
{
    internal class Helper
    {
        public static readonly string defaultConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
    }
}
