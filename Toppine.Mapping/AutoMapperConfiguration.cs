using System.IO;
using AutoMapper;
using Toppine.Model.Entities;

using Toppine.Model.ViewModels.DTO;
using Newtonsoft.Json;

namespace Toppine.Mapping
{
    /// <summary>
    /// AutoMapper的全局实体映射配置静态类
    /// </summary>
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            #region 2. Inventory

            #endregion
            #region 2.14 RRF
            CreateMap<RRF, RRFDto>().ReverseMap();
            #endregion
        }
    }
}
