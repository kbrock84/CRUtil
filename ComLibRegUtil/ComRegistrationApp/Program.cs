using ComLibRegUtil.CRutil.Data;
using ComLibRegUtil.CRutil.Directories;
using ComLibRegUtil.CRutil.Dll;

namespace ComRegistrationApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Config config = ConfigJsonReader.ReadConfiguration(@".\config.json");

            RegAsmLocation regAsmLocation = RegAsmLocation.MakeDefaultRegAsmLocation();
            
            DllInstaller installer = new DllInstaller();
            installer.Install(config, regAsmLocation);
        }
    }
}