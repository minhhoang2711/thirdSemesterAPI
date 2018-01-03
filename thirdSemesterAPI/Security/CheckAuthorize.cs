using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace thirdSemesterAPI.Security
{
    public class CheckAuthorize : AuthorizeAttribute
    {
        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    if (string.IsNullOrEmpty(SessionPersister.Username))
        //    {
        //        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Account", Action = "Index" }));
        //    }
        //    else
        //    {
        //        AccountModel accountModel = new AccountModel();
        //        var account = accountModel.Find(SessionPersister.Username);
        //        MyPrincial myPrincial = new MyPrincial(account);
        //        if (!myPrincial.IsInRole(Roles))
        //        {
        //            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "UnAuthor", Action = "Index" }));
        //        }
        //    }
        //}
    }
}