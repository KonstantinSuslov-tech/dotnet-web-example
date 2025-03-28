using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWeb.Application.User.Dtos
{
    /// <summary>
    /// Контакт
    /// </summary>
    public  class ContactDto
    {
        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; } = default!;

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; } = default!;

    }
}
