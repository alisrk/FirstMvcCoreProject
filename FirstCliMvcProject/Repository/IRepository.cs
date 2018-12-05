using FirstCliMvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCliMvcProject.Repository
{
   public  interface IRepository <T> where T :class
    {

        List<T> getAll();
        void addAction(T entity);
        List<T> search(String searchText);
        
    }
}
