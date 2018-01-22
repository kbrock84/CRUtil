using System.IO;
using Newtonsoft.Json;

namespace ComLibRegUtil
{
    public static class ConfigJsonWriter
    {
        public static void WriteConfiguration(string fileName, ConfigData configData)
        {
            var configTextJson = JsonConvert.SerializeObject(configData);
            File.WriteAllText(fileName, configTextJson);
        }
    }
}