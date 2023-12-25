namespace UdemyAPI.DTOs.BaseDtos
{
    public class BaseAuditableEntityDto : BaseEntityDto
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
