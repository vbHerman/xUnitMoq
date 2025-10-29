using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace Toppine.Model.Entities
{
    [SugarTable("SubConLog")]
    public class SubConLog : CRUDBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Display(Name = "主键ID")]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键ID")]
        public int ID { get; set; }

        [Display(Name = "WorkType")]
        [SugarColumn(ColumnDescription = "WorkType", IsNullable = true)]
        public string WorkType { get; set; }

        [Display(Name = "PID")]
        [SugarColumn(ColumnDescription = "PID")]
        [Required(ErrorMessage = "请输入{0}")]
        public int PID { get; set; }                        //CRN/RRF-->ID.MWO->ID

        [Display(Name = "SID")]
        [SugarColumn(ColumnDescription = "SID")]
        [Required(ErrorMessage = "请输入{0}")]
        public int SID { get; set; }                        //SubConRemarkInventory-> ID

        [Display(Name = "Remark")]
        [SugarColumn(ColumnDescription = "Remark", IsNullable = true)]
        public string Remark { get; set; }                  //Remark

        [Display(Name = "LogTime")]
        [SugarColumn(ColumnDescription = "LogTime")]
        public DateTime LogTime { get; set; }               //Time

        [Display(Name = "Status")]
        [SugarColumn(ColumnDescription = "Status")]
        public bool Status { get; set; }
    }
}
