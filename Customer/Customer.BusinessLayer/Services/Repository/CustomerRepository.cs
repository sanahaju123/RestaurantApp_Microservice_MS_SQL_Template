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
            try
            {
                return (IEnumerable<Customers>)await _dbContext.Customers.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<Customers> FindOneAsync(int id)
        {
            try
            {
                return await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Customers> InsertAsync(Customers customer)
        {
            try
            {
                _dbContext.Add(customer);
                await _dbContext.SaveChangesAsync();
                return customer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Customers> UpdateAsync(Customers customer)
        {
            try
            {
                _dbContext.Update(customer);
                await _dbContext.SaveChangesAsync();
                return customer;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
