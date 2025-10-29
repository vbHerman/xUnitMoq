using SqlSugar;
using System.ComponentModel.DataAnnotations;

namespace Toppine.Model.Entities
{
    /// <summary>
    /// DistrictInventory实体类
    /// </summary>
    [SugarTable("DistrictInventory")]
    public partial class DistrictInventory : CRUDBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Display(Name = "主键ID")]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键ID")]
        [Required(ErrorMessage = "请输入{0}")]
        public int ID { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        [Display(Name = "Code")]
        [SugarColumn(IsNullable = false)]
        public string Code { get; set; }

        /// <summary>
        /// District
        /// </summary>
        [Display(Name = "地区")]
        [SugarColumn( ColumnDescription = "District", IsNullable = true)]
        public string District { get; set; }

        /// <summary>
        /// 取AreaCode中的前缀，一个area code只能对应一个District 
        /// 一个District可以对应多个area code,用 , 隔开
        /// </summary>
        [Display(Name = "责任区域代码")]
        [SugarColumn(ColumnDescription = "ResponsibleAreaCode", IsNullable = true)]
        public string ResponsibleAreaCode { get; set; }
    }
}
