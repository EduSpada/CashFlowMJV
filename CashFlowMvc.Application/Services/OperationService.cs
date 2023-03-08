using AutoMapper;
using CashFlowMvc.Application.DTOs;
using CashFlowMvc.Application.Interfaces;
using CashFlowMvc.Domain.Entities;
using CashFlowMvc.Domain.Interfaces;

namespace CashFlowMvc.Application.Services
{
    public class OperationService : IOperationService
    {
        private IOperationRepository _operationRepository;
        private IRepository _repo;
        private readonly IMapper _mapper;

        public OperationService(IOperationRepository operationRepository,
                                IRepository repo,
                                IMapper mapper)
        {
            _operationRepository = operationRepository ??
                throw new ArgumentException(nameof(operationRepository));
            _repo = repo ??
                throw new ArgumentException(nameof(repo));
            _mapper = mapper;
        }

        public async Task<IEnumerable<OperationDTO>> GetOperationsAsync()
        {
            var operationsEntity = await _operationRepository.GetOperationsAsync();
            return _mapper.Map<IEnumerable<OperationDTO>>(operationsEntity);
        }

        public async Task<OperationDTO> GetByIdAsync(int? id)
        {
            var operationsEntity = await _operationRepository.GetByIdAsync(id);
            return _mapper.Map<OperationDTO>(operationsEntity);
        }

        public async Task<OperationDTO> GetTrasactionPaymentMethodAsync(int? id)
        {
            var operationsEntity = await _operationRepository.GetTrasactionPaymentMethodAsync(id);
            return _mapper.Map<OperationDTO>(operationsEntity);
        }

        public async Task<OperationDTO> GetOperationDirectionAsync(int? id)
        {
            var operationsEntity = await _operationRepository.GetTrasactionPaymentMethodAsync(id);
            return _mapper.Map<OperationDTO>(operationsEntity);
        }

        public async Task<OperationDTO> GetByDescriptionAsync(string? description)
        {
            var operationsEntity = await _operationRepository.GetByDescriptionAsync(description);
            return _mapper.Map<OperationDTO>(operationsEntity);
        }

        public async Task<List<OperationDTO>> GetByCreatedAtAsync(DateTime? createdAt)
        {
            var operationsEntity = await _operationRepository.GetByCreatedAtAsync(createdAt);
            return _mapper.Map<List<OperationDTO>>(operationsEntity);
        }

        public async Task CreateAsync(OperationDTO operationDto)
        {
            var operationEntity = _mapper.Map<Operation>(operationDto);
            await _repo.CreateAsync(operationEntity);
        }

        public async Task UpdateAsync(OperationDTO operationDto)
        {
            var operationEntity = _mapper.Map<Operation>(operationDto);
            await _repo.UpdateAsync(operationEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var OperationEntity = _operationRepository.GetByIdAsync(id).Result;
            await _repo.RemoveAsync(OperationEntity);
        }
    }
}