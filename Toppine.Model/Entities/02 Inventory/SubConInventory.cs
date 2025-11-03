using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Toppine.Model.Entities
{
   
    public class SubConInventory : CRUDBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Code { get; set; }
        public string EnglishName { get; set; }
        public string ChineseName { get; set; }

        public string EnglishNameAbbr { get; set; }

        public string ChineseNameAbbr { get; set; }
    }
}
