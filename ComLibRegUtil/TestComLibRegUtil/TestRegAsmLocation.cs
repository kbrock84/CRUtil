using System.Collections.Generic;
using ComLibRegUtil.Directories;
using NUnit.Framework;

namespace TestComLibRegUtil
{
    [TestFixture]
    public class TestRegAsmLocation
    {
        class FakeDirectoryLocator : IDirectoryLocator
        {
            public string Locate(IEnumerable<string> inDirs, string primaryDirContains, string secondaryDirContains)
            {
                return @"C:\Windows\Microsoft.Net\Framework64\v4.0.30319";
            }
        }

        class FakeSimpleDirectory : ISimpleDirectory
        {
            public IEnumerable<string> EnumerateDirectories()
            {
                return new string[]
                {
                    @"C:\Windows\Microsoft.Net\Framework64\v2.0.50727",
                    @"C:\Windows\Microsoft.Net\Framework64\v3.0",
                    @"C:\Windows\Microsoft.Net\Framework64\v3.5",
                    @"C:\Windows\Microsoft.Net\Framework64\v4.0.30319"
                };
            }

            public void ChangeDirectory(string directoryPath)
            {
            }
        }

        [Test]
        public void TestLocate_RegAsmFound_ReturnsPathAsString()
        {
            FakeDirectoryLocator fakeDirLocator = new FakeDirectoryLocator();
            FakeSimpleDirectory fakeSimpleDirectory = new FakeSimpleDirectory();
            
            RegAsmLocation regAsmLocation = RegAsmLocation.MakeRegAsmLocaitonWithDirectory(
                fakeSimpleDirectory, fakeDirLocator);
            
            Assert.IsTrue(
                @"C:\Windows\Microsoft.Net\Framework64\v4.0.30319\RegAsm.exe" == regAsmLocation.ToString());
        }
    }
}