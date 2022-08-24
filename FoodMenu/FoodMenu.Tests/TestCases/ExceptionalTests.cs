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
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IMenuService _menuServices;
        public readonly Mock<IMenuRepository> menuservice = new Mock<IMenuRepository>();
        private readonly Menu _menu;
        private static string type = "Exception";
        public ExceptionalTests(ITestOutputHelper output)
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
        /// Test to validate if invalid food id is passed it will return false
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidFoodIdIsPassed()
        {
            //Arrange
            bool res = false;
            _menu.FoodId = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                menuservice.Setup(repo => repo.FindOneAsync(_menu.FoodId)).ReturnsAsync(_menu);
                var result = await _menuServices.FindOneAsync(_menu.FoodId);
                if (result == null || result.FoodId < 1)
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
