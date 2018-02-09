# CRUtil

<h2>COM Registration Utility library for registering COM visible libraries on Windows.</h2>
<h3>v1.0.0</h3>

This library automatically locates and uses the RegAsm.exe utility and will register a .Net class library, passing the <code>/tlb:</code> command, to generate a COM visible library. 

<h3>This is a personal utility that is subject to API breaking changes. Semantic versioning is used.</h3>

Example Usage:


```C#

public static void Main(string[] args)
{
    Config config = ConfigJsonReader.ReadConfiguration(@".\config.json");

    RegAsmLocation regAsmLocation = RegAsmLocation.MakeDefaultRegAsmLocation();

    DllInstaller installer = new DllInstaller();
    installer.Install(config, regAsmLocation);
}

```

See the <a href="https://github.com/kbrock84/CRUtil/blob/master/ComLibRegUtil/ComRegistrationApp/configFileExample.json">Json Config File Example</a> to manually write your configuration or save your configuration in Json format using <code>ConfigJsonWriter</code>:

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
        }
    }
}
```

<h2>License</h2>
<h4>This project is licensed under the terms of the MIT license.</h4>


