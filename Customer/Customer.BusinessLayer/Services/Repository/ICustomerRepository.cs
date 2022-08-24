using Customer.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.BusinessLayer.Services.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customers>> FindAllAsync();
        Task<Customers> FindOneAsync(int id);
        Task<Customers> InsertAsync(Customers customer);
        Task<Customers> UpdateAsync(Customers customer);
    }
}
