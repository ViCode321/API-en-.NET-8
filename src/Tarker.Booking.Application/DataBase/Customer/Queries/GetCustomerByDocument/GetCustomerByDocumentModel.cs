namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocument;

public class GetCustomerByDocumentModel
{
    public int CustomerId { get; set; }
    public string? FullName { get; set; }
    public string? DocumentNumber { get; set; }
}
