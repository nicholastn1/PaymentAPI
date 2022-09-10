using PaymentAPI.Models;

namespace PaymentAPI.Repository
{
    public interface IPaymentRepository
    {
        PaymentModel Register(PaymentModel payment);
        PaymentModel Update(PaymentModel payment);
        PaymentModel ListById(int id);
    }
}
