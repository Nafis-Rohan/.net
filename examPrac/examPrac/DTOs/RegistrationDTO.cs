using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace examPrac.DTOs
{
    public class RegistrationDTO
    {
        public int Id { get; set; }
        public int SId { get; set; }
        public string Status { get; set; }

        public int[] Courses { get; set; }
    }
}