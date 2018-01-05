﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace thirdSemesterAPI.Controllers
{
    [RoutePrefix("api/sendmail")]
    public class SendMailController : ApiController
    {
        [HttpGet]
        [Route("sendmailviawebapi")]
        private void SendEmailViaWebApi(string Subject, string Body, string EmailTo)
        {
            string FromMail = "nevergiveup271196@gmail.com";
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(FromMail);
            mail.To.Add(EmailTo);
            mail.Subject = Subject;
            mail.Body = Body;
            SmtpServer.Port = 465;
            SmtpServer.Credentials = new System.Net.NetworkCredential("nevergiveup271196@gmail.com", "85143958519254");
            SmtpServer.EnableSsl = false;
            SmtpServer.Send(mail);
        }
    }
}
