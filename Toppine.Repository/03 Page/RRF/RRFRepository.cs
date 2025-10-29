using SqlSugar;
using Toppine.IRepository;
using Toppine.IRepository.UnitOfWork;
using Toppine.Model.Entities;
using Toppine.Model.ViewModels.DTO;

namespace Toppine.Repository
{
    public class RRFRepository :BaseRepository<RRF>, IRRFRepository
    {
        public RRFRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<dynamic> GetHRWContentInventoryAsync()
        {
             var result = await DbClient.Queryable<HRWContentInventory>()
                .Select(i => new TextINTValueDto
                {
                   ID= i.ID,
                    Description= i.HRWContent
                })
                .With(SqlWith.NoLock)
                .ToListAsync();
            return result;
        }

    }
}

