---
title: "/langversion (Visual Basic) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "/langversion compiler option [Visual Basic]"
  - "langversion compiler option [Visual Basic]"
  - "-langversion compiler option [Visual Basic]"
ms.assetid: 59b7b0c8-2dde-4e9b-94e7-0237f7e0bafb
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# /langversion (Visual Basic)
Causes the compiler to accept only syntax that is included in the specified Visual Basic language version.  
  
## Syntax  
  
```  
/langversion:version  
```  
  
## Arguments  
 `version`  
 Required. The language version to be used during the compilation. Accepted values are `9`, `9.0`, `10`, and `10.0`.  
  
## Remarks  
 The `/langversion` option specifies what syntax the compiler accepts. For example, if you specify that the language version is 9.0, the compiler generates errors for syntax that is valid only in version 10.0 and later.  
  
 You can use this option when you develop applications that target different versions of the .NET Framework. For example, if you are targeting .NET Framework 3.5, you could use this option to ensure that you do not use syntax from language version 10.0.  
  
 You can set `/langversion` directly only by using the command line. For more information, see [Targeting a Specific .NET Framework Version](https://docs.microsoft.com/visualstudio/ide/targeting-a-specific-dotnet-framework-version).  
  
## Example  
 The following code compiles `sample.vb` for Visual Basic 9.0.  
  
```  
vbc /langversion:9.0 sample.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)   
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)   
 [Targeting a Specific .NET Framework Version](https://docs.microsoft.com/visualstudio/ide/targeting-a-specific-dotnet-framework-version)