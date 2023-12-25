using UdemyAPI.DTOs.BaseDtos;

namespace UdemyAPI.Entites
{
    public class StudentCourses : BaseAuditableEntityDto
    {
        public int StudentId { get; set; }
        public Student student { get; set; }
        public int CourseId { get; set; }
        public Course course { get; set; }
    }
}
