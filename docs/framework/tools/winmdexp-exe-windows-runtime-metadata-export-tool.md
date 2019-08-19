---
title: "Winmdexp.exe (Windows Runtime Metadata Export Tool)"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Windows Runtime Metadata Export Tool"
  - "Winmdexp.exe"
ms.assetid: d2ce0683-343d-403e-bb8d-209186f7a19d
author: "rpetrusha"
ms.author: "ronpet"
---
# Winmdexp.exe (Windows Runtime Metadata Export Tool)
The Windows Runtime Metadata Export Tool (Winmdexp.exe) transforms a .NET Framework module into a file that contains Windows Runtime metadata. Although .NET Framework assemblies and Windows Runtime metadata files use the same physical format, there are differences in the content of the metadata tables, which means that .NET Framework assemblies are not automatically usable as Windows Runtime Components. The process of turning a .NET Framework module into a Windows Runtime component is referred to as *exporting*. In the .NET Framework 4.5 and .NET Framework 4.5.1, the resulting Windows metadata (.winmd) file contains both metadata and implementation.  
  
 When you use the **Windows Runtime Component** template, which is located under **Windows Store** for C# and Visual Basic in Visual Studio 2013 or Visual Studio 2012, the compiler target is a .winmdobj file, and a subsequent build step calls Winmdexp.exe to export the .winmdobj file to a .winmd file. This is the recommended way to build a Windows Runtime component. Use Winmdexp.exe directly when you want more control over the build process than Visual Studio provides.  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt for Visual Studio (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 At the command prompt, type the following:  
  
## Syntax  
  
```  
winmdexp [options] winmdmodule  
```  
  
## Parameters  
  
|Argument or option|Description|  
|------------------------|-----------------|  
|`winmdmodule`|Specifies the module (.winmdobj) to be exported. Only one module is allowed. To create this module, use the `/target` compiler option with the `winmdobj` target. See [/target:winmdobj (C# Compiler Options)](~/docs/csharp/language-reference/compiler-options/target-winmdobj-compiler-option.md) or [/target (Visual Basic)](~/docs/visual-basic/reference/command-line-compiler/target.md).|  
|`/docfile:` `docfile`<br /><br /> `/d:` `docfile`|Specifies the output XML documentation file that Winmdexp.exe will produce. In the .NET Framework 4.5, the output file is essentially the same as the input XML documentation file.|  
|`/moduledoc:` `docfile`<br /><br /> `/md:` `docfile`|Specifies the name of the XML documentation file that the compiler produced with `winmdmodule`.|  
|`/modulepdb:` `symbolfile`<br /><br /> `/mp:` `symbolfile`|Specifies the name of the program database (PDB) file that contains symbols for `winmdmodule`.|  
|`/nowarn:` `warning`|Suppresses the specified warning number. For *warning*, supply only the numeric portion of the error code, without leading zeros.|  
|`/out:` `file`<br /><br /> `/o:` `file`|Specifies the name of the output Windows metadata (.winmd) file.|  
|`/pdb:` `symbolfile`<br /><br /> `/p:` `symbolfile`|Specifies the name of the output program database (PDB) file that will contain the symbols for the exported Windows metadata (.winmd) file.|  
|`/reference:` `winmd`<br /><br /> `/r:` `winmd`|Specifies a metadata file (.winmd or assembly) to reference during export. If you use the reference assemblies in "\Program Files (x86)\Reference Assemblies\Microsoft\Framework\\.NETCore\v4.5" ("\Program Files\\..." on 32-bit computers), include references to both System.Runtime.dll and mscorlib.dll.|  
|`/utf8output`|Specifies that output messages should be in UTF-8 encoding.|  
|`/warnaserror+`|Specifies that all warnings should be treated as errors.|  
|**@** `responsefile`|Specifies a response (.rsp) file that contains options (and optionally `winmdmodule`). Each line in `responsefile` should contain a single argument or option.|  
  
## Remarks  
 Winmdexp.exe is not designed to convert an arbitrary .NET Framework assembly to a .winmd file. It requires a module that is compiled with the `/target:winmdobj` option, and additional restrictions apply. The most important of these restrictions is that all types that are exposed in the API surface of the assembly must be Windows Runtime types. For more information, see the "Declaring types in Windows Runtime Components" section of the article [Creating Windows Runtime Components in C# and Visual Basic](https://go.microsoft.com/fwlink/p/?LinkID=238313) in the Windows Dev Center.  
  
 When you write a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app or a Windows Runtime component with C# or Visual Basic, the .NET Framework provides support to make programming with the Windows Runtime more natural. This is discussed in the article [.NET Framework Support for Windows Store Apps and Windows Runtime](../../standard/cross-platform/support-for-windows-store-apps-and-windows-runtime.md). In the process, some commonly used Windows Runtime types are mapped to .NET Framework types. Winmdexp.exe reverses this process and produces an API surface that uses the corresponding Windows Runtime types. For example, types that are constructed from the <xref:System.Collections.Generic.IList%601> interface map to types that are constructed from the Windows Runtime[IVector\<T>](https://go.microsoft.com/fwlink/p/?LinkId=251132)interface.  
  
## See also

- [.NET Framework Support for Windows Store Apps and Windows Runtime](../../standard/cross-platform/support-for-windows-store-apps-and-windows-runtime.md)
- [Creating Windows Runtime Components in C# and Visual Basic](https://go.microsoft.com/fwlink/p/?LinkID=238313)
- [Winmdexp.exe Error Messages](../../../docs/framework/tools/winmdexp-exe-error-messages.md)
- [Build, Deployment, and Configuration Tools (.NET Framework)](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/dd233108(v=vs.100))
