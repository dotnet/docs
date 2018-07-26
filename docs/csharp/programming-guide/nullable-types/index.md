---
title: "Nullable types (C# Programming Guide)"
description: Learn about C# nullable types and how to use them
ms.date: 07/26/2018
helpviewer_keywords: 
  - "nullable types [C#]"
  - "C# language, nullable types"
  - "types [C#], nullable"
ms.assetid: e473cb01-28ca-42be-9cea-f717055d72c6
---
# Nullable types (C# Programming Guide)

Nullable types are instances of the <xref:System.Nullable%601?displayProperty=nameWithType> struct. Nullable types can represent all the values of an underlying type `T`, and an additional [null](../../language-reference/keywords/null.md) value. The underlying type `T` can be any non-nullable [value type](../../language-reference/keywords/value-types.md). `T` cannot be a reference type.

For example, you can assign `null` or any integer value from -2,147,483,648 to 2,147,483,647 to a `Nullable<int>` and [true](../../language-reference/keywords/true-literal.md), [false](../../language-reference/keywords/false-literal.md), or `null` to a `Nullable<bool>`.

You use a nullable type when you need to represent the undefined value of an underlying type. A Boolean variable can have only two values: true and false. There is no "undefined" value. In many programming applications, most notably database interactions, variable value can be undefined. For example, a field in a database may contain the values true or false, or it may contain no value at all. You use a `Nullable<bool>` type in that case.

Nullable types have the following characteristics:
  
- Nullable types represent value-type variables that can be assigned the `null` value. You cannot create a nullable type based on a reference type. (Reference types already support the `null` value.)  
  
- The syntax `T?` is shorthand for `Nullable<T>`. The two forms are interchangeable.  
  
- Assign a value to a nullable type just as you would for an ordinary value type, for example `int? x = 10;` or `double? d = 4.108;`. You also can assign the `null` value: `int? x = null;`.  
  
- Use the <xref:System.Nullable%601.HasValue%2A> and <xref:System.Nullable%601.Value%2A> readonly properties to test for null and retrieve the value, as shown in the following example: `if (x.HasValue) y = x.Value;`  
  
  - The `HasValue` property returns `true` if the variable contains a value, or `false` if it's `null`.
  
  - The `Value` property returns a value if the variable contains a value. Otherwise, an <xref:System.InvalidOperationException> is thrown.  
  
- You can also use the `==` and `!=` operators with a nullable type, as shown in the following example: `if (x != null) y = x.Value;`. If `a` and `b` are both null, `a == b` evaluates to `true`.  
  
- The default value of `T?` is an instance whose `HasValue` property returns `false`.  

- Use the <xref:System.Nullable%601.GetValueOrDefault%2A> method to return either the assigned value, or the [default](../../language-reference/keywords/default-values-table.md) value of the underlying value type if the value of the nullable type is `null`.  
  
- Use the [null-coalescing operator](../../language-reference/operators/null-coalescing-operator.md) `??` to assign a value to an underlying type based on a value of the nullable type: `int? x = null; int y = x ?? -1;`. In the example, since `x` is null, the result value of `y` is `-1`.
  
- Nested nullable types are not allowed. The following line doesn't compile: `Nullable<Nullable<int>> n;`  

For more examples, see the [Using nullable types](using-nullable-types.md) topic.
  
## See also

 <xref:System.Nullable%601?displayProperty=nameWithType>  
 <xref:System.Nullable?displayProperty=nameWithType>  
 [Boxing nullable types](boxing-nullable-types.md)  
 [?? Operator](../../language-reference/operators/null-coalescing-operator.md)  
 [C# Programming Guide](../index.md)  
 [C# Guide](../../index.md)  
 [C# Reference](../../language-reference/index.md)  
 [Nullable Value Types (Visual Basic)](../../../visual-basic/programming-guide/language-features/data-types/nullable-value-types.md)  
