using HT.EFCode.EntityFrameworkCore;
using HT.EFCode.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ws.CommonWeb.Checks;
using Ws.CommonWeb.Interfaces;

namespace HT.Repositorys.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public readonly HTDbContext _dbContext;

        public BaseRepository(HTDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetByPrimaryKey(long id)
        {
            return _dbContext.Set<TEntity>().Where(e => e.Id == id);
        }
        public IQueryable<TEntity> GetList()
        {
            return _dbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> GetExpression(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression);
        }

        #region 添加一个或多个
        public int Create(TEntity input)
        {
            Check.NotNull(input, nameof(input));

            _dbContext.Set<TEntity>().Add(input);
            return _dbContext.SaveChanges();
        }
        public async Task<int> CreateAsync(TEntity input)
        {
            Check.NotNull(input, nameof(input));
            await _dbContext.Set<TEntity>().AddAsync(input);
            return await _dbContext.SaveChangesAsync();
        }
        public int CreateRange(IEnumerable<TEntity> input)
        {
            Check.HasNoNulls(input, nameof(input));
            _dbContext.Set<TEntity>().AddRange(input);
            return _dbContext.SaveChanges();
        }
        public async Task<int> CreateRangeAsync(IEnumerable<TEntity> input)
        {
            Check.HasNoNulls(input, nameof(input));
            await _dbContext.Set<TEntity>().AddRangeAsync(input);
            return await _dbContext.SaveChangesAsync();
        }
        #endregion

        #region 更新一个或多个
        public int Update(TEntity input)
        {
            Check.NotNull(input, nameof(input));
            _dbContext.Set<TEntity>().Update(input);
            return _dbContext.SaveChanges();
        }
        public async Task<int> UpdateAsync(TEntity input)
        {
            Check.NotNull(input, nameof(input));
            _dbContext.Set<TEntity>().Update(input);
            return await _dbContext.SaveChangesAsync();
        }
        public int UpdateRange(IEnumerable<TEntity> input)
        {
            Check.HasNoNulls(input, nameof(input));
            _dbContext.Set<TEntity>().UpdateRange(input);
            return _dbContext.SaveChanges();
        }
        public async Task<int> UpdateRangeAsync(IEnumerable<TEntity> input)
        {
            Check.HasNoNulls(input, nameof(input));
            _dbContext.Set<TEntity>().UpdateRange(input);
            return await _dbContext.SaveChangesAsync();
        }
        #endregion

        #region 删除一个或多个
        public int Delete(TEntity input)
        {
            //_dbContext.Set<TEntity>().Attach(input);
            _dbContext.Set<TEntity>().Remove(input);
            return _dbContext.SaveChanges();
        }
        public async Task<int> DeleteAsync(TEntity input)
        {
            //_dbContext.Set<TEntity>().Attach(input);
            _dbContext.Set<TEntity>().Remove(input);
            return await _dbContext.SaveChangesAsync();
        }
        public int DeleteRange(IEnumerable<TEntity> input)
        {
            //_dbContext.Set<TEntity>().Attach(input);
            Check.HasNoNulls(input, nameof(input));
            _dbContext.Set<TEntity>().RemoveRange(input);
            return _dbContext.SaveChanges();
        }
        public async Task<int> DeleteRangeAsync(IEnumerable<TEntity> input)
        {
            Check.HasNoNulls(input, nameof(input));
            //_dbContext.Set<TEntity>().Attach(input);
            _dbContext.Set<TEntity>().RemoveRange(input);
            return await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
