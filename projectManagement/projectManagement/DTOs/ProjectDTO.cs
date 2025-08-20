using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectManagement.DTOs
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int StatusId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime ComputionDate { get; set; }
        public int SupervisorId { get; set; }
    }
}