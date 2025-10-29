using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toppine.Model.ViewModels.DTO
{
    public class PageDto : BaseDto
    {
        //每页默认记录数
        private int _pageSize = 10;
        //每页返回最大记录数
        private const int MaxPageSize = 500;
        //当前页
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize && value != 999999 && value != 99999) ? MaxPageSize : value;
        }
        //排序字段,指定默认
        public string OrderBy { get; set; }

        /// <summary>
        /// Asc--升序   Desc--降序
        /// </summary>
        public string AscDesc { get; set; }

    }

    public class BaseDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "LoginName")]
        [SugarColumn(ColumnDescription = "LoginName", IsNullable = true)]
        public virtual string LoginName { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [Display(Name = "UID")]
        [SugarColumn(ColumnDescription = "UID", IsNullable = true)]
        public int? UID { get; set; }

        //保存权限的列表
        [NotMapped]
        public DistrictSubconPermissonDto DSPermission { get; set; }

    }
    public class IDListDto : BaseDto
    {
        public List<int> IDList { get; set; }

    }

    /// <summary>
    /// 表中含有
    /// </summary>
    public class EFBaseDto
    {
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateOn { get; set; }
    }

    /// <summary>
    /// 从TOKEN中获取District和SubCon有权限的数据
    /// </summary>
    public class DistrictSubconPermissonDto
    {
        public List<int> District { get; set; }
        public List<int> SubCon { get; set; }

    }
}
