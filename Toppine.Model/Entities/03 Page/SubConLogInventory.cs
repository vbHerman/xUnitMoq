using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toppine.Model.Entities
{
    /// <summary>
    /// SubConLogInventory实体类
    /// </summary>
    [Table("SubConLogInventory")]
    public partial class SubConLogInventory : CRUDBase
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public string RemarkGroup { get; set; }

    }
}
