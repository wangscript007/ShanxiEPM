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
    ///Base_Company:企业
    ///</summary>
    public class Base_Company : BaseBusiness
    {

        public Base_Company()
        {
            baseFiles = new List<Base_Files>();
        }
        [NotMapped]
        public List<Base_Files> baseFiles { get; set; }
        [NotMapped]
        public string RegionName { get; set; }
        /// <summary>
        /// 上级单位Id
        /// </summary>

        public long PId { get; set; }
        ///<summary>
        ///上级单位编码
        ///</summary>
        public string PreCode { get; set; }

        ///<summary>
        ///上级单位名称
        ///</summary>
        public string PreName { get; set; }

        ///<summary>
        ///单位编码
        ///</summary>
        public string Code { get; set; }

        ///<summary>
        ///单位名称
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        ///简称
        ///</summary>
        public string ShortName { get; set; }

        ///<summary>
        ///单位类型
        ///</summary>
        public string Type { get; set; }
        
        ///<summary>
        ///单位电话
        ///</summary>
        public string Phone { get; set; }

        ///<summary>
        ///电子邮箱
        ///</summary>
        public string Email { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public long? LinkManId { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string LinkMan { get; set; }

        /// <summary>
        /// 负责人电话
        /// </summary>
        public string LinkPhone { get; set; }
        ///<summary>
        ///所在省市
        ///</summary>
        public string Address { get; set; }

        ///<summary>
        ///详细地址
        ///</summary>
        public string AddressInfo { get; set; }

        ///<summary>
        ///简介
        ///</summary>
        public string Remark { get; set; }
        
        ///<summary>
        ///传真电话
        ///</summary>
        public string FaxPhone { get; set; }

        /// <summary>
        /// 组织机构类型 1 省公司，2 分公司， 3 机关， 4 加油站， 5 加气站， 6 研发企业， 7 片区， 8生产机关， 9 车 10 船， 11机关及其他部门
        /// </summary>
        public string OrgType { get; set; }

        /// <summary>
        /// 供应商类型
        /// </summary>
        public string CompanyType { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string CompanyTypeName { get; set; }

        /// <summary>
        /// 组织机构状态
        /// </summary>
        public string OrgState { get; set; }

        /// <summary>
        /// 供应商状态
        /// </summary>
        public string CompanyState { get; set; }

        /// <summary>
        /// 外部唯一标识
        /// </summary>
        public string ObjeId { get; set; }
        /// <summary>
        /// 正常缺位
        /// </summary>
        public string Normal_absence { get; set; }
        /// <summary>
        /// 异常缺位
        /// </summary>
        public string Abnormality { get; set; }
        //地址名字
        public string AddressName { get; set; }

        public bool? IsBlacklist { get; set; }//是否黑名单
        /// <summary>
        /// 供货商级别 0 一级、1 二级、2 三级
        /// </summary>
        public string CompanyRank { get; set; }
        /// <summary>
        /// 级别名称
        /// </summary>
        public string CompanyRankName { get; set; }
    }
}

