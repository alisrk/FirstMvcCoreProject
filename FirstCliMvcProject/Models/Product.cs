using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCliMvcProject.Models
{
    public class Product
    {
        public int id { get; set; }
        public string productName { get; set; }
        public int price { get; set; }
        public int Stok { get; set; }
      
        public string marka { get; set; }
        public string imagePath { get; set; }
    }
    
   
}
