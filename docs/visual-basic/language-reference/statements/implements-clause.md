---
description: "Learn more about: Implements Clause (Visual Basic)"
title: "Implements Clause"
ms.date: 07/20/2015
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
---
# Implements Clause (Visual Basic)

Indicates that a class or structure member is providing the implementation for a member defined in an interface.  
  
## Remarks  

The `Implements` keyword is not the same as the [Implements Statement](implements-statement.md). You use the `Implements` statement to specify that a class or structure implements one or more interfaces, and then for each member you use the `Implements` keyword to specify which interface and which member it implements.

If a class or structure implements an interface, it must include the `Implements` statement immediately after the [Class Statement](class-statement.md) or [Structure Statement](structure-statement.md), and it must implement all the members defined by the interface.

## Reimplementation  

In a derived class, you can reimplement an interface member that the base class has already implemented. This is different from overriding the base class member in the following respects:

- The base class member does not need to be [Overridable](../modifiers/overridable.md) to be reimplemented.
- You can reimplement the member with a different name.

The `Implements` keyword can be used in the following contexts:

- [Event Statement](event-statement.md)
- [Function Statement](function-statement.md)
- [Property Statement](property-statement.md)
- [Sub Statement](sub-statement.md)  
  
## See also

- [Implements Statement](implements-statement.md)
- [Interface Statement](interface-statement.md)
- [Class Statement](class-statement.md)
- [Structure Statement](structure-statement.md)
