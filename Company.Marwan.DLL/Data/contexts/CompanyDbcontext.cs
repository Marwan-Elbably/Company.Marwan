using Company.Marwan.BLL.Models;
using Company.Marwan.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Company.Marwan.DAL.Data.contexts
{
    public class CompanyDbcontext : IdentityDbContext<AppUser>
    {
        public CompanyDbcontext(DbContextOptions<CompanyDbcontext> options) : base(options) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");
        //}

        public DbSet<Department> departments { get; set; }

        public DbSet<Employee> employees { get; set; }

        

    }
}
