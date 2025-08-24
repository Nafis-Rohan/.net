using examPrac.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace examPrac.Controllers
{
    public class RegistrationController : Controller
    {
        regDBMSEntities db = new regDBMSEntities();
        // GET: Registration
        public ActionResult Index()
        {
            
            return View();
        }
    }
}