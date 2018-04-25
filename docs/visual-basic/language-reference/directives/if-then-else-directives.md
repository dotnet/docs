---
title: "#If...Then...#Else Directives"
ms.date: 04/11/2018
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.#EndIf"
  - "#End If"
  - "#Then"
  - "#ElseIf"
  - "vb.#ElseIf"
  - "vb.#Else"
  - "vb.#If"
helpviewer_keywords: 
  - "Visual Basic code, compiling"
  - "#If directive [Visual Basic]"
  - "conditional compilation [Visual Basic], directives"
  - "#End if directive [Visual Basic]"
  - "selective compiling"
  - "else directive (#else)"
  - "#Else directive [Visual Basic]"
ms.assetid: 10bba104-e3fd-451b-b672-faa472530502
author: rpetrusha
ms.author: ronpet
---
# #If...Then...#Else Directives
Conditionally compiles selected blocks of Visual Basic code.  
  
## Syntax  
  
```  
#If expression Then  
   statements  
[ #ElseIf expression Then  
   [ statements ]  
...  
#ElseIf expression Then  
   [ statements ] ]  
[ #Else  
   [ statements ] ]  
#End If  
```  
  
## Parts  
 `expression`  
 Required for `#If` and `#ElseIf` statements, optional elsewhere. Any expression, consisting exclusively of one or more conditional compiler constants, literals, and operators, that evaluates to `True` or `False`.  
  
 `statements`  
 Required for `#If` statement block, optional elsewhere. Visual Basic program lines or compiler directives that are compiled if the associated expression evaluates to `True`.  
  
 `#End If`  
 Terminates the `#If` statement block.  
  
## Remarks  
 On the surface, the behavior of the `#If...Then...#Else` directives appears the same as that of the `If...Then...Else` statements. However, the `#If...Then...#Else` directives evaluate what is compiled by the compiler, whereas the `If...Then...Else` statements evaluate conditions at run time.  
  
 Conditional compilation is typically used to compile the same program for different platforms. It is also used to prevent debugging code from appearing in an executable file. Code excluded during conditional compilation is completely omitted from the final executable file, so it has no effect on size or performance.  
  
 Regardless of the outcome of any evaluation, all expressions are evaluated using `Option Compare Binary`. The `Option Compare` statement does not affect expressions in `#If` and `#ElseIf` statements.  
  
> [!NOTE]
>  No single-line form of the `#If`, `#Else`, `#ElseIf`, and `#End If` directives exists. No other code can appear on the same line as any of the directives. 

The statements within a conditional compilation block must be complete logical statements. For example, you cannot conditionally compile only the attributes of a function, but you can conditionally declare the function along with its attributes:

```vb
   #If DEBUG Then
   <WebMethod()>
   Public Function SomeFunction() As String
   #Else
   <WebMethod(CacheDuration:=86400)>
   Public Function SomeFunction() As String
   #End If
```

## Example
 This example uses the `#If...Then...#Else` construct to determine whether to compile certain statements.  
  
 [!code-vb[VbVbalrConditionalComp#1](../../../visual-basic/language-reference/directives/codesnippet/VisualBasic/if-then-else-directives_1.vb)]  
  
## See Also  
[#Const Directive](../../../visual-basic/language-reference/directives/const-directive.md)  
[If...Then...Else Statement](../../../visual-basic/language-reference/statements/if-then-else-statement.md)  
[Conditional Compilation](../../../visual-basic/programming-guide/program-structure/conditional-compilation.md)   
<xref:System.Diagnostics.ConditionalAttribute?displayProperty=nameWithType>   


