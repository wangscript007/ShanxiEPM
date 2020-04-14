//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2018-05-14 14:26:50
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
namespace hc.epm.DataModel.Business
{ 
	///<summary>
	///Epm_ChangeCompany:变更涉及单位表
	///</summary>
	 public  class  Epm_ChangeCompany:BaseBusiness
	{ 
		///<summary>
		///变更表Id
		///</summary>
		public long? ChangeId { get; set; }

		///<summary>
		///涉及单位Id
		///</summary>
		public long? CompanyId { get; set; }

		///<summary>
		///涉及单位Name
		///</summary>
		public string CompanyName { get; set; }

		///<summary>
		///状态
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

        /// <summary>
        /// 单位类型
        /// </summary>
        public string CompanyType { get; set; }

    }
}

