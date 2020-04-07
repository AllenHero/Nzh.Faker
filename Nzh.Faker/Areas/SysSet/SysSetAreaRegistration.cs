using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nzh.Faker.Areas.SysSet
{
    public class SysSetAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SysSet";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SysSet_default",
                "SysSet/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}