---
title: "-sdkpath"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "sdkpath"
  - "-sdkpath"
helpviewer_keywords: 
  - "-sdkpath compiler option [Visual Basic]"
  - "/sdkpath compiler option [Visual Basic]"
  - "sdkpath compiler option [Visual Basic]"
ms.assetid: fec8a3f1-b791-4a37-8af7-344859f8212d
author: rpetrusha
ms.author: ronpet
---
# -sdkpath
Specifies the location of mscorlib.dll and Microsoft.VisualBasic.dll.  
  
## Syntax  
  
```  
-sdkpath:path  
```  
  
## Arguments  
 `path`  
 The directory containing the versions of mscorlib.dll and Microsoft.VisualBasic.dll to use for compilation. This path is not verified until it is loaded. Enclose the directory name in quotation marks (" ") if it contains a space.  
  
## Remarks  
 This option tells the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler to load the mscorlib.dll and Microsoft.VisualBasic.dll files from a non-default location. The `-sdkpath` option was designed to be used with [-netcf](../../../visual-basic/reference/command-line-compiler/netcf.md). The [!INCLUDE[Compact](~/includes/compact-md.md)] uses different versions of these support libraries to avoid the use of types and language features not found on the devices.  
  
> [!NOTE]
>  The `-sdkpath` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line. The `-sdkpath` option is set when a [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] device project is loaded.  
  
 You can specify that the compiler should compile without a reference to the Visual Basic Runtime Library by using the `-vbruntime` compiler option. For more information, see [-vbruntime](../../../visual-basic/reference/command-line-compiler/vbruntime.md).  
  
## Example  
 The following code compiles `Myfile.vb` with the [!INCLUDE[Compact](~/includes/compact-md.md)], using the versions of Mscorlib.dll and Microsoft.VisualBasic.dll found in the default installation directory of the [!INCLUDE[Compact](~/includes/compact-md.md)] on the C drive. Typically, you would use the most recent version of the [!INCLUDE[Compact](~/includes/compact-md.md)].  
  
```console
vbc -netcf -sdkpath:"c:\Program Files\Microsoft Visual Studio .NET 2003\CompactFrameworkSDK\v1.0.5000\Windows CE " myfile.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)  
 [-netcf](../../../visual-basic/reference/command-line-compiler/netcf.md)  
 [-vbruntime](../../../visual-basic/reference/command-line-compiler/vbruntime.md)
