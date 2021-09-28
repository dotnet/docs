---
description: "Learn more about: -verbose"
title: "-verbose"
ms.date: 03/13/2018
helpviewer_keywords: 
  - "verbose compiler option [Visual Basic]"
  - "-verbose compiler option [Visual Basic]"
  - "/verbose compiler option [Visual Basic]"
ms.assetid: d1aec0c1-0261-421d-9adc-5b13756100be
---
# -verbose

Causes the compiler to produce verbose status and error messages.  
  
## Syntax  
  
```console  
-verbose[+ | -]  
```  
  
## Arguments  

 `+` &#124; `-`  
 Optional. Specifying `-verbose` is the same as specifying `-verbose+`, which causes the compiler to emit verbose messages. The default for this option is `-verbose-`.  
  
## Remarks  

 The `-verbose` option displays information about the total number of errors issued by the compiler, reports which assemblies are being loaded by a module, and displays which files are currently being compiled.  
  
> [!NOTE]
> The `-verbose` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## Example  

 The following code compiles `In.vb` and directs the compiler to display verbose status information.  
  
```console  
vbc -verbose in.vb  
```  
  
## See also

- [Visual Basic Command-Line Compiler](index.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
