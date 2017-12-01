---
title: "MustInherit (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "MustInherit"
  - "vb.MustInherit"
helpviewer_keywords: 
  - "classes [Visual Basic], abstract"
  - "MustInherit classes [Visual Basic], MustInherit keyword"
  - "abstract classes [Visual Basic], MustInherit class"
  - "MustInherit keyword [Visual Basic]"
ms.assetid: b8f05185-90e3-4dd7-adc2-90d852fab5b4
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# MustInherit (Visual Basic)
Specifies that a class can be used only as a base class and that you cannot create an object directly from it.  
  
## Remarks  
 The purpose of a *base class* (also known as an *abstract class*) is to define functionality that is common to all the classes derived from it. This saves the derived classes from having to redefine the common elements. In some cases, this common functionality is not complete enough to make a usable object, and each derived class defines the missing functionality. In such a case, you want the consuming code to create objects only from the derived classes. You use `MustInherit` on the base class to enforce this.  
  
 Another use of a `MustInherit` class is to restrict a variable to a set of related classes. You can define a base class and derive all these related classes from it. The base class does not need to provide any functionality common to all the derived classes, but it can serve as a filter for assigning values to variables. If your consuming code declares a variable as the base class, Visual Basic allows you to assign only an object from one of the derived classes to that variable.  
  
 The .NET Framework defines several `MustInherit` classes, among them <xref:System.Array>, <xref:System.Enum>, and <xref:System.ValueType>. <xref:System.ValueType> is an example of a base class that restricts a variable. All value types derive from <xref:System.ValueType>. If you declare a variable as <xref:System.ValueType>, you can assign only value types to that variable.  
  
## Rules  
  
-   **Declaration Context.** You can use `MustInherit` only in a `Class` statement.  
  
-   **Combined Modifiers.** You cannot specify `MustInherit` together with `NotInheritable` in the same declaration.  
  
## Example  
 The following example illustrates both forced inheritance and forced overriding. The base class `shape` defines a variable `acrossLine`. The classes `circle` and `square` derive from `shape`. They inherit the definition of `acrossLine`, but they must define the function `area` because that calculation is different for each kind of shape.  
  
 [!code-vb[VbVbalrKeywords#2](../../../visual-basic/language-reference/codesnippet/VisualBasic/mustinherit_1.vb)]  
  
 You can declare `shape1` and `shape2` to be of type `shape`. However, you cannot create an object from `shape` because it lacks the functionality of the function `area` and is marked `MustInherit`.  
  
 Because they are declared as `shape`, the variables `shape1` and `shape2` are restricted to objects from the derived classes `circle` and `square`. Visual Basic does not allow you to assign any other object to these variables, which gives you a high level of type safety.  
  
## Usage  
 The `MustInherit` modifier can be used in this context:  
  
 [Class Statement](../../../visual-basic/language-reference/statements/class-statement.md)  
  
## See Also  
 [Inherits Statement](../../../visual-basic/language-reference/statements/inherits-statement.md)  
 [NotInheritable](../../../visual-basic/language-reference/modifiers/notinheritable.md)  
 [Keywords](../../../visual-basic/language-reference/keywords/index.md)  
 [Inheritance Basics](../../../visual-basic/programming-guide/language-features/objects-and-classes/inheritance-basics.md)
