using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toppine.Caching.Redis
{
    public class RedisCacheService
    {
        // 通过IOptions获取Redis配置（自动映射appsettings.json）
        private readonly RedisConfig _redisConfig;

        // 构造函数注入
        public RedisCacheService(IOptions<RedisConfig> redisConfigOptions)
        {
            // 验证配置是否存在
            _redisConfig = redisConfigOptions.Value ??
                throw new ArgumentNullException(nameof(redisConfigOptions), "Redis配置未在appsettings.json中定义");
        }

        public void DoSomething()
        {
            // 使用配置：是否启用Redis缓存
            if (_redisConfig.UseCache)
            {
                // 执行Redis缓存逻辑
            }

            // 使用配置：是否启用Redis定时任务
            if (_redisConfig.UseTimedTask)
            {
                // 执行Redis定时任务逻辑
            }
        }
    }
}
