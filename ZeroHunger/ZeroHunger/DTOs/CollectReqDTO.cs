using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.DTOs
{
    public class CollectReqDTO
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public int RId { get; set; }
        public System.TimeSpan MaxPresTime { get; set; }
        public int StatusId { get; set; }
        public int EmpId { get; set; }
    }
}