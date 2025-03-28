using ExampleWeb.Infrastracture.Settings;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWeb.Infrastracture.Contexts
{
    public class RedisContext
    {
        private readonly IDatabase? _database;

        public RedisContext(IOptions<RedisSettings> settings)
        {
            var client = ConnectionMultiplexer.Connect(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase();
            }
        }

        public IDatabase RedisDb
        {
            get
            {
                return _database!;
            }
        }
    }
}
