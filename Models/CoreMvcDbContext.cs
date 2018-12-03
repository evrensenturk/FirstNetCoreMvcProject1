using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace FirstNetCoreMvcProject.Models
{
    public class CoreMvcDbContext:DbContext
    {
        public CoreMvcDbContext():base(CreateOpions(null))
        {
        }

        public CoreMvcDbContext(string conname) : base(CreateOpions(conname))
        { }

        public static  DbContextOptions<CoreMvcDbContext> CreateOpions(string connName)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CoreMvcDbContext>();
           
           
            
                optionsBuilder.UseSqlServer(connName);
            
            return optionsBuilder.Options;
        }
        public DbSet<Product> Products { get; set; }

        
    }
}
