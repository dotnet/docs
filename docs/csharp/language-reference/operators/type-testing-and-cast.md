---
title: "Type-testing operators and cast expression - C# reference"
description: "Learn about C# operators that you can use to check the type of an expression result and convert it to another type if necessary."
ms.date: 11/08/2021
author: pkulikov
f1_keywords: 
  - "is_CSharpKeyword"
  - "as_CSharpKeyword"
  - "()_CSharpKeyword"
  - "typeof_CSharpKeyword"
  - "as"
  - "typeof"
helpviewer_keywords: 
  - "type-testing operators [C#]"
  - "conversion operators [C#]"
  - "type conversion [C#]"
  - "is operator [C#]"
  - "as operator [C#]"
  - "cast operator [C#]"
  - "cast expression [C#]"
  - "() operator [C#]"
  - "typeof operator [C#]"
---
# Type-testing operators and cast expression (C# reference)

You can use the following operators and expressions to perform type checking or type conversion:

- [is operator](#is-operator): Check if the run-time type of an expression is compatible with a given type
- [as operator](#as-operator): Explicitly convert an expression to a given type if its run-time type is compatible with that type
- [cast expression](#cast-expression): Perform an explicit conversion
- [typeof operator](#typeof-operator): Obtain the <xref:System.Type?displayProperty=nameWithType> instance for a type

## is operator

The `is` operator checks if the run-time type of an expression result is compatible with a given type. Beginning with C# 7.0, the `is` operator also tests an expression result against a pattern.

The expression with the type-testing `is` operator has the following form

```csharp
E is T
```

where `E` is an expression that returns a value and `T` is the name of a type or a type parameter. `E` can't be an anonymous method or a lambda expression.

The `is` operator returns `true` when an expression result is non-null and any of the following conditions are true:

- The run-time type of an expression result is `T`.

- The run-time type of an expression result derives from type `T`, implements interface `T`, or another [implicit reference conversion](~/_csharpstandard/standard/conversions.md#1128-implicit-reference-conversions) exists from it to `T`.

- The run-time type of an expression result is a [nullable value type](../builtin-types/nullable-value-types.md) with the underlying type `T` and the <xref:System.Nullable%601.HasValue?displayProperty=nameWithType> is `true`.

- A [boxing](../../programming-guide/types/boxing-and-unboxing.md#boxing) or [unboxing](../../programming-guide/types/boxing-and-unboxing.md#unboxing) conversion exists from the run-time type of an expression result to type `T`.

The `is` operator doesn't consider user-defined conversions.

The following example demonstrates that the `is` operator returns `true` if the run-time type of an expression result derives from a given type, that is, there exists a reference conversion between types:

[!code-csharp[is with reference conversion](snippets/shared/TypeTestingAndConversionOperators.cs#IsWithReferenceConversion)]

The next example shows that the `is` operator takes into account boxing and unboxing conversions but doesn't consider [numeric conversions](../builtin-types/numeric-conversions.md):

[!code-csharp-interactive[is with int](snippets/shared/TypeTestingAndConversionOperators.cs#IsWithInt)]

For information about C# conversions, see the [Conversions](~/_csharpstandard/standard/conversions.md) chapter of the [C# language specification](~/_csharpstandard/standard/README.md).

### Type testing with pattern matching

Beginning with C# 7.0, the `is` operator also tests an expression result against a pattern. The following example shows how to use a [declaration pattern](patterns.md#declaration-and-type-patterns) to check the run-time type of an expression:

[!code-csharp-interactive[is with declaration pattern](snippets/shared/TypeTestingAndConversionOperators.cs#IsDeclarationPattern)]

For information about the supported patterns, see [Patterns](patterns.md).

## as operator

The `as` operator explicitly converts the result of an expression to a given reference or nullable value type. If the conversion isn't possible, the `as` operator returns `null`. Unlike a [cast expression](#cast-expression), the `as` operator never throws an exception.

The expression of the form

```csharp
E as T
```

where `E` is an expression that returns a value and `T` is the name of a type or a type parameter, produces the same result as

```csharp
E is T ? (T)(E) : (T)null
```

except that `E` is only evaluated once.

The `as` operator considers only reference, nullable, boxing, and unboxing conversions. You can't use the `as` operator to perform a user-defined conversion. To do that, use a [cast expression](#cast-expression).

The following example demonstrates the usage of the `as` operator:

[!code-csharp-interactive[as operator](snippets/shared/TypeTestingAndConversionOperators.cs#AsOperator)]

> [!NOTE]
> As the preceding example shows, you need to compare the result of the `as` expression with `null` to check if the conversion is successful. Beginning with C# 7.0, you can use the [is operator](#type-testing-with-pattern-matching) both to test if the conversion succeeds and, if it succeeds, assign its result to a new variable.

## Cast expression

A cast expression of the form `(T)E` performs an explicit conversion of the result of expression `E` to type `T`. If no explicit conversion exists from the type of `E` to type `T`, a compile-time error occurs. At run time, an explicit conversion might not succeed and a cast expression might throw an exception.

The following example demonstrates explicit numeric and reference conversions:

[!code-csharp-interactive[cast expression](snippets/shared/TypeTestingAndConversionOperators.cs#Cast)]

For information about supported explicit conversions, see the [Explicit conversions](~/_csharpstandard/standard/conversions.md#113-explicit-conversions) section of the [C# language specification](~/_csharpstandard/standard/README.md). For information about how to define a custom explicit or implicit type conversion, see [User-defined conversion operators](user-defined-conversion-operators.md).

### Other usages of ()

You also use parentheses to [call a method or invoke a delegate](member-access-operators.md#invocation-expression-).

Other use of parentheses is to adjust the order in which to evaluate operations in an expression. For more information, see [C# operators](index.md).

## typeof operator

The `typeof` operator obtains the <xref:System.Type?displayProperty=nameWithType> instance for a type. The argument to the `typeof` operator must be the name of a type or a type parameter, as the following example shows:

[!code-csharp-interactive[typeof operator](snippets/shared/TypeTestingAndConversionOperators.cs#TypeOf)]

The argument mustn't be a type that requires metadata annotations. Examples include the following types:

- `dynamic`
- `string?` (or any nullable reference type)

These types aren't directly represented in metadata. The types include attributes that describe the underlying type. In both cases, you can use the underlying type. Instead of `dynamic`, you can use `object`. Instead of `string?`, you can use `string`.

You can also use the `typeof` operator with unbound generic types. The name of an unbound generic type must contain the appropriate number of commas, which is one less than the number of type parameters. The following example shows the usage of the `typeof` operator with an unbound generic type:

[!code-csharp-interactive[typeof unbound generic](snippets/shared/TypeTestingAndConversionOperators.cs#TypeOfUnboundGeneric)]

An expression can't be an argument of the `typeof` operator. To get the <xref:System.Type?displayProperty=nameWithType> instance for the run-time type of an expression result, use the <xref:System.Object.GetType%2A?displayProperty=nameWithType> method.

### Type testing with the `typeof` operator

Use the `typeof` operator to check if the run-time type of the expression result exactly matches a given type. The following example demonstrates the difference between type checking done with the `typeof` operator and the [is operator](#is-operator):

[!code-csharp[typeof vs is](snippets/shared/TypeTestingAndConversionOperators.cs#TypeCheckWithTypeOf)]

## Operator overloadability

The `is`, `as`, and `typeof` operators cannot be overloaded.

A user-defined type can't overload the `()` operator, but can define custom type conversions that can be performed by a cast expression. For more information, see [User-defined conversion operators](user-defined-conversion-operators.md).

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [The is operator](~/_csharpstandard/standard/expressions.md#121111-the-is-operator)
- [The as operator](~/_csharpstandard/standard/expressions.md#121112-the-as-operator)
- [Cast expressions](~/_csharpstandard/standard/expressions.md#1287-cast-expressions)
- [The typeof operator](~/_csharpstandard/standard/expressions.md#12716-the-typeof-operator)

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [How to safely cast by using pattern matching and the is and as operators](../../fundamentals/tutorials/safely-cast-using-pattern-matching-is-and-as-operators.md)
- [Generics in .NET](../../../standard/generics/index.md)
