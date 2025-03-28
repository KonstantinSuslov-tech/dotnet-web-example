using ExampleWeb.Application.Cache;
using ExampleWeb.Application.Exceptions;
using ExampleWeb.Application.Mappers;
using ExampleWeb.Application.Repositories;
using MediatR;


namespace ExampleWeb.Application.User.GetUsers
{
    /// <summary>
    /// Хендлер на получение данных по пользователю 
    /// </summary>
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, GetUsersResponse>
    {
        public IUserRepository _repository;
        public IUserCache _cache;

        public GetUsersHandler(IUserRepository repository, IUserCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<GetUsersResponse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var usersFromCache = await _cache.GetUsersFromCache(request.Ids);

            if (usersFromCache != null)
            {
                return new GetUsersResponse() { Users = usersFromCache.ToArray() };
            }

            var users = new List<Domain.Entities.User>();

            try
            {
                users = await _repository.GetUsersByIds(request.Ids, cancellationToken);
            }
            catch (InvalidOperationException ex)
            {
                throw new NotFoundExceptions($"По данному индетификатору {request.Ids} не найден пользователь", ex);
            }

            var userDto = users.Select(s => s.UserMap()).ToArray();

            await _cache.SaveUsersToCache(userDto, request.Ids);

            return new GetUsersResponse() 
            { 
                Users = users.Select(s => s.UserMap()).ToArray() 
            };
        }
    }
}
