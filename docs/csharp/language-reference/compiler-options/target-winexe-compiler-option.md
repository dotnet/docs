---
title: "-target:winexe (C# Compiler Options)"
ms.date: 07/20/2015
f1_keywords: 
  - "/target:winexe"
helpviewer_keywords: 
  - "/target compiler options [C#], /target:winexe"
  - "-target compiler options [C#], /target:winexe"
  - "target compiler options [C#], /target:winexe"
ms.assetid: b5a0619c-8caa-46a5-a743-1cf68408ad7a
---
# -target:winexe (C# Compiler Options)
The **-target:winexe** option causes the compiler to create an executable (EXE), Windows program.  
  
## Syntax  
  
```console  
-target:winexe  
```  
  
## Remarks  
 The executable file will be created with the .exe extension. A Windows program is one that provides a user interface from either the .NET Framework library or with the Windows APIs.  
  
 Use [-target:exe](./target-exe-compiler-option.md) to create a console application.  
  
 Unless otherwise specified with the [-out](./out-compiler-option.md) option, the output file name takes the name of the input file that contains the [Main](../../programming-guide/main-and-command-args/index.md) method.  
  
 When specified at the command line, all files until the next **-out** or [-target](./target-compiler-option.md) option are used to create the Windows program.  
  
 One and only one **Main** method is required in the source code files that are compiled into an .exe file. The [-main](./main-compiler-option.md) option lets you specify which class contains the **Main** method, in cases where your code has more than one class with a **Main** method.  
  
### To set this compiler option in the Visual Studio development environment  
  
1. Open the project's **Properties** page.  
  
2. Click the **Application** property page.  
  
3. Modify the **Output type** property.  
  
 For information on how to set this compiler option programmatically, see <xref:VSLangProj80.ProjectProperties3.OutputType%2A>.  
  
## Example  
 Compile `in.cs` into a Windows program:  
  
```console  
csc -target:winexe in.cs  
```  
  
## See also

- [-target (C# Compiler Options)](./target-compiler-option.md)
- [C# Compiler Options](./index.md)
