//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2019-12-30 09:10:56
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
namespace hc.epm.DataModel.Business
{ 
	///<summary>
	///Epm_ProjectAttendance:项目考勤设置表
	///</summary>
	 public  class  Epm_ProjectAttendance:BaseBusiness
	{ 
		///<summary>
		///所属项目ID
		///</summary>
		public long ProjectId { get; set; }

		///<summary>
		///考勤人员类型
		///</summary>
		public string AttendanceType { get; set; }

		///<summary>
		///考勤人员类型名称
		///</summary>
		public string AttendanceName { get; set; }

		///<summary>
		///考勤时间
		///</summary>
		public string AttendanceTime { get; set; }

		///<summary>
		///误差时间（分钟）
		///</summary>
		public int? MarginError { get; set; }

		///<summary>
		///本次考勤打卡开始时间
		///</summary>
		public string StartTime { get; set; }

		///<summary>
		///本次考勤打卡截止时间
		///</summary>
		public string EndTime { get; set; }

		///<summary>
		///
		///</summary>
		public DateTime? SetDate { get; set; }

	}
}

