using UdemyAPI.DTOs.BaseDtos;

namespace UdemyAPI.Entites
{
    public class Student : BaseAuditableEntityDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public ICollection <StudentCourses> Courses { get; set; }
    }
}
