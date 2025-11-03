using Microsoft.Extensions.Logging;
using Toppine.IServices;
using Toppine.Model.ViewModels.DTO;
using Toppine.Model.Entities;
using Toppine.Model.FromBody;
using Toppine.IRepository;
using System.Data.Common;
/// <summary>
/// 实现类
/// </summary>
namespace Toppine.Services;

public class RRFService : BaseServices<RRF>, IRRFService
{
    // 依赖项：日志服务（通过构造函数注入）
    private readonly ILogger<RRFService> _logger;
    //private readonly IUnitOfWork _unitOfWork;
    private readonly IRRFRepository _dal;
    private readonly IDistrictInventoryRepository _districtInventoryRepository;
    private readonly ISubConInventoryRepository _subConInventoryRepository;
    private readonly ISubConLogRepository _subConLogRepository;

    /// <summary>
    /// 构造函数（带参数，接收依赖）
    /// </summary>
    /// <param name="logger">日志服务</param>
    public RRFService(ILogger<RRFService> logger, IRRFRepository dal, IDistrictInventoryRepository districtInventoryRepository, ISubConInventoryRepository subConInventoryRepository, ISubConLogRepository subConLogRepository) :base(dal)
    {

        _logger = logger; // 初始化依赖
        _dal = dal;
        _districtInventoryRepository = districtInventoryRepository;
        _subConInventoryRepository = subConInventoryRepository;
        _subConLogRepository = subConLogRepository;
    }
    /// <summary>
    /// 测试实现接口的方法
    /// </summary>
    public string GetWelcomeMessage(string name)
    {
        // 使用注入的日志服务
        _logger.LogInformation("用户 {Name} 调用了欢迎接口", name);

        return $"欢迎您，{name}！这是来自服务层的响应";
    }
    public  async Task<dynamic> InitAsync(FMInitial entity)
    {
        var districtList = await _districtInventoryRepository.GetItemDropAsync(entity);
        var subConList = await _subConInventoryRepository.GetItemDropAsync(entity);

        // 修正语法错误：去掉多余的点（..），并确认调用的仓储是否正确
        var subConLogDescriptionList = await _subConLogRepository.GetItemDropAsync(); // 假设该方法也属于此仓储

        var highRiskWorkList = await _dal.GetHRWContentInventoryAsync();

        return (new
        {
            DistrictList = districtList,
            SubConList = subConList,
            SubConLogDescriptionList = subConLogDescriptionList,
            HighRiskWorkList = highRiskWorkList
        });
    }
    //public async Task<List<RRFSearchDto>> SearchAsync(SearchKeyDropDto para)
    //{ 
        
    //}

    public async Task<CRUDResult> CheckData(RRFDto para, bool isAdd = false)
    {
        CRUDResult result = new CRUDResult();

        #region 1.常规错误检查【包括空字段，格式等非数据库交互的检查】

        if (string.IsNullOrWhiteSpace(para.CRNRRF))
            result.MessageList.Add("CRN RRF cannot be null.");

        //有错误先返回
        if (result.MessageList.Count > 0)
            return result;
        #endregion

        #region 2.与数据库交互错误检查
        RRF existEntity = null;
        if (para.ID > 0)
        {
            //existEntity = await _dal.QueryByIdAsync(para.ID);
            existEntity = await _dal.GetFirstOrDefaultAsync(
                predicate: i => i.ID == para.ID,  // 传递ID条件
                asNoTracking: true);
        }
        else
        {
            existEntity = await _dal.GetFirstOrDefaultAsync(
               predicate: i => i.CRNRRF == para.CRNRRF,  // 传递CRNRRF条件
               asNoTracking: true
           );
        }
        if (existEntity != null)
        {
            result.Entity = existEntity;
            if (isAdd)
            {
                //如果新增
                result.MessageList.Add(string.Format("CRN/RRF is exist!"));
            }
        }
        else
        {
            if (!isAdd)
            {
                //如果修改
                result.MessageList.Add(string.Format("FCRN/RRF  is not exist!"));
            }
        }
        #endregion

        if (result.MessageList.Count <= 0)
            result.Result = true;

        return result;
    }
}

