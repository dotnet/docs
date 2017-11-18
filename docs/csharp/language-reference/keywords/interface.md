---
title: "interface (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "interface_CSharpKeyword"
helpviewer_keywords: 
  - "interface keyword [C#]"
ms.assetid: 7da38e81-4f99-4bc5-b07d-c986b687eeba
caps.latest.revision: 29
author: "BillWagner"
ms.author: "wiwagn"
---
# interface (C# Reference)
An interface contains only the signatures of [methods](../../../csharp/programming-guide/classes-and-structs/methods.md), [properties](../../../csharp/programming-guide/classes-and-structs/properties.md), [events](../../../csharp/programming-guide/events/index.md) or [indexers](../../../csharp/programming-guide/indexers/index.md). A class or struct that implements the interface must implement the members of the interface that are specified in the interface definition. In the following example, class `ImplementationClass` must implement a method named `SampleMethod` that has no parameters and returns `void`.  
  
 For more information and examples, see [Interfaces](../../../csharp/programming-guide/interfaces/index.md).  
  
## Example  
 [!code-csharp[csrefKeywordsTypes#14](../../../csharp/language-reference/keywords/codesnippet/CSharp/interface_1.cs)]  
  
 An interface can be a member of a namespace or a class and can contain signatures of the following members:  
  
-   [Methods](../../../csharp/programming-guide/classes-and-structs/methods.md)  
  
-   [Properties](../../../csharp/programming-guide/classes-and-structs/using-properties.md)  
  
-   [Indexers](../../../csharp/programming-guide/indexers/using-indexers.md)  
  
-   [Events](../../../csharp/language-reference/keywords/event.md)  
  
 An interface can inherit from one or more base interfaces.  
  
 When a base type list contains a base class and interfaces, the base class must come first in the list.  
  
 A class that implements an interface can explicitly implement members of that interface. An explicitly implemented member cannot be accessed through a class instance, but only through an instance of the interface.  
  
 For more details and code examples on explicit interface implementation, see [Explicit Interface Implementation](../../../csharp/programming-guide/interfaces/explicit-interface-implementation.md).  
  
## Example  
 The following example demonstrates interface implementation. In this example, the interface contains the property declaration and the class contains the implementation. Any instance of a class that implements `IPoint` has integer properties `x` and `y`.  
  
 [!code-csharp[csrefKeywordsTypes#15](../../../csharp/language-reference/keywords/codesnippet/CSharp/interface_2.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Reference Types](../../../csharp/language-reference/keywords/reference-types.md)  
 [Interfaces](../../../csharp/programming-guide/interfaces/index.md)  
 [Using Properties](../../../csharp/programming-guide/classes-and-structs/using-properties.md)  
 [Using Indexers](../../../csharp/programming-guide/indexers/using-indexers.md)  
 [class](../../../csharp/language-reference/keywords/class.md)  
 [struct](../../../csharp/language-reference/keywords/struct.md)  
 [Interfaces](../../../csharp/programming-guide/interfaces/index.md)
