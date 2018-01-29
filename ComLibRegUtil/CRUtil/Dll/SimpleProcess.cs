using System.Diagnostics;

namespace ComLibRegUtil.CRutil.Dll
{
    internal class SimpleProcess : ISimpleProcess
    {
        private Process _process;
        
        public bool Start(string exePath, string args)
        {
            _process = Process.Start(new ProcessStartInfo(exePath, args));
            return _process != null;
        }

        public void Close()
        {
            _process?.Close();
        }
    }
}