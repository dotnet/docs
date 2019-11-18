---
title: "-target (C# Compiler Options)"
ms.date: 07/20/2015
f1_keywords: 
  - "/target"
helpviewer_keywords: 
  - "target compiler options [C#]"
  - "/target compiler options [C#]"
  - "assemblies [C#], compiling"
  - "-target compiler options [C#]"
ms.assetid: a18bbd8e-bbf7-49e7-992c-717d0eb1f76f
---
# -target (C# Compiler Options)
The **-target** compiler option can be specified in one of four forms:  
  
 [-target:appcontainerexe](./target-appcontainerexe-compiler-option.md)  
 To create an .exe file for Windows 8.x Store apps.  
  
 [-target:exe](./target-exe-compiler-option.md)  
 To create an .exe file.  
  
 [-target:library](./target-library-compiler-option.md)  
 To create a code library.  
  
 [-target:module](./target-module-compiler-option.md)  
 To create a module.  
  
 [-target:winexe](./target-winexe-compiler-option.md)  
 To create a Windows program.  
  
 [-target:winmdobj](./target-winmdobj-compiler-option.md)  
 To create an intermediate .winmdobj file.  
  
 Unless you specify **-target:module**, **-target** causes a .NET Framework assembly manifest to be placed in an output file. For more information, see [Assemblies in .NET](../../../standard/assembly/index.md) and [Common Attributes](../../programming-guide/concepts/attributes/common-attributes.md).  
  
 The assembly manifest is placed in the first .exe output file in the compilation or in the first DLL, if there is no .exe output file. For example, in the following command line, the manifest will be placed in `1.exe`:  
  
```console  
csc -out:1.exe t1.cs -out:2.netmodule t2.cs  
```  
  
 The compiler creates only one assembly manifest per compilation. Information about all files in a compilation is placed in the assembly manifest. All output files except those created with **-target:module** can contain an assembly manifest. When producing multiple output files at the command line, only one assembly manifest can be created and it must go into the first output file specified on the command line. No matter what the first output file is (**-target:exe**, **-target:winexe**, **-target:library** or **-target:module**), any other output files produced in the same compilation must be modules (**-target:module**).  
  
 If you create an assembly, you can indicate that all or part of your code is CLS compliant with the <xref:System.CLSCompliantAttribute> attribute.  
  
```csharp  
// target_clscompliant.cs  
[assembly:System.CLSCompliant(true)]   // specify assembly compliance  
  
[System.CLSCompliant(false)]   // specify compliance for an element  
public class TestClass  
{  
    public static void Main() {}  
}  
```  
  
 For more information about setting this compiler option programmatically, see <xref:VSLangProj80.ProjectProperties3.OutputType%2A>.  
  
## See also

- [C# Compiler Options](./index.md)
- [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
- [-subsystemversion (C# Compiler Options)](./subsystemversion-compiler-option.md)
