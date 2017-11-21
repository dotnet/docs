---
title: "Generic Interfaces (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "C# language, generic interfaces"
  - "generics [C#], interfaces"
ms.assetid: a8fa49a1-6e78-4a09-87e5-84a0b9f5ffbe
caps.latest.revision: 28
author: "BillWagner"
ms.author: "wiwagn"
---
# Generic Interfaces (C# Programming Guide)
It is often useful to define interfaces either for generic collection classes, or for the generic classes that represent items in the collection. The preference for generic classes is to use generic interfaces, such as <xref:System.IComparable%601> rather than <xref:System.IComparable>, in order to avoid boxing and unboxing operations on value types. The .NET Framework class library defines several generic interfaces for use with the collection classes in the <xref:System.Collections.Generic> namespace.  
  
 When an interface is specified as a constraint on a type parameter, only types that implement the interface can be used. The following code example shows a `SortedList<T>` class that derives from the `GenericList<T>` class. For more information, see [Introduction to Generics](../../../csharp/programming-guide/generics/introduction-to-generics.md). `SortedList<T>` adds the constraint `where T : IComparable<T>`. This enables the `BubbleSort` method in `SortedList<T>` to use the generic <xref:System.IComparable%601.CompareTo%2A> method on list elements. In this example, list elements are a simple class, `Person`, that implements `IComparable<Person>`.  
  
 [!code-csharp[csProgGuideGenerics#29](../../../csharp/programming-guide/generics/codesnippet/CSharp/generic-interfaces_1.cs)]  
  
 Multiple interfaces can be specified as constraints on a single type, as follows:  
  
 [!code-csharp[csProgGuideGenerics#30](../../../csharp/programming-guide/generics/codesnippet/CSharp/generic-interfaces_2.cs)]  
  
 An interface can define more than one type parameter, as follows:  
  
 [!code-csharp[csProgGuideGenerics#31](../../../csharp/programming-guide/generics/codesnippet/CSharp/generic-interfaces_3.cs)]  
  
 The rules of inheritance that apply to classes also apply to interfaces:  
  
 [!code-csharp[csProgGuideGenerics#32](../../../csharp/programming-guide/generics/codesnippet/CSharp/generic-interfaces_4.cs)]  
  
 Generic interfaces can inherit from non-generic interfaces if the generic interface is contra-variant, which means it only uses its type parameter as a return value. In the .NET Framework class library, <xref:System.Collections.Generic.IEnumerable%601> inherits from <xref:System.Collections.IEnumerable> because <xref:System.Collections.Generic.IEnumerable%601> only uses `T` in the return value of <xref:System.Collections.Generic.IEnumerable%601.GetEnumerator%2A> and in the <xref:System.Collections.Generic.IEnumerator%601.Current%2A> property getter.  
  
 Concrete classes can implement closed constructed interfaces, as follows:  
  
 [!code-csharp[csProgGuideGenerics#33](../../../csharp/programming-guide/generics/codesnippet/CSharp/generic-interfaces_5.cs)]  
  
 Generic classes can implement generic interfaces or closed constructed interfaces as long as the class parameter list supplies all arguments required by the interface, as follows:  
  
 [!code-csharp[csProgGuideGenerics#34](../../../csharp/programming-guide/generics/codesnippet/CSharp/generic-interfaces_6.cs)]  
  
 The rules that control method overloading are the same for methods within generic classes, generic structs, or generic interfaces. For more information, see [Generic Methods](../../../csharp/programming-guide/generics/generic-methods.md).  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Introduction to Generics](../../../csharp/programming-guide/generics/introduction-to-generics.md)  
 [interface](../../../csharp/language-reference/keywords/interface.md)  
 [Generics](~/docs/standard/generics/index.md)
