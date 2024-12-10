using Tarker.Booking.Domain.Models.GmailGridEmail;

namespace Tarker.Booking.Application.External.GmailGridEmail
{
    public interface IGmailGridEmailService
    {
        Task<bool> Execute(GmailGridEmailRequestModel model);
    }
}
