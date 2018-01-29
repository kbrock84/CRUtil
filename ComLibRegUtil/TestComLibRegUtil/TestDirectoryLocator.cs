
using System;
using ComLibRegUtil.CRutil.Directories;
using NUnit.Framework;


namespace TestComLibRegUtil
{
    [TestFixture]
    public class TestDirectoryLocator
    {
        [Test]
        public void TestLocate_PrimaryDirectoryAvailable_ReturnsPrimaryDirectory()
        {
            string[] fakeDirectories =
            {
                @"C:\Windows\Microsoft.Net\Framework64",
                @"C:\Windows\Microsoft.Net\Framework",
                @"C:\Windows\Microsoft.Net\assembly",
                @"C:\Windows\Microsoft.Net\authman"
            };
            
            DirectoryLocator locator = new DirectoryLocator();
            string dir = locator.Locate(fakeDirectories, "Framework64", "Framework");
            
            Assert.IsTrue(dir == @"C:\Windows\Microsoft.Net\Framework64");
        }
        
        [Test]
        public void TestLocate_PrimaryDirectoryNotAvailable_ReturnsSecondaryDirectory()
        {
            string[] fakeDirectories =
            {
                @"C:\Windows\Microsoft.Net\Framework",
                @"C:\Windows\Microsoft.Net\assembly",
                @"C:\Windows\Microsoft.Net\authman"
            };

            DirectoryLocator locator = new DirectoryLocator();
            string dir = locator.Locate(fakeDirectories, "Framework64", "Framework");
            
            Assert.IsTrue(dir == @"C:\Windows\Microsoft.Net\Framework");
        }

        [Test]
        public void TestLocate_DirectoriesNotAvailable_ThrowsFileNotFoundException()
        {
            string[] fakeDirectories =
            {
                @"C:\Windows\addins",
                @"C:\Windows\Boot",
                @"C:\Windows\containers"
            };

            DirectoryLocator locator = new DirectoryLocator();
            
            Assert.Throws<ArgumentException>(() => locator.Locate(fakeDirectories, "Framework64", "Framework"));
        }
    }
}