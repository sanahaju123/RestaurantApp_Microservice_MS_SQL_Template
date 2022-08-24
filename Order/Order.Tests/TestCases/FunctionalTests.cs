using Moq;
using Order.DataLayer.Data;
using Order.Entities.Models;
using Order.BusinessLayer.Services;
using Order.BusinessLayer.Services.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Order.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IOrderService _orderServices;
        public readonly Mock<IOrderRepository> orderservice = new Mock<IOrderRepository>();
        private readonly Orders _order;
        private static string type = "Functional";
        public FunctionalTests(ITestOutputHelper output)
        {
            _orderServices = new OrderService(orderservice.Object);
            _output = output;
            _order = new Orders
            {
                OrderId = 1,
                OrderDate = DateTime.Now,
                OrderStatus = "Pending",
                TotalAmount = 200,
            };
        }

        /// <summary>
        /// Test to Add a new Order.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Add_Order()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                orderservice.Setup(repos => repos.InsertAsync(_order)).ReturnsAsync(_order);
                var result = await _orderServices.InsertAsync(_order);

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
        /// Test to Update a Order by Order Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Update_Order()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateOrder = new Orders()
            {
                OrderId = 1,
                OrderDate = DateTime.Now,
                OrderStatus = "Completed",
                TotalAmount = 200,
            };
            //Act
            try
            {
                orderservice.Setup(repos => repos.UpdateAsync(_updateOrder)).ReturnsAsync(_order);
                var result = await _orderServices.UpdateAsync(_updateOrder);
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
        /// Test to Get all Orders
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAll_Orders()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                orderservice.Setup(repos => repos.FindAllAsync());
                var result = await _orderServices.FindAllAsync();
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
        /// Test to get Order By Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetOrderById()
        {
            //Arrange
            var res = false;
            int orderId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                orderservice.Setup(repos => repos.FindOneAsync(orderId)).ReturnsAsync(_order);
                var result = await _orderServices.FindOneAsync(orderId);
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