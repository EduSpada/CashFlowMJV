

using CashFlowMvc.Domain.Entities;

namespace CashFlowMvc.Domain.Interfaces
{
    public interface IOperationRepository
    {
         Task<IEnumerable<Operation>> GetOperationsAsync();

         Task<Operation> GetByIdAsync(int? id);

         Task<Operation> GetTrasactionPaymentMethodAsync(int? id);

         Task<Operation> GetByDescriptionAsync(string? description);

         Task<Operation> GetByCreatedAtAsync(string? createdAt);
    }
}