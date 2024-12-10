namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserByNameAndPassword;

public interface IGetUserByNameAndPasswordQuery
{
    Task<GetUserByNameAndPasswordModel> Execute(string userName, string password);
}
