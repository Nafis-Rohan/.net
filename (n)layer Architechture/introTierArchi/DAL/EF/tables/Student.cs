using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.tables
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="VARCHAR")]
        public string Name { get; set; }

        [ForeignKey("dept")]
        public int DId { get; set; }
        public virtual Department dept { get; set; }

    }
}
