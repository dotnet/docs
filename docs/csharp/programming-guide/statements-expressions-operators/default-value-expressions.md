---
title: "default value expressions in Generic Code (C# Programming Guide)"

ms.date: "2017-08-03"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "generics [C#], default keyword"
  - "default keyword [C#], generic programming"
ms.assetid: b9daf449-4e64-496e-8592-6ed2c8875a98
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# default operator for default value expressions (C# programming guide)

A default value expression produces the default value for a type. Default value expressions are particularly useful in generic classes and methods. One issue that arises using generics is how to assign a default value to a parameterized type `T` when you do not know the following in advance:

- Whether `T` will be a reference type or a value type.
- If `T` is a value type, whether it will be a numeric value or a user defined struct.

 Given a variable `t` of a parameterized type `T`, the statement `t = null` is only valid if `T` is a reference type and `t = 0` will only work for numeric value types but not for structs. The solution is to use the `default(T)` operator, which will return `null` for reference types (class types and interface types) and zero for numeric value types. For structs, it will return each member of the struct initialized to zero or `null` depending on whether they are value or reference types. For nullable value types, default returns a <xref:System.Nullable%601?displayProperty=fullName>, which is initialized like any struct.

The `default(T)` expression is not limited to generic classes and methods. Default value expressions can be used with any managed type. Any of these expressions are valid:

 [!code-cs[csProgGuideGenerics#1](codesnippet/CSharp/default-value-expressions.cs)]

 The following example from the `GenericList<T>` class shows how to use the `default(T)` operator in a generic class. For more information, see [Generics Overview](../generics/introduction-to-generics.md).

 [!code-cs[csProgGuideGenerics#2](codesnippet/CSharp/default-keyword-in-generic-code_1.cs)]

## default literal and type inference

Beginning with C# 7.1, the `default` literal can be used for default value expressions when the compiler can infer the type of the expression. The `default` literal produces the same value as the equivalent `default(T)` where `T` is the inferred type. This can make code more concise by reducing the redundancy of declaring a type more than once. The `default` literal can be used in any of the following locations:

- variable initializer
- variable assignment
- declaring the default value for an optional parameter
- providing the value for a method call argument
- return statement (or expression in an expression bodied member)

The following examples show usages of the `default` literal in a default value expression:

[!code-cs[csProgGuideGenerics#3](codesnippet/CSharp/default-literal.cs)]

## See Also

 <xref:System.Collections.Generic>
 [C# Programming Guide](../index.md)
 [Generics](../generics/index.md)
 [Generic Methods](../generics/generic-methods.md)
 [Generics](~/docs/standard/generics/index.md)
