using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SaleWebMvc.Models
{
    public class SaleWebMvcContext : DbContext
    {
        public SaleWebMvcContext (DbContextOptions<SaleWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<SaleWebMvc.Models.Department> Department { get; set; }
    }
}
