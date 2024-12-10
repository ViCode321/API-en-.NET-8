using System;

namespace Tarker.Booking.Application.DataBase.User.Commands.CreateUser;

public class CreateUserModel
{
    /* ENTIDADES PARA CreateUser */
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }

}
