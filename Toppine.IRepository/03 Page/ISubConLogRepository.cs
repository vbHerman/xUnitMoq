using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toppine.Model.Entities;
using Toppine.Model.ViewModels.DTO;

namespace Toppine.IRepository
{
    public interface  ISubConLogRepository :IBaseRepository<SubConLog>
    {
        /// <summary>
        /// 获取缓存的下拉数据
        /// </summary>
        Task<List<IntIDValueDescriptionDto>> GetItemDropAsync();

        /// <summary>
        /// 更新下拉数据缓存
        /// </summary>
        Task<List<IntIDValueDescriptionDto>> UpdateItemDropCacheAsync();
    }
    
}
