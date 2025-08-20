using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            ViewBag.titleName = "List";
            
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.titleName = "Create";
            return View();
        }
    }
}