using Customer.DataLayer.Data;
using Customer.Entities.Models;
using Customer.BusinessLayer.Services;
using Customer.BusinessLayer.Services.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Customer.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly ICustomerService _customerServices;
        public readonly Mock<ICustomerRepository> customerservice = new Mock<ICustomerRepository>();
        private readonly Customers _customer;
        private static string type = "Exception";
        public ExceptionalTests(ITestOutputHelper output)
        {
            _customerServices = new CustomerService(customerservice.Object);
            _output = output;
            _customer = new Customers
            {
                Id = 1,
                Email = "Customer@gmail.com",
                Name = "Customer1",
            };
        }
        /// <summary>
        /// Test to validate if invalid customer id is passed it will return false
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidCustomerIdIsPassed()
        {
            //Arrange
            bool res = false;
            _customer.Id = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                customerservice.Setup(repo => repo.FindOneAsync(_customer.Id)).ReturnsAsync(_customer);
                var result = await _customerServices.FindOneAsync(_customer.Id);
                if (result == null || result.Id < 1)
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