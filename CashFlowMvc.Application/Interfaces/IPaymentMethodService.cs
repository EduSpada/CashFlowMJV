using CashFlowMvc.Application.DTOs;

namespace CashFlowMvc.Application.Interfaces
{
    public interface IPaymentMethodService
    {
         Task<IEnumerable<PaymentMethodDTO>> GetPaymentMethodsAsync();

         Task<PaymentMethodDTO> GetByIdAsync(int? id);

         Task<PaymentMethodDTO> GetPaymentMethodDirectionAsync(int? id);

         Task<PaymentMethodDTO> GetByDescriptionAsync(string? description);
         
         Task CreateAsync(PaymentMethodDTO paymentMethodDto);
         Task UpdateAsync(PaymentMethodDTO paymentMethodDto);
         Task RemoveAsync(int? id);
    }
}