using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PropertyLettingsPortal.Data.Models;

namespace PropertyLettingsPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        //Dbsets representing tables
        public DbSet<Property> Property { get; set; }
        public DbSet<PropertyManager> PropertyManager { get; set; }
    }
}
