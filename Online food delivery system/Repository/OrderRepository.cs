using Microsoft.EntityFrameworkCore;
using Online_food_delivery_system.Interface;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly FoodDbContext _context;
        public OrderRepository(FoodDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
            // Calculate the total amount for the order
            // Extract the list of ItemIDs from OrderMenuItems
            IList<int> orderMenuItemIds = order.OrderMenuItems.Select(o => o.ItemID).ToList();

            // Fetch the corresponding MenuItems from the database
            IEnumerable<MenuItem> menuItems = await _context.MenuItems
                .Where(m => orderMenuItemIds.Contains(m.ItemID))
                .ToListAsync();

            // Calculate the total amount
            order.TotalAmount = menuItems.Sum(m => m.Price ?? 0);

            // Add the order
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            // Create the payment entry
            Payment payment = new Payment
            {
                OrderID = order.OrderID,
                Amount = order.TotalAmount,
                PaymentMethod = "Cash", // or any default value
                Status = "Pending" // or any default value
            };

            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int OrderID)
        {
            var ord = await _context.Orders.FindAsync(OrderID);
            if (ord != null)
            {
                _context.Orders.Remove(ord);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Restaurant)
                .Include(o => o.OrderMenuItems)
                .ThenInclude(omi => omi.MenuItem)
                .Include(o => o.Payment)
                .Include(o => o.Delivery)
                .ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int? OrderID)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Restaurant)
                .Include(o => o.OrderMenuItems)
                .ThenInclude(omi => omi.MenuItem)
                .Include(o => o.Payment)
                .Include(o => o.Delivery)
                .FirstOrDefaultAsync(o => o.OrderID == OrderID);
            if (order == null)
            {
                throw new Exception("Order not Found");
            }
            return order;
        }

        public async Task UpdateAsync(Order order)
        {
            // Calculate the total amount for the order
           // order.CalculateTotalAmount();

            // Update the order
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            // Update the payment entry
            var payment = await _context.Payments.FirstOrDefaultAsync(p => p.OrderID == order.OrderID);
            if (payment != null)
            {
                payment.Amount = order.TotalAmount;
                _context.Payments.Update(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
