---
title: "Implements Clause (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.ImplementsClause"
helpviewer_keywords: 
  - "interface implementation [Visual Basic], reimplementation"
  - "interface members [Visual Basic], reimplementation"
  - "interface members [Visual Basic], Implements keyword"
  - "interface members"
  - "members [Visual Basic], reimplementation"
  - "interface implementation [Visual Basic], Implements keyword"
  - "interface members [Visual Basic], implementing"
  - "Implements keyword [Visual Basic]"
  - "Implements statement [Visual Basic], about Implements"
  - "members [Visual Basic], implementing"
  - "members [Visual Basic], Implements keyword"
  - "reimplementation"
ms.assetid: 5252cdf9-964d-4fc6-af0f-0449b7126b5a
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# Implements Clause (Visual Basic)
Indicates that a class or structure member is providing the implementation for a member defined in an interface.  
  
## Remarks  
The `Implements` keyword is not the same as the [Implements Statement](../../../visual-basic/language-reference/statements/implements-statement.md). You use the `Implements` statement to specify that a class or structure implements one or more interfaces, and then for each member you use the `Implements` keyword to specify which interface and which member it implements.

If a class or structure implements an interface, it must include the `Implements` statement immediately after the [Class Statement](../../../visual-basic/language-reference/statements/class-statement.md) or [Structure Statement](../../../visual-basic/language-reference/statements/structure-statement.md), and it must implement all the members defined by the interface.

## Reimplementation  
In a derived class, you can reimplement an interface member that the base class has already implemented. This is different from overriding the base class member in the following respects:

- The base class member does not need to be [Overridable](../../../visual-basic/language-reference/modifiers/overridable.md) to be reimplemented.
- You can reimplement the member with a different name.

The `Implements` keyword can be used in the following contexts:
- [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md)
- [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)
- [Property Statement](../../../visual-basic/language-reference/statements/property-statement.md)
- [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  
  
## See Also  
 [Implements Statement](../../../visual-basic/language-reference/statements/implements-statement.md)  
 [Interface Statement](../../../visual-basic/language-reference/statements/interface-statement.md)  
 [Class Statement](../../../visual-basic/language-reference/statements/class-statement.md)  
 [Structure Statement](../../../visual-basic/language-reference/statements/structure-statement.md)
