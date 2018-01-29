using System.Threading;

namespace ComLibRegUtil.Dll
{
    public interface ISimpleProcess
    {
        bool Start(string exePath, string args);
        void Close();
    }
}