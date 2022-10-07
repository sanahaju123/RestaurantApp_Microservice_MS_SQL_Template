using FoodMenu.DataLayer.Data;
using FoodMenu.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMenu.BusinessLayer.Services.Repository
{
    public class MenuRepository:IMenuRepository
    {
        private readonly MenuDbContext _dbContext;
        public MenuRepository(MenuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public async Task<IEnumerable<Menu>> FindAllAsync()
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Menu> FindOneAsync(int id)
        {
             //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Menu> InsertAsync(Menu menu)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Menu> UpdateAsync(Menu menu)
        {
             //Write Your Code Here
            throw new NotImplementedException();
        }
    }
}
