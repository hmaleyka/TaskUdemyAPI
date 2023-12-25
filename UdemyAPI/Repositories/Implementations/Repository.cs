using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UdemyAPI.DAL;
using UdemyAPI.DTOs.BaseDtos;
using UdemyAPI.Repositories.Interfaces;

namespace UdemyAPI.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseAuditableEntityDto, new()
    {
        private readonly AppDbContext _dbcontext;
        private DbSet<TEntity> _table;
        public Repository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _table = _dbcontext.Set<TEntity>();
        }
        public DbSet<TEntity> Table => _dbcontext.Set<TEntity>();


        public async Task Create(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null,
            Expression<Func<TEntity, object>>? OrderByExpression = null,
            bool isDescending = false
            , params string[] includes)
        {
            IQueryable<TEntity> query = Table.Where(b => b.IsDeleted == false);
            if (expression is not null)
            {
                query = query.Where(expression);
            }
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }

            if (OrderByExpression != null)
            {
                query = isDescending ? query.OrderByDescending(OrderByExpression) : query.OrderBy(OrderByExpression);
            }


            return query;
        }


        public async  Task<TEntity> GetByIdAsync(int id)
        {
            return await _table.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }
        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }
    }
}
