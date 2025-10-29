using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Toppine.IServices;
using Toppine.Model.FromBody;

namespace Toppine.API.Controllers;


/// <summary>
/// 示例控制器
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class RRFController : ControllerBase
{
    // 注入服务接口（而非具体实现类，符合面向接口编程）
    private readonly IRRFService _rrfService;
    /// <summary>
    /// 控制器构造函数（注入服务）
    /// </summary>
    public RRFController(IRRFService rrfService)
    {
        _rrfService = rrfService;
    }

    /// <summary>
    /// 获取欢迎信息
    /// </summary>
    /// <param name="name">用户名（例如：张三）</param>
    /// <returns>欢迎消息</returns>
    [HttpGet("welcome")]
    public IActionResult GetWelcome([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest("用户名不能为空");
        }

        var message = _rrfService.GetWelcomeMessage(name);
        return Ok(message);
    }

    [HttpGet("init")]
    [Description("初始化API")]
    public async Task<IActionResult> InitAsync([FromQuery] FMInitial para)
    {
        //除登录API外，所有其它API的参数需要带上当前登录用户ID[默认继承BaseDto，如果没值，从token中获取]
        //GetUID(para);
        return Ok(await _rrfService.InitAsync(para));
    }
}


