using AutoMapper;
using CashFlowMvc.Application.DTOs;
using CashFlowMvc.Domain.Entities;

namespace CashFlowMvc.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<PaymentMethod, PaymentMethodDTO>().ReverseMap();
            CreateMap<Operation, OperationDTO>().ReverseMap();
        }
    }
}