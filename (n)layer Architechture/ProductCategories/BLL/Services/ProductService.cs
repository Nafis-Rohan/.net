using AutoMapper;
using BLL.DTOs;
using DAL.Repos;
using DAL.EF.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<ProductDTO> Get()
        {
            var data = new ProductRepo().GetProduct();
            return GetMapper().Map<List<ProductDTO>>(data);
        }
    }
}
