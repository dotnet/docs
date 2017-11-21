---
title: "Default value expressions (C# Programming Guide)"
description: "Default value expressions produce the default value for any reference type or value type"
ms.date: 08/23/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "generics [C#], default keyword"
  - "default keyword [C#], generic programming"
ms.assetid: b9daf449-4e64-496e-8592-6ed2c8875a98
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
---
# default value expressions (C# programming guide)

A default value expression produces the default value for a type. Default value expressions are particularly useful in generic classes and methods. One issue that arises using generics is how to assign a default value to a parameterized type `T` when you do not know the following in advance:

- Whether `T` is a reference type or a value type.
- If `T` is a value type, whether is a numeric value or a user-defined struct.

 Given a variable `t` of a parameterized type `T`, the statement `t = null` is only valid if `T` is a reference type. The assignment `t = 0` only works for numeric value types but not for structs. The solution is to use a default value expression, which returns `null` for reference types (class types and interface types) and zero for numeric value types. For user-defined structs, it returns the struct initialized to the zero bit pattern, which produces 0 or `null` for each member depending on whether that member is a value or reference type. For nullable value types, `default` returns a <xref:System.Nullable%601?displayProperty=nameWithType>, which is initialized like any struct.

The `default(T)` expression is not limited to generic classes and methods. Default value expressions can be used with any managed type. Any of these expressions are valid:

 [!code-csharp[csProgGuideGenerics#1](../../../../samples/snippets/csharp/programming-guide/statements-expressions-operators/default-value-expressions.cs)]

 The following example from the `GenericList<T>` class shows how to use the `default(T)` operator in a generic class. For more information, see [Generics Overview](../generics/introduction-to-generics.md).

 [!code-csharp[csProgGuideGenerics#2](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#Snippet41)]

## default literal and type inference

Beginning with C# 7.1, the `default` literal can be used for default value expressions when the compiler can infer the type of the expression. The `default` literal produces the same value as the equivalent `default(T)` where `T` is the inferred type. This can make code more concise by reducing the redundancy of declaring a type more than once. The `default` literal can be used in any of the following locations:

- variable initializer
- variable assignment
- declaring the default value for an optional parameter
- providing the value for a method call argument
- return statement (or expression in an expression bodied member)

The following example shows many usages of the `default` literal in a default value expression:

[!code-csharp[csProgGuideGenerics#3](../../../../samples/snippets/csharp/programming-guide/statements-expressions-operators/default-literal.cs)]

## See also

 <xref:System.Collections.Generic>
 [C# Programming Guide](../index.md)  
 [Generics](../generics/index.md)  
 [Generic Methods](../generics/generic-methods.md)  
 [Generics](~/docs/standard/generics/index.md)  
