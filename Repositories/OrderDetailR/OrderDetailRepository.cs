using BusinessObject;
using DataLayerAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.OrderDetailR
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public async Task AddOrderDetail(OrderDetail orderDetail) => await OrderDetailDAO.Instance.AddOrderDetail(orderDetail);

        public async Task DeleteOrderDetail(OrderDetail orderDetail) => await OrderDetailDAO.Instance.DeleteOrderDetail(orderDetail);

        public async Task<List<OrderDetail>> GetAllOrderDetail() => await OrderDetailDAO.Instance.GetAllOrderDetail();

        public async Task<OrderDetail> GetOrderDetailById(string orderId, string productPhoneId) => await OrderDetailDAO.Instance.GetOrderDetailById(orderId, productPhoneId);

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(string orderId) => await OrderDetailDAO.Instance.GetOrderDetailByOrderId(orderId);

        public async Task<List<OrderDetail>> GetOrderHistory(int customerId) => await OrderDetailDAO.Instance.GetOrderHistory(customerId);
        public async Task UpdateOrderDetail(OrderDetail orderDetail) => await OrderDetailDAO.Instance.UpdateOrderDetail(orderDetail);
    }
}
