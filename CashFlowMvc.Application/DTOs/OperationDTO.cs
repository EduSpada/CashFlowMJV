using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CashFlowMvc.Domain.Entities;

namespace CashFlowMvc.Application.DTOs
{
    public class OperationDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MinLength(5)]
        [MaxLength(150)]
        [DisplayName("Description")]
        public string? Description { get; set; }


        public PaymentMethod? PaymentMethod { get; set; }
        [Required(ErrorMessage = "Payment Method Id is required.")]
        [DisplayName("Payment Methods")]
        public int PaymentMethodId { get; set; }

        [DisplayName("Created Date")]
        public DateTime? CreatedAt { get; set; }

        [Required(ErrorMessage = "Value is required.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Operation Value")]
        public decimal Value { get; set; }
    }
}