using System.IO;
using ComLibRegUtil.Data;
using ComLibRegUtil.Directories;

namespace ComLibRegUtil.Dll
{
    public class DllInstaller
    {
        public void Install(Config config, RegAsmLocation regAsmLocation)
        {   
            FileInfo dllOriginFile = new FileInfo(config.LibraryOrigin);
            FileInfo dllNewFile = dllOriginFile.CopyTo(config.LibraryDestination, true);

            string fileToReplace = $@"{dllNewFile.Directory.FullName}\{config.OutputFileName}";
        
            //RegAsm.exe will fail if the file already exists
            if (File.Exists(fileToReplace))
            {
                File.Delete(fileToReplace);
            }
            
            ComDllRegistration comDllRegistration =  ComDllRegistration.MakeDefaultComDllRegistration();
        
            comDllRegistration.RegisterDll(config.LibraryDestination,
                regAsmLocation.Location,
                config.OutputFileName);
        }
    }
}