using Nzh.Faker.App_Start.Handler;
using Nzh.Faker.Common;
using Nzh.Faker.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nzh.Faker.Controllers
{
    [HandlerLogin]
    public class BaseController : Controller
    {
        protected const string SuccessText = "操作成功！";

        protected const string ErrorText = "操作失败！";

        public IButtonService ButtonService { get; set; }

        public OperatorModel Operator
        {
            get { return OperatorProvider.Provider.GetCurrent(); }
        }

        // GET: Base
        public virtual ActionResult Index(int? id)
        {
            var _menuId = id == null ? 0 : id.Value;
            var _roleId = Operator.RoleId;
            if (id != null)
            {
                ViewData["RightButtonList"] = ButtonService.GetButtonListByRoleIdMenuId(_roleId, _menuId, PositionEnum.FormInside);
                ViewData["TopButtonList"] = ButtonService.GetButtonListByRoleIdMenuId(_roleId, _menuId, PositionEnum.FormRightTop);
            }
            return View();
        }

        protected virtual AjaxResult SuccessTip(string message = SuccessText)
        {
            return new AjaxResult { state = ResultType.success.ToString(), message = message };
        }

        protected virtual AjaxResult ErrorTip(string message = ErrorText)
        {
            return new AjaxResult { state = ResultType.error.ToString(), message = message };
        }
    }
}