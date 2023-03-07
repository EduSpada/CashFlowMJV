using CashFlowMvc.Domain.Validation;

namespace CashFlowMvc.Domain.Entities
{
    public sealed class Operation : Entity
    {
        public decimal Value { get; private set; }

        public int PaymentMethodId { get; private set; }
        public PaymentMethod? PaymentMethod { get; set; }

        public Operation(string description,
                           decimal value,
                           int paymentMethodId)
        {
            ValidateDomain(description,
                           paymentMethodId,
                           value);
            CreatedAt = DateTime.UtcNow;
        }
        public Operation(int id,
                           string description,
                           decimal value,
                           int paymentMethodId)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(description,
                           paymentMethodId,
                           value);
            CreatedAt = DateTime.UtcNow;
        }
        public void Update(string description,
                           decimal value,
                           int paymentMethodId)
        {
            ValidateDomain(description,
                           paymentMethodId,
                           value);
            UpdatedAt = DateTime.UtcNow;
        }
        private void ValidateDomain(string description,
                                    int paymentMethodId,
                                    decimal value)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                                           "Invalid description, must not be empty or null.");

            DomainExceptionValidation.When(description.Length < 5,
                                           "Invalid description, too short, minimum 5 characters.");

            DomainExceptionValidation.When(paymentMethodId < 0,
                                           "PaymentMethodId must be positive.");

            DomainExceptionValidation.When(value <= 0,
                                           "Value must be greater than zero.");

            PaymentMethodId = paymentMethodId;
            Description = description;
            Value = value;
        }
    }
}