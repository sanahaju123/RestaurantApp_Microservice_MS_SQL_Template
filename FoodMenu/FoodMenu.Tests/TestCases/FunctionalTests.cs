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
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IMenuService _menuServices;
        public readonly Mock<IMenuRepository> menuservice = new Mock<IMenuRepository>();
        private readonly Menu _menu;
        private static string type = "Functional";
        public FunctionalTests(ITestOutputHelper output)
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
        /// Test to Add a new Menu.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Add_Menu()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                menuservice.Setup(repos => repos.InsertAsync(_menu)).ReturnsAsync(_menu);
                var result = await _menuServices.InsertAsync(_menu);

                //Assertion
                if (result != null)
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


        /// <summary>
        /// Test to Update a Menu by Menu Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Update_Menu()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateMenu = new Menu()
            {
                FoodId = 1,
                FoodName = "Biryani",
                FoodType = "Indian",
                Rate = 300,
                Rating=5
            };
            //Act
            try
            {
                menuservice.Setup(repos => repos.UpdateAsync(_updateMenu)).ReturnsAsync(_menu);
                var result = await _menuServices.UpdateAsync(_updateMenu);
                if (result != null)
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


        /// <summary>
        /// Test to Get all Menus
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAll_Menus()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                menuservice.Setup(repos => repos.FindAllAsync());
                var result = await _menuServices.FindAllAsync();
                //Assertion
                if (result != null)
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

        /// <summary>
        /// Test to get Menu By Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetMenuById()
        {
            //Arrange
            var res = false;
            int menuId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                menuservice.Setup(repos => repos.FindOneAsync(menuId)).ReturnsAsync(_menu);
                var result = await _menuServices.FindOneAsync(menuId);
                //Assertion
                if (result != null)
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
