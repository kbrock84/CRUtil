using System.IO;

namespace ComLibRegUtil
{
    public class DllInstaller
    {
        void Install(ConfigData configData, RegAsmLocation regAsmLocation)
        {   
            FileInfo dllOriginFile = new FileInfo(configData.LibraryOrigin);
            FileInfo dllNewFile = dllOriginFile.CopyTo(configData.LibraryDestination, true);

            string fileToReplace = $@"{dllNewFile.Directory.FullName}\{configData.OutputFileName}";
        
            //RegAsm.exe will fail if the file already exists
            if (File.Exists(fileToReplace))
            {
                File.Delete(fileToReplace);
            }
            
            ComDllCreator comDllcreator =  new ComDllCreator();
        
            comDllcreator.CreateComDll(configData.LibraryDestination,
                regAsmLocation.Locate(@"C:\Windows\Microsoft.Net"),
                configData.OutputFileName);
        }
    }
}