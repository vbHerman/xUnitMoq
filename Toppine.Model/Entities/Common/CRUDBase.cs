using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toppine.Model.Entities
{
    public class CRUDBase
    {
        [Display(Name = "创建者名字CreateBy")]
        [SugarColumn(ColumnDescription = "创建人名字CreateBy")]
        public int CreateBy { get; set; }

        [Display(Name = "创建时间CreateOn")]
        [SugarColumn(ColumnDescription = "创建CreateOn")]
        public DateTime CreateOn { get; set; }

        [Display(Name = "修改者名字UpdateBy")]
        [SugarColumn(ColumnDescription = "修改者名字UpdateBy")]
        public int UpdateBy { get; set; }

        [Display(Name = "修改者时间UpdateOn")]
        [SugarColumn(ColumnDescription = "修改者时间UpdateOn")]
        public DateTime UpdateOn { get; set; }
    }
}
