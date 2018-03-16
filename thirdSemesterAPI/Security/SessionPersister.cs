using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Security
{
    public class SessionPersister
    {
        public static string Email
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return null;
                }
                var session = HttpContext.Current.Session["email"];
                if (session != null)
                {
                    return session.ToString();
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["email"] = value;
            }
        }
    }
}