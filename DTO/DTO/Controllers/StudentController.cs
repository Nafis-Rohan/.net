using DTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DTO.Controllers
{

    public class StudentController : Controller
    {
        // GET:
        StudentDBMSEntities db = new StudentDBMSEntities();
        public ActionResult Index()
        {
            var students = db.Students.ToList();
            return View(students);
        }

        [HttpGet]
       
        public ActionResult Edit()
        {
            // This action is used to edit student details

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            // This action is used to display the form for creating a new student
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            // This action is used to create a new student
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}