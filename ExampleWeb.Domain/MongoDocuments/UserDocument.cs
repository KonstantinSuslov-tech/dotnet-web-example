using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExampleWeb.Domain.MongoDocuments
{
    public class UserDocument
    {
        /// <summary>
        /// Идентификатор документа в монго
        /// </summary>

        [BsonId]
        public ObjectId Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя в БД постгре
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Тип юзера
        /// </summary>
        public string Document { get; set; } = default!;
    }
}
