using System.Collections.Generic;
using SecondHomework.Models;

namespace SecondHomework.Services
{
    public interface IStudentsStorageService
    {
        Student FindStudentById(int id);
        void AddStudent(Student newStudent);
        void DeleteStudent(int id);
        void Update(Student student);
        Student[] GetAllStudents();
    }
}