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
using System.ComponentModel.DataAnnotations.Schema;

namespace hc.epm.DataModel.Basic
{
    ///<summary>
    ///Base_Files:附件表
    ///</summary>
    public class Base_Files : BaseBusiness
    {
        ///<summary>
        ///
        ///</summary>
        public string TableName { get; set; }

        ///<summary>
        ///表中某条数据
        ///</summary>
        public long TableId { get; set; }
        /// <summary>
        /// 表中某列数据
        /// </summary>
        public string TableColumn { get; set; }
        ///<summary>
        ///附件名称
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        ///附件大小
        ///</summary>
        public string Size { get; set; }

        ///<summary>
        ///
        ///</summary>
        public long UploadUserId { get; set; }

        ///<summary>
        ///数字签名
        ///</summary>
        public string Sign { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public string FileTimestamp { get; set; }
        /// <summary>
        /// 文件服务器返回的guid
        /// </summary>
        public string FileGuid { get; set; }

        /// <summary>
        /// 文件路径
        /// or
        /// FDFS_NAME
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 图片类型 big：大图,small：小图,start：原图
        /// </summary>
        public string ImageType { get; set; }

        /// <summary>
        /// 大图、小图、原图FileId相同
        /// </summary>
        public string GuidId { get; set; }

        /// <summary>
        /// FDFS_GROUP
        /// </summary>
        public string Group { get; set; }

        [NotMapped]
        public string TypeName { get; set; }

        //证件编号
        public string CredentialsNumber { get; set; }
        //颁发单位
        public string IssueUnit { get; set; }
        //获证日期
        public DateTime? GetCertificateTime { get; set; }
        //有效期至
        public DateTime? TermofvalidityTime { get; set; }

        /// <summary>
        /// base64格式图片路径
        /// </summary>
        [NotMapped]
        public string imageUrl { get; set; }
    }
}

