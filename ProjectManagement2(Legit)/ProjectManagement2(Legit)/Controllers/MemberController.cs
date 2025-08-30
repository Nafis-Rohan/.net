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
    public class MemberController : Controller
    {
        // GET: Member
        ProjectDBMSpEntities db = new ProjectDBMSpEntities();

        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Supervisor, SupervisorDTO>().ReverseMap();
                cfg.CreateMap<Project, ProjectDTO>().ReverseMap();
                cfg.CreateMap<Member, MemberDTO>().ReverseMap();
                cfg.CreateMap<Member, MemberDTO>().ReverseMap();

            });
            return new Mapper(config);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowProjects() {

            var data = GetMapper().Map<List<ProjectDTO>>(db.Projects.ToList());

            

            return View(data);
        }

        [HttpGet]
        public ActionResult Enroll(int id) {

            //var enrolled = (from pm in db.ProjectMembers
            //                where pm.PId == id
            //                select pm).ToList();

            //var data = GetMapper().Map<ProjectMemberDTO>(enrolled);

            var data = GetMapper().Map<ProjectDTO>(db.Projects.Find(id));
            var Members = GetMapper().Map<List<MemberDTO>>(db.Members.ToList());
            ViewBag.Members = Members;

            return View(data);

        }
        [HttpPost]
        public ActionResult Enroll(int ProjectId, int[] MemberIds) {

            if (MemberIds == null || MemberIds.Length == 0)
            {
                TempData["Error"] = "Pick at least one member.";
                return RedirectToAction("Enroll", new { id = ProjectId });
            }

            // How many already in this project
            int current =
                (from pm in db.ProjectMembers
                 where pm.PId == ProjectId
                 select pm).Count();

            // If already full
            if (current >= 4)
            {
                TempData["Error"] = "This project already has 4 members.";
                return RedirectToAction("Enroll", new { id = ProjectId });
            }

            // Distinct selection
            var selected = MemberIds.Distinct().ToList();

            // Remove members who are already enrolled
            var already =
                (from pm in db.ProjectMembers
                 where pm.PId == ProjectId
                 select pm.MId).ToList();

            var toAdd =
                (from mid in selected
                 where !already.Contains(mid)
                 select mid).ToList();

            if (toAdd.Count == 0)
            {
                TempData["Error"] = "All selected members are already enrolled.";
                return RedirectToAction("Enroll", new { id = ProjectId });
            }

            // Capacity check: current + toAdd must be <= 4
            int slotsLeft = 4 - current;
            if (toAdd.Count > slotsLeft)
            {
                TempData["Error"] = $"Only {slotsLeft} slot(s) left in this project.";
                return RedirectToAction("Enroll", new { id = ProjectId });
            }

            // Save
            foreach (var mid in toAdd)
                db.ProjectMembers.Add(new ProjectMember { PId = ProjectId, MId = mid });

            db.SaveChanges();
            TempData["Success"] = $"Enrolled {toAdd.Count} member(s).";

            return RedirectToAction("Enroll", new { id = ProjectId });


        }
    }
}