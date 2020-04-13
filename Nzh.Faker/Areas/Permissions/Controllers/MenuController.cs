﻿using Nzh.Faker.Controllers;
using Nzh.Faker.IService.Permissions;
using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nzh.Faker.Areas.Permissions.Controllers
{
    public class MenuController : BaseController
    {
        public IMenuService MenuService { get; set; }

        public override ActionResult Index(int? id)
        {
            base.Index(id);
            return View();
        }

        [HttpGet]
        public JsonResult List()
        {
            var list = MenuService.GetAll();
            var result = new { code = 0, count = list.Count(), data = list };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetMenuList()
        {
            object result = MenuService.GetMenuList(Operator.RoleId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetMenuTreeSelect()
        {
            var result = MenuService.GetMenuTreeSelect();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(MenuModel model)
        {
            model.FontFamily = "ok-icon";
            model.CreateTime = DateTime.Now;
            model.CreateUserId = Operator.UserId;
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            var result = MenuService.Insert(model) ? SuccessTip("添加成功") : ErrorTip("添加失败");
            return Json(result);
        }

        public ActionResult Edit(int id)
        {
            var model = MenuService.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(MenuModel model)
        {
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            var result = MenuService.UpdateById(model) ? SuccessTip("修改成功") : ErrorTip("修改失败");
            return Json(result);
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            var result = MenuService.DeleteById(id) ? SuccessTip("删除成功") : ErrorTip("删除失败");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult MenuButtonList(int roleId)
        {
            var list = MenuService.GetMenuButtonList(roleId);
            var result = new { code = 0, count = list.Count(), data = list };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}