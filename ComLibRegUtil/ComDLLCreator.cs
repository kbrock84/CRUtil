using System.Diagnostics;
using System.IO;

namespace ComLibRegUtil
{
    public class ComDllCreator
    {
        public void CreateComDll(string dllPath, string regasmPath, string outputName)
        {
            var regasmExe = new Process();
            var regArgs = $@"{dllPath} /tlb:{outputName}";

            var regasm = Process.Start(new ProcessStartInfo(regasmPath, regArgs));
            if (regasm == null)
            {
                throw new FileNotFoundException("Could not find RegAsm.exe");
            }
            if (!File.Exists(dllPath))
            {
                throw new FileNotFoundException("Could not find the specified dll");
            }
            regasm.Close();
        }
    }
}