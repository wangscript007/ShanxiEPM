//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2018-08-15 09:04:34
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
namespace hc.epm.DataModel.Business
{
    ///<summary>
    ///Epm_Constitute:
    ///</summary>
    public class Epm_Constitute : BaseBusiness
    {
        ///<summary>
        ///项目性质
        ///</summary>
        public string ProjectNatureCode { get; set; }

        ///<summary>
        ///项目性质
        ///</summary>
        public string ProjectNatureName { get; set; }

        ///<summary>
        ///批复构成
        ///</summary>
        public string ConstituteKey { get; set; }

        ///<summary>
        ///批复构成
        ///</summary>
        public string ConstituteName { get; set; }

        ///<summary>
        ///是否计费
        ///</summary>
        public bool? IsCharging { get; set; }

        ///<summary>
        ///是否计费
        ///</summary>
        public bool? IsAProvide { get; set; }

        ///<summary>
        ///排序
        ///</summary>
        public int? Sort { get; set; }

        ///<summary>
        ///工程要点
        ///</summary>
        public string MainPoints { get; set; }

    }
}

