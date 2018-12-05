using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCliMvcProject.Models
{
    public class productViewModel
    {
        private static List<Product> listproduct { get; set; }
        public Product product { get; set; }
        public List<SelectListItem> brands { get; set; }
        public IFormFile File { set; get; }

        public productViewModel()
        {
            if (listproduct == null)
            {
                listproduct = new List<Product>();
            }
        }

        public void addproductFunc(Product productModel)
        {
            listproduct.Add(productModel);
        }
        public List<Product> getAll()
        {
            return listproduct;
        }
    }
}
