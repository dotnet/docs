---
title: "default operator - C# reference"
ms.custom: seodec18
description: "Use default operator to produce the default value of a type"
ms.date: 07/31/2019
helpviewer_keywords: 
  - "default keyword [C#]"
---
# default operator (C# reference)

A default value expression `default(T)` produces the default value of a type `T`. The following table shows which values are produced for various types:

|Type|Default value|
|---------|---------|
|Any reference type|`null`|
|Numeric value type|Zero|
|[bool](../../language-reference/keywords/bool.md)|`false`|
|[char](../../language-reference/keywords/char.md)|`'\0'`|
|[enum](../../language-reference/keywords/enum.md)|The value produced by the expression `(E)0`, where `E` is the enum identifier.|
|[struct](../../language-reference/keywords/struct.md)|The value produced by setting all value type fields to their default value and all reference type fields to `null`.|
|Nullable type|An instance for which the <xref:System.Nullable%601.HasValue%2A> property is `false` and the <xref:System.Nullable%601.Value%2A> property is undefined.|

Default value expressions are particularly useful in generic classes and methods. One issue that arises using generics is how to assign a default value of a parameterized type `T` when you don't know the following in advance:

- Whether `T` is a reference type or a value type.
- If `T` is a value type, whether it's a numeric value or a struct.

 Given a variable `t` of a parameterized type `T`, the statement `t = null` is only valid if `T` is a reference type. The assignment `t = 0` only works for numeric value types but not for structs. To solve that, use a default value expression:

```csharp
T t = default(T);
```

The `default(T)` expression is not limited to generic classes and methods. Default value expressions can be used with any managed type. Any of these expressions are valid:

 [!code-csharp[csProgGuideGenerics#1](../../../../samples/snippets/csharp/programming-guide/statements-expressions-operators/default-value-expressions.cs)]

 The following example from the `GenericList<T>` class shows how to use the `default(T)` operator in a generic class. For more information, see [Introduction to Generics](../generics/introduction-to-generics.md).

 [!code-csharp[csProgGuideGenerics#2](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#Snippet41)]

## default literal

Beginning with C# 7.1, the `default` literal can be used for default value expressions when the compiler can infer the type of the expression. The `default` literal produces the same value as the equivalent `default(T)` where `T` is the inferred type. This can make code more concise by reducing the redundancy of declaring a type more than once. The `default` literal can be used in any of the following locations:

- variable initializer
- variable assignment
- declaring the default value for an optional parameter
- providing the value for a method call argument
- return statement (or expression in an expression bodied member)

The following example shows many usages of the `default` literal in a default value expression:

[!code-csharp[csProgGuideGenerics#3](../../../../samples/snippets/csharp/programming-guide/statements-expressions-operators/default-literal.cs)]

For more information, see the [feature proposal note](~/_csharplang/proposals/csharp-7.1/target-typed-default.md).

## C# language specification

For more information, see the [Default value expressions](~/_csharplang/spec/expressions.md#default-value-expressions) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [Default values table](../keywords/default-values-table.md)
