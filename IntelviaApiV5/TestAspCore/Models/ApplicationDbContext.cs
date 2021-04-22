using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Models;

namespace TestAspCore.Authentication
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<CategorieModel> Categories { get; set; }
        public DbSet<CommandeModel> Commendes { get; set; }
        public DbSet<ImageProduct> Image_Products{ get; set; }
        public DbSet<ProductModel> productsI { get; set; }
        public DbSet<TestAspCore.Models.CommendProduct> cmdProducts { get; set; }

    }
}
