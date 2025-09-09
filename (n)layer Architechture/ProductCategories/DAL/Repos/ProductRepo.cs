using DAL.EF;
using DAL.EF.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ProductRepo
    {
        UMSContext db;

        public ProductRepo()
        {
            db = new UMSContext();  
        }

        public bool Create(Product p)
        {
            db.Products.Add(p);

            return db.SaveChanges() > 0;
        }

        public List<Product> GetProduct()
        {

            return db.Products.ToList();

        }

        public Product GetProduct(int id) { 
            
            return db.Products.Find(id);
        }

        public bool Update(Product p)
        {
            var exobj = GetProduct(p.Id);

            db.Entry(exobj).CurrentValues.SetValues(p);
            return db.SaveChanges()>0;
        }

        public bool Delete(int id) { 
            
            var exobj = GetProduct(id);

            db.Products.Remove(exobj);

            return db.SaveChanges()>0;
        }
    }
}
