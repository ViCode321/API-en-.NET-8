using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Tarker.Booking.Application.External.GmailGridEmail;
using Tarker.Booking.Domain.Models.GmailGridEmail;

namespace Tarker.Booking.External.GmailEmail
{
    public class GmailGridEmailService : IGmailGridEmailService
    {
        private readonly IConfiguration _configuration;

        public GmailGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Execute(GmailGridEmailRequestModel model)
        {
            var smtpServer = _configuration["GmailSettings:SmtpServer"];
            var port = int.Parse(_configuration["GmailSettings:Port"] ?? string.Empty);
            var senderEmail = _configuration["GmailSettings:SenderEmail"];
            var senderPassword = _configuration["GmailSettings:SenderPassword"];

            using var client = new SmtpClient(smtpServer, port)
            {
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail ?? string.Empty, model.From?.Name),
                Subject = model.Personalizations?.FirstOrDefault()?.Subject,
                Body = model.Content?.FirstOrDefault()?.Value,
                IsBodyHtml = true
            };

            foreach (var to in model.Personalizations?.FirstOrDefault()?.To ?? new List<ContentEmail>())
            {
                mailMessage.To.Add(new MailAddress(to.Email ?? string.Empty));
            }

            await client.SendMailAsync(mailMessage);
            return true;
        }
    }
}
