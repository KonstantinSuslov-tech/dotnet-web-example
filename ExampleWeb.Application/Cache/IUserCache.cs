using ExampleWeb.Application.User.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWeb.Application.Cache
{
    /// <summary>
    /// Кэш с пользователями
    /// </summary>
    public interface IUserCache
    {
        /// <summary>
        /// Получение пользователя из кэша
        /// </summary>
        /// <param name="ids">Идентификаторы пользователей</param>
        /// <returns>Данные из кэша или null</returns>
        Task<IReadOnlyCollection<UserDto>?> GetUsersFromCache(int[] ids);

        /// <summary>
        /// Сохранение пользователей в кэш
        /// </summary>
        /// <param name="users">Пользователи</param>
        /// <param name="ids">Идентификаторы пользователей</param>
        /// <returns><see cref="Task"/></returns>
        Task SaveUsersToCache(IReadOnlyCollection<UserDto> users, int[] ids);
    }
}
