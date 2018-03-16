using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace thirdSemesterAPI.Confirm
{
    public class SendMailAuto
    {
        private void SendEmailViaWebApi(string Subject,string Body,string EmailTo )
        {           
            string FromMail = "nevergiveup271196@gmail.com";
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("mail.google.com/mail/u/0/");
            mail.From = new MailAddress(FromMail);
            mail.To.Add(EmailTo);
            mail.Subject = Subject;
            mail.Body = Body;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("nevergiveup271196@gmail.com", "85143958519254");
            SmtpServer.EnableSsl = false;
            SmtpServer.Send(mail);
        }
    }
}