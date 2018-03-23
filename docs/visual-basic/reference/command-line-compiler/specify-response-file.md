---
title: "@ (Specify Response File) (Visual Basic)"
ms.date: 03/13/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "@ (Specify Response File) compiler option [Visual Basic]"
ms.assetid: a6847eaa-e5f9-4303-9421-45b55484b9ca
author: rpetrusha
ms.author: ronpet
---
# @ (Specify Response File) (Visual Basic)
Specifies a file that contains compiler options and source-code files to compile.  
  
## Syntax  
  
```  
@response_file  
```  
  
## Arguments  
 `response_file`  
 Required. A file that lists compiler options or source-code files to compile. Enclose the file name in quotation marks (" ") if it contains a space.  
  
## Remarks  
 The compiler processes the compiler options and source-code files specified in a response file as if they had been specified on the command line.  
  
 To specify more than one response file in a compilation, specify multiple response-file options, such as the following.  
  
```  
@file1.rsp @file2.rsp  
```  
  
 In a response file, multiple compiler options and source-code files can appear on one line. A single compiler-option specification must appear on one line (cannot span multiple lines). Response files can have comments that begin with the `#` symbol.  
  
 You can combine options specified on the command line with options specified in one or more response files. The compiler processes the command options as it encounters them. Therefore, command-line arguments can override previously listed options in response files. Conversely, options in a response file override options listed previously on the command line or in other response files.  
  
 Visual Basic provides the Vbc.rsp file, which is located in the same directory as the Vbc.exe file. The Vbc.rsp file is included by default unless the `-noconfig` option is used. For more information, see [-noconfig](../../../visual-basic/reference/command-line-compiler/noconfig.md).  
  
> [!NOTE]
>  The `@` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## Example  
 The following lines are from a sample response file.  
  
```console
# build the first output file  
-target:exe   
-out:MyExe.exe  
source1.vb   
source2.vb  
```  
  
## Example  
 The following example demonstrates how to use the `@` option with the response file named `File1.rsp`.  
  
```console
vbc @file1.rsp  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [-noconfig](../../../visual-basic/reference/command-line-compiler/noconfig.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)
