using CashFlowMvc.Domain.Entities;

namespace CashFlowMvc.Domain.Interfaces
{
    public interface IPaymentMethodRepository
    {
         Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync();

         Task<PaymentMethod> GetByIdAsync(int? id);

         Task<PaymentMethod> GetByDescriptionAsync(string description);

         Task<PaymentMethod> GetPaymentMethodDirectionAsync(int? directionId);
    }
}