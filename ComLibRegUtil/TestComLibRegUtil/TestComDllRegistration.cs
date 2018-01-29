using System.IO;
using ComLibRegUtil.Directories;
using NUnit.Framework;
using ComLibRegUtil.Dll;

namespace TestComLibRegUtil
{
    [TestFixture]
    public class TestComDllRegistration
    {
        class FakeSimpleProcess : ISimpleProcess
        {
            private readonly bool _returnValue;

            public FakeSimpleProcess(bool returnValue)
            {
                _returnValue = returnValue;
            }

            public bool Start(string exePath, string args)
            {
                return _returnValue;
            }

            public void Close()
            {
            }
        }
        
        class FakeSimpleFile : ISimpleFile
        {
            private readonly bool _returnValue;

            public FakeSimpleFile(bool returnValue)
            {
                _returnValue = returnValue;
            }

            public bool Exists(string exePath)
            {
                return _returnValue;
            }

        }

        [Test]
        public void TestRegisterDll_DllAndRegAsmExist_ArgumentsAreFormattedCorrectly()
        {
            FakeSimpleProcess fakeRegAsmExeProcess = new FakeSimpleProcess(true);
            FakeSimpleFile fakeDll = new FakeSimpleFile(true);
            ComDllRegistration comDllRegistration =
                ComDllRegistration.MakeCustomComDllRegistration(fakeRegAsmExeProcess, fakeDll);
            string expectedResult = $@"C:\SomeDirectory\SomeFile.dll /tlb:OutputFileName";
            
            string args = comDllRegistration.RegisterDll(
                @"C:\SomeDirectory\SomeFile.dll",
                @"C:\SomeOtherDirectory\RegAsm.exe",
                @"OutputFileName");
            
            Assert.AreEqual(args, expectedResult);
        }
        
        [Test]
        public void TestRegisterDll_RegAsmDoesNotExist_ThrowsFileNotFoundException()
        {
            FakeSimpleProcess fakeRegAsmExeProcess = new FakeSimpleProcess(false);
            FakeSimpleFile fakeDll = new FakeSimpleFile(true);
            
            ComDllRegistration comDllRegistration =
                ComDllRegistration.MakeCustomComDllRegistration(fakeRegAsmExeProcess, fakeDll);
            
            Assert.Throws<FileNotFoundException>(() => comDllRegistration.RegisterDll(
                @"C:\SomeDirectory\SomeFile.dll",
                @"C:\SomeOtherDirectory\RegAsm.exe",
                @"OutputFileName"));
        }
        
        [Test]
        public void TestRegisterDll_DllDoesNotExist_ThrowsFileNotFoundException()
        {
            FakeSimpleProcess fakeRegAsmExeProcess = new FakeSimpleProcess(true);
            FakeSimpleFile fakeDll = new FakeSimpleFile(false);
            
            ComDllRegistration comDllRegistration =
                ComDllRegistration.MakeCustomComDllRegistration(fakeRegAsmExeProcess, fakeDll);
            
            Assert.Throws<FileNotFoundException>(() => comDllRegistration.RegisterDll(
                @"C:\SomeDirectory\SomeFile.dll",
                @"C:\SomeOtherDirectory\RegAsm.exe",
                @"OutputFileName"));
        }
    }
}