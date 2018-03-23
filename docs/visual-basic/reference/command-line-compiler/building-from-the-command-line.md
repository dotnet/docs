---
title: "Building from the Command Line (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "builds [Visual Basic], command-line"
  - "Visual Basic compiler, about Visual Basic compiler"
  - "command line [Visual Basic], compilers"
  - "command line [Visual Basic], building from"
  - "command line [Visual Basic], builds"
  - "compilers [Visual Basic], invoking from command line"
  - "command-line builds"
  - "compiling source code"
  - "command-line compilers [Visual Basic], Visual Basic"
  - "command line [Visual Basic], Visual Basic"
ms.assetid: e61947e9-a42e-4717-a699-5f70a98cdd03
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
---
# Building from the Command Line (Visual Basic)
A [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] project is made up of one or more separate source files. During the process known as compilation, these files are brought together into one package—a single executable file that can be run as an application.  
  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] provides a command-line compiler as an alternative to compiling programs from within the [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] integrated development environment (IDE). The command-line compiler is designed for situations in which you do not require the full set of features in the IDE—for example, when you are using or writing for computers with limited system memory or storage space.  
  
  To compile source files from within the [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] IDE, choose the **Build** command from the **Build** menu.  
  
> [!TIP]
>  When you build project files by using the Visual Studio IDE, you can display information about the associated **vbc** command and its switches in the output window. To display this information, open the [Options Dialog Box,  Projects and Solutions, Build and Run](/visualstudio/ide/reference/options-dialog-box-projects-and-solutions-build-and-run), and then set the **MSBuild project build output verbosity** to **Normal** or a higher level of verbosity. For more information, see [How to: View, Save, and Configure Build Log Files](http://msdn.microsoft.com/library/75d38b76-26d6-4f43-bbe7-cbacd7cc81e7).  
  
 You can compile project (.vbproj) files at a command prompt by using MSBuild. For more information, see [Command-Line Reference](/visualstudio/msbuild/msbuild-command-line-reference) and [Walkthrough: Using MSBuild](/visualstudio/msbuild/walkthrough-using-msbuild).  
  
## In This Section  
 [How to: Invoke the Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/how-to-invoke-the-command-line-compiler.md)  
 Describes how to invoke the command-line compiler at the MS-DOS prompt or from a specific subdirectory.  
  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)  
 Provides a list of sample command lines that you can modify for your own use.  
  
## Related Sections  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 Provides lists of compiler options, organized alphabetically or by purpose.  
  
 [Conditional Compilation](../../../visual-basic/programming-guide/program-structure/conditional-compilation.md)  
 Describes how to compile particular sections of code.  
  
 [Building and Cleaning Projects and Solutions in Visual Studio](/visualstudio/ide/building-and-cleaning-projects-and-solutions-in-visual-studio)  
 Describes how to organize what will be included in different builds, choose project properties, and ensure that projects build in the correct order.
