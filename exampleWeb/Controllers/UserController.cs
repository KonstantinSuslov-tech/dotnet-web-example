using ExampleWeb.Application.User.GetUserDocument;
using ExampleWeb.Application.User.GetUsers;
using ExampleWeb.Application.User.SaveUserDocument;
using ExampleWeb.Application.User.SaveUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="mediator"><see cref="IMediator"/></param>
        public UserController(IMediator mediator) => _mediator = mediator;


        [HttpGet]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation(
        OperationId = nameof(GetUserAsync),
        Summary = "Получение данных по пользователям")]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetUsersResponse))]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(GetUsersResponse))]
        public async Task<GetUsersResponse> GetUserAsync([FromQuery] GetUsersQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }



        [HttpPost]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation(
        OperationId = nameof(SetUserAsync),
        Summary = "Сохранение данных по пользователю")]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetUsersResponse))]
        public async Task<SaveUsersResponse> SetUserAsync([FromBody] SaveUsersCommand saveUser, CancellationToken cancellationToken)
        {
            return await _mediator.Send(saveUser, cancellationToken);
        }



        [HttpGet("document")]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation(
         OperationId = nameof(GetUserDocument),
         Summary = "Получение документов пользователя")]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetUserDocumentResponse))]
        public async Task<GetUserDocumentResponse> GetUserDocument([FromQuery] GetUserDocumentQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost("document")]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation(
         OperationId = nameof(GetUserDocument),
         Summary = "Сохранение документов пользователя")]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetUserDocumentResponse))]
        public async Task<SaveUserDocumentResponse> SaveUserDocument([FromBody] SaveUserDocumentCommand query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }

    }
}
