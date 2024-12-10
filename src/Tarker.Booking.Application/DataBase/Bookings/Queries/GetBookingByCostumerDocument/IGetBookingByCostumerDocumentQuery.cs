using System;

namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingByCostumerDocument;

public interface IGetBookingByCostumerDocumentQuery
{
    Task<List<GetBookingByCostumerDocumentModel>> Execute(string customerDocumentNumber);
}
