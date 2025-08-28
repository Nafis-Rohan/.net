using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ApiCrudCF.EF.Tables;
using System.ComponentModel.DataAnnotations;

namespace ApiCrudCF.EF
{
    public class UMContext : DbContext
    {
        
        public DbSet<Department> Departments { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}