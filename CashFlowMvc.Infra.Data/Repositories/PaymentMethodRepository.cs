using CashFlowMvc.Domain.Entities;
using CashFlowMvc.Domain.Interfaces;
using CashFlowMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CashFlowMvc.Infra.Data.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private ApplicationDbContext _context;
        public PaymentMethodRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaymentMethod> GetPaymentMethodDirectionAsync(int? directionId)
        {
            return await _context.PaymentMethods
                    .SingleOrDefaultAsync(p => p.DirectionId == directionId);
        }

        public async Task<PaymentMethod> GetByIdAsync(int? id)
        {
            return await _context.PaymentMethods.FindAsync(id);
        }

        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync()
        {
            return await _context.PaymentMethods.ToListAsync();
        }

        public async Task<PaymentMethod> GetByDescriptionAsync(string description)
        {
            return await _context.PaymentMethods.FindAsync(description);
        }
    }
}