using System.Linq.Expressions;
using Toppine.Model.Entities;
using Toppine.Model.FromBody;
using Toppine.Model.ViewModels.DTO;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Threading.Tasks;

namespace Toppine.IRepository
{
    public interface IRRFRepository: IBaseRepository<RRF>
    {
        Task<dynamic> GetHRWContentInventoryAsync();

        // Task<RRF> GetRRFByCRNRRFAsync(string crnrr);
       
    }
   
}
