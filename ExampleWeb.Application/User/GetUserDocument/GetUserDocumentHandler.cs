using ExampleWeb.Application.Repositories;
using ExampleWeb.Application.User.Dtos;
using MediatR;

namespace ExampleWeb.Application.User.GetUserDocument
{
    /// <summary>
    /// Хендлер для получения документов пользователя
    /// </summary>
    public class GetUserDocumentHandler : IRequestHandler<GetUserDocumentQuery, GetUserDocumentResponse>
    {

        private readonly IUserDocumentRepository _userDocumentRepository;

        public GetUserDocumentHandler(IUserDocumentRepository userDocumentRepository) 
        {
            _userDocumentRepository = userDocumentRepository;
        }

        public async Task<GetUserDocumentResponse> Handle(GetUserDocumentQuery request, CancellationToken cancellationToken)
        {
            var userDoc = await _userDocumentRepository.GetUserDocumentsById(request.UserId, cancellationToken);

            return new GetUserDocumentResponse
            {
                Documents = userDoc.Select(x => new UserDocumentDto
                {

                    Document = x.Document,
                    UserId = x.UserId,
                    Name = x.Name

                }).ToArray()
            };
        }
    }
}
