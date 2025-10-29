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
    /// HRWContentInventory 实体类 
    /// </summary>
    [SugarTable("HRWContentInventory")]
    public class HRWContentInventory
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Display(Name = "主键ID")]
        [SugarColumn(IsPrimaryKey = true, ColumnDescription = "主键ID")]

        public int ID { get; set; }

        [Display(Name = "HRWContent")]
        [SugarColumn(ColumnDescription = "HRWContent")]
        public string HRWContent { get; set; }

    }
}
