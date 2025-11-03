using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toppine.Model.Entities
{
   
    public class HRWContentInventory
    {
        [Key]
        public int ID { get; set; }
        public string HRWContent { get; set; }

    }
}
