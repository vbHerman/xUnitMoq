using System.ComponentModel.DataAnnotations;

namespace Toppine.Model.ViewModels.DTO
{
    public class CRUDResult
    {
        //保存错误信息
        public List<string> MessageList { get; set; } = new List<string>();
        //操作结果 
        public bool Result { get; set; } = false;
        //返回ID值
        public Guid? ID { get; set; }
        public string InspectionNo { get; set; }
        //返回结果中多个值，如Photo的FilePath
        public List<string> ValuesList { get; set; } = new List<string>();
        //返回当前实体
        public dynamic Entity { get; set; }
        public string GetMessage
        {
            get
            {
                if (MessageList.Count > 0)
                {
                    string errorMsg = string.Join(System.Environment.NewLine + "  -- ", MessageList);
                    return "The following fields are empty or incorrectly entered, please enter the correct data:" + System.Environment.NewLine + errorMsg;
                }
                else
                    return "";
            }
        }

    }
}
