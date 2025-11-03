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
        public int CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateOn { get; set; }
    }
}
