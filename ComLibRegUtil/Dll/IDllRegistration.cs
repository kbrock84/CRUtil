namespace ComLibRegUtil.Dll
{
    internal interface IDllRegistration
    {
        string RegisterDll(string dllPath, string regasmPath, string outputName);
    }
}