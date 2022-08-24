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
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly ICustomerService _customerServices;
        public readonly Mock<ICustomerRepository> customerservice = new Mock<ICustomerRepository>();
        private readonly Customers _customer;
        private static string type = "Boundary";
        public BoundaryTests(ITestOutputHelper output)
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
        /// Test to validate customer name connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Customer_Name_NotEmpty()
        {
            //Arrange
            bool res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                customerservice.Setup(repo => repo.FindOneAsync(id)).ReturnsAsync(_customer);
                var result = await _customerServices.FindOneAsync(id);
                if (result.Name.ToString().Length != 0)
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
