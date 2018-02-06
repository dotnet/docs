---
title: "void (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "void_CSharpKeyword"
  - "void"
helpviewer_keywords: 
  - "void keyword [C#]"
ms.assetid: 0d2d8a95-fe20-4fbd-bf5d-c1e54bce71d4
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
---
# void (C# Reference)
When used as the return type for a method, `void` specifies that the method doesn't return a value.

`void` isn't allowed in the parameter list of a method. A method that takes no parameters and returns no value is declared as follows:

```csharp
public void SampleMethod()
{
    // Body of the method.
}
```

`void` is also used in an unsafe context to declare a pointer to an unknown type. For more information, see [Pointer types](../../../csharp/programming-guide/unsafe-code-pointers/pointer-types.md).

`void` is an alias for the .NET Framework <xref:System.Void?displayProperty=nameWithType> type.

## C# Language Specification
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Reference Types](../../../csharp/language-reference/keywords/reference-types.md)  
 [Value Types](../../../csharp/language-reference/keywords/value-types.md)  
 [Methods](../../../csharp/programming-guide/classes-and-structs/methods.md)  
 [Unsafe Code and Pointers](../../../csharp/programming-guide/unsafe-code-pointers/index.md)
