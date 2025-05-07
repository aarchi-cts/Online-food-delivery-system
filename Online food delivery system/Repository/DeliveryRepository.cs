using Microsoft.EntityFrameworkCore;
using Online_food_delivery_system.Interface;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Repository
{
    public class DeliveryRepository : IDelivery
    {
        private readonly FoodDbContext _context;

        public DeliveryRepository(FoodDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Delivery>> GetAllAsync()
        {
            return await _context.Deliveries
                .Include(d => d.Order) // Include related Order
                    .ThenInclude(o => o.Customer) // Include Customer in Order
                .Include(d => d.Order)
                    .ThenInclude(o => o.Restaurant) // Include Restaurant in Order
                .Include(d => d.Order)
                    .ThenInclude(o => o.Payment) // Include Payment in Order
                .Include(d => d.Order)
                    .ThenInclude(o => o.OrderMenuItems) // Include OrderMenuItems in Order
                .Include(d => d.Agent) // Include related Agent
                .ToListAsync();
        }

        public async Task<Delivery> GetByIdAsync(int deliveryId)
        {
            return await _context.Deliveries
                .Include(d => d.Order) // Include related Order
                    .ThenInclude(o => o.Customer) // Include Customer in Order
                .Include(d => d.Order)
                    .ThenInclude(o => o.Restaurant) // Include Restaurant in Order
                .Include(d => d.Order)
                    .ThenInclude(o => o.Payment) // Include Payment in Order
                .Include(d => d.Order)
                    .ThenInclude(o => o.OrderMenuItems) // Include OrderMenuItems in Order
                .Include(d => d.Agent) // Include related Agent
                .FirstOrDefaultAsync(d => d.DeliveryID == deliveryId);
        }

        public async Task AddAsync(Delivery delivery)
        {
            await _context.Deliveries.AddAsync(delivery);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Delivery delivery)
        {
            _context.Deliveries.Update(delivery);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int deliveryId)
        {
            var delivery = await _context.Deliveries.FindAsync(deliveryId);
            if (delivery != null)
            {
                _context.Deliveries.Remove(delivery);
                await _context.SaveChangesAsync();
            }
        }
    }
}
