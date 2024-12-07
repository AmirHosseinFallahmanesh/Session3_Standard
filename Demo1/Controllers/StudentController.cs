using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Data;
using Demo.EF;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository studentRepository;

        public StudentController(StudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            var student = studentRepository.GetAll();
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            studentRepository.Create(student);
            return RedirectToAction("index");
        }


        public IActionResult Edit(Guid id)
        {
          var student=  studentRepository.GetStudent(id);

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            studentRepository.Update(student);

            return RedirectToAction("index");
        }

        public IActionResult Delete(Guid id)
        {

          

            studentRepository.Remove(id);
            return RedirectToAction("index");
        }
    }
}