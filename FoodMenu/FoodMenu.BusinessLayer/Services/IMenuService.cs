using FoodMenu.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMenu.BusinessLayer.Services
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> FindAllAsync();
        Task<Menu> FindOneAsync(int id);
        Task<Menu> InsertAsync(Menu menu);
        Task<Menu> UpdateAsync(Menu menu);
    }
}
