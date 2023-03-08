

using CashFlowMvc.Domain.Entities;

namespace CashFlowMvc.Domain.Interfaces
{
    public interface IOperationRepository
    {
         Task<IEnumerable<Operation>> GetOperationsAsync();

         Task<Operation> GetByIdAsync(int? id);

         Task<Operation> GetTrasactionPaymentMethodAsync(int? id);

         Task<List<Operation>> GetByDescriptionAsync(string? description);

         Task<List<Operation>> GetByCreatedAtAsync(DateTime? createdAt);

         Task<List<Operation>> GetByCreatedAtAndDescriptionAsync(DateTime? createdAt, string? description);
    }
}