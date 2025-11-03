using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Toppine.IRepository;
using Toppine.Model.ViewModels.Basics;
using Microsoft.EntityFrameworkCore;
using Toppine.Model.ViewModels.DTO.Common;

namespace Toppine.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _db;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext dbContext)
        {
            _db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _db.Set<T>();
        }

        /// <summary>
        /// 根据主键查询单条记录
        /// </summary>
        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// 根据主键查询单条记录（支持复合主键）
        /// </summary>
        public async Task<T> GetByIdAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }

        /// <summary>
        /// 查询单条记录
        /// </summary>
        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false)
        {
            var query = _db.Set<T>().Where(predicate);

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// 查询所有记录
        /// </summary>
        public async Task<List<T>> GetAllAsync(bool asNoTracking = false)
        {
            var query = _dbSet.AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// 根据条件查询列表
        /// </summary>
        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false)
        {
            var query = _dbSet.Where(predicate);

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// 根据条件查询列表（带排序）
        /// </summary>
        public async Task<List<T>> GetListAsync<TKey>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, TKey>> orderBy,
            bool isDescending = false,
            bool asNoTracking = false)
        {
            var query = _dbSet.Where(predicate);

            if (isDescending)
            {
                query = query.OrderByDescending(orderBy);
            }
            else
            {
                query = query.OrderBy(orderBy);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// 批量新增实体
        /// </summary>
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 批量更新实体
        /// </summary>
        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 根据主键删除实体
        /// </summary>
        public async Task<bool> DeleteByIdAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 根据条件删除实体
        /// </summary>
        public async Task<int> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = await _dbSet.Where(predicate).ToListAsync();
            if (!entities.Any())
                return 0;

            _dbSet.RemoveRange(entities);
            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 批量删除实体
        /// </summary>
        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 判断是否存在满足条件的记录
        /// </summary>
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        /// <summary>
        /// 获取记录数量
        /// </summary>
        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return await _dbSet.CountAsync();

            return await _dbSet.CountAsync(predicate);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        public async Task<(List<T> Items, int TotalCount)> GetPagedListAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<T, bool>> predicate = null,
            Expression<Func<T, object>> orderBy = null,
            bool isDescending = false,
            bool asNoTracking = false)
        {
            var query = _dbSet.AsQueryable();

            // 条件过滤
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            // 获取总数
            var totalCount = await query.CountAsync();

            // 排序
            if (orderBy != null)
            {
                query = isDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
            }

            // 分页
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            // 无跟踪查询
            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            var items = await query.ToListAsync();

            return (items, totalCount);
        }

        /// <summary>
        /// 获取 IQueryable（用于复杂查询）
        /// </summary>
        public IQueryable<T> GetQueryable(bool asNoTracking = false)
        {
            var query = _dbSet.AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return query;
        }

        /// <summary>
        /// 包含导航属性的查询
        /// </summary>
        public IQueryable<T> GetQueryableWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        /// <summary>
        /// 执行原生 SQL 查询
        /// </summary>
        //public async Task<List<T>> FromSqlAsync(string sql, params object[] parameters)
        //{
        //    return await _dbSet.FromSqlRaw(sql, parameters).ToListAsync();
        //}

        /// <summary>
        /// 执行 SQL 命令
        /// </summary>
        //public async Task<int> ExecuteSqlAsync(string sql, params object[] parameters)
        //{
        //    return await _db.Database.ExecuteSqlRawAsync(sql, parameters);
        //}
      
      
        public Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<T>> GetPagedListAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> predicate = null, string orderBy = "")
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        Task IBaseRepository<T>.DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            return DeleteAsync(predicate);
        }
    }


    /// <summary>
    /// 分页列表抽象基类（实现IPagedList<T>接口，封装通用逻辑）
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public abstract class BasePagedList<T> : IPagedList<T>
    {
        // 实现IPagedList<T>的属性
        public int PageIndex { get; protected set; }
        public int PageSize { get; protected set; }
        public int TotalCount { get; protected set; }
        public int TotalPages { get; protected set; }
        public IEnumerable<T> Items { get; protected set; }

        /// <summary>
        /// 基类构造函数：计算总页数（通用逻辑）
        /// </summary>
        /// <param name="pageIndex">页码（从0或1开始，根据业务定义）</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="totalCount">总条数</param>
        protected BasePagedList(int pageIndex, int pageSize, int totalCount)
        {
            // 校验参数合法性（通用校验）
            if (pageIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(pageIndex), "页码不能小于0");
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "页大小必须大于0");
            if (totalCount < 0)
                throw new ArgumentOutOfRangeException(nameof(totalCount), "总条数不能小于0");

            // 赋值基础属性
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;

            // 计算总页数（核心通用逻辑：向上取整）
            TotalPages = TotalCount == 0 ? 0 : (int)Math.Ceiling(TotalCount / (double)PageSize);
        }
       
    }

    public class PagedList<T> : BasePagedList<T>
    {
        /// <summary>
        /// 构造函数：接收分页数据并赋值
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="totalCount">总条数</param>
        /// <param name="items">当前页数据</param>
        public PagedList(int pageIndex, int pageSize, int totalCount, IEnumerable<T> items)
            : base(pageIndex, pageSize, totalCount) // 调用基类构造函数（复用总页数计算）
        {
            Items = items ?? throw new ArgumentNullException(nameof(items), "分页数据不能为空");
        }
    }
}
