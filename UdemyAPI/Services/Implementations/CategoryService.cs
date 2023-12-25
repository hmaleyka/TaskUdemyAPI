using Microsoft.EntityFrameworkCore;
using UdemyAPI.DTOs.BaseDtos;
using UdemyAPI.DTOs.CategoryDtos;
using UdemyAPI.Entites;
using UdemyAPI.Repositories.Interfaces;
using UdemyAPI.Services.Interfaces;

namespace UdemyAPI.Services.Implementations
{
    public class CategoryService : BaseAuditableEntityDto, ICategoryService 
    {
        private readonly ICategoryRepository _repo;
        private readonly IWebHostEnvironment _env;

        public CategoryService(ICategoryRepository repo, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
        }
        public async Task<Category> Create(CategoryCreateDto createcategorydto)
        {
            if (createcategorydto == null) throw new Exception("Category should noy be null");
            Category category = new Category()
            {
                Name = createcategorydto.Name,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
            };
            await _repo.Create(category);
            await _repo.SaveChangesAsync();
            return category;
        }

        public async  Task<ICollection<Category>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();

            return await categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            if (id <= 0) throw new Exception("it should not be negative");
            var category = await _repo.GetByIdAsync(id);
            if (category == null) throw new Exception("Category should not be null");
            return category;
        }

        public async Task<Category> Update(int id, CategoryUpdateDto updatecategoryDto)
        {
          Category category = await _repo.GetByIdAsync(id);
            if (category == null) throw new Exception("Category should not be null");
            category.Name = updatecategoryDto.Name;
            _repo.Update(category);
            await _repo.SaveChangesAsync();
            return category;

        }
        public async Task<Category> Delete(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null) throw new Exception("Category should not be null");
            _repo.Delete(category);
            await _repo.SaveChangesAsync();
            return category;

        }
    }
}
