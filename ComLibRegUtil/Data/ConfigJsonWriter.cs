using System.IO;
using Newtonsoft.Json;

namespace ComLibRegUtil.Data
{
    public static class ConfigJsonWriter
    {
        public static void WriteConfiguration(string fileName, Config config)
        {
            var configTextJson = JsonConvert.SerializeObject(config);
            File.WriteAllText(fileName, configTextJson);
        }
    }
}