using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UdemyAPI.DTOs.BaseDtos;

namespace UdemyAPI.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntityDto, new()
    {
        public DbSet<TEntity> Table { get; }
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null,
            Expression<Func<TEntity, object>>? OrderByExpression = null,
            bool isDescending = false
            , params string[] includes);
        Task<TEntity> GetByIdAsync(int id);
        Task Create(TEntity entity);
        void Update(TEntity entity);

        void Delete(TEntity entity);
        Task SaveChangesAsync();
    }
}
