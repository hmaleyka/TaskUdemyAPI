using UdemyAPI.DTOs.BaseDtos;
using UdemyAPI.Entites;

namespace UdemyAPI.DTOs.CategoryDtos
{
    public class CategoryUpdateDto : BaseEntityDto
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }
    }
}
