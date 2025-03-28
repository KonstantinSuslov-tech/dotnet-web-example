using ExampleWeb.Application.Repositories;
using ExampleWeb.Infrastracture.Contexts;
using ExampleWeb.Infrastracture.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ExampleWeb.Infrastracture.Repositories
{
    public class RedisRepository : IRedisRepository
    {
        private readonly RedisContext _context;

        public RedisRepository(IOptions<RedisSettings> settings)
        {
            _context = new RedisContext(settings);
        }

        public async Task SaveDataToRedis(string dataToCash, string key)
        {
            var serialize = JsonConvert.SerializeObject(dataToCash);
            await _context.RedisDb.StringSetAsync(key, serialize, TimeSpan.FromDays(1));
        }

        public async Task<string?> GetDataFromRedis(string key)
        {
            var serialize = await _context.RedisDb.StringGetAsync(key);
            if (serialize.IsNull)
            {
                return null;
            }
            var data = JsonConvert.DeserializeObject<string>(serialize!);
            return data;
        }


    }
}
