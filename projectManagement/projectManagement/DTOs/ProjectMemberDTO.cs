using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectManagement.DTOs
{
    public class ProjectMemberDTO
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int MemberId { get; set; }
        public bool isConfirmedBySupervisor { get; set; }
    }
}