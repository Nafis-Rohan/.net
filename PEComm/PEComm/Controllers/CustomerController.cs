using AutoMapper;
using PEComm.Auth;
using PEComm.Enums;
using PEComm.DTOs;
using PEComm.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEComm.Controllers
{
    public class CustomerController : Controller
    {
        PECommDBEntities2 db = new PECommDBEntities2();
        // GET: Customer

        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<Order, OrderProductDTO>();
                cfg.CreateMap<OrderDetail, OrderDetailDTO>();
                cfg.CreateMap<Product, ProductDTO>();
            });
            return new Mapper(config);
        }
        [Logged]
        public ActionResult Index()
        {
            var user = (User)Session["user"];
            var orders = (from o in db.Orders
                          where
                         o.CustomerId == (int)user.CustomerId
                          select o).ToList();
            //OrderStatus status = (OrderStatus)1;
            //var test = status.ToString();
            return View(GetMapper().Map<List<OrderDTO>>(orders));
        }
    }
}