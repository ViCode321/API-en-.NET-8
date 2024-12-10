namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserByNameAndPassword;

public class GetUserByNameAndPasswordModel
{
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Token { get; set; }
}
