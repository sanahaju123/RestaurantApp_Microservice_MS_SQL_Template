using Order.Entities.Models;
using Order.BusinessLayer.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.BusinessLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
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


