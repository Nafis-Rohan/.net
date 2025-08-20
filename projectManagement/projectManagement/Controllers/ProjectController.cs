using AutoMapper;
using projectManagement.DTOs;
using projectManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectManagement.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        ProjectDBEntities1 db = new ProjectDBEntities1();

        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Project, ProjectDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public ActionResult Index()
        {
            var data = db.Projects.ToList();
            var projects = GetMapper().Map<List<ProjectDTO>>(data);
            return View(projects);
        }
    }
}