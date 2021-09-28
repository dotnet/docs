---
description: "Learn more about: #Const Directive"
title: "#Const Directive"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.#Const"
  - "#vb.Const"
  - "#Const"
helpviewer_keywords: 
  - "#Const directive"
  - "conditional compilation [Visual Basic], directives"
  - "Const directive (#Const)"
  - "Visual Basic compiler, compiler directives"
  - "constants [Visual Basic], Const directive"
  - "constants [Visual Basic], declaring"
  - "Const statement [Visual Basic], directive (#Const)"
  - "declaring constants [Visual Basic], #const directive"
ms.assetid: 707669e5-23f9-4f17-8622-a0d534429386
---
# #Const Directive

Defines conditional compiler constants for Visual Basic.  
  
## Syntax  
  
```vb  
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
  
 [!code-vb[VbVbalrConditionalComp#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrConditionalComp/VB/Class1.vb#3)]  
  
## See also

- [-define (Visual Basic)](../../reference/command-line-compiler/define.md)
- [#If...Then...#Else Directives](if-then-else-directives.md)
- [Const Statement](../statements/const-statement.md)
- [Conditional Compilation](../../programming-guide/program-structure/conditional-compilation.md)
- [If...Then...Else Statement](../statements/if-then-else-statement.md)
