using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWeb.Application.User.SaveUsers
{
    /// <summary>
    /// Ответ сохранения пользователей
    /// </summary>
    public class SaveUsersResponse
    {
        /// <summary>
        /// Идентификаторы пользователей
        /// </summary>
        public int[] Ids { get; set; } = default!;
    }
}
