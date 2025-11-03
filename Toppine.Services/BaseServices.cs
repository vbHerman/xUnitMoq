using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Toppine.IRepository;
using Toppine.IServices;
using Toppine.Model.ViewModels.Basics;

namespace Toppine.Services
{
    /// <summary>
    /// 服务层基类实现
    /// </summary>
    /// <typeparam name="T">泛型实体类</typeparam>
    public class BaseServices<T> : IBaseServices<T> where T : class
    {
        // 依赖注入仓储层接口（通过构造函数注入）
        protected readonly IBaseRepository<T> _baseRepository;

        /// <summary>
        /// 构造函数：注入仓储实例
        /// </summary>
        /// <param name="baseRepository">仓储层实例</param>
        public BaseServices(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository), "仓储接口不能为空");
        }

        #region 查询方法
        /// <summary>
        /// 按ID查询实体
        /// </summary>
        public async Task<T> GetByIdAsync(object id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 按条件查询单条实体
        /// </summary>
        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false)
        {
            return await _baseRepository.GetFirstOrDefaultAsync(predicate, asNoTracking);
        }

        /// <summary>
        /// 按条件查询实体列表
        /// </summary>
        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await _baseRepository.GetListAsync(predicate);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        public async Task<Model.ViewModels.DTO.Common.IPagedList<T>> GetPagedListAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> predicate = null, string orderBy = "")
        {
            return await _baseRepository.GetPagedListAsync(pageIndex, pageSize, predicate, orderBy);
        }
        #endregion

        #region 增删改方法
        /// <summary>
        /// 新增实体
        /// </summary>
        public async Task<T> AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "新增实体不能为空");

            return await _baseRepository.AddAsync(entity);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "更新实体不能为空");

            await _baseRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 按ID删除实体
        /// </summary>
        public async Task DeleteAsync(object id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), "删除ID不能为空");

            await _baseRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 按条件删除实体
        /// </summary>
        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate), "删除条件不能为空");

            await _baseRepository.DeleteAsync(predicate);
        }
        #endregion

        #region 工具方法
        /// <summary>
        /// 判断实体是否存在
        /// </summary>
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _baseRepository.ExistsAsync(predicate);
        }

        /// <summary>
        /// 统计实体数量
        /// </summary>
        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await _baseRepository.CountAsync(predicate);
        }
        #endregion

        #region 批量操作
        /// <summary>
        /// 批量新增
        /// </summary>
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            if (entities == null || !entities.Any())
                throw new ArgumentException("批量新增的实体集合不能为空", nameof(entities));

            await _baseRepository.AddRangeAsync(entities);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            if (entities == null || !entities.Any())
                throw new ArgumentException("批量更新的实体集合不能为空", nameof(entities));

            await _baseRepository.UpdateRangeAsync(entities);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            if (entities == null || !entities.Any())
                throw new ArgumentException("批量删除的实体集合不能为空", nameof(entities));

            await _baseRepository.DeleteRangeAsync(entities);
        }
        #endregion
    }
}
