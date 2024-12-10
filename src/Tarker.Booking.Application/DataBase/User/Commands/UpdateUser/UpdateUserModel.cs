using System;

namespace Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;

public class UpdateUserModel
{
    /* ENTIDADES PARA UpdateUser */
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}
