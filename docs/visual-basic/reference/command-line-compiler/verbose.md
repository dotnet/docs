---
title: "-verbose"
ms.date: 03/13/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "verbose compiler option [Visual Basic]"
  - "-verbose compiler option [Visual Basic]"
  - "/verbose compiler option [Visual Basic]"
ms.assetid: d1aec0c1-0261-421d-9adc-5b13756100be
author: rpetrusha
ms.author: ronpet
---
# -verbose
Causes the compiler to produce verbose status and error messages.  
  
## Syntax  
  
```  
-verbose[+ | -]  
```  
  
## Arguments  
 `+` &#124; `-`  
 Optional. Specifying `-verbose` is the same as specifying `-verbose+`, which causes the compiler to emit verbose messages. The default for this option is `-verbose-`.  
  
## Remarks  
 The `-verbose` option displays information about the total number of errors issued by the compiler, reports which assemblies are being loaded by a module, and displays which files are currently being compiled.  
  
> [!NOTE]
>  The `-verbose` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## Example  
 The following code compiles `In.vb` and directs the compiler to display verbose status information.  
  
```console  
vbc -verbose in.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)
