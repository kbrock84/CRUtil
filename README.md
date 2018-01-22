# CRUtil

<h3>v0.1.0</h3>

COM Registration Utility library for registering COM visible libraries on Windows.
This library automatically locates and uses the RegAsm.exe utility and will register a .Net class library, passing the <code>/tlb:</code> command, to generate a COM visible library. 

<h3>This is a personal utility that is subject to refactoring but open to all</h3>

Be sure to decorate your class library with the proper <code>ComVisible(true)</code> attributes:

```C#
namespace RiderLibraryTest
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class Class1
    {
        public Excel.Workbook ExcelWorkbook; 
       
        public Class1()
        {
        }
        
        [ComVisible(true)]
        public void Init(Excel.Workbook workbook)
        {
            ExcelWorkbook = workbook;
        }

        ~Class1()
        {
            Marshal.ReleaseComObject(ExcelWorkbook);
            ExcelWorkbook = null;
            MessageBox.Show("Cleanup Success");
        }
    }
}
```

You may save your configuration in Json format using <code>ConfigJsonWriter</code>:

```C#

  ConfigData configData = new ConfigData(
            libraryOrigin: @"C:\Users\PC\MyLibrary.dll",
            libraryDestination: @"C:\Windows\SysWOW64\MyLibrary.dll",
            outputFileName: @"MyLibraryForComVisibility.dll");

  ConfigJsonWriter.WriteConfiguration("installconfig.json", configData);

```

You may also read in the <code>ConfigData</code> object form your created Json file using the <code>ConfigJsonReader</code>.

```C#
  
  ConfigData configData = ConfigJsonReader.ReadConfiguration("installconfig.json");
  
```
Locate the RegAsm.exe utility using the <code>RegAsmLocation</code> object, then use the <code>ComDllCreator</code> to register your COM visible library. pass the Microsoft.Net folder to <code>RegAsmLocation.Locate(string dotNetDirs)</code>:

```C#

  RegAsmLocation regAsmLocation = new RegAsmLocation();
  string regAsmExe = regAsmLocation.Locate(@"C:\Windows\Microsoft.Net");
  
  ComDllCreator dllCreator = new ComDllCreator();
  dllCreator.CreateComDll(configData.LibraryDestination, regAsmExe, configData.OutputFileName);

```

You may also manually create the RegAsm.exe location by manually assigning the <code>RegAsmLocation.Location</code> property.
