using System.Collections.Generic;

namespace ComLibRegUtil.Directories
{
    public interface ISimpleDirectory
    {
        IEnumerable<string> EnumerateDirectories();
        void ChangeDirectory(string directoryPath);
    }
}