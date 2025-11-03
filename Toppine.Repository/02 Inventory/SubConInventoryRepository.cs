using Microsoft.EntityFrameworkCore;

using Toppine.Caching.Manual;
using Toppine.Configuration;
using Toppine.Data;
using Toppine.IRepository;

using Toppine.Model.Entities;
using Toppine.Model.ViewModels.DTO;

namespace Toppine.Repository
{
    public class SubConInventoryRepository :BaseRepository<SubConInventory>, ISubConInventoryRepository
    {
        private DBSQLContext _db;
        public SubConInventoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<IntIDValueDescriptionDto>> GetItemDropAsync(BaseDto para = null)
        {
            var cacheKey = GlobalConstVars.SubConInventoryDropList;
            List<IntIDValueDescriptionDto> itemList = ManualDataCache.Instance.Get<List<IntIDValueDescriptionDto>>(cacheKey);

            if (itemList == null)
            {
                // EF Core查询：从DbSet查询并投影到DTO，异步获取列表
                itemList = await _db.SubConInventory // _db应为你的DbContext实例，SubConInventory是DbSet<SubConInventory>
                    .Select(p => new IntIDValueDescriptionDto
                    {
                        ID = p.ID,
                        Value = p.Code,
                        Description = p.EnglishName
                    })
                    .ToListAsync(); // EF Core异步查询方法（需引入Microsoft.EntityFrameworkCore）

                // 存入缓存（保持原有缓存逻辑）
                 ManualDataCache.Instance.Set(cacheKey, itemList);
            }
            if (para != null && para.DSPermission != null && para.DSPermission.SubCon != null )
            {
                if (para?.DSPermission?.SubCon?.Count > 0)
                {
                    var permissionSet = new HashSet<int>(para.DSPermission.SubCon);
                    itemList = itemList.Where(item => permissionSet.Contains(item.ID)).ToList();
                }
            }

            return itemList;
        }
    }
}
