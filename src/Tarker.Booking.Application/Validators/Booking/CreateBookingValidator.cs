using FluentValidation;
using Tarker.Booking.Application.DataBase.Bookings.Commands.CreateBooking;

namespace Tarker.Booking.Application.Validators.Booking;

public class CreateBookingValidator: AbstractValidator<CreateBookingModel>
{
    public CreateBookingValidator()
    {
        RuleFor(x => x.Code).NotNull().NotEmpty().MaximumLength(10);
        RuleFor(x => x.Type).NotNull().NotEmpty().MaximumLength(10);
        RuleFor(x => x.CustomerId).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(x => x.UserId).NotNull().NotEmpty().GreaterThan(0);
    }
}
