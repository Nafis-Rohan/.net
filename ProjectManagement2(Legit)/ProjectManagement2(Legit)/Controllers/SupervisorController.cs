using AutoMapper;
using ProjectManagement2_Legit_.DTOs;
using ProjectManagement2_Legit_.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagement2_Legit_.Controllers
{
    public class SupervisorController : Controller
    {
        // GET: Supervisor
        ProjectDBMSpEntities db = new ProjectDBMSpEntities();

        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Supervisor, SupervisorDTO>().ReverseMap();
                cfg.CreateMap<Project, ProjectDTO>().ReverseMap();
                cfg.CreateMap<Member, MemberDTO>().ReverseMap();
                cfg.CreateMap<Member, MemberDTO>().ReverseMap();

            });
            return new Mapper(config);
        }
        public ActionResult Index(int id)
        {
            var data = GetMapper().Map<ProjectDTO>(db.Projects.Find(id));
            return View(data);
        }
        [HttpGet]
        public ActionResult Open() {

            var data = GetMapper().Map<List<ProjectDTO>>(db.Projects.ToList());
            
            return View(data);
        }
        [HttpGet]
        public ActionResult OpenDetails(int id)
        {


            var data = GetMapper().Map<ProjectDTO>(db.Projects.Find(id));
            return View(data);
        }

        [HttpGet]
        public ActionResult Create() {

            var data = GetMapper().Map<List<ProjectDTO>>(db.Projects.ToList());
            var supervisors = GetMapper().Map<List<SupervisorDTO>>(db.Supervisors.ToList());
            ViewBag.Supervisors = supervisors;
            return View(data);
        }
        [HttpPost]
        public ActionResult Create(ProjectDTO p,int SupervisorID)
        {
            var data = GetMapper().Map<Project>(p);

            if (data != null)
            {
                data.StatusId = 1;
                data.SId = SupervisorID;
                db.Projects.Add(data);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }
    }
}