namespace Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;

public interface IUpdateUserPasswordCommand
{
    Task<bool> Execute(UpdateUserPasswordModel model);
}
