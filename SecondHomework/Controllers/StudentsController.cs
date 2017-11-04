﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SecondHomework.Models;

namespace SecondHomework.Controllers
{
    public class StudentsController : Controller
    { 
        public IActionResult Index()
        {
            var students = LoadStudentsFromFile("students.txt");
            var studentsOrderedById = students.Values.OrderBy(student => student.Id);
            return View(studentsOrderedById);
        }

        public IActionResult Add(Student newStudent)
        {
            var students = LoadStudentsFromFile("students.txt");

            if (students.ContainsKey(newStudent.Id))
            {
                return BadRequest($"student with id = {newStudent.Id} already exist");
            }

            students.Add(newStudent.Id, newStudent);
            var serializedStudent = JsonConvert.SerializeObject(newStudent);
            SaveStudentsToFile(students);
            return Content($"Added {serializedStudent}, Students count: {students.Values.Count}");
        }

        public IActionResult Delete(int studentId)
        {
            var students = LoadStudentsFromFile("students.txt");
            students.Remove(studentId);
            SaveStudentsToFile(students);
            return Content($"Deleted student with id {studentId}");
        }

        public IActionResult Update(Student student)
        {
            var students = LoadStudentsFromFile("students.txt");
            if (!students.ContainsKey(student.Id))
            {
                return BadRequest($"Can't update: student with id = {student.Id} doesn't exist");
            }

            var oldValue = JsonConvert.SerializeObject(students[student.Id]);
            students[student.Id] = student;
            SaveStudentsToFile(students);
            return Content($"updated student: {oldValue} -> {JsonConvert.SerializeObject(student)}");
        }

        public IActionResult Read(int studentId)
        {
            var students = LoadStudentsFromFile("students.txt");

            if (!students.ContainsKey(studentId))
            {
                return BadRequest($"Can't read: student with id = {studentId} doesn't exist");
            }

            return Ok(students[studentId]);
        }

        [NonAction]
        public Dictionary<int, Student> LoadStudentsFromFile(string filePath)
        {
            if(!System.IO.File.Exists("students.txt"))
                return new Dictionary<int, Student>();
            var fileContent = System.IO.File.ReadAllText("students.txt");
            return JsonConvert.DeserializeObject<Dictionary<int, Student>>(fileContent);
        }

        [NonAction]
        public void SaveStudentsToFile(Dictionary<int, Student> students)
        {
            var serializedStudents = JsonConvert.SerializeObject(students);
            System.IO.File.WriteAllText("students.txt", serializedStudents);
        }
    }
}
