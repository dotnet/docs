---
title: "Nullable types (C# Programming Guide)"
description: Learn about C# nullable types and how to use them
ms.date: 07/30/2018
helpviewer_keywords: 
  - "nullable types [C#]"
  - "C# language, nullable types"
  - "types [C#], nullable"
ms.assetid: e473cb01-28ca-42be-9cea-f717055d72c6
---
# Nullable types (C# Programming Guide)

Nullable types are instances of the <xref:System.Nullable%601?displayProperty=nameWithType> struct. Nullable types can represent all the values of an underlying type `T`, and an additional [null](../../language-reference/keywords/null.md) value. The underlying type `T` can be any non-nullable [value type](../../language-reference/keywords/value-types.md). `T` cannot be a reference type.

For example, you can assign `null` or any integer value from <xref:System.Int32.MinValue?displayProperty=nameWithType> to <xref:System.Int32.MaxValue?displayProperty=nameWithType> to a `Nullable<int>` and [true](../../language-reference/keywords/true-literal.md), [false](../../language-reference/keywords/false-literal.md), or `null` to a `Nullable<bool>`.

You use a nullable type when you need to represent the undefined value of an underlying type. A Boolean variable can have only two values: true and false. There is no "undefined" value. In many programming applications, most notably database interactions, a variable value can be undefined or missing. For example, a field in a database may contain the values true or false, or it may contain no value at all. You use a `Nullable<bool>` type in that case.

Nullable types have the following characteristics:
  
- Nullable types represent value-type variables that can be assigned the `null` value. You cannot create a nullable type based on a reference type. (Reference types already support the `null` value.)  
  
- The syntax `T?` is shorthand for `Nullable<T>`. The two forms are interchangeable.  
  
- Assign a value to a nullable type just as you would for an underlying value type: `int? x = 10;` or `double? d = 4.108;`. You also can assign the `null` value: `int? x = null;`.  
  
- Use the <xref:System.Nullable%601.HasValue%2A?displayProperty=nameWithType> and <xref:System.Nullable%601.Value%2A?displayProperty=nameWithType> readonly properties to test for null and retrieve the value, as shown in the following example: `if (x.HasValue) y = x.Value;`  
  
  - The <xref:System.Nullable%601.HasValue%2A> property returns `true` if the variable contains a value, or `false` if it's `null`.
  
  - The <xref:System.Nullable%601.Value%2A> property returns a value if <xref:System.Nullable%601.HasValue%2A> returns `true`. Otherwise, an <xref:System.InvalidOperationException> is thrown.  
  
- You can also use the `==` and `!=` operators with a nullable type, as shown in the following example: `if (x != null) y = x.Value;`. If `a` and `b` are both null, `a == b` evaluates to `true`.  

- Beginning with C# 7.0, you can use [pattern matching](../../pattern-matching.md#the-is-type-pattern-expression) to both examine and get a value of a nullable type: `if (x is int valueOfX) y = valueOfX;`.
  
- The default value of `T?` is an instance whose <xref:System.Nullable%601.HasValue%2A> property returns `false`.  

- Use the <xref:System.Nullable%601.GetValueOrDefault> method to return either the assigned value, or the [default](../../language-reference/keywords/default-values-table.md) value of the underlying value type if the value of the nullable type is `null`.  

- Use the <xref:System.Nullable%601.GetValueOrDefault(%600)> method to return either the assigned value, or the provided default value if the value of the nullable type is `null`.
  
- Use the [null-coalescing operator](../../language-reference/operators/null-coalescing-operator.md), `??`, to assign a value to an underlying type based on a value of the nullable type: `int? x = null; int y = x ?? -1;`. In the example, since `x` is null, the result value of `y` is `-1`.

- If a user-defined conversion is defined between two data types, the same conversion can also be used with the nullable versions of these data types.
  
- Nested nullable types are not allowed. The following line doesn't compile: `Nullable<Nullable<int>> n;`  

For more information, see the [Using nullable types](using-nullable-types.md) and [How to: Identify a nullable type](how-to-identify-a-nullable-type.md) topics.
  
## See also

 <xref:System.Nullable%601?displayProperty=nameWithType>  
 <xref:System.Nullable?displayProperty=nameWithType>  
 [?? Operator](../../language-reference/operators/null-coalescing-operator.md)  
 [C# Programming Guide](../index.md)  
 [C# Guide](../../index.md)  
 [C# Reference](../../language-reference/index.md)  
 [Nullable Value Types (Visual Basic)](../../../visual-basic/programming-guide/language-features/data-types/nullable-value-types.md)  
