using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.DeleteUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserById;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserByNameAndPassword;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.External.ApplicationInsights;
using Tarker.Booking.Application.External.GetTokenJwt;
using Tarker.Booking.Application.Features;
using Tarker.Booking.Common.Constants;
using Tarker.Booking.Domain.Models.ApplicationInsights;

namespace Tarker.Booking.Api.Controllers
{
    #pragma warning disable
    [Authorize]
    [Route("api/v1/user")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UserController : ControllerBase
    {
        private readonly IInsertApplicationInsightsService _insertApplicationInsightsService;
        public UserController(IInsertApplicationInsightsService insertApplicationInsightsService)
        {
            _insertApplicationInsightsService = insertApplicationInsightsService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateUserModel model,
            [FromServices] ICreateUserCommand createUserCommand,
            [FromServices] IValidator<CreateUserModel> validator
        )
        {
            var validate = await validator.ValidateAsync(model);

            if(!validate.IsValid)
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createUserCommand.Execute(model);

            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateUserModel model,
            [FromServices] IUpdateUserCommand updateUserCommand,
            [FromServices] IValidator<UpdateUserModel> validator
        )
        {
            var validate = await validator.ValidateAsync(model);

            if(!validate.IsValid)
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await updateUserCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se pudo xdd"));
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword(
            [FromBody] UpdateUserPasswordModel model,
            [FromServices] IUpdateUserPasswordCommand updateUserPasswordCommand,
            [FromServices] IValidator<UpdateUserPasswordModel> validator
        )
        {
            var validate = await validator.ValidateAsync(model);

            if(!validate.IsValid)
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await updateUserPasswordCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se pudo xdd"));
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> Delete(
            int userId,
            [FromServices] IDeleteUserCommand deleteUserCommand)
        {
            if(userId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await deleteUserCommand.Execute(userId);
            if(!data)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se pudo xdd"));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get(
            [FromServices] IGetAllUserQuery getAllUserQuery
        )
        {
            var metric = new InsertApplicationInsightsModel(
            ApplicationInsightsConstants.METRIC_TYPE_API_CALL,
            EntitiesConstants.USER,
            "get-all"
            );
        
            _insertApplicationInsightsService.Execute(metric);
            
            var data = await getAllUserQuery.Execute();
            if (data == null || data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se pudo xdd"));
        }

        [HttpGet("get-by-id/{userId}")]
        public async Task<IActionResult> GetById(
            int userId, 
            [FromServices] IGetUserByIdQuery getUserByIdQuery)
        {
            var metric = new InsertApplicationInsightsModel(
            ApplicationInsightsConstants.METRIC_TYPE_API_CALL,
            EntitiesConstants.USER,
            "get-by-id"
            );
        
            _insertApplicationInsightsService.Execute(metric);

            if(userId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getUserByIdQuery.Execute(userId);

            if(data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se pudo xdd"));
        }


        [AllowAnonymous]
        [HttpGet("get-by-username-password/{userName}/{password}")]
        public async Task<IActionResult> GetByUsernamePassword(
            string userName, string password,
            [FromServices] IGetUserByNameAndPasswordQuery getUserByNameAndPasswordQuery,
            [FromServices] IValidator<(string, string)> validator,
            [FromServices] IGetTokenJwtService getTokenJwtService
        )
        {
            var metric = new InsertApplicationInsightsModel(
            ApplicationInsightsConstants.METRIC_TYPE_API_CALL,
            EntitiesConstants.USER,
            "get-by-username-password"
            );
        
        _insertApplicationInsightsService.Execute(metric);

            var validate = await validator.ValidateAsync((userName, password));

            if(!validate.IsValid)
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data =  await getUserByNameAndPasswordQuery.Execute(userName, password);
            if(data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            data.Token = getTokenJwtService.Execute(data.UserId.ToString());

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se pudo de nuevo xdd"));
        }
    }
}
