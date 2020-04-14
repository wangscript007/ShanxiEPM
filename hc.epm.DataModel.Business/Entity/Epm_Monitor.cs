//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2018-05-14 14:26:51
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
namespace hc.epm.DataModel.Business
{ 
	///<summary>
	///Epm_Monitor:安全质量检查表
	///</summary>
	 public  class  Epm_Monitor:BaseBusiness
	{ 
		///<summary>
		///项目表Id
		///</summary>
		public long? ProjectId { get; set; }

		///<summary>
		///项目名称
		///</summary>
		public string ProjectName { get; set; }

		///<summary>
		///业主单位Id
		///</summary>
		public long? CompanyId { get; set; }

		///<summary>
		///业主单位名称
		///</summary>
		public string CompanyName { get; set; }

		///<summary>
		///检查类型Key
		///</summary>
		public string MonitorTypeNo { get; set; }

		///<summary>
		///检查类型Value
		///</summary>
		public string MonitorTypeName { get; set; }

		///<summary>
		///标题
		///</summary>
		public string Title { get; set; }

		///<summary>
		///说明
		///</summary>
		public string Content { get; set; }

        ///<summary>
        ///检查结果 1 正常 2 需整改
        ///</summary>
        public int? Result { get; set; }

        /// <summary>
        /// 整改建议
        /// </summary>
        public string Rectification { get; set; }

        ///<summary>
        ///检查单位Id
        ///</summary>
        public long? MonitorCompanyId { get; set; }

		///<summary>
		///检查单位Name
		///</summary>
		public string MonitorCompanyName { get; set; }

        /// <summary>
        /// 检查人Id
        /// </summary>
        public long? MonitorUserId { get; set; }

        /// <summary>
        /// 检查人Name
        /// </summary>
        public string MonitorUserName { get; set; }

        ///<summary>
        ///检查时间
        ///</summary>
        public DateTime? MonitorTime { get; set; }

        /// <summary>
        /// 整改结果
        /// </summary>
        public string RectificationResult { get; set; }
        
		///<summary>
		///状态[10待处理,20审核通过,25确认通过,30已驳回,40已废弃,50整改完成]枚举
		///</summary>
		public int? State { get; set; }

		///<summary>
		///备注
		///</summary>
		public string Remark { get; set; }

		///<summary>
		///创建单位Id
		///</summary>
		public long? CrtCompanyId { get; set; }

		///<summary>
		///创建单位Name
		///</summary>
		public string CrtCompanyName { get; set; }

	    ///<summary>
	    /// 整改单位
	    ///</summary>
	    public long? RectifCompanyId { get; set; }

	    ///<summary>
	    /// 整改单位名称
	    ///</summary>
	    public string RectifCompanyName { get; set; }

	    ///<summary>
	    /// 限期整改日期
	    ///</summary>
	    public DateTime? Deadline { get; set; }
    }
}

