---
title: "-target (Visual Basic)"
ms.date: 03/13/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "target compiler options [Visual Basic]"
  - "-target compiler options [Visual Basic]"
  - "/target compiler options [Visual Basic]"
ms.assetid: e0954147-548b-461f-9c4b-a8f88845616c
author: rpetrusha
ms.author: ronpet
---
# -target (Visual Basic)
Specifies the format of compiler output.  
  
## Syntax  
  
```  
-target:{exe | library | module | winexe | appcontainerexe | winmdobj}  
```  
  
## Remarks  
 The following table summarizes the effect of the `-target` option.  
  
|**Option**|**Behavior**|  
|----------------|------------------|  
|`-target:exe`|Causes the compiler to create an executable console application.<br /><br /> This is the default option when no `-target` option is specified. The executable file is created with an .exe extension.<br /><br /> Unless otherwise specified with the `/out` option, the output file name takes the name of the input file that contains the `Sub Main` procedure.<br /><br /> Only one `Sub Main` procedure is required in the source-code files that are compiled into an .exe file. Use the `-main` compiler option to specify which class contains the `Sub Main` procedure.|  
|`-target:library`|Causes the compiler to create a dynamic-link library (DLL).<br /><br /> The dynamic-link library file is created with a .dll extension.<br /><br /> Unless otherwise specified with the `-out` option, the output file name takes the name of the first input file.<br /><br /> When building a DLL, a `Sub Main` procedure is not required.|  
|`-target:module`|Causes the compiler to generate a module that can be added to an assembly.<br /><br /> The output file is created with an extension of .netmodule.<br /><br /> The .NET common language runtime cannot load a file that does not have an assembly. However, you can incorporate such a file into the assembly manifest of an assembly by using `-reference`.<br /><br /> When code in one module references internal types in another module, both modules must be incorporated into an assembly manifest by using `-reference`.<br /><br /> The [-addmodule](../../../visual-basic/reference/command-line-compiler/addmodule.md) option imports metadata from a module.|  
|`-target:winexe`|Causes the compiler to create an executable Windows-based application.<br /><br /> The executable file is created with an .exe extension. A Windows-based application is one that provides a user interface from either the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] class library or with the Win32 APIs.<br /><br /> Unless otherwise specified with the `-out` option, the output file name takes the name of the input file that contains the `Sub Main` procedure.<br /><br /> Only one `Sub Main` procedure is required in the source-code files that are compiled into an .exe file. In cases where your code has more than one class that has a `Sub Main` procedure, use the `-main` compiler option to specify which class contains the `Sub Main` procedure|  
|`-target:appcontainerexe`|Causes the compiler to create an executable Windows-based application that must be run in an app container. This setting is designed to be used for [!INCLUDE[win8_appname_long](~/includes/win8-appname-long-md.md)] applications.<br /><br /> The **appcontainerexe** setting sets a bit in the Characteristics field of the [Portable Executable](http://go.microsoft.com/fwlink/p/?LinkId=236960) file. This bit indicates that the app must be run in an app container. When this bit is set, an error occurs if the `CreateProcess` method tries to launch the application outside of an app container. Aside from this bit setting, **-target:appcontainerexe** is equivalent to **-target:winexe**.<br /><br /> The executable file is created with an .exe extension.<br /><br /> Unless you specify otherwise by using the `-out` option, the output file name takes the name of the input file that contains the `Sub Main` procedure.<br /><br /> Only one `Sub Main` procedure is required in the source-code files that are compiled into an .exe file. If your code contains more than one class that has a `Sub Main` procedure, use the `-main` compiler option to specify which class contains the `Sub Main` procedure|  
|`-target:winmdobj`|Causes the compiler to create an intermediate file that you can convert to a Windows Runtime binary (.winmd) file. The .winmd file can be consumed by JavaScript and C++ programs, in addition to managed language programs.<br /><br /> The intermediate file is created with a .winmdobj extension.<br /><br /> Unless you specify otherwise by using the `-out` option, the output file name takes the name of the first input file. A `Sub Main` procedure isn’t required.<br /><br /> The .winmdobj file is designed to be used as input for the <xref:Microsoft.Build.Tasks.WinMDExp> export tool to produce a Windows metadata (WinMD) file. The WinMD file has a .winmd extension and contains both the code from the original library and the WinMD definitions that JavaScript, C++, and  the Windows Runtime use.|  
  
 Unless you specify `-target:module`, `-target` causes a [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] assembly manifest to be added to an output file.  
  
 Each instance of Vbc.exe produces, at most, one output file. If you specify a compiler option such as `-out` or `-target` more than one time, the last one the compiler processes is put into effect. Information about all files in a compilation is added to the manifest. All output files except those created with `-target:module` contain assembly metadata in the manifest. Use [Ildasm.exe (IL Disassembler)](https://msdn.microsoft.com/library/f7dy01k1) to view the metadata in an output file.  
  
 The short form of `-target` is `-t`.  
  
### To set -target in the Visual Studio IDE  
  
1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**.   
  
2.  Click the **Application** tab.  
  
3.  Modify the value in the **Application Type** box.  
  
## Example  
 The following code compiles `in.vb`, creating `in.dll`:  
  
```console
vbc -target:library in.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [-main](../../../visual-basic/reference/command-line-compiler/main.md)  
 [-out (Visual Basic)](../../../visual-basic/reference/command-line-compiler/out.md)  
 [-reference (Visual Basic)](../../../visual-basic/reference/command-line-compiler/reference.md)  
 [-addmodule](../../../visual-basic/reference/command-line-compiler/addmodule.md)  
 [-moduleassemblyname](../../../visual-basic/reference/command-line-compiler/moduleassemblyname.md)  
 [Assemblies and the Global Assembly Cache](../../../visual-basic/programming-guide/concepts/assemblies-gac/index.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)
