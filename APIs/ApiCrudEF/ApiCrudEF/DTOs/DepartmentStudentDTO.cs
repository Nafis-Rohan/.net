using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCrudEF.DTOs
{
    public class DepartmentStudentDTO : DepartmentDTO
    {
        public List<StudentDTO> Students { get; set; }
        public DepartmentStudentDTO() { 
            Students = new List<StudentDTO>();
        }
    }
}