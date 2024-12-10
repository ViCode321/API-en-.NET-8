namespace Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;

public interface ICreateCustomerCommand
{
    Task<CreateCustomerModel> Execute(CreateCustomerModel model);
}
