//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2019-11-22 17:11:34
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace hc.epm.DataModel.Business
{ 
	///<summary>
	///Epm_TimeLimitAndCrossings:
	///</summary>
	 public  class Epm_TimeLimitAndProcedure: BaseBusiness
	{ 
		///<summary>
		///项目id
		///</summary>
		public long? ProjectId { get; set; }

        ///<summary>
        ///外部手续
        ///</summary>
        public bool? IsCrossings { get; set; }

        ///<summary>
        ///实际停业时间
        ///</summary>
        public DateTime? ShutdownTime { get; set; }

        ///<summary>
        ///计划开工时间
        ///</summary>
        public DateTime? PlanWorkStartTime { get; set; }

        ///<summary>
        ///计划完工时间
        ///</summary>
        public DateTime? PlanWorkEndTime { get; set; }

        ///<summary>
        ///工期
        ///</summary>
        public int? TimeLimit { get; set; }

        ///<summary>
        ///计划开业时间
        ///</summary>
        public DateTime? PlanOpeningTime { get; set; }

        ///<summary>
        ///计划停业时长
        ///</summary>
        public int? PlanShutdowLimit { get; set; }

        [NotMapped]
        public List<Epm_TzAttachs> TzAttachs { get; set; }
        public Epm_TimeLimitAndProcedure()
        {
            TzAttachs = new List<Epm_TzAttachs>();
        }
        [NotMapped]
        public int? typeSub { get; set; }
    }
}

