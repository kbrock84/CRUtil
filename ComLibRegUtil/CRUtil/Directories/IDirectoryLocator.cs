using System.Collections.Generic;

namespace ComLibRegUtil.CRutil.Directories
{
    public interface IDirectoryLocator
    {
        string Locate(IEnumerable<string> inDirs, string primaryDirContains, string secondaryDirContains);
    }
}