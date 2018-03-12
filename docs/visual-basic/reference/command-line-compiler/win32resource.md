---
title: "-win32resource"
ms.date: 03/13/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "-win32resource"
  - "win32resource"
helpviewer_keywords: 
  - "/win32resource compiler option [Visual Basic]"
  - "-win32resource compiler option [Visual Basic]"
  - "win32resource compiler option [Visual Basic]"
ms.assetid: e226946d-19ce-4cc9-91f5-aed24f77aa2b
author: rpetrusha
ms.author: ronpet
---
# -win32resource
Inserts a Win32 resource file in the output file.  
  
## Syntax  
  
```  
-win32resource:filename  
```  
  
## Arguments  
 `filename`  
 The name of the resource file to add to your output file. Enclose the file name in quotation marks (" ") if it contains a space.  
  
## Remarks  
 You can create a Win32 resource file with the Microsoft Windows Resource Compiler (RC).  
  
 A Win32 resource can contain version or bitmap (icon) information that helps identify your application in **File Explorer**. If you do not specify `-win32resource`, the compiler generates version information based on the assembly version. The `-win32resource` and `-win32icon` options are mutually exclusive.  
  
 See [-linkresource (Visual Basic)](../../../visual-basic/reference/command-line-compiler/linkresource.md) to reference a [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] resource file, or [-resource (Visual Basic)](../../../visual-basic/reference/command-line-compiler/resource.md) to attach a [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] resource file.  
  
> [!NOTE]
>  The `-win32resource` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## Example  
 The following code compiles `In.vb` and attaches a Win32 resource file, `Rf.res`:  
  
```console  
vbc -win32resource:rf.res in.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)
