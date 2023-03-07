namespace CashFlowMvc.Domain.Tests
{
    public class TrasactionUnitTest1
    {
        [Fact(DisplayName = "Create Operation With Valid Parameters")]
        public void CreateOperation_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Operation(1,
                                                  "George Wells Company",
                                                  200.15m,
                                                  15);
            action.Should()
                .NotThrow<CashFlowMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Operation With Negative Id")]
        public void CreateOperation_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Operation(-1,
                                                  "George Wells Company",
                                                  200.15m,
                                                  15);
            action.Should()
                .Throw<CashFlowMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }
        [Fact(DisplayName = "Create Operation With Too Short Description")]
        public void CreateOperation_ToShortDescriptionValue_DomainExceptionTooShortDescription()
        {
            Action action = () => new Operation(1,
                                                  "Well",
                                                  200.15m,
                                                  15);
            action.Should()
                .Throw<CashFlowMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters.");
        }
        [Fact(DisplayName = "Create Operation With Empty Description")]
        public void CreateOperation_WithEmptyDescriptionValue_DomainExceptionRequiredDescription()
        {
            Action action = () => new Operation(1,
                                                  "",
                                                  200.15m,
                                                  15);
            action.Should()
                .Throw<CashFlowMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, must not be empty or null.");
        }
        [Fact(DisplayName = "Create Operation With Null Description")]
        public void CreateOperation_WithNullDescriptionValue_DomainExceptionRequiredDescription()
        {
            Action action = () => new Operation(1,
                                                  null,
                                                  200.15m,
                                                  15);
            action.Should()
                .Throw<CashFlowMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, must not be empty or null.");
        }
        [Fact(DisplayName = "Create Operation With Negative Value")]
        public void CreateOperation_WithNegativeValue_DomainExceptionValueLessThanZero()
        {
            Action action = () => new Operation(1,
                                                  "George Wells Company",
                                                  -200.15m,
                                                  15);
            action.Should()
                .Throw<CashFlowMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Value must be greater than zero.");
        }
        [Fact(DisplayName = "Create Operation With Value Like A Zero")]
        public void CreateOperation_WithValueLikeAZero_DomainExceptionValueLessThanZero()
        {
            Action action = () => new Operation(1,
                                                  "George Wells Company",
                                                  0,
                                                  15);
            action.Should()
                .Throw<CashFlowMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Value must be greater than zero.");
        }
        [Fact(DisplayName = "Create Operation With Negative PaymentMothodId")]
        public void CreateOperation_WithNegativePaymentMethodId_DomainExceptionPaymentMethodIdNegative()
        {
            Action action = () => new Operation(1,
                                                  "George Wells Company",
                                                  200.15m,
                                                  -1);
            action.Should()
                .Throw<CashFlowMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("PaymentMethodId must be positive.");
        }
    }
}