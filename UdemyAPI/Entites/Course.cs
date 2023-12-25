using UdemyAPI.DTOs.BaseDtos;

namespace UdemyAPI.Entites
{
    public class Course : BaseAuditableEntityDto
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        public Teacher teacher { get; set; }
        public ICollection<StudentCourses> studentCourses { get; set;}
    }
}
