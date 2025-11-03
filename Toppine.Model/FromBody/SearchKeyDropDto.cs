using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Toppine.Model.ViewModels.DTO;

namespace Toppine.Model.FromBody
{
    public class SearchKeyDropDto : BaseDto
    {
        public string keyWords { get; set; }
    }
}
