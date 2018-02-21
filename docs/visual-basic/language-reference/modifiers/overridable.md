---
title: "Overridable (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "Overridable"
  - "vb.Overridable"
helpviewer_keywords: 
  - "elements [Visual Basic], concrete"
  - "properties [Visual Basic], redefining"
  - "overriding, Overridable keyword"
  - "elements [Visual Basic], virtual"
  - "virtual [elements VB]"
  - "procedures [Visual Basic], overriding"
  - "concrete [elements VB]"
  - "procedures [Visual Basic], redefining"
  - "Overridable keyword [Visual Basic]"
  - "properties [Visual Basic], overriding"
ms.assetid: 612581e7-8a4c-4a5d-beff-3402fffa6f35
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# Overridable (Visual Basic)
Specifies that a property or procedure can be overridden by an identically named property or procedure in a derived class.  
  
## Remarks  
 The `Overridable` modifier allows a property or method in a class to be overridden in a derived class. The [NotOverridable](../../../visual-basic/language-reference/modifiers/notoverridable.md) modifier prevents a property or method from being overridden in a derived class.  For more information, see [Inheritance Basics](../../../visual-basic/programming-guide/language-features/objects-and-classes/inheritance-basics.md).  
  
 If the `Overridable` or `NotOverridable` modifier is not specified, the default setting depends on whether the property or method overrides a base class property or method. If the property or method overrides a base class property or method, the default setting is `Overridable`; otherwise, it is `NotOverridable`.  
  
 You can shadow or override to redefine an inherited element, but there are significant differences between the two approaches. For more information, see [Shadowing in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/shadowing.md).  
  
 An element that can be overridden is sometimes referred to as a *virtual* element. If it can be overridden, but does not have to be, it is sometimes also called a *concrete* element.  
  
 You can use `Overridable` only in a property or procedure declaration statement.  
  
## Combined Modifiers  
 You cannot specify `Overridable` or `NotOverridable` for a `Private` method.  
  
 You cannot specify `Overridable` together with `MustOverride`, `NotOverridable`, or `Shared` in the same declaration.  
  
 Because an overriding element is implicitly overridable, you cannot combine `Overridable` with `Overrides`.  
  
## Usage  
 The `Overridable` modifier can be used in these contexts:  
  
 [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)  
  
 [Property Statement](../../../visual-basic/language-reference/statements/property-statement.md)  
  
 [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  
  
## See Also  
 [Modifiers](../../../visual-basic/language-reference/modifiers/index.md)  
 [Inheritance Basics](../../../visual-basic/programming-guide/language-features/objects-and-classes/inheritance-basics.md)  
 [MustOverride](../../../visual-basic/language-reference/modifiers/mustoverride.md)  
 [NotOverridable](../../../visual-basic/language-reference/modifiers/notoverridable.md)  
 [Overrides](../../../visual-basic/language-reference/modifiers/overrides.md)  
 [Keywords](../../../visual-basic/language-reference/keywords/index.md)  
 [Shadowing in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/shadowing.md)
