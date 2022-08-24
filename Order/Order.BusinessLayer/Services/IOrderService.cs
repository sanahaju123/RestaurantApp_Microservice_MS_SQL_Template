using Order.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.BusinessLayer.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Orders>> FindAllAsync();
        Task<Orders> FindOneAsync(int id);
        Task<Orders> InsertAsync(Orders orders);
        Task<Orders> UpdateAsync(Orders orders);
    }
}
