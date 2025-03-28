using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWeb.Application.User.SaveUserDocument
{
    /// <summary>
    /// Ответ сохранения документов пользователя
    /// </summary>
    public class SaveUserDocumentResponse
    {
        /// <summary>
        /// Успешно ли сохранены пользователи
        /// </summary>
        public bool IsSucccess { get; set; }
    }
}
