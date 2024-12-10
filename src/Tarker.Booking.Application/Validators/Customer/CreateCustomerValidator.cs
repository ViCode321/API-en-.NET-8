using FluentValidation;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;

namespace Tarker.Booking.Application.Validators.Customer;

public class CreateCustomerValidator: AbstractValidator<CreateCustomerModel>
{
    public CreateCustomerValidator()
    {
        RuleFor(x => x.FullName).NotNull().NotEmpty().MaximumLength(50);
        RuleFor(x => x.DocumentNumber).NotNull().NotEmpty().MaximumLength(10);
    }
}
