using Shop.DALPractices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.DALPractices
{
    public interface IUnitOfWork
    {
        GenericRepository<Product> ProductRepository { get; }
        GenericRepository<Customer> CustomerRepository { get; }
        GenericRepository<Order> OrderRepository { get; }
        GenericRepository<ProductOrder> ProductOrderRepository { get; }

        Task SaveAsync();
    }
}
