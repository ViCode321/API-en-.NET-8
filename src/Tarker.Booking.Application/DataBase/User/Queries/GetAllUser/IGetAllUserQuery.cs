using System;

namespace Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;

public interface IGetAllUserQuery
{
    Task<List<GetAllUserModel>> Execute();
}
