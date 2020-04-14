//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2017-08-14 10:19:43
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
namespace hc.epm.DataModel.Msg
{
    ///<summary>
    ///Msg_SMSTemplete:短信模板
    ///</summary>
    public class Msg_SMSTemplete : BaseMsg
    {
        ///<summary>
        ///短信模板编号 ，务必对应阿里大鱼的模板编号
        ///</summary>
        public string No { get; set; }

        ///<summary>
        ///短信服务商模板编号,务必对应阿里大鱼的模板编号
        ///</summary>
        public string ServerNo { get; set; }

        ///<summary>
        ///短信模板名称
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        ///短信模板适用环节
        ///</summary>
        public string Step { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string TemplateCon { get; set; }

        ///<summary>
        ///短信模板参数说明
        ///</summary>
        public string ParameterDes { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string SignName { get; set; }
        ///<summary>
        ///短信模板是否启用，默认值为0，启用
        ///</summary>
        public bool IsEnable { get; set; }

        ///<summary>
        ///短信模板确认状态，默认为1，未确认
        ///</summary>
        public bool IsConfirm { get; set; }

    }
}

