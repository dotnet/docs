---
title: "In (Generic Modifier) (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.VarianceIn"
helpviewer_keywords: 
  - "contravariance, In keyword [Visual Basic]"
  - "In keyword [Visual Basic]"
ms.assetid: 59bb13c5-fe96-42b8-8286-86293d1661c5
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# In (Generic Modifier) (Visual Basic)
For generic type parameters, the `In` keyword specifies that the type parameter is contravariant.  
  
## Remarks  
 Contravariance enables you to use a less derived type than that specified by the generic parameter. This allows for implicit conversion of classes that implement variant interfaces and implicit conversion of delegate types.  
  
 For more information, see [Covariance and Contravariance](../../programming-guide/concepts/covariance-contravariance/index.md).  
  
## Rules  
 You can use the `In` keyword in generic interfaces and delegates.  
  
 A type parameter can be declared contravariant in a generic interface or delegate if it is used only as a type of method arguments and not used as a method return type. `ByRef` parameters cannot be covariant or contravariant.  
  
 Covariance and contravariance are supported for reference types and not supported for value types.  
  
 In Visual Basic, you cannot declare events in contravariant interfaces without specifying the delegate type. Also, contravariant interfaces cannot have nested classes, enums, or structures, but they can have nested interfaces.  
  
## Behavior  
 An interface that has a contravariant type parameter allows its methods to accept arguments of less derived types than those specified by the interface type parameter. For example, because in .NET Framework 4, in the <xref:System.Collections.Generic.IComparer%601> interface, type T is contravariant, you can assign an object of the `IComparer(Of Person)` type to an object of the `IComparer(Of Employee)` type without using any special conversion methods if `Person` inherits `Employee`.  
  
 A contravariant delegate can be assigned another delegate of the same type, but with a less derived generic type parameter.  
  
## Example  
 The following example shows how to declare, extend, and implement a contravariant generic interface. It also shows how you can use implicit conversion for classes that implement this interface.  
  
 [!code-vb[vbVarianceKeywords#1](../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/in-generic-modifier_1.vb)]  
  
## Example  
 The following example shows how to declare, instantiate, and invoke a contravariant generic delegate. It also shows how you can implicitly convert a delegate type.  
  
 [!code-vb[vbVarianceKeywords#2](../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/in-generic-modifier_2.vb)]  
  
## See Also  
 [Variance in Generic Interfaces](../../programming-guide/concepts/covariance-contravariance/variance-in-generic-interfaces.md)  
 [Out](../../../visual-basic/language-reference/modifiers/out-generic-modifier.md)
