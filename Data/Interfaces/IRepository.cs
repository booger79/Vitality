using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
   public interface IRepository<T> where T : BaseEntity
   {
        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        T GetById(Guid id);

        /// <summary>
        /// Get all entity
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        bool Insert(T entity);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        bool Insert(IEnumerable<T> entities);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        bool Update(T entity);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        bool Update(IEnumerable<T> entities);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        bool Delete(T entity);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        bool Delete(IEnumerable<T> entities);


        /// <summary>
        /// Context SaveChanges
        /// </summary>
        int Commit();

        IQueryable<T> GetListByFilter(Expression<System.Func<T, bool>> expression);
    }
}
