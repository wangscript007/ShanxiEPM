//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2019-11-04 18:14:37
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace hc.epm.DataModel.Business
{
    ///<summary>
    ///Epm_TzConDrawing:施工图纸会审
    ///</summary>
    public class Epm_CompletionAcceptanceResUpload : BaseBusiness
	{ 
        public Epm_CompletionAcceptanceResUpload()
        {
            TzAttachs = new List<Epm_TzAttachs>();
        }
        [NotMapped]
        public List<Epm_TzAttachs> TzAttachs { set; get; }

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
        public string Content { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? Num { get; set; }

        ///<summary>
        ///
        ///</summary>
        public long? RecCompanyId { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string RecCompanyName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public long? RecUserId { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string RecUserName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? RecTime { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? AcceptanceResult { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? State { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Remark { get; set; }

        ///<summary>
        ///
        ///</summary>
        public long? CrtCompanyId { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string CrtCompanyName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Title { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string RectifContent { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Opinion { get; set; }

    }
}

