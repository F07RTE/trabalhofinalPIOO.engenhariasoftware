using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Context
{
    public class AdministratorContext : DbContext
    {
        public AdministratorContext(DbContextOptions<AdministratorContext> options) : base(options)
        {

        }

        //Entities
        public DbSet<Model.Administrator> Administrator { get; set; }
    }
}
