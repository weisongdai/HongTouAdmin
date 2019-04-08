using HT.EFCode.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HT.Repositorys.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetByPrimaryKey(long id);
        IQueryable<TEntity> GetList();
        IQueryable<TEntity> GetExpression(Expression<Func<TEntity, bool>> expression);

        #region 添加一个或多个
        int Create(TEntity input);
        Task<int> CreateAsync(TEntity input);
        int CreateRange(IEnumerable<TEntity> input);
        Task<int> CreateRangeAsync(IEnumerable<TEntity> input);
        #endregion

        #region 更新一个或多个
        int Update(TEntity input);
        Task<int> UpdateAsync(TEntity input);
        int UpdateRange(IEnumerable<TEntity> input);
        Task<int> UpdateRangeAsync(IEnumerable<TEntity> input);
        #endregion

        #region 删除一个或多个
        int Delete(TEntity input);
        Task<int> DeleteAsync(TEntity input);
        int DeleteRange(IEnumerable<TEntity> input);
        Task<int> DeleteRangeAsync(IEnumerable<TEntity> input);
        #endregion
    }
}
