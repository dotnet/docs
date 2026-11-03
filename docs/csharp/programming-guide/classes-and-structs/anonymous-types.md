---
title: "Anonymous types"
description: Learn about C# anonymous types, which provide a way to create objects with read-only properties without defining a named type first.
ms.date: 04/10/2026
helpviewer_keywords:
  - "anonymous types [C#]"
  - "C# Language, anonymous types"
  - "C# Language, var and anonymous types"
ai-usage: ai-assisted
---
# Anonymous types (C# Programming Guide)

Anonymous types provide a convenient way to encapsulate a set of read-only properties into a single object without defining a named type first. The compiler generates a type name at compile time that you can't access in your source code. The compiler infers the type of each property.

Create anonymous types by using the [`new`](../../language-reference/operators/new-operator.md) operator together with an object initializer. The following example shows an anonymous type that's initialized with two properties, `Name` and `Age`:

:::code language="csharp" source="./snippets/anonymous-types/csharp/Program.cs" id="BasicAnonymousType":::

## Inferred property names

You can specify property names explicitly by using the `Name = value` syntax. When you initialize an anonymous type with a variable or member access expression, the compiler infers the property name from that expression:

:::code language="csharp" source="./snippets/anonymous-types/csharp/Program.cs" id="InferredNames":::

In the preceding example, the compiler infers `productName` and `price` as the property names from the variable names used in the initializer.

## Declare anonymous types with var

Because the compiler generates the type name and you can't access it in source code, you must use [`var`](../../language-reference/statements/declarations.md#implicitly-typed-local-variables) to declare the local variable. You can't specify the type name explicitly:

```csharp
// You must use var — you can't write a named type here.
var person = new { Name = "Alice", Age = 30 };
```

## Use anonymous types in LINQ queries

Anonymous types appear most often in the [`select`](../../language-reference/keywords/select-clause.md) clause of a query expression, where they project a subset of properties from each source element:

:::code language="csharp" source="./snippets/anonymous-types/csharp/Program.cs" id="LinqProjection":::

## Equality

Two anonymous type instances that have the same property names and types in the same order share the same compiler-generated type. The compiler overrides <xref:System.Object.Equals*> and <xref:System.Object.GetHashCode*> so that equality compares property values rather than reference identity:

:::code language="csharp" source="./snippets/anonymous-types/csharp/Program.cs" id="Equality":::

## Nested anonymous types

Anonymous types can contain other anonymous types as property values:

:::code language="csharp" source="./snippets/anonymous-types/csharp/Program.cs" id="Nested":::

## Characteristics

Anonymous types have the following characteristics:

- The compiler generates them as `internal sealed class` types that derive from <xref:System.Object>.
- All properties are `public` and read-only.
- Anonymous types support [`with` expressions](../../language-reference/operators/with-expression.md) for nondestructive mutation.
- The compiler generates value-based <xref:System.Object.Equals*>, <xref:System.Object.GetHashCode*>, and <xref:System.Object.ToString*> overrides.
- Anonymous types support [expression trees](../../advanced-topics/expression-trees/index.md), while tuples don't.

## Limitations

Anonymous types have several limitations:

- You can't use them as method return types, method parameters, or field types because you can't name the type.
- They're scoped to the method where you declare them.
- You can't add methods, events, or custom operators.
- Properties are always read-only; anonymous types don't support mutable properties.

## When to use tuples instead

For most new code, consider using [tuples](../../fundamentals/types/tuples.md#tuples-vs-anonymous-types) instead of anonymous types. As value types, tuples provide better performance. They also provide deconstruction support and more flexible syntax. Anonymous types remain the better choice when you need expression tree support or reference-type semantics. For a detailed comparison, see [Choosing between anonymous and tuple types](../../../standard/base-types/choosing-between-anonymous-and-tuple.md).

## See also

- [Object and collection initializers](object-and-collection-initializers.md)
- [Implicitly typed local variables](implicitly-typed-local-variables.md)
- [Tuples and deconstruction](../../fundamentals/types/tuples.md)
- [LINQ in C#](../../linq/index.md)
- [Choosing between anonymous and tuple types](../../../standard/base-types/choosing-between-anonymous-and-tuple.md)
