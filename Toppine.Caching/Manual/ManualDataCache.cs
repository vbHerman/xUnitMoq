using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toppine.Caching.Redis;
using Toppine.Configuration;
using Toppine.Caching.MemoryCache;

namespace Toppine.Caching.Manual
{
    /// <summary>
    /// 手动缓存调用
    /// </summary>
    public static partial class ManualDataCache
    {
        private static IManualCacheManager _instance = null;
        /// <summary>
        /// 静态实例，外部可直接调用
        /// </summary>
        public static IManualCacheManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (AppSettingsConstVars.RedisUseCache)
                    {
                        _instance = new RedisCacheManager();
                    }
                    else
                    {
                        _instance = new MemoryCacheManager();

                    }
                }
                return _instance;
            }
        }
    }
}
