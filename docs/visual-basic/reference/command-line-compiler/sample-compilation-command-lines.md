---
description: "Learn more about: Sample compilation command lines (Visual Basic)"
title: "Sample Compilation Command Lines"
ms.date: 03/13/2018
helpviewer_keywords:
  - "command line [Visual Basic], compilers"
  - "compilation [Visual Basic], command-line"
  - "command-line compilers"
  - "compiling source code [Visual Basic], from command line"
  - "Visual Basic compiler, sample command lines"
ms.assetid: 5bfbb487-5f47-4267-969a-39dfb917beeb
---
# Sample compilation command lines (Visual Basic)

As an alternative to compiling Visual Basic programs from within Visual Studio, you can compile from the command line to produce executable (.exe) files or dynamic-link library (.dll) files.

The Visual Basic command-line compiler supports a complete set of options that control input and output files, assemblies, and debug and preprocessor options. Each option is available in two interchangeable forms: `-option` and `/option`. This documentation shows only the `-option` form.

The following table lists some sample command lines you can modify for your own use.

|To|Use|
|--------|---------|
|Compile File.vb and create File.exe|`vbc -reference:Microsoft.VisualBasic.dll File.vb`|
|Compile File.vb and create File.dll|`vbc -target:library File.vb`|
|Compile File.vb and create My.exe|`vbc -out:My.exe File.vb`|
|Compile File.vb and create both a library and a reference assembly named File.dll|`vbc -target:library -ref:.\debug\bin\ref\file.dll File.vb`|
|Compile all Visual Basic files in the current directory, with optimizations on and the `DEBUG` symbol defined, producing File2.exe|`vbc -define:DEBUG=1 -optimize -out:File2.exe *.vb`|
|Compile all Visual Basic files in the current directory, producing a debug version of File2.dll without displaying the logo or warnings|`vbc -target:library -out:File2.dll -nowarn -nologo -debug *.vb`|
|Compile all Visual Basic files in the current directory to Something.dll|`vbc -target:library -out:Something.dll *.vb`|

> [!TIP]
> When you build a project by using the Visual Studio IDE, you can display information about the associated **vbc** command with its compiler options in the output window. To display this information, open the [Options Dialog Box,  Projects and Solutions, Build and Run](/visualstudio/ide/reference/options-dialog-box-projects-and-solutions-build-and-run), and then set the **MSBuild project build output verbosity** to **Normal** or a higher level of verbosity.

## See also

- [Visual Basic Command-Line Compiler](index.md)
- [Conditional Compilation](../../programming-guide/program-structure/conditional-compilation.md)
