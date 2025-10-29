using SqlSugar;
using Toppine.Caching.Manual;
using Toppine.Configuration;
using Toppine.IRepository;
using Toppine.IRepository.UnitOfWork;
using Toppine.Model.Entities;
using Toppine.Model.ViewModels.DTO;

namespace Toppine.Repository
{
    public class DistrictInventoryRepository : BaseRepository<DistrictInventory>, IDistrictInventoryRepository
    {
        public DistrictInventoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        /// <summary>  
        /// 获取地区库存下拉列表（含缓存和权限过滤）  
        /// </summary>  
        public async Task<List<IntIDDescriptionDto>> GetItemDropAsync(BaseDto para = null)
        {
            var cacheKey = GlobalConstVars.CacheDistrictInventoryDropList;
            // 1. 从缓存获取数据（CoreShop使用ManualDataCache管理缓存）  
            var itemList = ManualDataCache.Instance.Get<List<IntIDDescriptionDto>>(cacheKey);
            if (itemList == null)
            {
                // 2. 缓存未命中，从数据库查询  
                itemList = await DbClient.Queryable<DistrictInventory>()
                    .Select(p => new IntIDDescriptionDto
                    {
                        ID = p.ID,
                        Description = p.Code // 假设表中字段为Code，对应Description  
                    })
                    .With(SqlWith.NoLock) // 读未提交（提升查询性能）  
                    .ToListAsync();

                // 3. 存入缓存  
                ManualDataCache.Instance.Set(cacheKey, itemList);
            }

            // 4. 权限过滤（仅返回用户有权限的地区）  
            if (para != null && para.DSPermission != null && para.DSPermission.District != null)
            {
                if (para?.DSPermission?.District?.Count > 0)
                {
                    var permissionSet = new HashSet<int>(para.DSPermission.District);
                    itemList = itemList.Where(item => permissionSet.Contains(item.ID)).ToList();
                }
               
            }

            return itemList;
        }
    }
}
