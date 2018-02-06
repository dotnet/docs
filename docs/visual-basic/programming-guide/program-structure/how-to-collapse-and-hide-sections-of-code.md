---
title: "How to: Collapse and Hide Sections of Code (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Visual Basic, code collapsing"
  - "Visual Basic, code hiding"
  - "Visual Basic code, collapsing and hiding"
ms.assetid: b770e8f5-e07d-491a-ab4b-a977980f9ba2
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Collapse and Hide Sections of Code (Visual Basic)
The `#Region` directive enables you to collapse and hide sections of code in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] files. The `#Region` directive lets you specify a block of code that you can expand or collapse when using the [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] code editor. The ability to hide code selectively makes your files more manageable and easier to read. For more information, see [Outlining](/visualstudio/ide/outlining).  
  
 `#Region` directives support code block semantics such as `#If...#End If`. This means they cannot begin in one block and end in another; the start and end must be in the same block. `#Region` directives are not supported within functions.  
  
### To collapse and hide a section of code  
  
-   Place the section of code between the `#Region` and `#End Region` statements, as in the following example:  
  
     [!code-vb[VbVbalrConditionalComp#6](../../../visual-basic/language-reference/directives/codesnippet/VisualBasic/how-to-collapse-and-hide-sections-of-code_1.vb)]  
  
     The `#Region` block can be used multiple times in a code file; thus, users can define their own blocks of procedures and classes that can, in turn, be collapsed. `#Region` blocks can also be nested within other `#Region` blocks.  
  
    > [!NOTE]
    >  Hiding code does not prevent it from being compiled and does not affect `#If...#End If` statements.  
  
## See Also  
 [Conditional Compilation](../../../visual-basic/programming-guide/program-structure/conditional-compilation.md)  
 [#Region Directive](../../../visual-basic/language-reference/directives/region-directive.md)  
 [#If...Then...#Else Directives](../../../visual-basic/language-reference/directives/if-then-else-directives.md)  
 [Outlining](/visualstudio/ide/outlining)
