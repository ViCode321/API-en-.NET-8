using System;

namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingByType;

public interface IGetBookingByTypeQuery
{
    Task<List<GetBookingByTypeModel>> Execute(string type);
}
