using System.IO;
using Newtonsoft.Json;

namespace ComLibRegUtil.Data
{
    public static class ConfigJsonReader
    {
        public static Config ReadConfiguration(string fileName)
        {
            return JsonConvert.DeserializeObject<Config>(File.ReadAllText(fileName));
        }
    }
}