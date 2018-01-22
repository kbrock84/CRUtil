using System.IO;
using Newtonsoft.Json;

namespace ComLibRegUtil
{
    public static class ConfigJsonReader
    {
        public static ConfigData ReadConfiguration(string fileName)
        {
            return JsonConvert.DeserializeObject<ConfigData>(File.ReadAllText(fileName));
        }
    }
}