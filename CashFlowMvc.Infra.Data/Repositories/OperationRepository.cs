using CashFlowMvc.Domain.Entities;
using CashFlowMvc.Domain.Interfaces;
using CashFlowMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CashFlowMvc.Infra.Data.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private ApplicationDbContext _context;
        public OperationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Operation>> GetByCreatedAtAsync(DateTime? createdAt)
        {
            return await _context.Operations.Include(p => 
                        p.PaymentMethod).OrderBy(t => 
                        t.CreatedAt).Where(o => 
                        o.CreatedAt.Value.Date == createdAt.Value.Date).ToListAsync();

        }

        public async Task<Operation> GetByDescriptionAsync(string? description)
        {
            return await _context.Operations.FindAsync(description);
        }

        public async Task<Operation> GetByIdAsync(int? id)
        {
            return await _context.Operations.FindAsync(id);
        }

        public async Task<IEnumerable<Operation>> GetOperationsAsync()
        {
            return await _context.Operations.Include(p => p.PaymentMethod)
                            .OrderBy(t => t.CreatedAt).ToListAsync();
        }

        public async Task<Operation> GetTrasactionPaymentMethodAsync(int? id)
        {
            return await _context.Operations.Include(p => p.PaymentMethod)
                    .SingleOrDefaultAsync(t => t.Id == id);
        }
    }
}