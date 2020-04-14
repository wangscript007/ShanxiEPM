//------------------------------------------------------------------------------
// <auto-generated>
// 此代码由华春网络代码生成工具生成
// version 1.0
// author hanshiwei 2017.07.24
// auto create time:2019-01-17 16:19:49
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using hc.epm.DataModel.BaseCore;
namespace hc.epm.DataModel.Business
{
    ///<summary>
    ///Bp_OilStation:
    ///</summary>
    public class Bp_OilStation : BaseBusiness
    {
        ///<summary>
        ///
        ///</summary>
        public string HB_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Code { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        /// 本省省
        ///</summary>
        public string Province { get; set; }

        ///<summary>
        /// 武汉市
        ///</summary>
        public string City { get; set; }

        ///<summary>
        /// 江岸区
        ///</summary>
        public string Area { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Address { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string HB_CompanyID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string CompanyName { get; set; }

        ///<summary>
        /// 经度
        ///</summary>
        public string Longitude { get; set; }

        ///<summary>
        /// 维度
        ///</summary>
        public string Latitude { get; set; }

        ///<summary>
        /// 经营状态,0:正在营业;1:停业;2:关闭
        ///</summary>
        public string RunState { get; set; }

        ///<summary>
        /// 库站类别,0:一类站;1:二类站;2:三类站;3:四类站
        ///</summary>
        public string StationCategory { get; set; }

        ///<summary>
        /// 库站类型,0:加油站;1:加气站;2:油气站
        ///</summary>
        public string StationType { get; set; }

        ///<summary>
        /// 库站性质,0:全资;1:租赁;2:控股
        ///</summary>
        public string StationNature { get; set; }

        ///<summary>
        /// 位置类型,0:乡镇站;1:市道站;2:省道站;3:国道站;4:高速公路站;5:地级以上城区站;6:县城城区站;7:城郊结合部站;8:地级以上环城快速路站;9:县级市城区站;10:水上站
        ///</summary>
        public string StationAddress { get; set; }

        ///<summary>
        /// 经营方式,0:自主经营;1:委托经营;2:合资合作
        ///</summary>
        public string RunFuction { get; set; }

    }
}

