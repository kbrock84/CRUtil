
namespace ComLibRegUtil.CRutil.Dll
{
    public interface ISimpleProcess
    {
        bool Start(string exePath, string args);
        void Close();
    }
}