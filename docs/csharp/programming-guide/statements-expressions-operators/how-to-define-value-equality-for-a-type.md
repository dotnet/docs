---
title: "How to define value equality for a class or struct - C# Programming Guide"
description: Learn how to define value equality for a class or struct. See code examples and view available resources.
ms.topic: how-to
ms.date: 03/26/2021
helpviewer_keywords: 
  - "overriding Equals method [C#]"
  - "object equivalence [C#]"
  - "Equals method [C#], overriding"
  - "value equality [C#]"
  - "equivalence [C#]"
ms.assetid: 4084581e-b931-498b-9534-cf7ef5b68690
---
# How to define value equality for a class or struct (C# Programming Guide)

[Records](../../fundamentals/types/records.md) automatically implement value equality. Consider defining a `record` instead of a `class` when your type models data and should implement value equality.

When you define a class or struct, you decide whether it makes sense to create a custom definition of value equality (or equivalence) for the type. Typically, you implement value equality when you expect to add objects of the type to a collection, or when their primary purpose is to store a set of fields or properties. You can base your definition of value equality on a comparison of all the fields and properties in the type, or you can base the definition on a subset.

In either case, and in both classes and structs, your implementation should follow the five guarantees of equivalence (for the following rules, assume that `x`, `y` and `z` are not null):  
  
1. The reflexive property: `x.Equals(x)` returns `true`.
  
2. The symmetric property: `x.Equals(y)` returns the same value as `y.Equals(x)`.
  
3. The transitive property: if `(x.Equals(y) && y.Equals(z))` returns `true`, then `x.Equals(z)` returns `true`.
  
4. Successive invocations of `x.Equals(y)` return the same value as long as the objects referenced by x and y aren't modified.  
  
5. Any non-null value isn't equal to null. However, `x.Equals(y)` throws an exception when `x` is null. That breaks rules 1 or 2, depending on the argument to `Equals`.

Any struct that you define already has a default implementation of value equality that it inherits from the <xref:System.ValueType?displayProperty=nameWithType> override of the <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> method. This implementation uses reflection to examine all the fields and properties in the type. Although this implementation produces correct results, it is relatively slow compared to a custom implementation that you write specifically for the type.  
  
The implementation details for value equality are different for classes and structs. However, both classes and structs require the same basic steps for implementing equality:  
  
1. Override the [virtual](../../language-reference/keywords/virtual.md) <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> method. In most cases, your implementation of `bool Equals( object obj )` should just call into the type-specific `Equals` method that is the implementation of the <xref:System.IEquatable%601?displayProperty=nameWithType> interface. (See step 2.)  
  
2. Implement the <xref:System.IEquatable%601?displayProperty=nameWithType> interface by providing a type-specific `Equals` method. This is where the actual equivalence comparison is performed. For example, you might decide to define equality by comparing only one or two fields in your type. Don't throw exceptions from `Equals`. For classes that are related by inheritance:

   * This method should examine only fields that are declared in the class. It should call `base.Equals` to examine fields that are in the base class. (Don't call `base.Equals` if the type inherits directly from <xref:System.Object>, because the <xref:System.Object> implementation of <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> performs a reference equality check.)

   * Two variables should be deemed equal only if the run-time types of the variables being compared are the same. Also, make sure that the `IEquatable` implementation of the `Equals` method for the run-time type is used if the run-time and compile-time types of a variable are different. One strategy for making sure run-time types are always compared correctly is to implement `IEquatable` only in `sealed` classes. For more information, see the [class example](#class-example) later in this article.
  
3. Optional but recommended: Overload the [==](../../language-reference/operators/equality-operators.md#equality-operator-) and [!=](../../language-reference/operators/equality-operators.md#inequality-operator-) operators.  
  
4. Override <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType> so that two objects that have value equality produce the same hash code.  
  
5. Optional: To support definitions for "greater than" or "less than," implement the <xref:System.IComparable%601> interface for your type, and also overload the [<=](../../language-reference/operators/comparison-operators.md#less-than-or-equal-operator-) and [>=](../../language-reference/operators/comparison-operators.md#greater-than-or-equal-operator-) operators.  

> [!NOTE]
> Starting in C# 9.0, you can use records to get value equality semantics without any unnecessary boilerplate code.

## Class example

The following example shows how to implement value equality in a class (reference type).

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/ValueEqualityClass/Program.cs":::

On classes (reference types), the default implementation of both <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> methods performs a reference equality comparison, not a value equality check. When an implementer overrides the virtual method, the purpose is to give it value equality semantics.

The `==` and `!=` operators can be used with classes even if the class does not overload them. However, the default behavior is to perform a reference equality check. In a class, if you overload the `Equals` method, you should overload the `==` and `!=` operators, but it is not required.

> [!IMPORTANT]
> The preceding example code may not handle every inheritance scenario the way you expect. Consider the following code:
>
> ```csharp
> TwoDPoint p1 = new ThreeDPoint(1, 2, 3);
> TwoDPoint p2 = new ThreeDPoint(1, 2, 4);
> Console.WriteLine(p1.Equals(p2)); // output: True
> ```
>
> This code reports that `p1` equals `p2` despite the difference in `z` values. The difference is ignored because the compiler picks the `TwoDPoint` implementation of `IEquatable` based on the compile-time type.
>
> The built-in value equality of `record` types handles scenarios like this correctly. If `TwoDPoint` and `ThreeDPoint` were `record` types, the result of `p1.Equals(p2)` would be `False`. For more information, see [Equality in `record` type inheritance hierarchies](../../language-reference/builtin-types/record.md#equality-in-inheritance-hierarchies).

## Struct example

The following example shows how to implement value equality in a struct (value type):

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/ValueEqualityStruct/Program.cs":::
  
For structs, the default implementation of <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> (which is the overridden version in <xref:System.ValueType?displayProperty=nameWithType>) performs a value equality check by using reflection to compare the values of every field in the type. When an implementer overrides the virtual `Equals` method in a struct, the purpose is to provide a more efficient means of performing the value equality check and optionally to base the comparison on some subset of the struct's field or properties.
  
The [==](../../language-reference/operators/equality-operators.md#equality-operator-) and [!=](../../language-reference/operators/equality-operators.md#inequality-operator-) operators can't operate on a struct unless the struct explicitly overloads them.

## See also

- [Equality comparisons](equality-comparisons.md)
- [C# programming guide](../index.md)
