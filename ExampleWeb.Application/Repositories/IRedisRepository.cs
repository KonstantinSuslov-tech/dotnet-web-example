using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWeb.Application.Repositories
{
    public interface IRedisRepository
    {
        /// <summary>
        /// Сохранить данные в кэш
        /// </summary>
        /// <param name="dataToCash">Данные для кэша</param>
        /// <param name="key">Ключ</param>
        /// <returns><see cref="Task"/></returns>
        Task SaveDataToRedis(string dataToCash, string key);

        /// <summary>
        /// Получить данные из кэша
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>Данные</returns>
        Task<string?> GetDataFromRedis(string key);
    }
}
