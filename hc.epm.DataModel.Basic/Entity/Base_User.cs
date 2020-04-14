//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2017-08-04 08:45:07
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace hc.epm.DataModel.Basic
{
    ///<summary>
    ///Base_User:用户
    ///</summary>
    public class Base_User : BaseBusiness
    {
        ///<summary>
        ///用户名
        ///</summary>
        public string UserName { get; set; }

        ///<summary>
        ///登陆账户
        ///</summary>
        public string UserAcct { get; set; }

        ///<summary>
        ///用户编号
        ///</summary>
        public string UserCode { get; set; }

        ///<summary>
        ///最新密码
        ///</summary>
        public string PassWord { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Phone { get; set; }

        public string WebChat { get; set; }
        ///<summary>
        ///关联QQ
        ///</summary>
        public string QQ { get; set; }

        ///<summary>
        ///性别
        ///</summary>
        public bool Sex { get; set; }

        ///<summary>
        ///EMail
        ///</summary>
        public string Email { get; set; }

        ///<summary>
        ///是否锁定
        ///</summary>
        public bool IsLock { get; set; }

        ///<summary>
        ///最后登录时间
        ///</summary>
        public DateTime LastLoginTime { get; set; }

        ///<summary>
        ///单位ID
        ///</summary>
        public long CompanyId { get; set; }
        
        ///<summary>
        ///帐号登录失败次数
        ///</summary>
        public int LockNum { get; set; }

        ///<summary>
        ///上次修改密码时间
        ///</summary>
        public DateTime PassTime { get; set; }

        /// <summary>
        /// android token
        /// </summary>
        public string AndroidToken { get; set; }
        /// <summary>
        /// android token 失效时间
        /// </summary>
        public DateTime? AndroidTokenTime { get; set; }
        /// <summary>
        /// ios token
        /// </summary>
        public string IosToken { get; set; }
        /// <summary>
        /// ios token 失效时间
        /// </summary>
        public DateTime? IosTokenTime { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// 毕业院校
        /// </summary>
        public string University { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        public string Major { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public string Education { get; set; }
        /// <summary>
        /// 现住址（市、县）
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 开始职业时间
        /// </summary>
        public DateTime? OccupationalStartTime { get; set; }
        /// <summary>
        /// 职业简述
        /// </summary>
        public string OccupationalContent { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
        public string Professional { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
        public string ProfessionalValue { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
        public string Post { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
        public string PostValue { get; set; }
        /// <summary>
        /// 职业资格
        /// </summary>
        public string ProfessionalQualification { get; set; }
        /// <summary>
        /// 职业资格
        /// </summary>
        public string ProfessionalQualificationValue { get; set; }

        /// <summary>
        /// 外部唯一标识
        /// </summary>
        public string ObjeId { get; set; }
        /// <summary>
        /// Card
        /// </summary>
        public string Card { get; set; }

        /// <summary>
        /// 所在部门
        /// </summary>
        public long? DepartmentId { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        [NotMapped]
        public string CompanyName { get; set; }

        /// <summary>
        /// 附件列表
        /// </summary>
        [NotMapped]
        public List<Base_Files> fileList { get; set; }

        [NotMapped]
        public string addressName { get; set; }
        /// <summary>
        /// 人员成绩
        /// </summary>
        public decimal? achievement { get; set; }
        /// <summary>
        /// 成绩开始时间
        /// </summary>
        public DateTime? achievementStartTime { get; set; }

        /// <summary>
        /// 成绩结束时间
        /// </summary>
        public DateTime? achievementEndTime { get; set; }

    }
}

