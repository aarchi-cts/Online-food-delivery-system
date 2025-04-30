using Microsoft.EntityFrameworkCore;
using Online_food_delivery_system.Interface;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Repository
{
    public class PaymentRepository : IPayment
    {
        private readonly FoodDbContext _context;
        public PaymentRepository(FoodDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int PaymentID)
        {
            var pay=await _context.Payments.FindAsync(PaymentID);
            if(pay != null)
            {
                _context.Payments.Remove(pay);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments.Include(s=>s.Order).Include(s=>s.Delivery).ToListAsync();
        }

        public async Task<Payment> GetByIdAsync(int ID)
        {
            var payment=await _context.Payments
                .Include(s=>s.Order)
                .Include(s=>s.Delivery)
                .FirstOrDefaultAsync(p=>p.OrderID==ID);
            if(payment == null)
            {
                throw new Exception("Payment not found");
            }
            return payment;
        }

        public async Task UpdateAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }
    }
}
