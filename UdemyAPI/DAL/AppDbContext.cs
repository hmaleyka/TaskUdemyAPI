using Microsoft.EntityFrameworkCore;
using UdemyAPI.Entites;

namespace UdemyAPI.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)         
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasOne(s => s.Parent)
                .WithMany(m => m.Children)
                .HasForeignKey(e => e.ParentCategoryId);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Category> categories { get; set; }

        public DbSet<Student > students { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<StudentCourses> studentCourses { get; set;}
        public DbSet<Teacher> teachers { get; set; }
    }
}
