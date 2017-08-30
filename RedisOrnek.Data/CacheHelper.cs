using Newtonsoft.Json;
using System.Text;

namespace RedisOrnek.Data
{
    public class CacheHelper
    {
        protected virtual byte[] Serialize(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);
            return Encoding.UTF8.GetBytes(jsonString);
        }

        protected virtual T Deserialize<T>(string[] serializedObject)
        {
            if (serializedObject == null)
                return default(T);

            string returnString = "[" + string.Join(",", serializedObject) + "]";

            return JsonConvert.DeserializeObject<T>(returnString);
        }
    }
}