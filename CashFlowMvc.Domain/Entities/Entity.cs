using System.ComponentModel.DataAnnotations;

namespace CashFlowMvc.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; protected set; }

        public string? Description { get; protected set; }

        private DateTime? _createdAt;
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            protected set { _createdAt = (value == null ? DateTime.UtcNow : value); }
        }

        public DateTime? UpdatedAt { get; protected set; }
    }
}