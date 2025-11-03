using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Diagnostics.Contracts;
using System.IO;
using Toppine.Model.Entities;


namespace Toppine.Data
{
    public class DBSQLContext : DbContext
    {
        //添加日志工厂
        //方式1
        public static readonly ILoggerFactory MyLoggerFactory2
            = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                //builder
                //	.AddFilter((category, level) =>
                //		category == DbLoggerCategory.Database.Command.Name
                //		&& level == LogLevel.Information)
                //	.AddConsole();
            });
        public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] {
            new DebugLoggerProvider()
        });
        public static readonly ILoggerFactory MyLoggerFactory3
    = LoggerFactory.Create(builder => { builder.AddConsole(); });

        private string _contractnNo = "";//默认当前合约数据库
                                         //public DBSQLContext(DbContextOptions options) : base(options)
                                         //{

        //}

        public DBSQLContext(string connection = "")
        {
            if (!string.IsNullOrEmpty(connection))
                ContractNo = connection;
        }
        public string ContractNo
        {
            get
            {
                return _contractnNo;
            }
            set
            {
                _contractnNo = value;
            }
        }

        public virtual DbSet<RRF> RRF { get; set; }
        public virtual DbSet<HRWContentInventory> HRWContentInventory { get; set; }
        public virtual DbSet<SubConInventory> SubConInventory { get; set; }
        public virtual DbSet<SubConLogInventory> SubConLogInventory { get; set; }
        public virtual DbSet<DistrictInventory> DistrictInventory { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //连接字符串有有2种方式，一种是 通过 addDbContext 方式 在ConfigureServices中添加，
            //一种就是复写 DbContext.OnConfiguring 方法来实现。
            string useDB = "SqlServer";

            //添加 json 文件路径
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            //创建配置根对象
            var Configuration = builder.Build();
            optionsBuilder.UseLoggerFactory(MyLoggerFactory)
                //.UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer(Configuration.GetConnectionString(useDB)
                , sqlServerOptionsAction: sqlOptions =>
                {
                    //批处理最大数据
                    //批处理的条数MaxBatchSize,操作数据条数 <=3 的时候，不会批处理，还是分多次请求，只有>3，才会批处理
                    //sqlOptions.MaxBatchSize(3);
                    sqlOptions.EnableRetryOnFailure
                    (
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: new int[] { 2 }
                    );

                });
            //.UseLazyLoadingProxies(); //延迟加载
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
