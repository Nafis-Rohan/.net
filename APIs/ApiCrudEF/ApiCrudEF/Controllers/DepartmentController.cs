using ApiCrudEF.DTOs;
using ApiCrudEF.EF;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCrudEF.Controllers
{
    [RoutePrefix("api/department")]
    public class DepartmentController : ApiController
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
                cfg.CreateMap<Student, StudentDepartDTO>().ReverseMap();
                cfg.CreateMap<Department, DepartmentDTO>().ReverseMap();
                cfg.CreateMap<Department, DepartmentStudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        StudentDBMSEntities db = new StudentDBMSEntities();

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = GetMapper().Map<List<DepartmentDTO>>(db.Departments.ToList());
                return Request.CreateResponse(HttpStatusCode.OK, data);
            } catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetAll(int id)
        {
            try
            {
                var data = GetMapper().Map<DepartmentDTO>(db.Departments.Find(id));
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/student")]
        public HttpResponseMessage GetStudent(int id)
        {
            try {
                var data = GetMapper().Map<DepartmentStudentDTO>(db.Departments.Find(id));
                return Request.CreateResponse(HttpStatusCode.OK,data);
            }catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message);
            }

        }

        



    }

}
