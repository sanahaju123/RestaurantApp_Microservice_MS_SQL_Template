using FoodMenu.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMenu.DataLayer.Data
{
    public class MenuDbContext : DbContext
    {
        public MenuDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }
    }
}
