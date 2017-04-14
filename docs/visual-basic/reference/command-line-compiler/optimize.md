---
title: "/optimize | Microsoft Docs"

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
  - "optimize compiler option [Visual Basic]"
  - "/optimize compiler option [Visual Basic]"
  - "optimization, enabling"
  - "-optimize compiler option [Visual Basic]"
ms.assetid: fcba4a97-3622-4b87-a891-0f77deab4998
caps.latest.revision: 15
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
# /optimize
Enables or disables compiler optimizations.  
  
## Syntax  
  
```  
/optimize[ + | - ]  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`+` &#124; `-`|Optional. The `/optimize-` option disables compiler optimizations. The `/optimize+` option enables optimizations. By default, optimizations are disabled.|  
  
## Remarks  
 Compiler optimizations make your output file smaller, faster, and more efficient. However, because optimizations result in code rearrangement in the output file, `/optimize+` can make debugging difficult.  
  
 All modules generated with `/target:module` for an assembly must use the same `/optimize` settings as the assembly. For more information, see [/target (Visual Basic)](../../../visual-basic/reference/command-line-compiler/target.md).  
  
 You can combine the `/optimize` and `/debug` options.  
  
|To set /optimize in the Visual Studio integrated development environment|  
|---|  
|1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**.<br />     For more information, see [Introduction to the Project Designer](http://msdn.microsoft.com/en-us/898dd854-c98d-430c-ba1b-a913ce3c73d7).<br />2.  Click the **Compile** tab.<br />3.  Click the **Advanced** button.<br />4.  Modify the **Enable optimizations** check box.|  
  
## Example  
 The following code compiles `T2.vb` and enables compiler optimizations.  
  
```  
vbc t2.vb /optimize  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)   
 [/debug (Visual Basic)](../../../visual-basic/reference/command-line-compiler/debug.md)   
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)   
 [/target (Visual Basic)](../../../visual-basic/reference/command-line-compiler/target.md)