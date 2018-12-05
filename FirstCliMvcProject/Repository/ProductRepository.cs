using FirstCliMvcProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCliMvcProject.Models
{
    public class ProductRepository : IRepository<Product>
    {
        private static List<Product> listProduct { get; set; }

        public ProductRepository()
        {
            if(listProduct == null)
            {
                listProduct = new List<Product>();
            }
        }

        public void addAction(Product entity)
        {
            listProduct.Add(entity);
        }

        public List<Product> getAll()
        {
            return listProduct;
        }

        public List<Product> search(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
