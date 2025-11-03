using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Toppine.Caching.Manual;
using Toppine.Configuration;
using Toppine.Data;
using Toppine.IRepository;

using Toppine.Model.Entities;
using Toppine.Model.ViewModels.DTO;

namespace Toppine.Repository
{
    public  class SubConLogRepository:BaseRepository<SubConLog>, ISubConLogRepository
    {
        private DBSQLContext _db;
        public SubConLogRepository(DbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// 从缓存获取下拉数据（优先查缓存，无则更新缓存）
        /// </summary>
        public async Task<List<IntIDValueDescriptionDto>> GetItemDropAsync()
        {
            // 尝试从缓存获取
            var cacheData = ManualDataCache.Instance.Get<List<IntIDValueDescriptionDto>>(GlobalConstVars.CurrentPageName);
            if (cacheData != null)
            {
                return cacheData;
            }

            // 缓存不存在则查询数据库并更新缓存
            return await UpdateItemDropCacheAsync();
        }
        public async Task<List<IntIDValueDescriptionDto>> UpdateItemDropCacheAsync()
        {
            var cacheKey = GlobalConstVars.CurrentPageName;
            var itemList = await _db.SubConLogInventory
                                    .Select(p => new IntIDValueDescriptionDto
                                    {
                                        ID = p.ID,
                                        Value = p.RemarkGroup,
                                        Description = p.Description,
                                    })
                .ToListAsync();
            // 存入缓存（项目中默认无过期时间，按需添加）
            ManualDataCache.Instance.Set(cacheKey, itemList);
            return itemList;
        }

    }
}
