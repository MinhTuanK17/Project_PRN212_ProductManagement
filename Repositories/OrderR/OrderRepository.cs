using BusinessObject;
using DataLayerAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.OrderR
{
    public class OrderRepository : IOrderRepository
    {
        public async Task AddNewOrder(Order order) => await OrderDAO.Instance.AddNewOrder(order);   

        public async Task DeleteOrder(Order order) => await OrderDAO.Instance.DeleteOrder(order);

        public async Task<List<Order>> GetAllOrder() => await OrderDAO.Instance.GetAllOrder();

        public async Task<int> GetMaxOrderId() => await OrderDAO.Instance.GetMaxOrderId();

        public async Task<Order> GetOrderById(int orderId) => await OrderDAO.Instance.GetOrderById(orderId);

        public async Task UpdateOrder(Order order) => await OrderDAO.Instance.UpdateOrder(order);
    }
}
