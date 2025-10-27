using Microsoft.Extensions.Logging;
//using Xunit.IServices;


/// <summary>
/// 实现类
/// </summary>
namespace Xunit.Services;

public class RRFService : IRRFService
{
    // 依赖项：日志服务（通过构造函数注入）
    private readonly ILogger<RRFService> _logger;


    /// <summary>
    /// 构造函数（带参数，接收依赖）
    /// </summary>
    /// <param name="logger">日志服务</param>
    public RRFService(ILogger<RRFService> logger)
    {
        _logger = logger; // 初始化依赖
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
}

