---
title: "#Const Directive | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net

ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vb.#Const"
  - "#vb.Const"
  - "#Const"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "#Const directive"
  - "conditional compilation, directives"
  - "Const directive (#Const)"
  - "Visual Basic compiler, compiler directives"
  - "constants, Const directive"
  - "constants, declaring"
  - "Const statement [Visual Basic], directive (#Const)"
  - "declaring constants, #const directive"
ms.assetid: 707669e5-23f9-4f17-8622-a0d534429386
caps.latest.revision: 17
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
# #Const Directive
Defines conditional compiler constants for Visual Basic.  
  
## Syntax  
  
```  
#Const constname = expression  
```  
  
## Parts  
 `constname`  
 Required. Name of the constant being defined.  
  
 `expression`  
 Required. Literal, other conditional compiler constant, or any combination that includes any or all arithmetic or logical operators except `Is`.  
  
## Remarks  
 Conditional compiler constants are always private to the file in which they appear. You cannot create public compiler constants using the `#Const` directive; you can create them only in the user interface or with the `/define` compiler option.  
  
 You can use only conditional compiler constants and literals in `expression`. Using a standard constant defined with `Const` causes an error. Conversely, you can use constants defined with the `#Const` keyword only for conditional compilation. Constants can also be undefined, in which case they have a value of `Nothing`.  
  
## Example  
 This example uses the `#Const` directive.  
  
 [!code-vb[VbVbalrConditionalComp#3](../../../visual-basic/language-reference/directives/codesnippet/VisualBasic/const-directive_1.vb)]  
  
## See Also  
 [/define (Visual Basic)](../../../visual-basic/reference/command-line-compiler/define.md)   
 [#If...Then...#Else Directives](../../../visual-basic/language-reference/directives/if-then-else-directives.md)   
 [Const Statement](../../../visual-basic/language-reference/statements/const-statement.md)   
 [Conditional Compilation](../../../visual-basic/programming-guide/program-structure/conditional-compilation.md)   
 [If...Then...Else Statement](../../../visual-basic/language-reference/statements/if-then-else-statement.md)