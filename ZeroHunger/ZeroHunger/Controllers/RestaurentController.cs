using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.DTOs;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    public class RestaurentController : Controller
    {
        // GET: Restaurent
        ZeroHungerDBMSEntities db = new ZeroHungerDBMSEntities();

        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CollectReq,CollectReqDTO>().ReverseMap();
                cfg.CreateMap<Restaurent,RestaurentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create() { 
            return View();
        }


        [HttpPost]
        public ActionResult Create (CollectReqDTO c)
        {
            var data = GetMapper().Map<CollectReq>(c);

            if(data != null)
            {
                data.StatusId = 1;
                data.EmpId = 1;
                data.RId = 1;
                db.CollectReqs.Add(data);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}