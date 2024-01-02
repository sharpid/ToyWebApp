using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ToyWebApp.Helper;

public static class ToJsonStringHelper
{
    public static string ToJsonString<T>(this T obj)  where T : class
    {
        return JsonConvert.SerializeObject(obj, Formatting.None);
    }
}
