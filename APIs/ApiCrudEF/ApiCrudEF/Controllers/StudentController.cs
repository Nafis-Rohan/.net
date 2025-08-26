using ApiCrudEF.DTOs;
using ApiCrudEF.EF;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace ApiCrudEF.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
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
            try {

                var data = GetMapper().Map<List<StudentDTO>>(db.Students.ToList());
                return Request.CreateResponse(HttpStatusCode.OK,data);

            }catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("all/dept")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = GetMapper().Map<List<StudentDepartDTO>>(db.Students.ToList());
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }


        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(StudentDTO s)
        {
            try
            {
                var data = GetMapper().Map<Student>(s);
                db.Students.Add(data);
                if (db.SaveChanges() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error Occured in Creation of Student");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        [Route("edit")]
        public HttpResponseMessage Edit(StudentDTO s)
        {
            try
            {
                var data = (db.Students.Find(s.Id));
                if (data != null)
                {
                    data.Name = s.Name;
                    data.DeptId = s.DeptId;
                    data.Cgpa = s.Cgpa;

                    if (db.SaveChanges() > 0)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.OK, "Update");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Update failed");
                    }


                }
                else {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found");
                }

                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id) {

            try
            {
                var data = db.Students.Find(id);
                if (data != null)
                {
                    db.Students.Remove(data);
                    db.SaveChanges();

                    return Request.CreateErrorResponse(HttpStatusCode.OK, data.Name);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Delete failed");
                }
            }catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
