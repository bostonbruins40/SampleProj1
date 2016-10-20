using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwilioClient;
using SampleProj1.Models;
using Utility;
using SampleApp_DAL;

namespace SampleProj1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(SMSFormModel frmModel)
        {
            if (frmModel == null)
            {
                frmModel = new SMSFormModel();
            }
            else
            {
                if (Request.HttpMethod == "POST")
                {
                    frmModel.OutcomeMessage = ProcessTextMessageRequest(frmModel);
                }
                else
                {
                    frmModel.OutcomeMessage = "";
                }
            }

            return View(frmModel);
            
        }

        public ActionResult SendSMSMessage()
        {
            return View();
        }

        private string ProcessTextMessageRequest(SMSFormModel frmModel)
        {
            RestClient rClient = new RestClient();
 
            ResponseMessage message = rClient.SendMessage(frmModel.SentFromPhoneNumber, frmModel.SendToPhoneNumber, frmModel.SendToMessage);

            rClient = null;

            return ProcessResponseInfo(message);
        }

        private string ProcessResponseInfo(ResponseMessage message)
        {
            SentMessageDA smDA = new SentMessageDA();
            smDA.SaveSentMessage(message);

            if(message != null && message.ErrorCode != null)
            {
                switch(message.ErrorCode)
                {
                    case (int)Enumerations.MessageResponseCode.FROM_PhoneNumberInvalid: //21212
                        return "The from phone number is not valid.";
                    case (int)Enumerations.MessageResponseCode.FROM_NotCapableOfSMS: //21606
                        return "This from phone number is not owned by your account or is not SMS-capable.";
                    case (int)Enumerations.MessageResponseCode.FROM_SMSQueueIsFull: //21611
                        return "This from number has an SMS message queue that is full";

                    case (int)Enumerations.MessageResponseCode.TO_PhoneNumberInvalid: //21211
                        return "This phone number is invalid.";
                    case (int)Enumerations.MessageResponseCode.TO_CanNotRoute: //21612
                        return "This service cannot route to this number.";
                    case (int)Enumerations.MessageResponseCode.TO_NoInternationalPermission: //21408
                        return "This service doesn't have the international permissions necessary to SMS this number.";
                    case (int)Enumerations.MessageResponseCode.TO_NumberBlacklisted: //21610
                        return "This number is blacklisted for this service.";
                    case (int)Enumerations.MessageResponseCode.TO_CanNotAcceptSMS: //21614
                        return "This number is incapable of receiving SMS messages.";
                    default:
                        return "Message Sent"; 

                }
            }
            else
            {
                return "Message Sent.";
            }
        }
    }
}