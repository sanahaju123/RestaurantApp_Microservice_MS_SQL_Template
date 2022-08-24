using Customer.BusinessLayer.Services;
using Customer.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.WebAPI.Controllers
{
    [Route("Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        // POST: api/customers
        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customers customer)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        // PUT: api/customers 
        [HttpPut]
        public async Task<IActionResult> PutCustomer([FromBody] Customers customer)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        // PUT: api/customers 
        [HttpGet]
        [Route("{customerId}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

    }
}
