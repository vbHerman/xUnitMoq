using Toppine.Model.Entities;
using Toppine.Model.ViewModels.DTO;

namespace Toppine.IRepository
{
    public interface IDistrictInventoryRepository:IBaseRepository<DistrictInventory>
    {
        Task<List<IntIDDescriptionDto>> GetItemDropAsync(BaseDto para = null);
    }
}
