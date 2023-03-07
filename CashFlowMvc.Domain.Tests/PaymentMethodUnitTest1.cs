namespace CashFlowMvc.Domain.Tests
{
    public class PaymentMethodUnitTest1
    {
        [Fact(DisplayName = "Create Payment Method With Valid Parameters")]
        public void CreatePaymentMethod_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new PaymentMethod(1,
                                                    "Payment in kind",
                                                    2);
            action.Should()
                .NotThrow<CashFlowMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Payment Method With Negative Id")]
        public void CreatePaymentMethod_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new PaymentMethod(-1,
                                                    "Payment in kind",
                                                    2);
            action.Should()
                .Throw<CashFlowMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }
        [Fact(DisplayName = "Create Payment Method With Empty Description")]
        public void CreatePaymentMethod_MissingDescriptionValue_DomainExceptionRequireDescription()
        {
            Action action = () => new PaymentMethod(1,
                                                    "",
                                                    2);
            action.Should()
                .Throw<CashFlowMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, must not be empty or null.");
        }
        [Fact(DisplayName = "Create Payment Method With Null Description")]
        public void CreatePaymentMethod_NullDescriptionValue_DomainExceptionRequireDescription()
        {
            Action action = () => new PaymentMethod(1,
                                                    null,
                                                    2);
            action.Should()
                .Throw<CashFlowMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, must not be empty or null.");
        }
        [Fact(DisplayName = "Create Payment Method With Too Short Description")]
        public void CreatePaymentMethod_TooShortDescriptionValue_DomainExceptionTooShortDescription()
        {
            Action action = () => new PaymentMethod(1,
                                                    "kind",
                                                    2);
            action.Should()
                .Throw<CashFlowMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters.");
        }
        [Fact(DisplayName = "Create Payment Method With Negative DirectionId")]
        public void CreatePaymentMethod_WithNegativeDirectionIdValue_DomainExceptionInvalidDirectionId()
        {
            Action action = () => new PaymentMethod(1,
                                                    "Payment in kind",
                                                    -2);
            action.Should()
                .Throw<CashFlowMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid directionId value, must not be negative.");
        }
        [Fact(DisplayName = "Create Payment Method With Out Range DirectionId")]
        public void CreatePaymentMethod_WithDirectionIdOutRangeValue_DomainExceptionInvalidDirectionId()
        {
            Action action = () => new PaymentMethod(1,
                                                    "Payment in kind",
                                                    3);
            action.Should()
                .Throw<CashFlowMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid directionId value, must not be 1 to Inflow and 2 to Outflow.");
        }
    }
}