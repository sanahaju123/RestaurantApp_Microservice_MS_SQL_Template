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
            try
            {
                return (IEnumerable<Orders>)await _dbContext.Orders.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Orders> FindOneAsync(int id)
        {
            try
            {
                return await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Orders> InsertAsync(Orders orders)
        {
            try
            {
                _dbContext.Add(orders);
                await _dbContext.SaveChangesAsync();
                return orders;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Orders> UpdateAsync(Orders orders)
        {
            try
            {
                _dbContext.Update(orders);
                await _dbContext.SaveChangesAsync();
                return orders;
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
        }
    }
}
