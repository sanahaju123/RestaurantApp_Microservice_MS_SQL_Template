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
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IOrderService _orderServices;
        public readonly Mock<IOrderRepository> orderservice = new Mock<IOrderRepository>();
        private readonly Orders _order;
        private static string type = "Boundary";
        public BoundaryTests(ITestOutputHelper output)
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
        /// Test to validate order status connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Order_Status_NotEmpty()
        {
            //Arrange
            bool res = false;
            int orderId = 5;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                orderservice.Setup(repo => repo.FindOneAsync(orderId)).ReturnsAsync(_order);
                var result = await _orderServices.FindOneAsync(orderId);
                if (result.OrderStatus.ToString().Length != 0)
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
