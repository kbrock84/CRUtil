using System;
using System.Collections.Generic;
using System.IO;

namespace ComLibRegUtil
{
    internal class DirectoryLocator
    {
        private string _frameworkDir = string.Empty;
        public string Locate(IEnumerable<DirectoryInfo> inDirs, string primaryDirContains, string secondaryDirContains)
        {
            foreach (var dir in inDirs)
            {
                if (dir.Name.Contains(primaryDirContains))
                {
                    _frameworkDir = dir.FullName;
                    break;
                }
                if (dir.Name.Contains(secondaryDirContains))
                {
                    _frameworkDir = dir.FullName;
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