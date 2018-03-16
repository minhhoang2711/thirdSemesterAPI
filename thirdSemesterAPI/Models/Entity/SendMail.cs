using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace thirdSemesterAPI.Models.Entity
{
    public class SendMail
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string EmailTo { get; set; }
    }
}