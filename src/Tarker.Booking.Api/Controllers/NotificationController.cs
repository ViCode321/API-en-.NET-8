using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.External.GmailGridEmail;
using Tarker.Booking.Application.Features;
using Tarker.Booking.Domain.Models.GmailGridEmail;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/notification")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class NotificationController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] GmailGridEmailRequestModel model,
            [FromServices] IGmailGridEmailService gmailGridEmailService
        )
        {
            var data = await gmailGridEmailService.Execute(model);

            if (!data)
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ResponseApiService.Response(
                        StatusCodes.Status500InternalServerError
                        )
                    );
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(
                    StatusCodes.Status200OK
                    )
                );

        }

    }
}
