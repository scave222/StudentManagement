using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.ServiceRepository;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    
    public class StudentController : Controller
    {
        private readonly IStudent _student;
        private readonly IWebHostEnvironment hostingEnvironment;
        public StudentController(IStudent stud,
            IWebHostEnvironment hostingEnvironment)
        {
            _student = stud;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult List()
        {
            return View(_student.Students);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        //Method for creating adding student to data base
        [HttpPost]
        public IActionResult Create(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Student newEmployee = new Student
                {
                    Surname = model.Surname,
                    OtherName = model.OtherName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    HomeAddress = model.HomeAddress,
                    City = model.City,
                    State = model.State,
                    Passport = uniqueFileName
                };
                _student.AddStudent(newEmployee);
                // _employee.AddEmployee(employee);
                return RedirectToAction(nameof(Create));
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public IActionResult Details(long Id)
        {
            Student stu = _student.GetStudent(Id);
            if (stu == null)
            {
                return RedirectToAction("List");
            }
            return View(stu);
        }

        //Method for deleting student in data base
        [Authorize]
        [HttpGet]
        public IActionResult DeleteConfirm(long Id)
        {
            Student emp = _student.GetStudent(Id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(Student stud, long Id)
        {
            _student.Delete(Id);
            return View("Success");
        }

        //Methid for editing student in dats base
        [Authorize]
        [HttpGet]
        public IActionResult Edit(long Id)
        {
            Student Edemp = _student.GetStudent(Id);
            return View(Edemp);
        }
        [HttpPost]
        public IActionResult Edit(Student stud)
        {
            _student.EditStudent(stud);
            return View("Success");
        }

        public IActionResult Success()
        {
            return View();
        }


        //Method for searching students
        [HttpGet]
        public IActionResult Search()
        {
            //Employee person = _employee.GetEmployee(Id);
            return View();
        }

        [HttpPost]
        public IActionResult Search(string SName)
        {

            var result = _student.Search(SName);
            return View("SearchResult", result);

        }

    }
}
