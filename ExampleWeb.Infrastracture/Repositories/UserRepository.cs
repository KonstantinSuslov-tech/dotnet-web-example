using ExampleWeb.Application.Repositories;
using ExampleWeb.Domain.Entities;
using ExampleWeb.Infrastracture.Contexts;
using Microsoft.EntityFrameworkCore;


namespace ExampleWeb.Infrastracture.Repositories
{
    /// <inheritdoc />
    public class UserRepository : IUserRepository
    {
        private readonly PostgresContext _postgresContext;

        public UserRepository(PostgresContext postgresContext) 
        {
            _postgresContext = postgresContext;
        }

        /// <inheritdoc />
        public Task<List<User>> GetUsersByIds(int[] ids, CancellationToken cancellationToken)
        => _postgresContext.UserSet
            .Include(i => i.Passport)
            .Include(i => i.Contacts)
            .Where(w => ids.Contains(w.Id))
            .ToListAsync(cancellationToken);
        

        /// <inheritdoc />
        public async Task SaveUsers(User[] users, CancellationToken cancellationToken)
        {
            _postgresContext.UserSet.AddRange(users);
            await _postgresContext.SaveChangesAsync(cancellationToken);
        }   
    }
}
