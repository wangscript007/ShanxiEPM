//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2018-11-19 10:12:50
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
namespace hc.epm.DataModel.Business
{
    ///<summary>
    ///Epm_Massage:
    ///</summary>
    public class Epm_Massage : BaseBusiness
    {
        ///<summary>
        ///
        ///</summary>
        public string Title { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Content { get; set; }

        ///<summary>
        ///
        ///</summary>
        public bool? IsRead { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? ReadTime { get; set; }

        ///<summary>
        ///
        ///</summary>
        public long? SendId { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SendName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? SendTime { get; set; }

        ///<summary>
        ///
        ///</summary>
        public long? RecId { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string RecName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? RecTime { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? Type { get; set; }

        ///<summary>
        ///
        ///</summary>
        public long? ProjectId { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ProjectName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public long? BussinessId { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string BussinesType { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string BussinesChild { get; set; }

    }
}

