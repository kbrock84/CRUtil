using System.IO;

namespace ComLibRegUtil.CRutil.Directories
{
    public class SimpleFile : ISimpleFile
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}