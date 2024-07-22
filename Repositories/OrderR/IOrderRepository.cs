using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.OrderR
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(int orderId);
        Task<List<Order>> GetAllOrder();
        Task AddNewOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(Order order);

        Task<int> GetMaxOrderId();

    }
}
