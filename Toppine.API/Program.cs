using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Toppine.Configuration;
using Toppine.Core.AutoFac;
using Toppine.Data;
using Toppine.IRepository;
using Toppine.Repository;
using Toppine.Services;
using Toppine.Caching;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton(new AppSettingsHelper(builder.Environment.ContentRootPath));
// 1. 添加控制器
builder.Services.AddControllers();

// 2. 注册服务（接口与实现类绑定，支持依赖注入）

builder.Services.Configure<RedisConfig>(
    builder.Configuration.GetSection("RedisConfig") // 读取RedisConfig节点
);
// 配置 EF Core
builder.Services.AddDbContext<DBSQLContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
//// 配置 SqlSugar
//builder.Services.AddScoped<ISqlSugarClient>(provider =>
//{
//    var sqlSugar = new SqlSugarScope(new ConnectionConfig()
//    {
//        ConnectionString = builder.Configuration.GetConnectionString("SqlConnection"),
//        DbType = DbType.SqlServer,
//        IsAutoCloseConnection = true
//    });
//    return sqlSugar;
//});

////添加数据库连接SqlSugar注入支持
//builder.Services.AddSqlSugarSetup();
// 1. 注册Redis配置（绑定appsettings.json中的RedisConfig节点）


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
builder.Services.AddScoped<IRRFRepository, RRFRepository>();  // 注册专用仓储
builder.Services.AddScoped<RRFService>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacModuleRegister()); // 确保模块被注册
});

var app = builder.Build();

// 4. 开发环境启用Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // 优先加载，显示详细错误
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