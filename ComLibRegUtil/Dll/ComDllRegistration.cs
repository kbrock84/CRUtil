using System.IO;
using ComLibRegUtil.Directories;

namespace ComLibRegUtil.Dll
{
    public class ComDllRegistration : IDllRegistration
    {
        private readonly ISimpleProcess _regAsmProcess;
        private readonly ISimpleFile _file;

        private ComDllRegistration()
        {
            _regAsmProcess = new SimpleProcess();
            _file = new SimpleFile();
        }

        private ComDllRegistration(ISimpleProcess regAsmProcess, ISimpleFile file)
        {
            _regAsmProcess = regAsmProcess;
            _file = file;
        }

        public static ComDllRegistration MakeDefaultComDllRegistration()
        {
            return new ComDllRegistration();
        }

        public static ComDllRegistration MakeCustomComDllRegistration(ISimpleProcess regAsmProcess, ISimpleFile fileClass)
        {
            return new ComDllRegistration(regAsmProcess, fileClass);
        }

        public string RegisterDll(string dllPath, string regasmPath, string outputName)
        {
            var regArgs = $@"{dllPath} /tlb:{outputName}";

            bool isStarted = _regAsmProcess.Start(regasmPath, regArgs);
            if (!isStarted)
            {
                throw new FileNotFoundException("Could not find RegAsm.exe");
            }
            if (!_file.Exists(dllPath))
            {
                throw new FileNotFoundException("Could not find the specified dll");
            }
            _regAsmProcess.Close();
            return regArgs;
        }
    }
}