using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ComLibRegUtil
{
    public class RegAsmLocation
    {
        public string Location { get; set; }
        
        public string Locate(string dotNetDirectory)
        {
            DirectoryInfo windowsDirectoryInfo = new DirectoryInfo(@dotNetDirectory);
            DirectoryInfo[] dotNetDirs = windowsDirectoryInfo.GetDirectories();
            
            DirectoryLocator dirLocator = new DirectoryLocator();
            DirectoryInfo frameworkDir = new DirectoryInfo(dirLocator.Locate(dotNetDirs, "Framework64", "Framework"));
            DirectoryInfo[] frameworkVersionDirs = frameworkDir.GetDirectories();
            
            string frameworkVersionDir = dirLocator.Locate(frameworkVersionDirs, "v4.0", "v2.0");
            
            Location = $"{frameworkVersionDir}\\regasm.exe";
            return Location;
        }

        public override string ToString()
        {
            return Location;
        }
    }
}