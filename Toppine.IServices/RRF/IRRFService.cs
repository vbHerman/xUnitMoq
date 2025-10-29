using Toppine.Model.FromBody;
using Toppine.Model.Entities;

namespace Toppine.IServices;

/// <summary>
/// 服务接口
/// </summary>
public interface IRRFService : IBaseServices<RRF>
{
    /// <summary>
    /// 测试获取欢迎信息
    /// </summary>
    /// <param name="name">用户名</param>
    /// <returns>欢迎字符串</returns>
    string GetWelcomeMessage(string name);

    Task<dynamic> InitAsync(FMInitial entity);

}

