using AutoMapper;
using CashFlowMvc.Application.DTOs;
using CashFlowMvc.Application.Interfaces;
using CashFlowMvc.Domain.Entities;
using CashFlowMvc.Domain.Interfaces;

namespace CashFlowMvc.Application.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private IPaymentMethodRepository _paymentMethodRepository;
        private IRepository _repo;
        private readonly IMapper _mapper;
        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository,
                                    IRepository repo,
                                    IMapper mapper)
        {
            _paymentMethodRepository = paymentMethodRepository ??
                throw new ArgumentException(nameof(paymentMethodRepository));
            _repo = repo ??
                throw new ArgumentException(nameof(repo));
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentMethodDTO>> GetPaymentMethodsAsync()
        {
            var paymentMethodsEntity = await _paymentMethodRepository.GetPaymentMethodsAsync();
            return _mapper.Map<IEnumerable<PaymentMethodDTO>>(paymentMethodsEntity);
        }

        public async Task<PaymentMethodDTO> GetByIdAsync(int? id)
        {
            var paymentMethodsEntity = await _paymentMethodRepository.GetByIdAsync(id);
            return _mapper.Map<PaymentMethodDTO>(paymentMethodsEntity);
        }

        public async Task<PaymentMethodDTO> GetPaymentMethodDirectionAsync(int? directionId)
        {
            var paymentMethodsEntity = await _paymentMethodRepository.GetPaymentMethodDirectionAsync(directionId);
            return _mapper.Map<PaymentMethodDTO>(paymentMethodsEntity);
        }

        public async Task<PaymentMethodDTO> GetByDescriptionAsync(string? description)
        {
            var paymentMethodsEntity = await _paymentMethodRepository.GetByDescriptionAsync(description);
            return _mapper.Map<PaymentMethodDTO>(paymentMethodsEntity);
        }

        public async Task CreateAsync(PaymentMethodDTO paymentMethodDto)
        {
            var paymentMethodsEntity = _mapper.Map<PaymentMethod>(paymentMethodDto);
            await _repo.CreateAsync(paymentMethodsEntity);
        }

        public async Task UpdateAsync(PaymentMethodDTO paymentMethodDto)
        {
            var paymentMethodsEntity = _mapper.Map<PaymentMethod>(paymentMethodDto);
            await _repo.UpdateAsync(paymentMethodsEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var paymentMethodsEntity = _paymentMethodRepository.GetByIdAsync(id).Result;
            await _repo.RemoveAsync(paymentMethodsEntity);
        }
    }
}