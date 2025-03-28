using ExampleWeb.Application.User.Dtos;

namespace ExampleWeb.Application.User.GetUserDocument
{
    /// <summary>
    /// Ответ получения документов пользователя
    /// </summary>
    public class GetUserDocumentResponse
    {
        /// <summary>
        /// Документы пользователя
        /// </summary>
        public IReadOnlyCollection<UserDocumentDto> Documents { get; set; } = default!;
    }
}
