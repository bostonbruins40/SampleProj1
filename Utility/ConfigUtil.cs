using System.Web.Configuration;
using System.Configuration;

namespace Utility
{
    public class ConfigUtil
    {
        public static string TwilioAccountSid = WebConfigurationManager.AppSettings["TwilioAccountSid"];
        public static string TwilioAuthToken = WebConfigurationManager.AppSettings["TwilioAuthToken"];
        public static string TwilioPhoneNumber = WebConfigurationManager.AppSettings["TwilioPhoneNumber"];

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
    }
}
