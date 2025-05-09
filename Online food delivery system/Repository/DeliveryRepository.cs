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
                .Include(d => d.Order)
                    .ThenInclude(o => o.Customer!) // Use null-forgiving operator
                .Include(d => d.Order)
                    .ThenInclude(o => o.Restaurant!)
                .Include(d => d.Order)
                    .ThenInclude(o => o.Payment!)
                .Include(d => d.Order)
                    .ThenInclude(o => o.OrderMenuItems!)
                .Include(d => d.Agent!)
                .ToListAsync();
        }

        public async Task<Delivery?> GetByIdAsync(int deliveryId)
        {
            return await _context.Deliveries
                .Include(d => d.Order)
                    .ThenInclude(o => o.Customer!)
                .Include(d => d.Order)
                    .ThenInclude(o => o.Restaurant!)
                .Include(d => d.Order)
                    .ThenInclude(o => o.Payment!)
                .Include(d => d.Order)
                    .ThenInclude(o => o.OrderMenuItems!)
                .Include(d => d.Agent!)
                .FirstOrDefaultAsync(d => d.DeliveryID == deliveryId);
        }

        public async Task<IEnumerable<Agent>> GetAvailableAgentsAsync()
        {
            return await _context.Agents.Where(a => a.IsAvailable).ToListAsync();
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
        public async Task UpdateAgentAvailabilityAsync(Agent selectedAgent)
        {
            var agent = await _context.Agents.FindAsync(selectedAgent.AgentID);
            if (agent != null)
            {
                agent.IsAvailable = selectedAgent.IsAvailable;
                _context.Agents.Update(agent);
                await _context.SaveChangesAsync();
            }
        }
    }
}
