using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleAppDataModel;
using System.Data.SqlClient;
using System.Data;
using Utility;

namespace SampleApp_DAL
{
    public class SentMessageDA
    {
        #region public 
        public string SaveSentMessage(ResponseMessage messageToSave)
        {
            return SaveSentMessageToDB(messageToSave);
        }

        #endregion

        #region private

        private string SaveSentMessageToDB(ResponseMessage messageToSave)
        {
            string retString = string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigUtil.ConnectionString))
                {
                    using (SqlCommand cmdSQL = new SqlCommand("InsertUpdateMessage", cn))
                    {
                    
                        cmdSQL.CommandType = CommandType.StoredProcedure;
                        if (messageToSave.MessageId != null && messageToSave.MessageId > 0) { cmdSQL.Parameters.Add(new SqlParameter("@MessageId", messageToSave.MessageId)); }
                        if (messageToSave.From != null && !string.IsNullOrWhiteSpace(messageToSave.From)) { cmdSQL.Parameters.Add(new SqlParameter("@SentFromPhoneNumber", messageToSave.From)); }
                        if (messageToSave.To != null && !string.IsNullOrWhiteSpace(messageToSave.To)) { cmdSQL.Parameters.Add(new SqlParameter("@SendToPhoneNumber", messageToSave.To)); }
                        if (messageToSave.Body != null && !string.IsNullOrWhiteSpace(messageToSave.Body)) { cmdSQL.Parameters.Add(new SqlParameter("@MessageText", messageToSave.Body)); }

                        if (messageToSave.AccountSid != null && !string.IsNullOrWhiteSpace(messageToSave.AccountSid)) { cmdSQL.Parameters.Add(new SqlParameter("@AccountSid", messageToSave.AccountSid)); }
                        if (messageToSave.ApiVersion != null && !string.IsNullOrWhiteSpace(messageToSave.ApiVersion)) { cmdSQL.Parameters.Add(new SqlParameter("@ApiVersion", messageToSave.ApiVersion)); }
                        if (messageToSave.DateCreated != null && messageToSave.DateCreated > DateTime.MinValue) { cmdSQL.Parameters.Add(new SqlParameter("@DateCreated", messageToSave.DateCreated)); }
                        if (messageToSave.DateSent != null && messageToSave.DateSent > DateTime.MinValue) { cmdSQL.Parameters.Add(new SqlParameter("@DateSent", messageToSave.DateSent)); }
                        if (messageToSave.DateUpdated != null && messageToSave.DateUpdated > DateTime.MinValue) { cmdSQL.Parameters.Add(new SqlParameter("@DateUpdated", messageToSave.DateUpdated)); }
                        if (messageToSave.Direction != null && !string.IsNullOrWhiteSpace(messageToSave.Direction)) { cmdSQL.Parameters.Add(new SqlParameter("@Direction", messageToSave.Direction)); }
                        if (messageToSave.ErrorCode != null) { cmdSQL.Parameters.Add(new SqlParameter("@ErrorCode", messageToSave.ErrorCode)); }
                        if (messageToSave.ErrorMessage != null && !string.IsNullOrWhiteSpace(messageToSave.ErrorMessage)) { cmdSQL.Parameters.Add(new SqlParameter("@ErrorMessage", messageToSave.ErrorMessage)); }
                        if (messageToSave.NumImages != null) { cmdSQL.Parameters.Add(new SqlParameter("@NumImages", messageToSave.NumImages)); }
                        if (messageToSave.NumSegments != null) { cmdSQL.Parameters.Add(new SqlParameter("@NumSegments", messageToSave.NumSegments)); }
                        if (messageToSave.Price != null) { cmdSQL.Parameters.Add(new SqlParameter("@Price", messageToSave.Price)); }
                        if (messageToSave.Sid != null && !string.IsNullOrWhiteSpace(messageToSave.Sid)) { cmdSQL.Parameters.Add(new SqlParameter("@Sid", messageToSave.Sid)); }
                        if (messageToSave.Status != null && !string.IsNullOrWhiteSpace(messageToSave.Status)) { cmdSQL.Parameters.Add(new SqlParameter("@Status", messageToSave.Status)); }

                        cn.Open();
                        cmdSQL.ExecuteNonQuery();
                        cn.Close();
                    

                    }
                }

            }
            catch(Exception ex)
            {
                retString = ex.Message;
            }

            return retString;
        }

        #endregion

    }
}
