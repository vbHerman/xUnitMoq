using Microsoft.EntityFrameworkCore;
using Toppine.Data;
using Toppine.IRepository;

using Toppine.Model.Entities;
using Toppine.Model.ViewModels.DTO;

namespace Toppine.Repository
{
    public class RRFRepository : BaseRepository<RRF>, IRRFRepository
    {
        private DBSQLContext _db;
        public RRFRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<dynamic> GetHRWContentInventoryAsync()
        {
            var result = await _db.HRWContentInventory
               .Select(i => new TextINTValueDto
               {
                   ID = i.ID,
                   Description = i.HRWContent
               })
               .ToListAsync();
            return result;
        }


        //public async Task<RRF> GetRRFByIdAsync(string crnrr)
        //{
        //    var result = await DbClient.Queryable<RRF>()
        //        .Where(i => i.CRNRRF == crnrr)
        //        .FirstOrDefaultAsync();
        //    return result;
        //}
       

    }
}

