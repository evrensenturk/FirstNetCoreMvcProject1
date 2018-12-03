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
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = configuration["database:connection"];

            connName = connectionString;

            optionsBuilder.UseSqlServer(connName);
            
            return optionsBuilder.Options;
        }
        public DbSet<Product> Products { get; set; }

        
    }
}
