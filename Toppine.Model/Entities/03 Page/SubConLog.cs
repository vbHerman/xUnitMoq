using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Toppine.Model.Entities
{
 
    public class SubConLog : CRUDBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string WorkType { get; set; }
        public int PID { get; set; }                        //CRN/RRF-->ID.MWO->ID
        public int SID { get; set; }                        //SubConRemarkInventory-> ID
        public string Remark { get; set; }                  //Remark
        public DateTime LogTime { get; set; }               //Time
        public bool Status { get; set; }
    }
}
