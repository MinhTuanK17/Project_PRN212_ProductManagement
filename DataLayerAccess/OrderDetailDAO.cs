using BusinessObject;
using BusinessObject.Common;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayerAccess
{
    public class OrderDetailDAO : SingletonBase<OrderDetailDAO>
    {
        private MyPhoneDbContext? _context;

        public async Task<OrderDetail> GetOrderDetailById(string orderId, string productPhoneId)
        {
            try
            {
                _context = new();
                var orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(o => o.OrderId.Equals(orderId) && o.ProductPhoneId.Equals(productPhoneId));
                return orderDetail!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(string orderId)
        {
            try
            {
                _context = new();
                var orderDetail = await _context.OrderDetails.Where(b => b.OrderId.Equals(orderId)).ToListAsync();
                return orderDetail!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<OrderDetail>> GetAllOrderDetail()
        {
            _context = new();
            return await _context.OrderDetails.AsNoTracking().Include(o => o.Order).Include(o => o.Product).Include(b => b.Order.Account).ToListAsync();
        }

        public async Task AddOrderDetail(OrderDetail orderDetail)
        {
            _context = new();
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _context = new();
                var findOrderDetail = await GetOrderDetailById(orderDetail.OrderId, orderDetail.ProductPhoneId);
                if (findOrderDetail != null)
                {
                    _context.Entry(findOrderDetail).CurrentValues.SetValues(orderDetail);
                }
                else
                {
                    _context.OrderDetails.Update(orderDetail);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _context = new();
                var findOrderDetail = await GetOrderDetailById(orderDetail.OrderId, orderDetail.ProductPhoneId);
                if (findOrderDetail != null)
                {
                    _context.OrderDetails.Remove(findOrderDetail);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<List<OrderDetail>> GetOrderHistory(int customerId)
        {
            _context = new();
            return await _context.OrderDetails.AsNoTracking().Include(o => o.Order).Include(o => o.Product)
                .Where(od => od.Order.AccountId == customerId).ToListAsync();

        }

    }
}
