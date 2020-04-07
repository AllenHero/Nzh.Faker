﻿using Nzh.Faker.Areas.SysSet.Models;
using Nzh.Faker.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nzh.Faker.Areas.SysSet.Controllers
{
    public class DevSetController : BaseController
    {
        // GET: SysSet/DevSet
        public override ActionResult Index(int? id)
        {
            return View(new DevModel().GetDevInfo());
        }
        [HttpPost]
        public ActionResult Index(DevModel model)
        {
            try
            {
                new DevModel().SetDevInfo(model);
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "Error:" + ex.Message;
                return View(new DevModel().GetDevInfo());
            }
            ViewBag.Msg = "修改成功！";
            return View(new DevModel().GetDevInfo());
        }
    }
}