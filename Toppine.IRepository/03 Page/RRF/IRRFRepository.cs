using Toppine.Model.Entities;
using Toppine.Model.FromBody;
using Toppine.Model.ViewModels.DTO;

namespace Toppine.IRepository
{
    public interface IRRFRepository:IBaseRepository<RRF>
    {
        Task<dynamic> GetHRWContentInventoryAsync();
    }
}
