using UdemyAPI.DAL;
using UdemyAPI.Entites;
using UdemyAPI.Repositories.Interfaces;

namespace UdemyAPI.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbcontext) : base(dbcontext)
        {
        }

    }
}
