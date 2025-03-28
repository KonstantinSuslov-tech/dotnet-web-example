using ExampleWeb.Application.User.Dtos;
using ExampleWeb.Application.User.SaveUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWeb.Application.User.SaveUserDocument
{
    /// <summary>
    /// Команда сохранения документов пользователя
    /// </summary>
    public class SaveUserDocumentCommand : IRequest<SaveUserDocumentResponse>
    {
        /// <summary>
        /// Документы пользователя
        /// </summary>
        public IReadOnlyCollection<UserDocumentDto> Documents { get; set; } = default!;
    }
}
