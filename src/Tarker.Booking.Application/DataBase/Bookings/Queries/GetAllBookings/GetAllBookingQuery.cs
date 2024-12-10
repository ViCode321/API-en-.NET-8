using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetAllBookings;

public class GetAllBookingQuery: IGetAllBookingQuery
{
    private readonly IDataBaseService _dataBaseService;
    public GetAllBookingQuery(IDataBaseService dataBaseService)
    {
        _dataBaseService = dataBaseService;
    }

    public async Task<List<GetAllBookingModel>> Execute()
    {
        var result = await (from booking in _dataBaseService.Booking 
                            join customer in _dataBaseService.Customer
                            on booking.CustomerId equals customer.CustomerId
                            select new GetAllBookingModel
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
