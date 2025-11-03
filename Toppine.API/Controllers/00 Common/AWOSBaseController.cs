using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using Toppine.Model.ViewModels.DTO;

namespace Toppine.API.Controllers
{
    public class AWOSBaseController : ControllerBase
    {
        [NonAction]
        public void GetUID(BaseDto para)
        {
            if (HttpContext.User.Claims.Count() <= 0)
            {
                if (!para.UID.HasValue)
                    para.UID = -1; //匿名用户

                if ((string.IsNullOrWhiteSpace(para.LoginName)))
                    para.LoginName = "Anonymous"; //匿名用户

                para.DSPermission = GetDistrictSubconPermisson();
                return;
            }

            //如果有传值，优先使用传值
            if (!para.UID.HasValue)
            {
                para.UID = Convert.ToInt16(HttpContext.User.Claims.Where(i => i.Type == "UID").FirstOrDefault().Value);
            }
            if ((string.IsNullOrWhiteSpace(para.LoginName)))
            {
                para.LoginName = HttpContext.User.Claims.Where(i => i.Type == "LoginName").FirstOrDefault()?.Value;
            }

            para.DSPermission = GetDistrictSubconPermisson();
        }

        public DistrictSubconPermissonDto GetDistrictSubconPermisson()
        {
            //默认全部
            DistrictSubconPermissonDto dsEntity = new DistrictSubconPermissonDto() { District = new List<int>(), SubCon = new List<int>() };

            if (HttpContext.User.Claims.Count() <= 0)
            {
                return dsEntity;
            }

            //如果有传值，优先使用传值
            var district = HttpContext.User.Claims.Where(i => i.Type == "DistrictList").FirstOrDefault()?.Value;
            var subCon = HttpContext.User.Claims.Where(i => i.Type == "SubconList").FirstOrDefault()?.Value;

            if (!string.IsNullOrWhiteSpace(district))
            {
                List<string> districtList = new List<string>(district.Split(','));
                foreach (var d in districtList)
                {
                    dsEntity.District.Add(Convert.ToInt16(d));
                }
                //dsEntity.District = new List<int>(district.Split(','));
                //dsEntity.District=","+dsEntity.District+",";
            }
            if (!string.IsNullOrWhiteSpace(subCon))
            {
                List<string> subConList = new List<string>(subCon.Split(','));
                foreach (var d in subConList)
                {
                    dsEntity.SubCon.Add(Convert.ToInt16(d));
                }
                //dsEntity.SubCon = "," + dsEntity.SubCon + ",";
            }
            return dsEntity;
        }
    }
}
