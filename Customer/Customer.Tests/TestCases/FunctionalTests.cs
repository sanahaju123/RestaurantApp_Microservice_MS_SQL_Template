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
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly ICustomerService _customerServices;
        public readonly Mock<ICustomerRepository> customerservice = new Mock<ICustomerRepository>();
        private readonly Customers _customer;
        private static string type = "Functional";
        public FunctionalTests(ITestOutputHelper output)
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
        /// Test to Add a new Customer.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Add_Customer()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                customerservice.Setup(repos => repos.InsertAsync(_customer)).ReturnsAsync(_customer);
                var result = await _customerServices.InsertAsync(_customer);

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
        /// Test to Update a Customer by Customer Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Update_Customer()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateCustomer = new Customers()
            {
                Id = 1,
                Email = "Customer@gmail.com",
                Name = "Customer11",
            };
            //Act
            try
            {
                customerservice.Setup(repos => repos.UpdateAsync(_updateCustomer)).ReturnsAsync(_customer);
                var result = await _customerServices.UpdateAsync(_updateCustomer);
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
        /// Test to Get all Customers
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAll_Customers()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                customerservice.Setup(repos => repos.FindAllAsync());
                var result = await _customerServices.FindAllAsync();
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
        /// Test to get Customer By Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetCustomerById()
        {
            //Arrange
            var res = false;
            int customerId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                customerservice.Setup(repos => repos.FindOneAsync(customerId)).ReturnsAsync(_customer);
                var result = await _customerServices.FindOneAsync(customerId);
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
