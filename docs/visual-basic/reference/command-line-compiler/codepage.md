---
title: "-codepage (Visual Basic)"
ms.date: 03/09/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "-codepage compiler option [Visual Basic]"
  - "codepage compiler option [Visual Basic]"
  - "-codepage compiler option [Visual Basic]"
ms.assetid: be36ec33-6800-4505-838c-4124564f5cc9
author: dotnet-bot
ms.author: dotnetcontent
---
# -codepage (Visual Basic)
Specifies the code page to use for all source-code files in the compilation.  
  
## Syntax  
  
```  
-codepage:id  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`id`|Required. The compiler uses the code page specified by `id` to interpret the encoding of the source files.|  
  
## Remarks  
 To compile source code saved with a specific encoding, you can use `-codepage` to specify which code page should be used. The `-codepage` option applies to all source-code files in your compilation. For more information, see [Character Encoding in the .NET Framework](http://msdn.microsoft.com/library/bf6d9823-4c2d-48af-b280-919c5af66ae9).  
  
 The `-codepage` option is not needed if the source-code files were saved using the current ANSI code page, Unicode, or UTF-8 with a signature. [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] saves all source-code files with the current ANSI code page by default, unless the user specifies another encoding in the **Encoding** dialog box. [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] uses the **Encoding** dialog box to open source-code files saved with a different code page.  
  
> [!NOTE]
>  The `-codepage` option is not available from within the [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] development environment; it is available only when compiling from the command line.  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)
