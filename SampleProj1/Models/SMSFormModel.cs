using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SampleProj1.Models
{
    public class SMSFormModel
    {
        [DisplayName("From phone number")]
        public string SentFromPhoneNumber { get; set; }

        [DisplayName("To phone number")]
        public string SendToPhoneNumber { get; set; }

        [DisplayName("Text Message")]
        public string SendToMessage { get; set; }

        [DisplayName("")]
        public string OutcomeMessage { get; set; }
    }
}