using CashFlowMvc.Domain.Validation;

namespace CashFlowMvc.Domain.Entities
{
    public sealed class PaymentMethod : Entity
    {
        public int DirectionId { get; private set; }

        public IEnumerable<Operation>? Operations { get; set; }

        public PaymentMethod(string description,
                             int directionId)
        {
            ValidateDomain(description,
                           directionId);

        }
        public PaymentMethod(int id,
                             string description,
                             int directionId)
        {
            DomainExceptionValidation.When(id < 0,
                                           "Invalid Id value.");
            Id = id;
            ValidateDomain(description,
                           directionId);
        }
        public void Update(string description,
                           int directionId)
        {
            ValidateDomain(description,
                           directionId);

        }
        private void ValidateDomain(string description,
                                    int directionId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                                           "Invalid description, must not be empty or null.");

            DomainExceptionValidation.When(description.Length < 5,
                                           "Invalid description, too short, minimum 5 characters.");

            DomainExceptionValidation.When(directionId < 0,
                                           "Invalid directionId value, must not be negative.");
            DomainExceptionValidation.When(directionId > 2,
                                           "Invalid directionId value, must not be 1 to Inflow and 2 to Outflow.");
            
            DirectionId = directionId;
            Description = description;
        }
    }
}