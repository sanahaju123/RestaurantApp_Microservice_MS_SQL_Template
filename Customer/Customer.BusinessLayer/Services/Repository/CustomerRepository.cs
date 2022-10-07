using Customer.DataLayer.Data;
using Customer.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.BusinessLayer.Services.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;

        public CustomerRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Customers>> FindAllAsync()
        {
             //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Customers> FindOneAsync(int id)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Customers> InsertAsync(Customers customer)
        {
             //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Customers> UpdateAsync(Customers customer)
        {
             //Write Your Code Here
            throw new NotImplementedException();
        }
    }
}
