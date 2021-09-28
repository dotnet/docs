---
description: "Learn more about: -nologo (Visual Basic)"
title: "-nologo"
ms.date: 03/13/2018
helpviewer_keywords: 
  - "-nologo compiler option [Visual Basic]"
  - "banners [Visual Basic], suppressing startup"
  - "nologo compiler option [Visual Basic]"
  - "/nologo compiler option [Visual Basic]"
ms.assetid: 25ef54b6-d676-4639-a2d2-a747a158bc07
---
# -nologo (Visual Basic)

Suppresses display of the copyright banner and informational messages during compilation.  
  
## Syntax  
  
```console  
-nologo  
```  
  
## Remarks  

 If you specify `-nologo`, the compiler does not display a copyright banner. By default, `-nologo` is not in effect.  
  
> [!NOTE]
> The `-nologo` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## Example  

 The following code compiles `T2.vb` and does not display a copyright banner.  
  
```console
vbc -nologo t2.vb  
```  
  
## See also

- [Visual Basic Command-Line Compiler](index.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
