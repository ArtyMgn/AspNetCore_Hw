using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SecondHomework.Models;
using SecondHomework.Services;

namespace SecondHomework.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsStorageService studentsStorage;

        public StudentsController(IStudentsStorageService service)
        {
            studentsStorage = service;
        }
        
        public IActionResult Index([FromServices]IStudentsStorageService service)
        {
            var studentsOrderedById = service.GetAllStudents().OrderBy(student => student.Id);
            return View(studentsOrderedById);
        }

        [HttpPost]
        public IActionResult Add(Student newStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            studentsStorage.AddStudent(newStudent);
            var serializedStudent = JsonConvert.SerializeObject(newStudent);
            
            return Content($"Added {serializedStudent}");
        }

        [HttpDelete]
        public IActionResult Delete(int studentId)
        {
            var storageService =
                ActivatorUtilities.CreateInstance<SqlStudentsStorageService>(HttpContext.RequestServices);
            storageService.DeleteStudent(studentId);
            return Content($"Deleted student with id {studentId}");
        }
        
        public IActionResult Edit(Student student)
        {
            return View(student);
        }
        
        [HttpPost]
        public IActionResult Update(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            studentsStorage.Update(student);
            return RedirectToAction("Read", new {studentId = student.Id});
        }

        [HttpGet]
        public IActionResult Read(int studentId)
        {
            var storageService = HttpContext.RequestServices.GetService<IStudentsStorageService>();
            var student = storageService.FindStudentById(studentId);
            if (student is null)
            {
                return BadRequest($"Can't read: student with id = {studentId} doesn't exist");
            }
            return View(student);
        }
    }
}
