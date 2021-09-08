---
description: "var - C# reference"
title: "var - C# reference"
ms.date: 09/02/2021
f1_keywords: 
  - "var"
  - "var_CSharpKeyword"
helpviewer_keywords: 
  - "var keyword [C#]"
---
# var (C# reference)

Beginning with C# 3, variables that are declared at method scope can have an implicit "type" `var`. An implicitly typed local variable is strongly typed just as if you had declared the type yourself, but the compiler determines the type. The following two declarations of `i` are functionally equivalent:

```csharp
var i = 10; // Implicitly typed.
int i = 10; // Explicitly typed.
```

> [!IMPORTANT]
> When `var` is used with [nullable reference types](../builtin-types/nullable-reference-types.md) enabled, it always implies a nullable reference type even if the expression type isn't nullable. The compiler's null state analysis protects against dereferencing a potential `null` value. If the variable is never assigned to an expresssion that maybe null, the compiler won't emit any warnings. If you assign the variable to an expression that might be null, you must test that it isn't null before dereferencing it to avoid any warnings.

A common use of the `var` keyword is with constructor invocation expressions. The use of `var` allows you to not repeat a type name in a variable declaration and object instantiation, as the following example shows:

```csharp
var xs = new List<int>();
```

Beginning with C# 9.0, you can use a target-typed [`new` expression](../operators/new-operator.md) as an alternative:

```csharp
List<int> xs = new();
List<int>? ys = new();
```

In pattern matching, the `var` keyword is used in a [`var` pattern](../operators/patterns.md#var-pattern).

## Example

The following example shows two query expressions. In the first expression, the use of `var` is permitted but is not required, because the type of the query result can be stated explicitly as an `IEnumerable<string>`. However, in the second expression, `var` allows the result to be a collection of anonymous types, and the name of that type is not accessible except to the compiler itself. Use of `var` eliminates the requirement to create a new class for the result. Note that in Example #2, the `foreach` iteration variable `item` must also be implicitly typed.

[!code-csharp[csrefKeywordsTypes#18](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#18)]

## See also

- [C# reference](../index.md)
- [Implicitly typed local variables](../../programming-guide/classes-and-structs/implicitly-typed-local-variables.md)
- [Type relationships in LINQ query operations](../../programming-guide/concepts/linq/type-relationships-in-linq-query-operations.md)
