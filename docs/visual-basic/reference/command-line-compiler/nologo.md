---
title: "-nologo (Visual Basic)"
ms.date: 03/13/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "-nologo compiler option [Visual Basic]"
  - "banners [Visual Basic], suppressing startup"
  - "nologo compiler option [Visual Basic]"
  - "/nologo compiler option [Visual Basic]"
ms.assetid: 25ef54b6-d676-4639-a2d2-a747a158bc07
author: rpetrusha
ms.author: ronpet
---
# -nologo (Visual Basic)
Suppresses display of the copyright banner and informational messages during compilation.  
  
## Syntax  
  
```  
-nologo  
```  
  
## Remarks  
 If you specify `-nologo`, the compiler does not display a copyright banner. By default, `-nologo` is not in effect.  
  
> [!NOTE]
>  The `-nologo` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## Example  
 The following code compiles `T2.vb` and does not display a copyright banner.  
  
```console
vbc -nologo t2.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)
