using Toppine.Model.Entities;
using Toppine.Model.ViewModels.DTO;

namespace Toppine.IRepository
{
    public interface ISubConInventoryRepository:IBaseRepository<SubConInventory>
    {
        public Task<List<IntIDValueDescriptionDto>> GetItemDropAsync(BaseDto para  = null);
    }
    
}
