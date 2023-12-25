using UdemyAPI.DTOs.BaseDtos;

namespace UdemyAPI.DTOs.CategoryDtos
{
    public class CategoryGetDto : BaseAuditableEntityDto
    {
        public string Title { get; set; }
        public int ParentCategoryId { get; set; }

    }
}
