using ExampleWeb.Domain.MongoDocuments;
namespace ExampleWeb.Application.Repositories
{
    /// <summary>
    /// Репозиторий для получения документов пользователя
    /// </summary>
    public interface IUserDocumentRepository
    {
        /// <summary>
        /// Получение документов пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>Список документов пользователя</returns>
        Task<IReadOnlyCollection<UserDocument>> GetUserDocumentsById(int userId , CancellationToken cancellationToken);

        /// <summary>
        /// Сохранение документов пользователя
        /// </summary>
        /// <param name="document">Документы</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>Удалось ли сохранить документы</returns>
        Task<bool> MakeRecord(IReadOnlyCollection<UserDocument> document, CancellationToken cancellationToken);
    }
}
