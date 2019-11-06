using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Data.Repositories;
using FirstApp.Models;
using FirstApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;

        public HomeController(ITeacherRepository teacherRepository, IStudentRepository studentRepository)
        {
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var teachers = _teacherRepository.GetAllTeachers();

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Teachers = teachers
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        // GET: /<controller>/
        // Display Studnet.cshtml
        public IActionResult Student()
        {
            var students = _studentRepository.GetAllStudents();

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Students = students
            };

            return View(viewModel);
        }

        // Receive values from html view by HttpPost
        // ValidateAntiForgery - compare token between server and client
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Student(StudentTeacherViewModel model)
        {
            // Check valid of model values
            if (ModelState.IsValid)
            {
                // Store model data into Student table
                _studentRepository.AddStudent(model.Student);
                _studentRepository.Save();

                ModelState.Clear();
            }
            else
            {
                // If model values are not valid, display Error
            }

            var students = _studentRepository.GetAllStudents();

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Students = students
            };

            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            var result = _studentRepository.GetStudent(id);

            return View(result);
        }

        public IActionResult Edit(int id)
        {
            var result = _studentRepository.GetStudent(id);

            return View(result);
        }

        // Receive values from html view by HttpPost
        // ValidateAntiForgery - compare token between server and client
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            // Check valid of model values
            if (ModelState.IsValid)
            {
                // Edit model data in Student table
                _studentRepository.Edit(student);
                _studentRepository.Save();

                return RedirectToAction("Student");
            }
            
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var result = _studentRepository.GetStudent(id);

            if(result != null)
            {
                _studentRepository.Delete(result);
                _studentRepository.Save();
            }

            return RedirectToAction("Student");
        }
    }
}
