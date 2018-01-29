using System;
using System.Collections.Generic;

namespace ComLibRegUtil.CRutil.Directories
{
    public class DirectoryLocator : IDirectoryLocator
    {
        private string _frameworkDir = string.Empty;
        public string Locate(IEnumerable<string> inDirs, string primaryDirContains, string secondaryDirContains)
        {
            foreach (var name in inDirs)
            {
                if (name.Contains(primaryDirContains))
                {
                    _frameworkDir = name;
                    break;
                }
                if (name.Contains(secondaryDirContains))
                {
                    _frameworkDir = name;
                }
            }
            if (_frameworkDir == string.Empty)
            {
                throw new ArgumentException($"Cannot find the {primaryDirContains} or {secondaryDirContains} directory");
            }

            return _frameworkDir;
        }
    }
}