using Nzh.Faker.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nzh.Faker.App_Start.Handler
{
    public class HandlerLoginAttribute : AuthorizeAttribute
    {
        public bool Ignore = true;

        public HandlerLoginAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Ignore == false)
            {
                return;
            }
            if (OperatorProvider.Provider.GetCurrent() == null)
            {
                filterContext.HttpContext.Response.Write("<script>top.location.href = '/Login';</script>");
            }
        }
    }
}