using ExampleWeb.Application.Repositories;
using ExampleWeb.Application.User.Dtos;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExampleWeb.Application.Cache
{
    public class UserCache : IUserCache
    {
        private readonly IRedisRepository _cache;

        public UserCache(IRedisRepository cache)
        {
            _cache = cache;
        }

        public async Task<IReadOnlyCollection<UserDto>?> GetUsersFromCache(int[] ids)
        {
            var data = await _cache.GetDataFromRedis(string.Join(", ", ids));

            if (data == null)
                return null;

            return JsonSerializer.Deserialize<IReadOnlyCollection<UserDto>>(data);
        }

        public async Task SaveUsersToCache(IReadOnlyCollection<UserDto> users, int[] ids)
        {
            var jsonString = JsonSerializer.Serialize(users);

            await _cache.SaveDataToRedis(jsonString, string.Join(", ", ids));
        }
    }
}
