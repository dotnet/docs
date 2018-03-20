---
title: "-vbruntime"
ms.date: 03/13/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbruntime"
  - "-vbruntime"
helpviewer_keywords: 
  - "vbruntime compiler option [Visual Basic]"
  - "-vbruntime compiler option [Visual Basic]"
  - "/vbruntime compiler option [Visual Basic]"
ms.assetid: 1aa0239e-511a-4c29-957d-fd72877b350a
author: rpetrusha
ms.author: ronpet
---
# -vbruntime
Specifies that the compiler should compile without a reference to the Visual Basic Runtime Library, or with a reference to a specific runtime library.  
  
## Syntax  
  
```  
-vbruntime:{ - | + | * | path }  
```  
  
## Arguments  
 \-  
 Compile without a reference to the Visual Basic Runtime Library.  
  
 \+  
 Compile with a reference to the default Visual Basic Runtime Library.  
  
 \*  
 Compile without a reference to the Visual Basic Runtime Library, and embed core functionality from the Visual Basic Runtime Library into the assembly.  
  
 `path`  
 Compile with a reference to the specified library (DLL).  
  
## Remarks  
 The `-vbruntime` compiler option enables you to specify that the compiler should compile without a reference to the Visual Basic Runtime Library. If you compile without a reference to the Visual Basic Runtime Library, errors or warnings are logged on code or language constructs that generate a call to a Visual Basic runtime helper. (A *Visual Basic runtime helper* is a function defined in Microsoft.VisualBasic.dll that is called at runtime to execute a specific language semantic.)  
  
 The `-vbruntime+` option produces the same behavior that occurs if no `-vbruntime` switch is specified. You can use the `-vbruntime+` option to override previous `-vbruntime` switches.  
  
 Most objects of the `My` type are unavailable when you use the `-vbruntime-` or `-vbruntime:path` options.  
  
## Embedding Visual Basic Runtime core functionality  
 The `-vbruntime*` option enables you to compile without a reference to a runtime library. Instead, core functionality from the Visual Basic Runtime Library is embedded in the user assembly. You can use this option if your application runs on platforms that do not contain the Visual Basic runtime.  
  
 The following runtime members are embedded:  
  
-   <xref:Microsoft.VisualBasic.CompilerServices.Conversions> class  
  
-   <xref:Microsoft.VisualBasic.Strings.AscW%28System.Char%29> method  
  
-   <xref:Microsoft.VisualBasic.Strings.AscW%28System.String%29> method  
  
-   <xref:Microsoft.VisualBasic.Strings.ChrW%28System.Int32%29> method  
  
-   <xref:Microsoft.VisualBasic.Constants.vbBack> constant  
  
-   <xref:Microsoft.VisualBasic.Constants.vbCr> constant  
  
-   <xref:Microsoft.VisualBasic.Constants.vbCrLf> constant  
  
-   <xref:Microsoft.VisualBasic.Constants.vbFormFeed> constant  
  
-   <xref:Microsoft.VisualBasic.Constants.vbLf> constant  
  
-   <xref:Microsoft.VisualBasic.Constants.vbNewLine> constant  
  
-   <xref:Microsoft.VisualBasic.Constants.vbNullChar> constant  
  
-   <xref:Microsoft.VisualBasic.Constants.vbNullString> constant  
  
-   <xref:Microsoft.VisualBasic.Constants.vbTab> constant  
  
-   <xref:Microsoft.VisualBasic.Constants.vbVerticalTab> constant  
  
-   Some objects of the `My` type  
  
 If you compile using the `-vbruntime*` option and your code references a member from the Visual Basic Runtime Library that is not embedded with the core functionality, the compiler returns an error that indicates that the member is not available.  
  
## Referencing a specified library  
 You can use the `path` argument to compile with a reference to a custom runtime library instead of the default Visual Basic Runtime Library.  
  
 If the value for the `path` argument is a fully qualified path to a DLL, the compiler will use that file as the runtime library. If the value for the `path` argument is not a fully qualified path to a DLL, the Visual Basic compiler will search for the identified DLL in the current folder first. It will then search in the path that you have specified by using the [-sdkpath](../../../visual-basic/reference/command-line-compiler/sdkpath.md) compiler option. If the `-sdkpath` compiler option is not used, the compiler will search for the identified DLL in the .NET Framework folder (`%systemroot%\Microsoft.NET\Framework\versionNumber`).  
  
## Example  
 The following example shows how to use the `-vbruntime` option to compile with a reference to a custom library.  
  
```console
vbc -vbruntime:C:\VBLibraries\CustomVBLibrary.dll  
```  
  
## See Also  
 [Visual Basic Core – New compilation mode in Visual Studio 2010 SP1](http://blogs.msdn.com/b/vbteam/archive/2011/01/10/vb-core-new-compilation-mode-in-visual-studio-2010-sp1.aspx)  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)  
 [-sdkpath](../../../visual-basic/reference/command-line-compiler/sdkpath.md)
