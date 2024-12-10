using System;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocument;

public interface IGetCustomerByDocumentQuery
{
    Task<GetCustomerByDocumentModel> Execute(string document);
}
