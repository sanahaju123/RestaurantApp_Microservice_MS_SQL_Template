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
            try
            {
                return await _dbContext.Menus.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Menu> FindOneAsync(int id)
        {
            try
            {
                return await _dbContext.Menus.FirstOrDefaultAsync(x => x.FoodId == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Menu> InsertAsync(Menu menu)
        {
            try
            {
                _dbContext.Add(menu);
                await _dbContext.SaveChangesAsync();
                return menu;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Menu> UpdateAsync(Menu menu)
        {
            try
            {
                _dbContext.Update(menu);
                await _dbContext.SaveChangesAsync();
                return menu;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
