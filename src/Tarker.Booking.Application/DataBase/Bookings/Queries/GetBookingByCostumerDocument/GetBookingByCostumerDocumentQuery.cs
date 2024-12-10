using System;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingByCostumerDocument;

public class GetBookingByCostumerDocumentQuery: IGetBookingByCostumerDocumentQuery
{
    private readonly IDataBaseService _dataBaseService;
    
    public GetBookingByCostumerDocumentQuery(IDataBaseService dataBaseService)
    {
        _dataBaseService = dataBaseService;
    }

    public async Task<List<GetBookingByCostumerDocumentModel>> Execute(string customerDocumentNumber)
    {
        var result = await (from booking in _dataBaseService.Booking 
                            join customer in _dataBaseService.Customer
                            on booking.CustomerId equals customer.CustomerId
                            where customer.DocumentNumber == customerDocumentNumber
                            select new GetBookingByCostumerDocumentModel
                            {
                                BookingId = booking.BookingId,
                                Code = booking.Code,
                                RegisterDate = booking.RegisterDate,
                                Type = booking.Type,
                                CustomerFullName = customer.FullName,
                                CustomerDocumentNumber = customer.DocumentNumber
                            }).ToListAsync();
        return result;
    }
}
