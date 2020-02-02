using Microsoft.EntityFrameworkCore;
using Northwind.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Dal
{
    public class AppDbContext :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=NorthWindDB;Integrated Security=True");
        }

        public DbSet<Product> Products { get; set; }
    }
}
