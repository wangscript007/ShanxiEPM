//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2017-08-14 10:19:39
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
namespace hc.epm.DataModel.Msg
{ 
	///<summary>
	///Msg_EmailTemplete:邮件模板
	///</summary>
	 public  class  Msg_EmailTemplete: BaseMsg
    { 
		///<summary>
		///邮件模板编号
		///</summary>
		public string No { get; set; }

		///<summary>
		///模板名称
		///</summary>
		public string Name { get; set; }

		///<summary>
		///模板适用环节
		///</summary>
		public string Step { get; set; }

        ///<summary>
        ///邮件消息标题内容
        ///</summary>
        public string TitleCon { get; set; }

        ///<summary>
        ///模板内容
        ///</summary>
        public string TemplateCon { get; set; }

		///<summary>
		///模板参数说明
		///</summary>
		public string ParameterDes { get; set; }

		///<summary>
		///是否启用，默认为0，启用
		///</summary>
		public bool IsEnable { get; set; }

		///<summary>
		///是否确认，默认为1，未确认
		///</summary>
		public bool IsConfirm { get; set; }

	}
}

