﻿using hc.epm.Admin.ClientProxy;
using hc.epm.DataModel.Basic;
using hc.Plat.Common.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hc.epm.Common;
using hc.epm.UI.Common;
using hc.Plat.Common.Extend;
using hc.epm.ViewModel;
using Newtonsoft.Json;
using hc.epm.DataModel.Msg;

namespace hc.epm.Admin.Web.Controllers
{
    public class EmailSettingController : BaseController
    {
        // GET: EmailSetting
        [AuthCheck(Module = AdminModule.EmailSetting, Right = SystemRight.Browse)]
        public ActionResult Index(string Name = "", string IsEnable = "0", string IsConfirm = "0", int pageIndex = 1, int pageSize = 10)
        {
            ViewBag.Name = Name;
            ViewBag.pageIndex = pageIndex;
            //下拉框
            ViewBag.IsConfirm = HelperExt.GetConfirmList(true, IsConfirm);
            ViewBag.IsEnable = HelperExt.GetEnableList(true, IsEnable);
            ConditionExpression ce = null;
            QueryCondition qc = new QueryCondition();
            ce = new ConditionExpression();
            if (!string.IsNullOrEmpty(Name))
            {
                ce = new ConditionExpression();
                ce.ExpName = "Name";
                ce.ExpValue = "%" + Name + "%";
                ce.ExpOperater = eConditionOperator.Like;
                ce.ExpLogical = eLogicalOperator.And;
                qc.ConditionList.Add(ce);
            }
            if (IsEnable != "0")
            {
                ce = new ConditionExpression();
                ce.ExpName = "IsEnable";
                ce.ExpValue = IsEnable == EnumState.Enable.ToString();
                ce.ExpOperater = eConditionOperator.Equal;
                ce.ExpLogical = eLogicalOperator.And;
                qc.ConditionList.Add(ce);
            }
            if (IsConfirm != "0")
            {
                ce = new ConditionExpression();
                ce.ExpName = "IsConfirm";
                ce.ExpValue = IsConfirm == EnumState.Confirmed.ToString();
                ce.ExpOperater = eConditionOperator.Equal;
                ce.ExpLogical = eLogicalOperator.And;
                qc.ConditionList.Add(ce);
            }
            qc.PageInfo = GetPageInfo(pageIndex, pageSize);
            Result<List<Msg_EmailSetting>> result = new Result<List<Msg_EmailSetting>>();
            using (MessageClientProxy proxy = new MessageClientProxy(ProxyEx(Request)))
            {
                result = proxy.GetEmailSettingList(qc);
                ViewBag.Total = result.AllRowsCount;
              
            }

            return View(result.Data);
        }

        // GET: EmailSetting/Detail/5
        [AuthCheck(Module = AdminModule.EmailSetting, Right = SystemRight.Browse)]
        public ActionResult Detail(long id)
        {
            Result<Msg_EmailSetting> result = new Result<Msg_EmailSetting>();
            using (MessageClientProxy proxy = new MessageClientProxy(ProxyEx(Request)))
            {
                result = proxy.GetEmailSettingModel(id);

            }


            return View(result.Data);
        }

        // GET: EmailSetting/Create
        [AuthCheck(Module = AdminModule.EmailSetting, Right = SystemRight.Add)]
        public ActionResult Add()
        {
            ViewBag.IsConfirm = HelperExt.GetConfirmList(false);
            ViewBag.IsEnable = HelperExt.GetEnableList(false);
            return View();
        }

        // POST: EmailSetting/Create
        [HttpPost]
        [AuthCheck(Module = AdminModule.EmailSetting, Right = SystemRight.Add)]
        public ActionResult Add(Msg_EmailSetting model)
        {

            Result<int> result = new Result<int>();
            ResultView<int> view = new ResultView<int>();
            if (Request.Form["IsEnable"] == EnumState.Enable.ToString())
            {
                model.IsEnable = true;
            }
            else
            {
                model.IsEnable = false;
            }
            if (Request.Form["IsConfirm"] == EnumState.Confirmed.ToString())
            {
                model.IsConfirm = true;
            }
            else
            {
                model.IsConfirm = false;
            }
            using (MessageClientProxy proxy = new MessageClientProxy(ProxyEx(Request)))
            {
                result = proxy.AddEmailSetting(model);
                view = result.ToResultView();
            }
            return Json(view);
        }

        // GET: EmailSetting/Edit/5
        [AuthCheck(Module = AdminModule.EmailSetting, Right = SystemRight.Modify)]
        public ActionResult Edit(long id)
        {
            Result<Msg_EmailSetting> result = new Result<Msg_EmailSetting>();
            using (MessageClientProxy proxy = new MessageClientProxy(ProxyEx(Request)))
            {
                result = proxy.GetEmailSettingModel(id);

            }
            var isConfirm = result.Data.IsConfirm ? EnumState.Confirmed.ToString() : EnumState.NoConfim.ToString();
            var isEnable = result.Data.IsEnable ? EnumState.Enable.ToString() : EnumState.Disable.ToString();

            ViewBag.IsEnable = HelperExt.GetEnableList(false, isEnable);
            ViewBag.IsConfirm = HelperExt.GetConfirmList(false, isConfirm);


            return View(result.Data);
        }

        // POST: EmailSetting/Edit/5
        [HttpPost]
        [AuthCheck(Module = AdminModule.EmailSetting, Right = SystemRight.Modify)]
        public ActionResult Edit(Msg_EmailSetting model)
        {
            Result<int> result = new Result<int>();
            ResultView<int> view = new ResultView<int>();
            if (Request.Form["IsEnable"] == EnumState.Enable.ToString())
            {
                model.IsEnable = true;
            }
            else
            {
                model.IsEnable = false;
            }
            if (Request.Form["IsConfirm"] == EnumState.Confirmed.ToString())
            {
                model.IsConfirm = true;
            }
            else
            {
                model.IsConfirm = false;
            }
            using (MessageClientProxy proxy = new MessageClientProxy(ProxyEx(Request)))
            {
                result = proxy.UpdateEmailSetting(model);
                view = result.ToResultView();
            }
            return Json(view);
        }

        //EditState
        [HttpPost]
        public ActionResult EditState(long emailSettingId, int type)
        {
            Result<int> result = new Result<int>();
            using (MessageClientProxy proxy = new MessageClientProxy(ProxyEx(Request)))
            {
                result = proxy.AuditEmailSetting(emailSettingId, type);
            }
            return Json(result.ToResultView());
        }

        // POST: EmailSetting/Delete/5
        [HttpPost]
        [AuthCheck(Module = AdminModule.EmailSetting, Right = SystemRight.Delete)]
        public ActionResult Delete(string ids)
        {
            Result<int> result = new Result<int>();
            List<long> list = ids.SplitString(",").ToLongList();
            using (MessageClientProxy proxy = new MessageClientProxy(ProxyEx(Request)))
            {
                result = proxy.DeleteEmailSettingByIds(list);
            }
            return Json(result.ToResultView());
        }
    }
}
