﻿using Nzh.Faker.Controllers;
using Nzh.Faker.IService;
using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nzh.Faker.Areas.Permissions.Controllers
{
    public class RoleAuthorizeController : BaseController
    {
        public IRoleAuthorizeService RoleAuthorizeService { get; set; }

        public override ActionResult Index(int? id)
        {
            base.Index(id);
            return View();
        }

        [HttpPost]
        public ActionResult InsertBatch(IEnumerable<RoleAuthorizeModel> list, int roleId)
        {
            var result = RoleAuthorizeService.SavePremission(list, roleId) > 0 ? SuccessTip("保存成功") : ErrorTip("保存失败");
            return Json(result);
        }
    }
}