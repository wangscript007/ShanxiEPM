//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2019-09-02 13:52:36
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace hc.epm.DataModel.Business
{ 
	///<summary>
	///Epm_TzDevResourceReport:
	///</summary>
	 public  class  Epm_TzDevResourceReport:BaseBusiness
	{
        public Epm_TzDevResourceReport()
        {
            TzAttachs = new List<Epm_TzAttachs>();
            TzDevResourceReportItem = new List<Epm_TzDevResourceReportItem>();
        }
        ///<summary>
        ///标题
        ///</summary>
        public string Title { get; set; }

		///<summary>
		///申报人
		///</summary>
		public string ApplyUser { get; set; }

		///<summary>
		///申报人id
		///</summary>
		public long? ApplyUserId { get; set; }

		///<summary>
		///申报日期
		///</summary>
		public DateTime? ApplyDate { get; set; }

		///<summary>
		///所属单位
		///</summary>
		public string CompanyName { get; set; }

		///<summary>
		///所属单位ID
		///</summary>
		public long? CompanyId { get; set; }

		///<summary>
		///所属部门
		///</summary>
		public string Department { get; set; }

		///<summary>
		///所属部门ID
		///</summary>
		public long? DepartmentId { get; set; }

		///<summary>
		///部门负责人id
		///</summary>
		public long? DepLeaderId { get; set; }

		///<summary>
		///部门负责人
		///</summary>
		public string DepLeaderName { get; set; }

		///<summary>
		///分管领导id
		///</summary>
		public long? LeaderId { get; set; }

		///<summary>
		///分管领导
		///</summary>
		public string LeaderName { get; set; }

		///<summary>
		///当前状态
		///</summary>
		public string StateType { get; set; }

		///<summary>
		///状态编码
		///</summary>
		public string StateName { get; set; }

		///<summary>
		///签字意见
		///</summary>
		public string SignIdea { get; set; }

        /// <summary>
        /// 当前审批人
        /// </summary>
        public string ApprovalName { get; set; }

        /// <summary>
        /// 当前审批人Id
        /// </summary>
        public string ApprovalNameId { get; set; }

        /// <summary>
        /// 流程申请 ID
        /// </summary>
        public string WorkFlowId { get; set; }

        public int State { get; set; }

        [NotMapped]
        public List<Epm_TzAttachs> TzAttachs { get; set; }

        [NotMapped]
        public List<Epm_TzDevResourceReportItem> TzDevResourceReportItem { get; set; }
    }
}

