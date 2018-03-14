---
title: "Name &#39;&lt;name&gt;&#39; is not declared"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc30451"
  - "vbc30451"
helpviewer_keywords: 
  - "BC30451"
ms.assetid: 765f099b-e21e-47c6-a906-a065444e56b3
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# Name &#39;&lt;name&gt;&#39; is not declared
A statement refers to a programming element, but the compiler cannot find an element with that exact name.  
  
 **Error ID:** BC30451  
  
## To correct this error  
  
1.  Check the spelling of the name in the referring statement. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] is case-insensitive, but any other variation in the spelling is regarded as a completely different name. Note that the underscore (`_`) is part of the name and therefore part of the spelling.  
  
2.  Check that you have the member access operator (`.`) between an object and its member. For example, if you have a <xref:System.Windows.Forms.TextBox> control named `TextBox1`, to access its <xref:System.Windows.Forms.TextBoxBase.Text%2A> property you should type `TextBox1.Text`. If instead you type `TextBox1Text`, you have created a different name.  
  
3.  If the spelling is correct and the syntax of any object member access is correct, verify that the element has been declared. For more information, see [Declared Elements](../../../visual-basic/programming-guide/language-features/declared-elements/index.md).  
  
4.  If the programming element has been declared, check that it is in scope. If the referring statement is outside the region declaring the programming element, you might need to qualify the element name. For more information, see [Scope in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/scope.md).  
  
## See Also  
 [Declarations and Constants Summary](../../../visual-basic/language-reference/keywords/declarations-and-constants-summary.md)  
 [Visual Basic Naming Conventions](../../../visual-basic/programming-guide/program-structure/naming-conventions.md)  
 [Declared Element Names](../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md)  
 [References to Declared Elements](../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md)
