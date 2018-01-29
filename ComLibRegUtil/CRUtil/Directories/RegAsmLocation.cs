
namespace ComLibRegUtil.CRutil.Directories
{
    public class RegAsmLocation : IExecutableLocation
    {
        public string Location { get; set; }

        private const string DotNetDirectoryPath = @"C:\Windows\Microsoft.NET";
        
        private RegAsmLocation(ISimpleDirectory windowsDotNet, IDirectoryLocator locator)
        {
            windowsDotNet.ChangeDirectory(locator.Locate(windowsDotNet.EnumerateDirectories(), "Framework64", "Framework"));
            string dir = locator.Locate(windowsDotNet.EnumerateDirectories(), "v4.0", "v2.0");
            
            Location = $"{dir}\\RegAsm.exe";
        }

        public static RegAsmLocation MakeDefaultRegAsmLocation()
        {
            return new RegAsmLocation(new SimpleDirectory(DotNetDirectoryPath), new DirectoryLocator());
        }

        public static RegAsmLocation MakeRegAsmLocaitonWithDirectory(ISimpleDirectory windowsDotNet,
            IDirectoryLocator locator)
        {
            return new RegAsmLocation(windowsDotNet, locator);
        }

        public override string ToString()
        {
            return Location;
        }
    }
}