using CashFlowMvc.Application.DTOs;

namespace CashFlowMvc.Application.Interfaces
{
    public interface IOperationService
    {

         Task<IEnumerable<OperationDTO>> GetOperationsAsync();

         Task<OperationDTO> GetByIdAsync(int? id);

         Task<OperationDTO> GetTrasactionPaymentMethodAsync(int? id);

         Task<OperationDTO> GetOperationDirectionAsync(int? id);

         Task<OperationDTO> GetByDescriptionAsync(string? description);

         Task<List<OperationDTO>> GetByCreatedAtAsync(DateTime? createdAt);
         Task CreateAsync(OperationDTO OperationDto);
         Task UpdateAsync(OperationDTO OperationDto);
         Task RemoveAsync(int? id);
    }
}