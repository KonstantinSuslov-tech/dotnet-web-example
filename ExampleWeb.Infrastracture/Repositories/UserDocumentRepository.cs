using ExampleWeb.Application.Repositories;
using ExampleWeb.Domain.MongoDocuments;
using ExampleWeb.Infrastracture.Constants;
using ExampleWeb.Infrastracture.Contexts;
using ExampleWeb.Infrastracture.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Globalization;

namespace ExampleWeb.Infrastracture.Repositories
{
    /// <inheritdoc />
    public class UserDocumentRepository : IUserDocumentRepository
    {
        private readonly MongoContex _context;

        public UserDocumentRepository(IOptions<MongoSettings> settings) 
        {
            _context = new MongoContex(settings);
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<UserDocument>> GetUserDocumentsById(int userId, CancellationToken cancellationToken)
        {
            var filter = Builders<UserDocument>.Filter.Eq(MongoConstants.userId, userId);
            var userDocuments = await this._context.UserDocuments.Find(filter).ToListAsync(cancellationToken);

            return userDocuments;
        }

        /// <inheritdoc />
        public async Task<bool> MakeRecord(IReadOnlyCollection<UserDocument> document, CancellationToken cancellationToken)
        {
            try
            {
                await _context.UserDocuments.InsertManyAsync(document, null, cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
