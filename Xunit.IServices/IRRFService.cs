namespace Xunit.Services;

/// <summary>
/// 服务接口
/// </summary>
public interface IRRFService
{
    /// <summary>
    /// 测试获取欢迎信息
    /// </summary>
    /// <param name="name">用户名</param>
    /// <returns>欢迎字符串</returns>
    string GetWelcomeMessage(string name);
}

