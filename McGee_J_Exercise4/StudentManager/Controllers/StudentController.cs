using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManager.Models;
using StudentManager;

namespace StudentManager.Controllers
{
    public class StudentController : Controller
    {
        private McGeeJEx4DBContext context { get; set; }
        public StudentController(McGeeJEx4DBContext ctx)
        {
            context = ctx;
        }

        public IActionResult Details (int id)
        {
            var student = context.Student
                .FirstOrDefault(s => s.StudentId == id);
            return View(student);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Student());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var student = context.Student.FirstOrDefault(s => s.StudentId == id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            string action = (student.StudentId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    context.Student.Add(student);
                }
                else
                {
                    context.Student.Update(student);
                }
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                return View(student);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = context.Student.FirstOrDefault(s => s.StudentId == id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            context.Student.Remove(student);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
