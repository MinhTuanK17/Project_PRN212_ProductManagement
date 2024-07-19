using BusinessObject;
using BusinessObject.Common;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayerAccess
{
    public class OrderDAO : SingletonBase<OrderDAO>
    {
        private MyPhoneDbContext? _context;

        public async Task<Order> GetOrderById(string orderId)
        {
            try
            {
                _context = new();
                var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId.Equals(orderId));
                return order!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<List<Order>> GetAllOrder()
        {
            _context = new();
            return await _context.Orders.AsNoTracking().Include(o => o.Account).ToListAsync();
        }

        public async Task AddNewOrder(Order order)
        {
            _context = new();
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            try
            {
                _context = new();
                var findOrder = await GetOrderById(order.OrderId);
                if (findOrder != null)
                {
                    _context.Entry(findOrder).CurrentValues.SetValues(order);
                }
                else
                {
                    _context.Orders.Update(order);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteOrder(Order order)
        {
            try
            {
                _context = new();
                var findOrder = await GetOrderById(order.OrderId);
                if (findOrder != null)
                {
                    _context.Orders.Remove(findOrder);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
