using FirstCliMvcProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCliMvcProject.Data
{
    public class MvcDatabaseContext :DbContext
    {
        public MvcDatabaseContext(DbContextOptions<MvcDatabaseContext> options)
            : base(options)
        { }
        public DbSet<Product> Products { get; set; }
    }
}
