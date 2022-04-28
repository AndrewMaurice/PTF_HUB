using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PtfHub.DAL.IRepositories;
using PtfHub.Domain.Entities;

namespace PtfHub.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        #region Attributes

        private readonly DbSet<TEntity> _set;

        #endregion

        #region Constructor

        public GenericRepository(PTFContext pTFContext)
        {
            _set = pTFContext.Set<TEntity>();
        }

        #endregion

        #region Methods

        public async Task<TEntity> Add(TEntity entity)
        {
            var addedEntity =  await _set.AddAsync(entity);
            return addedEntity.Entity;
        }

        public async Task<TEntity> Filter(Expression<Func<TEntity, bool>> filterationExpression)
        {
             return await _set.FirstOrDefaultAsync(filterationExpression);
        }

        #endregion
    }
}
