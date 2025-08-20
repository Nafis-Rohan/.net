using AutoMapper;
using projectManagement.DTOs;
using projectManagement.EF;
using projectManagement.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace projectManagement.Controllers
{
    public class SupervisorController : Controller
    {
        ProjectDBEntities1 db = new ProjectDBEntities1();

        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Project, ProjectDTO>().ReverseMap();
                cfg.CreateMap<Member, MemberDTO>().ReverseMap();
                cfg.CreateMap<ProjectMember, ProjectMemberDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        // Show all projects (later you can filter only supervisor's)
        public ActionResult Index()
        {
            var data = db.Projects.ToList();
            var projects = GetMapper().Map<List<ProjectDTO>>(data);
            return View(projects);
        }

        // GET: OpenProject (form)
        public ActionResult OpenProject()
        {
            return View();
        }

        // POST: OpenProject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OpenProject(ProjectDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto.StatusId = (int)ProjectStatus.OnTheWay; // enum
                var project = GetMapper().Map<Project>(dto);

                db.Projects.Add(project);
                db.SaveChanges();

                return RedirectToAction("Projects");
            }
            return View(dto);
        }

        // Supervisor confirms team if >= 3 members confirmed
        public ActionResult ConfirmTeam(int projectId)
        {
            var project = db.Projects.Find(projectId);
            if (project == null) return HttpNotFound();

            var approvedMembers = db.ProjectMembers
                .Where(pm => pm.ProjectId == projectId && pm.isConfirmedBySupervisor)
                .Count();

            if (approvedMembers >= 3)
            {
                project.StatusId = (int)ProjectStatus.Completed; // or Active if you add it
                db.SaveChanges();
                TempData["Msg"] = "Team confirmed successfully!";
            }
            else
            {
                TempData["Msg"] = "Cannot confirm. Less than 3 members approved.";
            }

            return RedirectToAction("Projects");
        }
    }
}
