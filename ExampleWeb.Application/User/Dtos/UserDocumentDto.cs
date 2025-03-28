using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWeb.Application.User.Dtos
{
    /// <summary>
    /// Документ пользователя
    /// </summary>
    public class UserDocumentDto
    {
        /// <summary>
        /// Идентификатор пользователя из БД postgre
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Документы
        /// </summary>
        public string Document { get; set; } = default!;

        /// <summary>
        /// Имя документа
        /// </summary>
        public string Name { get; set; } = default!;
    }
}
