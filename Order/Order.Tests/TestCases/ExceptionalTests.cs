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
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IOrderService _orderServices;
        public readonly Mock<IOrderRepository> orderservice = new Mock<IOrderRepository>();
        private readonly Orders _order;
        private static string type = "Exception";
        public ExceptionalTests(ITestOutputHelper output)
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
        /// Test to validate if invalid order id is passed it will return false
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidOrdreIdIsPassed()
        {
            //Arrange
            bool res = false;
            _order.OrderId = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                orderservice.Setup(repo => repo.FindOneAsync(_order.OrderId)).ReturnsAsync(_order);
                var result = await _orderServices.FindOneAsync(_order.OrderId);
                if (result == null || result.OrderId < 1)
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
