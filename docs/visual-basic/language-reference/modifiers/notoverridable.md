---
description: "Learn more about: NotOverridable (Visual Basic)"
title: "NotOverridable"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.NotOverridable"
  - "NotOverridable"
helpviewer_keywords: 
  - "sealed methods [Visual Basic]"
  - "NotOverridable keyword [Visual Basic]"
  - "properties [Visual Basic], redefining"
  - "elements [Visual Basic], sealed"
  - "sealed [elements VB]"
  - "procedures [Visual Basic], overriding"
  - "procedures [Visual Basic], redefining"
  - "overriding"
  - "methods [Visual Basic], sealed"
  - "properties [Visual Basic], overriding"
ms.assetid: 66ec6984-f5f5-4857-b362-6a3907aaf9e0
---
# NotOverridable (Visual Basic)

Specifies that a property or procedure cannot be overridden in a derived class.  
  
## Remarks  

 The `NotOverridable` modifier prevents a property or method from being overridden in a derived class.  The [Overridable](overridable.md) modifier allows a property or method in a class to be overridden in a derived class. For more information, see [Inheritance Basics](../../programming-guide/language-features/objects-and-classes/inheritance-basics.md).  
  
 If the `Overridable` or `NotOverridable` modifier is not specified, the default setting depends on whether the property or method overrides a base class property or method. If the property or method overrides a base class property or method, the default setting is `Overridable`; otherwise, it is `NotOverridable`.  
  
 An element that cannot be overridden is sometimes called a *sealed* element.  
  
 You can use `NotOverridable` only in a property or procedure declaration statement. You can specify `NotOverridable` only on a property or procedure that overrides another property or procedure, that is, only in combination with `Overrides`.  
  
## Combined Modifiers  

 You cannot specify `Overridable` or `NotOverridable` for a `Private` method.  
  
 You cannot specify `NotOverridable` together with `MustOverride`, `Overridable`, or `Shared` in the same declaration.  
  
## Usage  

 The `NotOverridable` modifier can be used in these contexts:  
  
 [Function Statement](../statements/function-statement.md)  
  
 [Property Statement](../statements/property-statement.md)  
  
 [Sub Statement](../statements/sub-statement.md)  
  
## See also

- [Modifiers](index.md)
- [Inheritance Basics](../../programming-guide/language-features/objects-and-classes/inheritance-basics.md)
- [MustOverride](mustoverride.md)
- [Overridable](overridable.md)
- [Overrides](overrides.md)
- [Keywords](../keywords/index.md)
- [Shadowing in Visual Basic](../../programming-guide/language-features/declared-elements/shadowing.md)
