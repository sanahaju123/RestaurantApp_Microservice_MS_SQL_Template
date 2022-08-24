using FoodMenu.DataLayer.Data;
using FoodMenu.Entities.Models;
using FoodMenu.BusinessLayer.Services.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMenu.BusinessLayer.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
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


