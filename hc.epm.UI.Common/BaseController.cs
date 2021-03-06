﻿using Com.Itrus.Cert;
using Com.Itrus.CryptoRole;
using hc.epm.Admin.ClientProxy;
using hc.epm.Common;
using hc.epm.ViewModel;
using hc.Plat.Common.Extend;
using hc.Plat.Common.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace hc.epm.UI.Common
{
    public class BaseController : Controller
    {
        protected ClientProxyExType ProxyExNoLogin(HttpRequestBase request, string userName = "admin")
        {
            ClientProxyExType cpet = Session[ConstStr_Session.CurrentProxyExType] as ClientProxyExType;
            if (cpet == null)
            {
                //TODO:用户登录后需要修改为用户信息，同时给applicationcontext赋值用户信息看在多用户登录情况下服务中是否生效,否则如写日志等操作需要在客户端将用户id传递过去
                cpet = new ClientProxyExType();
                cpet.UserID = userName;
                cpet.IP_Client = request.UserHostAddress;
                cpet.IP_WebServer = hc.Plat.Common.Global.NetTools.GetLocalMachineIP4();
                Session[ConstStr_Session.CurrentProxyExType] = cpet;
            }
            return cpet;
        }

        /// <summary>
        /// session检查
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            ViewBag.CurrentAccount = null;
            var areaName = (string)RouteData.Values["area"];
            var controllerName = (string)RouteData.Values["controller"];
            var actionName = (string)RouteData.Values["action"];

            try
            {
                var userInfo = Session[ConstStr_Session.CurrentUserEntity] as UserView;
                if (userInfo == null)
                {
                    string url = Request.Url.ToString();
                    filterContext.Result = base.RedirectToAction("GoToLogin", "Currency");

                    //从cookie中取一次
                    //HttpCookie httpCookie = Request.Cookies[ConstString.SIGNALROPUSERCOOKIE];
                    //if (httpCookie != null && !string.IsNullOrEmpty(httpCookie.Value))
                    //{
                    //    string encryptUser = httpCookie.Value;
                    //    string decryptUser = DesTool.DesDecrypt(encryptUser);
                    //    var clientUser = HttpUtility.UrlDecode(decryptUser);
                    //    ClientUserView clientUserView = JsonConvert.DeserializeObject<ClientUserView>(clientUser);
                    //    using (AdminClientProxy proxy = new AdminClientProxy(ProxyExNoLogin(Request)))
                    //    {
                    //        var user = proxy.GetUserModel(clientUserView.UserId.ToLongReq()).Data;
                    //        var userView = proxy.Login(user.UserAcct, user.PassWord, clientUserView.RoleType.ToEnumReq<RoleType>()).Data;
                    //        Session[ConstStr_Session.CurrentUserEntity] = userView;
                    //    }
                    //}
                    //else
                    //{
                    //    filterContext.Result = base.RedirectToAction("GoToLogin", "Currency");
                    //}
                    //Response.Write("<script> var par = window.parent;if (par == null || par == undefined){window.location.href='/Currency/Login';}else{window.parent.location.href='/Currency/Login'; }</script>");
                    //Response.End();
                }
                else
                {
                    string rights = Session[ConstString.RIGHTSSESSION] as string;
                    if (string.IsNullOrEmpty(rights))
                    {
                        rights = JsonConvert.SerializeObject(userInfo.Rights);
                        Session[ConstString.RIGHTSSESSION] = rights;
                    }
                }
            }
            catch
            {
                filterContext.Result = base.RedirectToAction("GoToLogin", "Currency");
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

        /// <summary>
        /// action内的检查
        /// </summary>
        protected void ChekcRight(string module, string right)
        {
            bool result = Helper.IsCheck(HttpContext, module, right);
            if (!result)
            {
                Response.Redirect("/Currency/Error?msg=未授权操作");
                Response.End();
            }
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        public UserView CurrentUser
        {
            get
            {
                var userInfo = HttpContext.Session[ConstStr_Session.CurrentUserEntity] as UserView;
                if (userInfo == null)
                {
                    Response.Write("<script> var par = window.parent;if (par == null || par == undefined){window.location.href='/Currency/Login';}else{window.parent.location.href='/Currency/Login'; }</script>");
                    Response.End();
                }
                return userInfo;
            }
            set
            {
                HttpContext.Session[ConstStr_Session.CurrentUserEntity] = value;
            }
        }

        /// <summary>
        /// 代理信息获取
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected ClientProxyExType ProxyEx(HttpRequestBase request)
        {
            ClientProxyExType cpet = Session[ConstStr_Session.CurrentProxyExType] as ClientProxyExType;
            if (cpet == null || cpet.UserID == "admin")
            {
                //TODO:用户登录后需要修改为用户信息，同时给applicationcontext赋值用户信息看在多用户登录情况下服务中是否生效,否则如写日志等操作需要在客户端将用户id传递过去
                cpet = new ClientProxyExType();
                cpet.UserID = CurrentUser.UserId.ToString();
                cpet.IP_Client = GetHostAddress();
                cpet.IP_WebServer = hc.Plat.Common.Global.NetTools.GetLocalMachineIP4();
                cpet.CurrentUser = CurrentUser;
                Session[ConstStr_Session.CurrentProxyExType] = cpet;
            }
            else
            {
                var userId = cpet.UserID.ToLong();
                if (!userId.HasValue)
                {
                    cpet = new ClientProxyExType();
                    cpet.UserID = CurrentUser.UserId.ToString();
                    cpet.IP_Client = GetHostAddress();
                    cpet.IP_WebServer = hc.Plat.Common.Global.NetTools.GetLocalMachineIP4();
                    cpet.CurrentUser = CurrentUser;
                    Session[ConstStr_Session.CurrentProxyExType] = cpet;
                }
            }
            return cpet;
        }
        /// <summary>
        /// 获取客户端IP地址（无视代理）
        /// </summary>
        /// <returns>若失败则返回回送地址</returns>
        public string GetHostAddress()
        {
            string userHostAddress = Request.UserHostAddress;

            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = Request.ServerVariables["REMOTE_ADDR"];
            }

            //最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
            if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
            {
                return userHostAddress;
            }
            return "127.0.0.1";
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public PageListInfo GetPageInfo(int pageIndex = 1, int pageSize = 10, Dictionary<string, string> orderBy = null)
        {
            PageListInfo pli = new PageListInfo();
            pli.isAllowPage = true;
            //写PAGE cooike
            HttpCookie cook = Request.Cookies["hc.Plat.currentgridlinenumber"];
            if (cook == null)
            {
                cook = new HttpCookie("hc.Plat.currentgridlinenumber");
                cook.Value = pageSize.ToString();
                cook.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(cook);

                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, pageSize.ToString(), DateTime.Now,
                        DateTime.Now.AddMinutes(Session.Timeout - 1), false, pageSize.ToString());
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(authCookie);
            }

            pli.PageRowCount = pageSize;
            pli.CurrentPageIndex = pageIndex;
            if (orderBy == null)
            {
                orderBy = new Dictionary<string, string>();
                orderBy.Add("ID", "DESC");
            }
            string strOrder = "";
            foreach (var item in orderBy)
            {
                strOrder += item.Key + ":" + item.Value.ToUpper() + ",";
            }
            pli.OrderAndSortList = strOrder.TrimEnd(',');
            return pli;
        }
    }
}