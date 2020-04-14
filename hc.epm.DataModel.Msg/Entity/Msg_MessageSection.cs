//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2017-08-14 10:19:41
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
namespace hc.epm.DataModel.Msg
{ 
	///<summary>
	///Msg_MessageSection:消息环节配置
	///</summary>
	 public  class  Msg_MessageSection: BaseMsg
    { 
		///<summary>
		///环节编号
		///</summary>
		public string No { get; set; }

		///<summary>
		///环节名称
		///</summary>
		public string Name { get; set; }

		///<summary>
		///适用角色，不同角色用逗号隔开
		///</summary>
		public string RoleTypes { get; set; }

		///<summary>
		///消息发送方式，多种方式之间同逗号隔开
		///</summary>
		public string MsgTypes { get; set; }

		///<summary>
		///消息环节配置是否启用，默认0，启用
		///</summary>
		public bool IsEnable { get; set; }

		///<summary>
		///消息环节配置是否确认，默认1，未确认
		///</summary>
		public bool IsConfirm { get; set; }

	}
}

