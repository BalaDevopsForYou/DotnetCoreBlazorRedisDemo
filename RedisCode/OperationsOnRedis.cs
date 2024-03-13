using StackExchange.Redis;
using Microsoft.Extensions.Configuration;
namespace RedisDemo.RedisCode
{
    public class OperationsOnRedis
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public OperationsOnRedis(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<string> GetValueAsync(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            return await db.StringGetAsync(key);
        }

        public async Task SetValueAsync(string key, string value)
        {
            var db = _connectionMultiplexer.GetDatabase();
            await db.StringSetAsync(key, value);
        }
    }
}
