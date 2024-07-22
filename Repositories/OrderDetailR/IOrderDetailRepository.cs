using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.OrderDetailR
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> GetOrderDetailById(string orderId, string productPhoneId);
        Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(string orderId);
        Task<List<OrderDetail>> GetAllOrderDetail();
        Task AddOrderDetail(OrderDetail orderDetail);
        Task UpdateOrderDetail(OrderDetail orderDetail);
        Task DeleteOrderDetail(OrderDetail orderDetail);
        Task<List<OrderDetail>> GetOrderHistory(int customerId);
    }
}
