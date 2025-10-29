using SqlSugar;
using Toppine.Caching.Manual;
using Toppine.Configuration;
using Toppine.IRepository;
using Toppine.IRepository.UnitOfWork;
using Toppine.Model.Entities;
using Toppine.Model.ViewModels.DTO;

namespace Toppine.Repository
{
    public class SubConInventoryRepository :BaseRepository<SubConInventory>, ISubConInventoryRepository
    {
        public SubConInventoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
        public async Task<List<IntIDValueDescriptionDto>> GetItemDropAsync(BaseDto para = null)
        {
            var cacheKey = GlobalConstVars.SubConInventoryDropList;
            var itemList = ManualDataCache.Instance.Get<List<IntIDValueDescriptionDto>>(cacheKey);
            if (itemList == null)
            {
                itemList= await DbClient.Queryable<SubConInventory>()
                    .Select(p => new IntIDValueDescriptionDto
                    {
                        ID = p.ID,
                        Value = p.Code,
                        Description = p.EnglishName,
                    })
                .With(SqlWith.NoLock)
                .ToListAsync();
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
