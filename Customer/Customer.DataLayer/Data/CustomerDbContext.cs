using Customer.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.DataLayer.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customers> Customers { get; set; }
    }
}
