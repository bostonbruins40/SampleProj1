using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class ResponseMessage
    {
        public int? MessageId { get; set; }
        public string AccountSid { get; set; }
        public string ApiVersion { get; set; }
        public string Body { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateSent { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Direction { get; set; }
        public int? ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string From { get; set; }
        public int? NumImages { get; set; }
        public int? NumSegments { get; set; }
        public decimal? Price { get; set; }
        public string Sid { get; set; }
        public string Status { get; set; }
        public string To { get; set; }
    }
}
