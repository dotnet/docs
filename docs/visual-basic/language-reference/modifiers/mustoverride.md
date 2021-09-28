---
description: "Learn more about: MustOverride (Visual Basic)"
title: "MustOverride"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.MustOverride"
  - "MustOverride"
helpviewer_keywords: 
  - "virtual elements [Visual Basic], pure"
  - "elements [Visual Basic], pure virtual"
  - "properties [Visual Basic], redefining"
  - "procedures [Visual Basic], overriding"
  - "overriding, MustOverride keyword"
  - "procedures [Visual Basic], redefining"
  - "pure virtual elements [Visual Basic]"
  - "MustOverride keyword [Visual Basic]"
  - "properties [Visual Basic], overriding"
ms.assetid: 6e9d9ad6-bb64-433f-b32b-3ef84293bf96
---
# MustOverride (Visual Basic)

Specifies that a property or procedure is not implemented in this class and must be overridden in a derived class before it can be used.  
  
## Remarks  

 You can use `MustOverride` only in a property or procedure declaration statement. The property or procedure that specifies `MustOverride` must be a member of a class, and the class must be marked [MustInherit](mustinherit.md).  
  
## Rules  
  
- **Incomplete Declaration.** When you specify `MustOverride`, you do not supply any additional lines of code for the property or procedure, not even the `End Function`, `End Property`, or `End Sub` statement.  
  
- **Combined Modifiers.** You cannot specify `MustOverride` together with `NotOverridable`, `Overridable`, or `Shared` in the same declaration.  
  
- **Shadowing and Overriding.** Both shadowing and overriding redefine an inherited element, but there are significant differences between the two approaches. For more information, see [Shadowing in Visual Basic](../../programming-guide/language-features/declared-elements/shadowing.md).  
  
- **Alternate Terms.** An element that cannot be used except in an override is sometimes called a *pure virtual* element.  
  
 The `MustOverride` modifier can be used in these contexts:  
  
 [Function Statement](../statements/function-statement.md)  
  
 [Property Statement](../statements/property-statement.md)  
  
 [Sub Statement](../statements/sub-statement.md)  
  
## See also

- [NotOverridable](notoverridable.md)
- [Overridable](overridable.md)
- [Overrides](overrides.md)
- [MustInherit](mustinherit.md)
- [Keywords](../keywords/index.md)
- [Shadowing in Visual Basic](../../programming-guide/language-features/declared-elements/shadowing.md)
