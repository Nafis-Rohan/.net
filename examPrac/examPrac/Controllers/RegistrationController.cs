using AutoMapper;
using examPrac.EF;
using examPrac.DTOs;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace examPrac.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        regDBMSEntities db = new regDBMSEntities();


        public static Mapper  GetMapper() { 
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegistrationDTO , Registration>().ReverseMap();
            });
            var mapper = new Mapper(config);
            return mapper;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectCourse()
        {
            var courses = db.Courses.ToList();
            return View(courses);
        }

        [HttpPost]
        public ActionResult SelectCourses(RegistrationDTO r)
        {
            
            if (r.Courses.Length > 5)
            {
                return RedirectToAction("SelectCourse");
            }

            return View();
        }


    }
}