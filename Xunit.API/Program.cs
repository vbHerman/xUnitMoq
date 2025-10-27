using Xunit.Services;

var builder = WebApplication.CreateBuilder(args);

// 配置监听地址（同时支持 HTTP 和 HTTPS，避免重定向冲突）
builder.WebHost.UseUrls("http://*:5857", "https://*:5858");

// 服务注册（按顺序注册，先基础服务，后业务服务）
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// 注册业务服务（根据实际需求启用）
//builder.Services.AddScoped<IRRFService, RRFService>();
//builder.Services.AddScoped<PaddleOCREditingchtHelper>();

// 构建应用（此时服务注册完成）
var app = builder.Build();

// 从已构建的 app 中获取日志器（安全获取）
var logger = app.Services.GetRequiredService<ILogger<Program>>();

try
{
    // 启用请求缓冲中间件
    app.Use((context, next) =>
    {
        context.Request.EnableBuffering();
        return next();
    });

    // 开发环境启用 Swagger
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // 若需要 HTTPS 重定向（确保已配置 HTTPS 端口）
    app.UseHttpsRedirection();

    // 若需要身份验证和授权（按实际需求启用）
    // app.UseAuthentication();
    // app.UseAuthorization();

    // 映射控制器
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.LogError(ex, "应用程序启动时发生错误");
}