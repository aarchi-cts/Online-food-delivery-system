using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Interface
{
    public interface IPayment
    {
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment> GetByIdAsync(int PaymentID);
        Task AddAsync(Payment payment);
        Task UpdateAsync(Payment payment);
        Task DeleteAsync(int PaymentID);
        Task<Payment> ProcessPaymentAsync(Payment payment);
    }
}
