using System.Linq;
using SecondHomework.Models;

namespace SecondHomework.Services
{
    public class SqlStudentsStorageService : IStudentsStorageService
    {
        private readonly StudentContext context;
        
        public SqlStudentsStorageService(StudentContext context)
        {
            this.context = context;
        }
        
        public Student FindStudentById(int id)
        {
            return context.Students.Find(id);
        }

        public void AddStudent(Student newStudent)
        {
            context.Students.Add(newStudent);
            context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = context.Students.Find(id);
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public void Update(Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();
        }

        public Student[] GetAllStudents()
        {
            return context.Students.ToArray();
        }
    }
}