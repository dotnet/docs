---
title: "/recurse | Microsoft Docs"

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
  - "/recurse compiler option [Visual Basic]"
  - "-recurse compiler option [Visual Basic]"
  - "recurse compiler option [Visual Basic]"
ms.assetid: 84a0b670-33ae-44c4-a46a-b90388809317
caps.latest.revision: 12
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
# /recurse
Compiles source-code files in all child directories of either the specified directory or the project directory.  
  
## Syntax  
  
```  
/recurse:[dir\]file  
```  
  
## Arguments  
 `dir`  
 Optional. The directory in which you want the search to begin. If not specified, the search begins in the project directory.  
  
 `file`  
 Required. The file(s) to search for. Wildcard characters are allowed.  
  
## Remarks  
 You can use wildcards in a file name to compile all matching files in the project directory without using `/recurse`. If no output file name is specified, the compiler bases the output file name on the first input file processed. This is generally the first file in the list of files compiled when viewed alphabetically. For this reason, it is best to specify an output file using the `/out` option.  
  
> [!NOTE]
>  The `/recurse` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## Example  
 The following code compiles all [!INCLUDE[vbprvb](../../../csharp/programming-guide/concepts/linq/includes/vbprvb_md.md)] files in the current directory.  
  
```  
vbc *.vb  
```  
  
 The following code compiles all [!INCLUDE[vbprvb](../../../csharp/programming-guide/concepts/linq/includes/vbprvb_md.md)] files in the `Test\ABC` directory and any directories below it, and then generates `Test.ABC.dll`.  
  
```  
vbc /target:library /out:Test.ABC.dll /recurse:Test\ABC\*.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)   
 [/out (Visual Basic)](../../../visual-basic/reference/command-line-compiler/out.md)   
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)