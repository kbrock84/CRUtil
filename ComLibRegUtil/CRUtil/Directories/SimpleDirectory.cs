using System.Collections.Generic;
using System.IO;

namespace ComLibRegUtil.CRutil.Directories
{
    public class SimpleDirectory : ISimpleDirectory
    {
        private string _directoryPath;

        public SimpleDirectory(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public void ChangeDirectory(string directoryPath)
        {
            _directoryPath = directoryPath;
        }
        
        public IEnumerable<string> EnumerateDirectories()
        {
            return Directory.EnumerateDirectories(_directoryPath);
        }
    }
}