using System.IO;

namespace ComLibRegUtil.Directories
{
    public class SimpleFile : ISimpleFile
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}