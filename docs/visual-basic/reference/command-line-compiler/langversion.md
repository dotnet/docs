---
title: "-langversion (Visual Basic)"
ms.date: 03/10/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "/langversion compiler option [Visual Basic]"
  - "langversion compiler option [Visual Basic]"
  - "-langversion compiler option [Visual Basic]"
ms.assetid: 59b7b0c8-2dde-4e9b-94e7-0237f7e0bafb
author: dotnet-bot
ms.author: dotnetcontent
---
# -langversion (Visual Basic)
Causes the compiler to accept only syntax that is included in the specified Visual Basic language version.  
  
## Syntax  
  
```  
-langversion:version  
```  
  
## Arguments  
 `version`  
 Required. The language version to be used during the compilation. Accepted values are `9`, `9.0`, `10`, and `10.0`.  
  
## Remarks  
 The `-langversion` option specifies what syntax the compiler accepts. For example, if you specify that the language version is 9.0, the compiler generates errors for syntax that is valid only in version 10.0 and later.  
  
 You can use this option when you develop applications that target different versions of the .NET Framework. For example, if you are targeting .NET Framework 3.5, you could use this option to ensure that you do not use syntax from language version 10.0.  
  
 You can set `-langversion` directly only by using the command line. For more information, see [Targeting a Specific .NET Framework Version](/visualstudio/ide/targeting-a-specific-dotnet-framework-version).  
  
## Example  
 The following code compiles `sample.vb` for Visual Basic 9.0.  
  
```console  
vbc -langversion:9.0 sample.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)  
 [Targeting a Specific .NET Framework Version](/visualstudio/ide/targeting-a-specific-dotnet-framework-version)
