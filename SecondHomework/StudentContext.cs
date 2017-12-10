using Microsoft.EntityFrameworkCore;
using SecondHomework.Models;

namespace SecondHomework
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Student>().Property(x => x.Surname).HasMaxLength(200);
        }
    }
}