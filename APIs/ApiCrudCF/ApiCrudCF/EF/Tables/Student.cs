using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiCrudCF.EF.Tables
{
    public class Student
    {
        [Key]
        public int SId { get; set; }

        [Required]
        [StringLength(200)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }
        [Column(TypeName = "FLOAT")]
        public float? Cgpa { get; set; }

        [ForeignKey("dept")]
        public int DeptId { get; set; }
        public virtual Department dept { get; set; }    
    }
}