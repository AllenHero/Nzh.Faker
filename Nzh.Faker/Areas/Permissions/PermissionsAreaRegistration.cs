using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nzh.Faker.Areas.Permissions
{
    public class PermissionsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Permissions";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Permissions_default",
                "Permissions/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}