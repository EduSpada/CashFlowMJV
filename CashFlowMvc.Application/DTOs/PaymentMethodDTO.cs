using System.ComponentModel.DataAnnotations;
using CashFlowMvc.Domain.Entities;

namespace CashFlowMvc.Application.DTOs
{
    public class PaymentMethodDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [MinLength(5)]
        [MaxLength(150)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Direction Id is required.")]
        [Range(1, 2)]
        public int DirectionId { get; set; }
        private DateTime? _createdAt;
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            protected set { _createdAt = (value == null ? DateTime.UtcNow : value); }
        }
    }
}