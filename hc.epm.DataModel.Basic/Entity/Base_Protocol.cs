//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2017-08-04 08:45:08
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
namespace hc.epm.DataModel.Basic
{
    ///<summary>
    ///Base_Protocol:电子协议
    ///</summary>
    public class Base_Protocol : BaseBusiness
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        ///<summary>
        ///电子协议内容
        ///</summary>
        public string Info { get; set; }

        ///<summary>
        ///启用=0，禁用=1
        ///</summary>
        public bool IsEnable { get; set; }

        ///<summary>
        ///已确认=0，未确认=1
        ///</summary>
        public bool IsConfirm { get; set; }

        ///<summary>
        ///说明
        ///</summary>
        public string Remark { get; set; }

        /// <summary>
        /// 协议类型
        /// </summary>
        public string Type { get; set; }

    }
}

