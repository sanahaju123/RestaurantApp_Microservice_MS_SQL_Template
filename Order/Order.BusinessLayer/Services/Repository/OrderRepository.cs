using Microsoft.EntityFrameworkCore;
using Order.DataLayer.Data;
using Order.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.BusinessLayer.Services.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _dbContext;
        public OrderRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Orders>> FindAllAsync()
        {
             //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Orders> FindOneAsync(int id)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Orders> InsertAsync(Orders orders)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Orders> UpdateAsync(Orders orders)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }
    }
}
