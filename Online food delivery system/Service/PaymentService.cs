using System.Threading.Tasks;
using Online_food_delivery_system.Interface;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Service
{
    public class PaymentService
    {
        private readonly IPayment _paymentRepository;
        public PaymentService(IPayment paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _paymentRepository.GetAllAsync();
        }
        public async Task<Payment> GetPaymentByIdAsync(int paymentID)
        {
            return await _paymentRepository.GetByIdAsync(paymentID);
        }
        public async Task AddPaymentAsync(Payment payment)
        {
            await _paymentRepository.AddAsync(payment);
        }
        public async Task UpdatePayment(Payment payment)
        {
            await _paymentRepository.UpdateAsync(payment);
        }
        public async Task DeletePayment(int paymentID)
        {
            await _paymentRepository.DeleteAsync(paymentID);
        }
    }
}
