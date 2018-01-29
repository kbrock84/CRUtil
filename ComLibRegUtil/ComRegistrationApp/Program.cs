using ComLibRegUtil.CRutil.Data;
using ComLibRegUtil.CRutil.Directories;
using ComLibRegUtil.CRutil.Dll;

namespace ComRegistrationApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Config config = new Config(
                libraryOrigin: @"C:\Users\PC\RiderProjects\RiderLibraryTest\RiderLibraryTest\bin\Debug\RiderLibraryTest.dll",
                libraryDestination: @"C:\Windows\SysWOW64\RiderLibraryTest.dll",
                outputFileName: "RiderTest.dll");
            
            RegAsmLocation regAsmLocation = RegAsmLocation.MakeDefaultRegAsmLocation();
            
            DllInstaller installer = new DllInstaller();
            installer.Install(config, regAsmLocation);
        }
    }
}