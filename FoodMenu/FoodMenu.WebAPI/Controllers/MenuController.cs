using FoodMenu.BusinessLayer.Services;
using FoodMenu.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMenu.WebAPI.Controllers
{
    [Route("Menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        // GET: api/menus
        [HttpGet]
        public async Task<IActionResult> GetMenu()
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        // POST: api/menus
        [HttpPost]
        public async Task<IActionResult> PostMenu([FromBody] Menu menu)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        // PUT: api/menus 
        [HttpPut]
        public async Task<IActionResult> PutMenu([FromBody] Menu menu)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        // PUT: api/menus 
        [HttpGet]
        [Route("{menuId}")]
        public async Task<IActionResult> GetMenuById(int menuId)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

    }
}

