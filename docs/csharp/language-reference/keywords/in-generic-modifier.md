---
title: "in (Generic Modifier) (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "contravariance, in keyword [C#]"
  - "in keyword [C#]"
author: "BillWagner"
ms.author: "wiwagn"
---

# in (Generic Modifier) (C# Reference)

For generic type parameters, the `in` keyword specifies that the type parameter is contravariant. You can use the `in` keyword in generic interfaces and delegates.  
  
 Contravariance enables you to use a less derived type than that specified by the generic parameter. This allows for implicit conversion of classes that implement variant interfaces and implicit conversion of delegate types. Covariance and contravariance in generic type parameters are supported for reference types, but they are not supported for value types.  
  
 A type can be declared contravariant in a generic interface or delegate only if it defines the type of a method's parameters and not of a method's return type. `In`, `ref`, and `out` parameters must be invariant, meaning they are neither covariant or contravariant.
  
 An interface that has a contravariant type parameter allows its methods to accept arguments of less derived types than those specified by the interface type parameter. For example, in the <xref:System.Collections.Generic.IComparer%601> interface, type T is contravariant, you can assign an object of the `IComparer<Person>` type to an object of the `IComparer<Employee>` type without using any special conversion methods if `Employee` inherits `Person`.  
  
 A contravariant delegate can be assigned another delegate of the same type, but with a less derived generic type parameter.  
  
 For more information, see [Covariance and Contravariance](../../programming-guide/concepts/covariance-contravariance/index.md).  
  
## Contravariant generic interface   

 The following example shows how to declare, extend, and implement a contravariant generic interface. It also shows how you can use implicit conversion for classes that implement this interface.  
  
 [!code-csharp[csVarianceKeywords#1](../../../csharp/language-reference/keywords/codesnippet/CSharp/in-generic-modifier_1.cs)]  
  
## Contravariant generic delegate  

 The following example shows how to declare, instantiate, and invoke a contravariant generic delegate. It also shows how you can implicitly convert a delegate type.  
  
 [!code-csharp[csVarianceKeywords#2](../../../csharp/language-reference/keywords/codesnippet/CSharp/in-generic-modifier_2.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [out](../../../csharp/language-reference/keywords/out-generic-modifier.md)  
 [Covariance and Contravariance](../../programming-guide/concepts/covariance-contravariance/index.md)  
 [Modifiers](../../../csharp/language-reference/keywords/modifiers.md)  
