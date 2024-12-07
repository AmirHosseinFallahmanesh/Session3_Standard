using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.EF;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class StudentController : Controller
    {
        private readonly DemoContext context;

        public StudentController(DemoContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var student = context.Students.Where(a=>a.Active).ToList();
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
            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("index");
        }


        public IActionResult Edit(Guid id)
        {
           Student student= context.Students.Find(id);

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}