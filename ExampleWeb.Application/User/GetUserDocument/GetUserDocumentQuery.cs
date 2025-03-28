using MediatR;

namespace ExampleWeb.Application.User.GetUserDocument
{
    /// <summary>
    /// Запрос на получение документов пользователя
    /// </summary>
    public class GetUserDocumentQuery : IRequest<GetUserDocumentResponse>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; set; }
    }
}
