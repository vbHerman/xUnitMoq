using Autofac;
using Autofac.Extensions.DependencyInjection;
using Toppine.Core.AutoFac;
using Toppine.Core.Config;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://*:5857", "https://*:5858");
// 1. 添加控制器
builder.Services.AddControllers();

// 2. 注册服务（接口与实现类绑定，支持依赖注入）


//添加数据库连接SqlSugar注入支持
builder.Services.AddSqlSugarSetup();
//MediatR（只需要注册一个,同项目或类库下就不需要注册多个）
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(TextMessageEventCommand).Assembly));
// 3. 配置 Swagger（默认已包含，这里补充文档信息）
builder.Services.AddSwaggerGen(options =>
{
    // 添加Swagger文档信息（在UI中显示）
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "示例API",
        Version = "v1",
        Description = "包含接口、实现类、依赖注入和Swagger的示例"
    });
});
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacModuleRegister()); // 确保模块被注册
});

var app = builder.Build();

// 4. 开发环境启用Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // 生成Swagger文档
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "示例API v1");
    }); // 提供Swagger UI页面
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();