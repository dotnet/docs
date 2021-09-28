---
description: "Learn more about: -noconfig"
title: "-noconfig"
ms.date: 03/13/2018
helpviewer_keywords: 
  - "noconfig compiler option [Visual Basic]"
  - "-noconfig compiler option [Visual Basic]"
  - "/noconfig compiler option [Visual Basic]"
ms.assetid: a7405067-bd21-4171-adf4-a126fa3ad6c3
---
# -noconfig

Specifies that the compiler should not automatically reference the commonly used .NET Framework assemblies or import the `System` and `Microsoft.VisualBasic` namespaces.  
  
## Syntax  
  
```console  
-noconfig  
```  
  
## Remarks  

 The `-noconfig` option tells the compiler not to compile with the Vbc.rsp file, which is located in the same directory as the Vbc.exe file. The Vbc.rsp file references the commonly used .NET Framework assemblies and imports the `System` and `Microsoft.VisualBasic` namespaces. The compiler implicitly references the System.dll assembly unless the `-nostdlib` option is specified. The `-nostdlib` option tells the compiler not to compile with Vbc.rsp or automatically reference the System.dll assembly.  
  
> [!NOTE]
> The Mscorlib.dll and Microsoft.VisualBasic.dll assemblies are always referenced.  
  
 You can modify the Vbc.rsp file to specify additional compiler options that should be included in every Vbc.exe compilation (except when specifying the `-noconfig` option). For more information, see [@ (Specify Response File)](specify-response-file.md).  
  
 The compiler processes the options passed to the `vbc` command last. Therefore, any option on the command line overrides the setting of the same option in the Vbc.rsp file.  
  
> [!NOTE]
> The `-noconfig` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## See also

- [-nostdlib (Visual Basic)](nostdlib.md)
- [Visual Basic Command-Line Compiler](index.md)
- [@ (Specify Response File)](specify-response-file.md)
- [-reference (Visual Basic)](reference.md)
