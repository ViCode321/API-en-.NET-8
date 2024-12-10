using System;

namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetAllBookings;

public interface IGetAllBookingQuery
{
    Task<List<GetAllBookingModel>> Execute();
}
