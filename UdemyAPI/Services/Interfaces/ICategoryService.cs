using UdemyAPI.DTOs.CategoryDtos;
using UdemyAPI.Entites;

namespace UdemyAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> Create(CategoryCreateDto category);
        Task<Category> Update(int id, CategoryUpdateDto category);

        Task<Category> Delete(int id);
    }
}
