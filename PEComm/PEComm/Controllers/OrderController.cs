using AutoMapper;
using PEComm.DTOs;
using PEComm.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEComm.Controllers
{
    public class OrderController : Controller
    {
        PECommDBEntities2 db = new PECommDBEntities2();
        // GET: Order

        Mapper GetMapper() {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public ActionResult Index()
        {
            var data = db.Products.ToList();
            var products = GetMapper().Map<List<ProductDTO>>(data);
            return View(products);
        }

        public ActionResult AddToCart(int id) { 
            
            var p = db.Products.Find(id);
            var pr = GetMapper().Map<ProductDTO>(p);
            pr.Qty = 1; // Default quantity to 1
            
            List<ProductDTO> cart = null;
            if (Session["cart"] == null)
            {
                cart = new List<ProductDTO>();
            }
            else
            {
                cart = (List<ProductDTO>)Session["cart"];
            }

            cart.Add(pr);
            Session["cart"] = cart;

            return RedirectToAction("Index"); 
        }

        public ActionResult ShowCart()
        {
            if (Session["Cart"]== null)
            {
                TempData["Msg"] = "Your cart is empty";
                return RedirectToAction("Index");
            }

            var cart = (List<ProductDTO>)Session["cart"];
            return View(cart);

        }


        public ActionResult Details(int id)
        {
            var od = db.Orders.Find(id);
            var mapper = CustomerController.GetMapper();
            var order = mapper.Map<OrderProductDTO>(od);
            return View(order);
        }
    }
}