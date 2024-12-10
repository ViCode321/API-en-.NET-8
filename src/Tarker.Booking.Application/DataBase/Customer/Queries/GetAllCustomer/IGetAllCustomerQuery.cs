using System;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;

public interface IGetAllCustomerQuery
{
    Task<List<GetAllCustomerModel>> Execute();
}
