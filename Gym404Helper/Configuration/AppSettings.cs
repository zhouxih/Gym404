using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Gym404Helper.Configuration
{
    public class AppSettings
    {
        public static IConfiguration _configuration;
        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string GetValue(params string[] keys) 
        {
            var key = GetKey(keys);
            var value = _configuration[key] ?? throw new Exception($"未能通过 key:{key} 找到配置! ");
            return value;
        }


        public static T GetValue<T>(params string[] keys)
        {
            var key = GetKey(keys);
            var stringValue = _configuration[key] ?? throw new Exception($"未能通过 key:{key} 找到配置! ");
            var value = JsonConvert.DeserializeObject<T>(stringValue);
            return value;
        }


        private static string GetKey(params string[] keys) 
        {
            if (keys == null || keys.Length == 0)
            {
                throw new ArgumentNullException(" key 为 null ! ");
            }
            var key = string.Join(":", keys);
            return key;
        }

    }
}
