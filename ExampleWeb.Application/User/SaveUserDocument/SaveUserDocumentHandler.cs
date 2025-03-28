using ExampleWeb.Application.Mappers;
using ExampleWeb.Application.Repositories;
using ExampleWeb.Application.User.SaveUsers;
using ExampleWeb.Domain.MongoDocuments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWeb.Application.User.SaveUserDocument
{
    /// <summary>
    /// Хендлер сохранения пользователей
    /// </summary>
    public class SaveUserDocumentHandler : IRequestHandler<SaveUserDocumentCommand, SaveUserDocumentResponse>
    {
        private readonly IUserDocumentRepository _repository;

        public SaveUserDocumentHandler(IUserDocumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<SaveUserDocumentResponse> Handle(SaveUserDocumentCommand command, CancellationToken cancellationToken)
        {
            var isSuccess = await _repository.MakeRecord(command.Documents.Select(s =>
            new UserDocument 
            { 
                UserId = s.UserId,
                Name = s.Name,
                Document = s.Document
            }).ToArray(), cancellationToken);

            return new SaveUserDocumentResponse { IsSucccess = isSuccess };
        }
    }
    
}
