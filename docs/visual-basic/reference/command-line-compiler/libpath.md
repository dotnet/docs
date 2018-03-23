---
title: "-libpath"
ms.date: 03/10/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "libpath compiler option [Visual Basic]"
  - "/libpath compiler option [Visual Basic]"
  - "-libpath compiler option [Visual Basic]"
ms.assetid: 5f1c26c9-3455-4e89-bdf3-b12d6c2e655b
author: rpetrusha
ms.author: ronpet
---
# -libpath
Specifies the location of referenced assemblies.  
  
## Syntax  
  
```  
-libpath:dirList  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`dirList`|Required. Semicolon-delimited list of directories for the compiler to look in if a referenced assembly is not found in either the current working directory (the directory from which you are invoking the compiler) or the common language runtime's system directory. If the directory name contains a space, enclose the name in quotation marks (" ").|  
  
## Remarks  
 The `-libpath` option specifies the location of assemblies referenced by the [-reference](../../../visual-basic/reference/command-line-compiler/reference.md) option.  
  
 The compiler searches for assembly references that are not fully qualified in the following order:  
  
1.  Current working directory. This is the directory from which the compiler is invoked.  
  
2.  The common language runtime system directory.  
  
3.  Directories specified by `/libpath`.  
  
4.  Directories specified by the LIB environment variable.  
  
 The `-libpath` option is additive; specifying it more than once appends to any prior values.  
  
 Use `-reference` to specify an assembly reference.  
  
|To set /libpath in the Visual Studio integrated development environment|  
|---|  
|1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**. <br />2.  Click the **References** tab.<br />3.  Click the **Reference Paths...** button.<br />4.  In the **Reference Paths** dialog box, enter the directory name in the **Folder:** box.<br />5.  Click **Add Folder**.|  
  
## Example  
 The following code compiles `T2.vb` to create an .exe file. The compiler looks in the working directory, in the root directory of the C: drive, and in the New Assemblies directory of the C: drive for assembly references.  
  
```console  
vbc -libpath:c:\;"c:\New Assemblies" -reference:t2.dll t2.vb  
```  
  
## See Also  
 [Assemblies and the Global Assembly Cache](../../../visual-basic/programming-guide/concepts/assemblies-gac/index.md)  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)
