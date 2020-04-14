//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2019-08-21 16:35:58
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace hc.epm.DataModel.Business
{ 
	///<summary>
	///Epm_TzGasStationItem: 加油站项目信息前
	///</summary>
	 public  class  Epm_TzGasStationItem:BaseBusiness
	{
        public Epm_TzGasStationItem()
        {
            TzAttachs = new List<Epm_TzAttachs>();
        }

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
		public string ProjectCodeInvest { get; set; }

		///<summary>
		///
		///</summary>
		public string ProjectCodeWhole { get; set; }

		///<summary>
		///
		///</summary>
		public string ProjectCodeProject { get; set; }

		///<summary>
		///
		///</summary>
		public string ProjectNatureType { get; set; }

		///<summary>
		///
		///</summary>
		public string ProjectNatureTypeName { get; set; }

		///<summary>
		///
		///</summary>
		public long? StationId { get; set; }

		///<summary>
		///
		///</summary>
		public string StationName { get; set; }

		///<summary>
		///
		///</summary>
		public string StationCodeInvest { get; set; }

		///<summary>
		///
		///</summary>
		public string StationCodeWhole { get; set; }

		///<summary>
		///
		///</summary>
		public string StationCodeProject { get; set; }

		///<summary>
		///
		///</summary>
		public DateTime? ApplyTime { get; set; }

		///<summary>
		///
		///</summary>
		public long? CompanyId { get; set; }

		///<summary>
		///
		///</summary>
		public string CompanyName { get; set; }

		///<summary>
		///
		///</summary>
		public string CompanyCodeInvest { get; set; }

		///<summary>
		///
		///</summary>
		public string CompanyCodeWhole { get; set; }

		///<summary>
		///
		///</summary>
		public string CompanyCodeProject { get; set; }

		///<summary>
		///
		///</summary>
		public string ProvinceCode { get; set; }

		///<summary>
		///
		///</summary>
		public string ProvinceName { get; set; }

		///<summary>
		///
		///</summary>
		public string ProvinceCodeInvest { get; set; }

		///<summary>
		///
		///</summary>
		public string ProvinceCodeWhole { get; set; }

		///<summary>
		///
		///</summary>
		public string ProvinceCodeProject { get; set; }

		///<summary>
		///
		///</summary>
		public string Recommender { get; set; }

		///<summary>
		///
		///</summary>
		public string RecommenderJob { get; set; }

		///<summary>
		///
		///</summary>
		public string RecommenderCompany { get; set; }

		///<summary>
		///
		///</summary>
		public string Declarer { get; set; }

		///<summary>
		///
		///</summary>
		public string Position { get; set; }

		///<summary>
		///
		///</summary>
		public string PositionType { get; set; }

		///<summary>
		///
		///</summary>
		public string ProjectPosition { get; set; }

		///<summary>
		///
		///</summary>
		public string StationType { get; set; }

		///<summary>
		///
		///</summary>
		public string StationTypeCode { get; set; }

		///<summary>
		///
		///</summary>
		public decimal? PredictMoney { get; set; }

		///<summary>
		///
		///</summary>
		public decimal? PredictDayGas { get; set; }

		///<summary>
		///
		///</summary>
		public decimal? PredictDayOil { get; set; }

		///<summary>
		///
		///</summary>
		public string Remark { get; set; }

		///<summary>
		///
		///</summary>
		public int? State { get; set; }

        /// <summary>
        /// 相关附件(扩展字段)
        /// </summary>
        [NotMapped]
        public List<Epm_TzAttachs> TzAttachs { get; set; }

        /// <summary>
        /// 生成批复（请示）文号(扩展字段)
        /// </summary>
        [NotMapped]
        public string Titanic { get; set; }

        /// <summary>
        /// 项目阶段(扩展字段)
        /// </summary>
        [NotMapped]
        public string ProjectStage { get; set; }

        /// <summary>
        /// 项目对应业务阶段状态
        /// </summary>
        [NotMapped]
        public string OperateType { get; set; }

        /// <summary>
        /// 项目对应业务阶段状态名称
        /// </summary>
        [NotMapped]
        public string OperateTypeName { get; set; }
    }
}

