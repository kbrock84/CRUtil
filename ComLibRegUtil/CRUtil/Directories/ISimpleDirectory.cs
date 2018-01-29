using System.Collections.Generic;

namespace ComLibRegUtil.CRutil.Directories
{
    public interface ISimpleDirectory
    {
        IEnumerable<string> EnumerateDirectories();
        void ChangeDirectory(string directoryPath);
    }
}