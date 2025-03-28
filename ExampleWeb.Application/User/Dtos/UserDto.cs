using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWeb.Application.User.Dtos
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; } = default!;

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName { get; set; } = default!;

        /// <summary>
        /// Список контактов пользователя
        /// </summary>
        public ContactDto[] Contacts { get; set; } = default!;

        /// <summary>
        /// Паспорт пользователя
        /// </summary>
        public PassportInfoDto PassportInfo { get; set; } = default!;
    }
}
