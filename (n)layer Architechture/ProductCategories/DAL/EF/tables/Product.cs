using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.tables
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }


        [ForeignKey("cat")]
        public int CId { get; set; }
        public Category cat { get; set; }
    }
}
