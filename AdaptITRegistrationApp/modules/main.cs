using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;

namespace AdaptITRegistrationApp
{

    public class main
    {

        public enum QryStringValues
        {
            alreadyReg = 0,
            qryStringErr = 1,
            insertErr = 2
        }

        public string EmailTemplate_Merge(string EmailAddress, string Password, string Firstname, string Lastname)
        {

            string emailBody = "";
            StreamReader sr = new StreamReader(Sessionhandler.RegistrationDetails.EmailTemplateDirectory + Sessionhandler.RegistrationDetails.EmailTemplateName);

            string body = sr.ReadToEnd();
            sr.Close();

            string eventDetails = "";


            emailBody = body.Replace("[Firstname]", Firstname).Replace("[Lastname]", Lastname).Replace("[EmailAddress]", EmailAddress).Replace("[Password]", Password).Replace("[EmailAddress]", EmailAddress).Replace("%5BEmailAddress%5D", EmailAddress).Replace("%5BPassword%5D", Password);

            if (SendEmail(emailBody, EmailAddress) == "0")
            {
                return "Email was successfully sent";
                //return PasswordUpdate(Password, Sessionhandler.RegID, EmailAddress);
            }
            else
            {
                return "Email was not sent. Registration table in the database was not updated";
            }

        }

        public string EmailTemplate_Merge_AutoSend(string EmailAddress, string Password, string Firstname, string Lastname)
        {
            string emailBody = "";
            //StreamReader sr = new StreamReader(System.Configuration.ConfigurationManager.AppSettings.Get("EmailTemplateDirectory") + TemplateName);
            StreamReader sr = new StreamReader(Sessionhandler.RegistrationDetails.EmailTemplateDirectory + Sessionhandler.RegistrationDetails.EmailTemplateName);

            string body = sr.ReadToEnd();
            sr.Close();

            string eventDetails = "";
            

            emailBody = body.Replace("[Firstname]", Firstname).Replace("[Lastname]", Lastname).Replace("[EmailAddress]", EmailAddress).Replace("[Password]", Password).Replace("[EmailAddress]", EmailAddress).Replace("%5BEmailAddress%5D", EmailAddress).Replace("%5BPassword%5D", Password);

            if (SendEmail(emailBody, EmailAddress) == "0")
            {
                return "Email was successfully sent";
            }
            else
            {
                return "Email was not sent. Registration table in the database was not updated";
            }

        }

        public string SendEmail(string emailBody, string emailAddress)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            string SMTPUsername = System.Configuration.ConfigurationManager.AppSettings.Get("MailSMTPAuthUsername");
            string SMTPPassword = System.Configuration.ConfigurationManager.AppSettings.Get("MailSMTPAuthPassword");
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential(SMTPUsername, SMTPPassword);
            string SMTPServer = System.Configuration.ConfigurationManager.AppSettings.Get("MailSMTPServer");
            string FromName = System.Configuration.ConfigurationManager.AppSettings.Get("MailSMTPFromName");
            string FromAddress = System.Configuration.ConfigurationManager.AppSettings.Get("MailSMTPFromAddress");
            int Port = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings.Get("MailPort"));
            bool SSL = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("MailSSL"));
            string BCC = System.Configuration.ConfigurationManager.AppSettings.Get("MailBcc");
            string Subject = Sessionhandler.RegistrationDetails.EmailRegistrationSubject;

            System.Net.Mail.MailAddress fromAdr = new System.Net.Mail.MailAddress(FromAddress, FromName);
            System.Net.Mail.MailAddress bccAdr = new System.Net.Mail.MailAddress(BCC);
            System.Net.Mail.SmtpClient emailer = new System.Net.Mail.SmtpClient(SMTPServer);

            emailer.UseDefaultCredentials = false;
            emailer.Credentials = cred;
            emailer.Port = Port;
            emailer.EnableSsl = SSL;

            msg.IsBodyHtml = true;
            msg.Body = emailBody;
            msg.From = fromAdr;
            msg.To.Add(emailAddress);
            msg.Bcc.Add(bccAdr);
            msg.Subject = Subject;

            try
            {
                emailer.Send(msg);
                return "0";
                
            }
            catch (Exception ex)
            {

               return ex.ToString();
            }

        }

        

    }

}