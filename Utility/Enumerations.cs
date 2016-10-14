using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Enumerations
    {
        public enum MessageResponseCode
        {
            FROM_PhoneNumberInvalid = 21212,
            FROM_NotCapableOfSMS = 21606,
            FROM_SMSQueueIsFull = 21611,
            
            TO_PhoneNumberInvalid = 21211,
            TO_CanNotRoute = 21612,
            TO_NoInternationalPermission = 21408,
            TO_NumberBlacklisted = 21610,
            TO_CanNotAcceptSMS = 21614,
            
        }
    }
}
