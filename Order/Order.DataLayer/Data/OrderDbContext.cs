using Microsoft.EntityFrameworkCore;
using Order.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.DataLayer.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Orders> Orders { get; set; }
    }
}
