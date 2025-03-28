using ExampleWeb.Application.Mappers;
using ExampleWeb.Application.Repositories;
using ExampleWeb.Application.User.Dtos;
using ExampleWeb.Domain.MongoDocuments;
using MediatR;

namespace ExampleWeb.Application.User.SaveUsers
{
    /// <summary>
    /// Хендлер сохранения пользователей
    /// </summary>
    public class SaveUsersHandler : IRequestHandler<SaveUsersCommand, SaveUsersResponse>
    {
        public IUserRepository _repository;

        public SaveUsersHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<SaveUsersResponse> Handle(SaveUsersCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var users = command.Users.Select(u => u.ToSaveUserDomain()).ToArray();
                await _repository.SaveUsers(users, cancellationToken);

                return new SaveUsersResponse { Ids = users.Select(u => u.Id).ToArray() };
            }
            catch (Exception)
            {
                return new SaveUsersResponse();
            }
        }
    }
}

