using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toppine.Model.Entities
{
    /// <summary>
    /// SubConLogInventory实体类
    /// </summary>
    [SugarTable("SubConLogInventory")]
    public partial class SubConLogInventory : CRUDBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Display(Name = "主键ID")]
        [SugarColumn(IsPrimaryKey = true, ColumnDescription = "主键ID")]
        [Required(ErrorMessage = "请输入{0}")]
        public int ID { get; set; }

        [Display(Name = "Description")]
        [SugarColumn( ColumnDescription = "Description",IsNullable = true)]
        public string Description { get; set; }

        [Display(Name = "RemarkGroup")]
        [SugarColumn(ColumnDescription = "RemarkGroup", IsNullable = true)]
        public string RemarkGroup { get; set; }

    }
}
