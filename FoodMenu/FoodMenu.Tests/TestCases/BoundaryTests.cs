using FoodMenu.Entities.Models;
using FoodMenu.BusinessLayer.Services;
using FoodMenu.BusinessLayer.Services.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FoodMenu.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IMenuService _menuServices;
        public readonly Mock<IMenuRepository> menuservice = new Mock<IMenuRepository>();
        private readonly Menu _menu;
        private static string type = "Boundary";
        public BoundaryTests(ITestOutputHelper output)
        {
            _menuServices = new MenuService(menuservice.Object);
            _output = output;
            _menu = new Menu
            {
                FoodId = 1,
                FoodName = "Rice",
                FoodType = "Indian",
                Rate = 300,
                Rating = 5
            };
        }
        /// <summary>
        /// Test to validate food type connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Food_Type_NotEmpty()
        {
            //Arrange
            bool res = false;
            int foodId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                menuservice.Setup(repo => repo.FindOneAsync(foodId)).ReturnsAsync(_menu);
                var result = await _menuServices.FindOneAsync(foodId);
                if (result.FoodType.ToString().Length != 0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
    }
}
