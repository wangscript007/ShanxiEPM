﻿//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2018-05-14 14:26:50
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace hc.epm.DataModel.Business
{
    public class Epm_SignInformation: BaseBusiness
    {
        ///<summary>
        ///用户ID
        ///</summary>
        public long? userId { get; set; }

        ///<summary>
        ///用户名称
        ///</summary>
        public string userName { get; set; }

        ///<summary>
        ///项目ID
        ///</summary>
        public long? projectId { get; set; }

        ///<summary>
        ///项目名称
        ///</summary>
        public string projectName { get; set; }

        ///<summary>
        ///加油站名称
        ///</summary>
        public string gasstationName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string gpsInfo { get; set; }

        ///<summary>
        ///考勤状态
        ///</summary>
        public string state { get; set; }

        ///<summary>
        ///岗位信息
        ///</summary>
        public string jobInfo { get; set; }

        ///<summary>
        ///施工类型
        ///</summary>
        public string type { get; set; }

        ///<summary>
        ///图片路径
        ///</summary>
        public string picStrength { get; set; }

        /// <summary>
        /// 签到结果描述，接口调用失败，比对失败，签到成功
        /// </summary>
        public string SignResult { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// 签到时间
        /// </summary>
        public DateTime? SignTime { get; set; }

        [NotMapped]
        public string time { get; set; }
    }
}
