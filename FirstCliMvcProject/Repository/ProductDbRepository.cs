using FirstCliMvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FirstCliMvcProject.Data;

namespace FirstCliMvcProject.Repository
{
    public class ProductDbRepository : IRepository<Product>
    {
        private readonly MvcDatabaseContext _context;
        public ProductDbRepository(MvcDatabaseContext context)
        {
            this._context = context;
        }

        public void addAction(Product entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public List<Product> getAll()
        {
            return _context.Products.ToList();
        }

        public List<Product> search(string searchText)
        {
            
           
                return _context.Products.ToList().Where(s => s.productName.Contains(searchText)).ToList();
            
        }
    }
}
