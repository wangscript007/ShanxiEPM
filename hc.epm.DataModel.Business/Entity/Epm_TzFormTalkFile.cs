//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2019-10-31 08:32:29
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace hc.epm.DataModel.Business
{
    ///<summary>
    ///Epm_TzFormTalkFile:评审材料上报
    ///</summary>
    public class Epm_TzFormTalkFile : BaseBusiness
    {
        ///<summary>
        ///所属项目ID
        ///</summary>
        public long? ProjectId { get; set; }

        ///<summary>
        ///地市项目负责人ID
        ///</summary>
        public long? ProjectLeaderId { get; set; }

        ///<summary>
        ///地市项目负责人
        ///</summary>
        public string ProjectLeaderName { get; set; }

        ///<summary>
        ///地市负责人协同编码
        ///</summary>
        public string ProjectLeaderXT { get; set; }

        ///<summary>
        ///地市项目决策人ID
        ///</summary>
        public long? ProjectDecisionerId { get; set; }

        ///<summary>
        ///地市项目决策人
        ///</summary>
        public string ProjectDecisionerName { get; set; }

        ///<summary>
        ///地市项目决策协同编码
        ///</summary>
        public string ProjectDecisionerIdXT { get; set; }

        ///<summary>
        ///编写负责人ID
        ///</summary>
        public long? WriterId { get; set; }

        ///<summary>
        ///编写负责人
        ///</summary>
        public string WriterName { get; set; }

        ///<summary>
        ///编写负责人协同编码
        ///</summary>
        public string WriterIdXT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Remark { get; set; }

        ///<summary>
        ///状态
        ///</summary>
        public int? State { get; set; }

        /// <summary>
        /// 相关附件(扩展字段)
        /// </summary>
        [NotMapped]
        public List<Epm_TzAttachs> TzAttachs { get; set; }
        /// <summary>
        /// 流程申请 ID
        /// </summary>
        public string WorkFlowId { get; set; }

        ///<summary>
        ///当前状态
        ///</summary>
        public string StateType { get; set; }

        ///<summary>
        ///状态编码
        ///</summary>
        public string StateName { get; set; }

        /// <summary>
        /// 当前审批人
        /// </summary>
        public string ApprovalName { get; set; }

        /// <summary>
        /// 当前审批人Id
        /// </summary>
        public long? ApprovalNameId { get; set; }

        /// <summary>
        /// 开工报告审批时间（本次流程全部审批完成时间（年月日），若还未完成审批，不显示）
        /// </summary>
        public DateTime? WorkStartApprovalTime { get; set; }
    }
}

