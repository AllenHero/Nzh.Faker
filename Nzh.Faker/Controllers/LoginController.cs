﻿using Nzh.Faker.Common;
using Nzh.Faker.IService;
using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nzh.Faker.Controllers
{
    public class LoginController : Controller
    {
        public IUserService UserService { get; set; }

        public ILogService LogService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }

        [HttpPost]
        public ActionResult LoginOn(string username, string password, string captcha)
        {
            LogModel logEntity = new LogModel();
            logEntity.LogType = DbLogType.Login.ToString();
            try
            {
                if (Session["session_verifycode"].IsEmpty() || Md5.md5(captcha.ToLower(), 16) != Session["session_verifycode"].ToString())
                {
                    throw new Exception("验证码错误");
                }
                UserModel userEntity = UserService.LoginOn(username, Md5.md5(password, 32));
                if (userEntity != null)
                {
                    if (userEntity.EnabledMark == 1)
                    {
                        throw new Exception("账号被锁定，禁止登录");
                    }
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = userEntity.Id;
                    operatorModel.Account = userEntity.Account;
                    operatorModel.RealName = userEntity.RealName;
                    operatorModel.HeadIcon = userEntity.HeadIcon;
                    operatorModel.RoleId = userEntity.RoleId;
                    operatorModel.LoginIPAddress = Net.Ip;
                    //operatorModel.LoginIPAddressName = Net.GetLocation(Net.Ip);
                    OperatorProvider.Provider.AddCurrent(operatorModel);
                    logEntity.Account = userEntity.Account;
                    logEntity.RealName = userEntity.RealName;
                    logEntity.Description = "登陆成功";
                    LogService.WriteDbLog(logEntity);
                    return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功" }.ToJson());
                }
                else
                {
                    throw new Exception("用户名或密码错误");
                }
            }
            catch (Exception ex)
            {
                logEntity.Account = username;
                logEntity.RealName = username;
                logEntity.Description = "登录失败，" + ex.Message;
                LogService.WriteDbLog(logEntity);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }

        [HttpGet]
        public ActionResult LoginOut()
        {
            LogService.WriteDbLog(new LogModel
            {
                LogType = DbLogType.Exit.ToString(),
                Account = OperatorProvider.Provider.GetCurrent().Account,
                RealName = OperatorProvider.Provider.GetCurrent().RealName,
                Description = "安全退出系统",
            });
            Session.Abandon();
            Session.Clear();
            OperatorProvider.Provider.RemoveCurrent();
            return RedirectToAction("Index", "Login");
        }
    }
}