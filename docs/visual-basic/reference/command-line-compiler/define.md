---
title: "/define (Visual Basic) | Microsoft Docs"

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
  - "-d compiler option [Visual Basic]"
  - "/d compiler option [Visual Basic]"
  - "-define compiler option [Visual Basic]"
  - "d compiler option [Visual Basic]"
  - "/define compiler option [Visual Basic]"
  - "define compiler option [Visual Basic]"
ms.assetid: f735c57d-1cf9-4f2f-a26f-0de630fd4077
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
# /define (Visual Basic)
Defines conditional compiler constants.  
  
## Syntax  
  
```  
/define:["]symbol[=value][,symbol[=value]]["]  
' -or-  
/d:["]symbol[=value][,symbol[=value]]["]  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`symbol`|Required. The symbol to define.|  
|`value`|Optional. The value to assign `symbol`. If `value` is a string, it must be surrounded by backslash/quotation-mark sequences (\\") instead of quotation marks. If no value is specified, then it is taken to be True.|  
  
## Remarks  
 The `/define` option has an effect  similar to using a `#Const` preprocessor directive in your source file, except that constants defined with `/define` are public and apply to all files in the project.  
  
 You can use symbols created by this option with the `#If`...`Then`...`#Else` directive to compile source files conditionally.  
  
 `/d` is the short form of `/define`.  
  
 You can define multiple symbols with `/define` by using a comma to separate symbol definitions.  
  
|To set /define in the Visual Studio integrated development environment|  
|---|  
|1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**. For more information, see [Introduction to the Project Designer](http://msdn.microsoft.com/en-us/898dd854-c98d-430c-ba1b-a913ce3c73d7).<br />2.  Click the **Compile** tab.<br />3.  Click **Advanced**.<br />4.  Modify the value in the **Custom Constants** box.|  
  
## Example  
 The following code defines and then uses two conditional compiler constants.  
  
 [!code-vb[VbVbalrCompiler#45](../../../visual-basic/reference/command-line-compiler/codesnippet/VisualBasic/define_1.vb)]  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)   
 [#If...Then...#Else Directives](../../../visual-basic/language-reference/directives/if-then-else-directives.md)   
 [#Const Directive](../../../visual-basic/language-reference/directives/const-directive.md)   
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)