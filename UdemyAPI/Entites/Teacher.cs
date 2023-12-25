using UdemyAPI.DTOs.BaseDtos;

namespace UdemyAPI.Entites
{
    public class Teacher : BaseAuditableEntityDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
