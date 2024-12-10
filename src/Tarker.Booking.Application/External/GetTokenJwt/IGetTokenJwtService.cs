using System;

namespace Tarker.Booking.Application.External.GetTokenJwt;

public interface IGetTokenJwtService
{
    string Execute(string id);
}
