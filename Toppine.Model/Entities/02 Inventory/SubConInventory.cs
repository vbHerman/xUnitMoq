using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Toppine.Model.Entities
{
    [SugarTable("SubConInventory")]
    public class SubConInventory : CRUDBase
    {
        /// <summary>
        /// Code
        /// </summary>
        [Display(Name = "主键ID")]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键ID")]
        public int ID { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        [Display(Name = "Code")]
        [SugarColumn(IsNullable = false)]
        public string Code { get; set; }

        /// <summary>
        /// EnglishName
        /// </summary>
        [Display(Name = "EnglishName")]
        [SugarColumn(IsNullable = true)]
        public string EnglishName { get; set; }

        /// <summary>
        /// ChineseName
        /// </summary>
        [Display(Name = "ChineseName")]
        [SugarColumn(IsNullable = true)]
        public string ChineseName { get; set; }

        /// <summary>
        /// EnglishNameAbbr
        /// </summary>
        [Display(Name = "EnglishNameAbbr")]
        [SugarColumn(IsNullable = true)]
        public string EnglishNameAbbr { get; set; }

        /// <summary>
        /// ChineseNameAbbr
        /// </summary>
        [Display(Name = "ChineseNameAbbr")]
        [SugarColumn(IsNullable = true)]
        public string ChineseNameAbbr { get; set; }
    }
}
