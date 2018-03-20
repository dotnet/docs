---
title: "-linkresource (Visual Basic)"
ms.date: 03/10/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "/linkresource compiler option [Visual Basic]"
  - "-linkresource compiler option [Visual Basic]"
  - "linkresource compiler option [Visual Basic]"
  - "/linkres compiler option [Visual Basic]"
  - "linkres compiler option [Visual Basic]"
  - "-linkres compiler option [Visual Basic]"
ms.assetid: cf4dcad8-17b7-404c-9184-29358aa05b15
author: dotnet-bot
ms.author: dotnetcontent
---
# -linkresource (Visual Basic)
Creates a link to a managed resource.  
  
## Syntax  
  
```  
-linkresource:filename[,identifier[,public|private]]  
' -or-  
-linkres:filename[,identifier[,public|private]]  
```  
  
## Arguments  
 `filename`  
 Required. The resource file to link to the assembly. If the file name contains a space, enclose the name in quotation marks (" ").  
  
 `identifier`  
 Optional. The logical name for the resource. The name that is used to load the resource. The default is the name of the file. Optionally, you can specify whether the file is public or private in the assembly manifest, for example: `-linkres:filename.res,myname.res,public`. By default, `filename` is public in the assembly.  
  
## Remarks  
 The `-linkresource` option does not embed the resource file in the output file; use the `-resource` option to do this.  
  
 The `-linkresource` option requires one of the `-target` options other than `-target:module`.  
  
 If `filename` is a [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] resource file created, for example, by the [Resgen.exe (Resource File Generator)](http://msdn.microsoft.com/library/8ef159de-b660-4bec-9213-c3fbc4d1c6f4) or in the development environment, it can be accessed with members in the <xref:System.Resources> namespace. (For more information, see <xref:System.Resources.ResourceManager>.) To access all other resources at run time, use the methods that begin with `GetManifestResource` in the <xref:System.Reflection.Assembly> class.  
  
 The file name can be any file format. For example, you may want to make a native DLL part of the assembly, so that it can be installed into the global assembly cache and accessed from managed code in the assembly.  
  
 The short form of `-linkresource` is `-linkres`.  
  
> [!NOTE]
>  The `-linkresource` option is not available from the Visual Studio development environment; it is available only when you compile from the command line.  
  
## Example  
 The following code compiles `in.vb` and links to resource file `rf.resource`.  
  
```console  
vbc -linkresource:rf.resource in.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [-target (Visual Basic)](../../../visual-basic/reference/command-line-compiler/target.md)  
 [-resource (Visual Basic)](../../../visual-basic/reference/command-line-compiler/resource.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)
