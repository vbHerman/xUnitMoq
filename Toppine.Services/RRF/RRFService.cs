using Microsoft.Extensions.Logging;
using Toppine.IServices;
using Toppine.Model.ViewModels.DTO;
using Toppine.Model.Entities;
using Toppine.IRepository.UnitOfWork;
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
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRRFRepository _dal;
    private readonly IDistrictInventoryRepository _districtInventoryRepository;
    private readonly ISubConInventoryRepository _subConInventoryRepository;
    private readonly ISubConLogRepository _subConLogRepository;
    /// <summary>
    /// 构造函数（带参数，接收依赖）
    /// </summary>
    /// <param name="logger">日志服务</param>
    public RRFService(ILogger<RRFService> logger, IUnitOfWork unitOfWork, IRRFRepository dal, IDistrictInventoryRepository districtInventoryRepository, ISubConInventoryRepository subConInventoryRepository, ISubConLogRepository subConLogRepository)
    {
        _logger = logger; // 初始化依赖
        _unitOfWork = unitOfWork;
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
    public new async Task<dynamic> InitAsync(FMInitial entity)
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
}

