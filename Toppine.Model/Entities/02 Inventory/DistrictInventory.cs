//
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Toppine.Model.Entities
{
   
    public partial class DistrictInventory : CRUDBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Code { get; set; }
        public string District { get; set; }
        /// <summary>
        /// 取AreaCode中的前缀，一个area code只能对应一个District 
        /// 一个District可以对应多个area code,用 , 隔开
        /// </summary>
		public string ResponsibleAreaCode { get; set; }
    }
}
