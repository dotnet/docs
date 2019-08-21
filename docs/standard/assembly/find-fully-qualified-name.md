---
title: "How to: Determine an assembly's fully qualified name"
ms.date: "08/20/2019"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "names [.NET Framework], fully qualified type names"
  - "names [.NET Framework], assemblies"
  - "assemblies [.NET Framework], names"
ms.assetid: 009dae23-e1f6-4a64-9a9a-32e4c34802b0
author: "rpetrusha"
ms.author: "ronpet"
---
# How to: Determine an assembly's fully qualified name
To discover the fully qualified name of an assembly in the global assembly cache, use the Global Assembly Cache tool ([Gacutil.exe](../../framework/tools/gacutil-exe-gac-tool.md)). See [How to: View the contents of the global assembly cache](../../framework/app-domains/how-to-view-the-contents-of-the-gac.md).  
  
 For assemblies that are not in the global assembly cache, you can get the fully qualified assembly name in a number of ways: can use code to output the information to the console or to a variable, or you can use the [Ildasm.exe (IL Disassembler)](../../framework/tools/ildasm-exe-il-disassembler.md) to examine the assembly's metadata, which contains the fully qualified name.  
  
- If the assembly is already loaded by the application, you can retrieve the value of the <xref:System.Reflection.Assembly.FullName%2A?displayProperty=nameWithType> property to get the fully qualified name. You can use this approach whether or not the assembly is in the global assembly cache. The example provides an illustration.  
  
- If you know the assembly's file system path, you can call the `static` (C#) or `Shared` (Visual Basic) <xref:System.Reflection.AssemblyName.GetAssemblyName%2A?displayProperty=nameWithType> method to get the fully qualified assembly name. The following is a simple example.  
  
  # [C#](#tab/csharp)
  ```csharp
  using System;
  using System.Reflection;
  
  public class Example
  {
     public static void Main()
     {
        Console.WriteLine(AssemblyName.GetAssemblyName(@".\UtilityLibrary.dll"));
     }
  }
  // The example displays output like the following:
  //   UtilityLibrary, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
  ```
  # [Visual Basic](#tab/vb)
  ```vb
  Imports System.Reflection
  
  Public Module Example
     Public Sub Main
        Console.WriteLine(AssemblyName.GetAssemblyName(".\UtilityLibrary.dll"))
     End Sub
  End Module
  ' The example displays output like the following:
  '   UtilityLibrary, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
  ```
  ---
  
- You can use the [Ildasm.exe (IL Disassembler)](../../framework/tools/ildasm-exe-il-disassembler.md) to examine the assembly's metadata, which contains the fully qualified name.  
  
For more information about setting assembly attributes such as version, culture, and assembly name, see [Set assembly attributes](set-attributes.md). For more information about giving an assembly a strong name, see [Create and use strong-named assemblies](create-use-strong-named.md).  
  
## Example  
The following code example shows how to display the fully qualified name of an assembly containing a specified class to the console. Because it retrieves the name of an assembly that the app has already loaded, it doesn't matter whether the assembly is in the global assembly cache.  

# [C++](#tab/cpp)
```cpp
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Reflection;

ref class asmname
{
public:
    static void Main()
    {
        Type^ t = System::Data::DataSet::typeid;
        String^ s = t->Assembly->FullName->ToString();
        Console::WriteLine("The fully qualified assembly name " +
            "containing the specified class is {0}.", s);
    }
};

int main()
{
    asmname::Main();
}
```
# [C#](#tab/csharp)
```csharp
using System;
using System.Reflection;

class asmname
{
    public static void Main()
    {
        Type t = typeof(System.Data.DataSet);
        string s = t.Assembly.FullName.ToString();
        Console.WriteLine("The fully qualified assembly name " +
            "containing the specified class is {0}.", s);
    }
}
```
# [Visual Basic](#tab/vb)
```vb
Imports System
Imports System.Reflection

Class asmname
    Public Shared Sub Main()
        Dim t As Type = GetType(System.Data.DataSet)
        Dim s As String = t.Assembly.FullName.ToString()
        Console.WriteLine("The fully qualified assembly name " +
            "containing the specified class is {0}.", s)
    End Sub
End Class
```
---
## See also

- [Assembly names](names.md)
- [Create assemblies](create.md)
- [Create and use strong-named assemblies](create-use-strong-named.md)
- [Global assembly cache](../../framework/app-domains/gac.md)
- [How the runtime locates assemblies](../../framework/deployment/how-the-runtime-locates-assemblies.md)
- [Program with assemblies](program.md)
