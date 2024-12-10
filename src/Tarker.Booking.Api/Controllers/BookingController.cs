using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetAllBookings;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingByCostumerDocument;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingByType;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/booking")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class BookingController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateBookingModel model,
            [FromServices] ICreateBookingCommand command,
            [FromServices] IValidator<CreateBookingModel> validator
        )
        {
            var validate = await validator.ValidateAsync(model);

            if(!validate.IsValid)
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors)
                );
            var data = await command.Execute(model);

            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data)
            );
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get(
            [FromServices] IGetAllBookingQuery query
        )
        {
            var data = await query.Execute();

            if(data == null || data.Count == 0)
                return StatusCode(
                    StatusCodes.Status404NotFound,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data)
                );
            return StatusCode(
                StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se pudo xdd")
            );
        }

        [HttpGet("get-by-document/{document}")]
        public async Task<IActionResult> GetByDocument(
            string document,
            [FromServices] IGetBookingByCostumerDocumentQuery query
        )
        {
            if(document == null)
                return StatusCode(
                    StatusCodes.Status400BadRequest, 
                    ResponseApiService.Response(StatusCodes.Status400BadRequest)
                );

            var data = await query.Execute(document);

            if(data == null)
                return StatusCode(
                    StatusCodes.Status404NotFound,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data)
                );
            return StatusCode(
                StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se pudo xdd")
            );
        }

        [HttpGet("get-by-type/{type}")]
        public async Task<IActionResult> GetByType(
            string type,
            [FromServices] IGetBookingByTypeQuery query
        )
        {
            if(type == null)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
            
            var data = await query.Execute(type);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));
            
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se pudo xdd"));
        }

    }
}
