using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toppine.Caching
{
    /// <summary>
    /// Redis配置模型（映射appsettings.json中的RedisConfig节点）
    /// </summary>
    public class RedisConfig
    {
        /// <summary>
        /// 是否启用Redis缓存
        /// </summary>
        public bool UseCache { get; set; }

        /// <summary>
        /// 是否启用Redis作为定时任务
        /// </summary>
        public bool UseTimedTask { get; set; }
    }
}
