namespace ExampleWeb.Application.Repositories
{
    /// <summary>
    /// Репозиторий для пользователя
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Получение пользователей по идентификаторам
        /// </summary>
        /// <param name="id">Идентификаторы</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>Данные пользователей</returns>
        Task<List<Domain.Entities.User>> GetUsersByIds(int[] ids, CancellationToken cancellationToken);

        /// <summary>
        /// Сохранение пользователей
        /// </summary>
        /// <param name="users">Пользователи</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>Пользователи</returns>
        Task SaveUsers(Domain.Entities.User[] users, CancellationToken cancellationToken);
    }
}
