using System;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById;

public interface IGetCustomerByIdQuery
{
    Task<GetCustomerByIdModel> Execute(int customerId);
}
