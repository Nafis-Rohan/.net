using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCrudEF.DTOs
{
    public class StudentDepartDTO : StudentDTO
    {
        public DepartmentDTO department { get; set; }
    }
}