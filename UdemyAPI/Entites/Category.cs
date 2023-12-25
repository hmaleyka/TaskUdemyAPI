using UdemyAPI.DTOs.BaseDtos;

namespace UdemyAPI.Entites
{
    public class Category : BaseAuditableEntityDto
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }

    }
}
    