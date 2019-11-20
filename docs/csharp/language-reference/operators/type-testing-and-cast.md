---
title: "Type-testing and cast operators - C# reference"
description: "Learn about C# operators that you can use to check the type of an expression result and convert it to another type if necessary."
ms.date: 06/21/2019
author: pkulikov
f1_keywords: 
  - "is_CSharpKeyword"
  - "as_CSharpKeyword"
  - "()_CSharpKeyword"
  - "typeof_CSharpKeyword"
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
# Type-testing and cast operators (C# reference)

You can use the following operators to perform type checking or type conversion:

- [is operator](#is-operator): to check if the runtime type of an expression is compatible with a given type
- [as operator](#as-operator): to explicitly convert an expression to a given type if its runtime type is compatible with that type
- [cast operator ()](#cast-operator-): to perform an explicit conversion
- [typeof operator](#typeof-operator): to obtain the <xref:System.Type?displayProperty=nameWithType> instance for a type

## is operator

The `is` operator checks if the runtime type of an expression result is compatible with a given type. Beginning with C# 7.0, the `is` operator also tests an expression result against a pattern.

The expression with the type-testing `is` operator has the following form

```csharp
E is T
```

where `E` is an expression that returns a value and `T` is the name of a type or a type parameter. `E` cannot be an anonymous method or a lambda expression.

The `E is T` expression returns `true` if the result of `E` is non-null and can be converted to type `T` by a reference conversion, a boxing conversion, or an unboxing conversion; otherwise, it returns `false`. The `is` operator doesn't consider user-defined conversions.

The following example demonstrates that the `is` operator returns `true` if the runtime type of an expression result derives from a given type, that is, there exists a reference conversion between types:

[!code-csharp[is with reference conversion](~/samples/csharp/language-reference/operators/TypeTestingAndConversionOperators.cs#IsWithReferenceConversion)]

The next example shows that the `is` operator takes into account boxing and unboxing conversions but doesn't consider [numeric conversions](../builtin-types/numeric-conversions.md):

[!code-csharp-interactive[is with int](~/samples/csharp/language-reference/operators/TypeTestingAndConversionOperators.cs#IsWithInt)]

For information about C# conversions, see the [Conversions](~/_csharplang/spec/conversions.md) chapter of the [C# language specification](~/_csharplang/spec/introduction.md).

### Type testing with pattern matching

Beginning with C# 7.0, the `is` operator also tests an expression result against a pattern. In particular, it supports the type pattern in the following form:

```csharp
E is T v
```

where `E` is an expression that returns a value, `T` is the name of a type or a type parameter, and `v` is a new local variable of type `T`. If the result of `E` is non-null and can be converted to `T` by a reference, boxing, or unboxing conversion, the `E is T v` expression returns `true` and the converted value of the result of `E` is assigned to variable `v`.

The following example demonstrates the usage of the `is` operator with the type pattern:

[!code-csharp-interactive[is with type pattern](~/samples/csharp/language-reference/operators/TypeTestingAndConversionOperators.cs#IsTypePattern)]

For more information about the type pattern and other supported patterns, see [Pattern matching with is](../keywords/is.md#pattern-matching-with-is).

## as operator

The `as` operator explicitly converts the result of an expression to a given reference or nullable value type. If the conversion is not possible, the `as` operator returns `null`. Unlike the [cast operator ()](#cast-operator-), the `as` operator never throws an exception.

The expression of the form

```csharp
E as T
```

where `E` is an expression that returns a value and `T` is the name of a type or a type parameter, produces the same result as

```csharp
E is T ? (T)(E) : (T)null
```

except that `E` is only evaluated once.

The `as` operator considers only reference, nullable, boxing, and unboxing conversions. You cannot use the `as` operator to perform a user-defined conversion. To do that, use the [cast operator ()](#cast-operator-).

The following example demonstrates the usage of the `as` operator:

[!code-csharp-interactive[as operator](~/samples/csharp/language-reference/operators/TypeTestingAndConversionOperators.cs#AsOperator)]

> [!NOTE]
> As the preceding example shows, you need to compare the result of the `as` expression with `null` to check if the conversion is successful. Beginning with C# 7.0, you can use the [is operator](#type-testing-with-pattern-matching) both to test if the conversion succeeds and, if it succeeds, assign its result to a new variable.

## Cast operator ()

A cast expression of the form `(T)E` performs an explicit conversion of the result of expression `E` to type `T`. If no explicit conversion exists from the type of `E` to type `T`, a compile-time error occurs. At run time, an explicit conversion might not succeed and a cast expression might throw an exception.

The following example demonstrates explicit numeric and reference conversions:

[!code-csharp-interactive[cast expression](~/samples/csharp/language-reference/operators/TypeTestingAndConversionOperators.cs#Cast)]

For information about supported explicit conversions, see the [Explicit conversions](~/_csharplang/spec/conversions.md#explicit-conversions) section of the [C# language specification](~/_csharplang/spec/introduction.md). For information about how to define a custom explicit or implicit type conversion, see [User-defined conversion operators](user-defined-conversion-operators.md).

### Other usages of ()

You also use parentheses to [call a method or invoke a delegate](member-access-operators.md#invocation-operator-).

Other use of parentheses is to adjust the order in which to evaluate operations in an expression. For more information, see [C# operators](index.md).

## typeof operator

The `typeof` operator obtains the <xref:System.Type?displayProperty=nameWithType> instance for a type. The argument to the `typeof` operator must be the name of a type or a type parameter, as the following example shows:

[!code-csharp-interactive[typeof operator](~/samples/csharp/language-reference/operators/TypeTestingAndConversionOperators.cs#TypeOf)]

You also can use the `typeof` operator with unbound generic types. The name of an unbound generic type must contain the appropriate number of commas, which is one less than the number of type parameters. The following example shows the usage of the `typeof` operator with an unbound generic type:

[!code-csharp-interactive[typeof unbound generic](~/samples/csharp/language-reference/operators/TypeTestingAndConversionOperators.cs#TypeOfUnboundGeneric)]

An expression cannot be an argument of the `typeof` operator. To get the <xref:System.Type?displayProperty=nameWithType> instance for the runtime type of an expression result, use the <xref:System.Object.GetType%2A?displayProperty=nameWithType> method.

### Type testing with the `typeof` operator

Use the `typeof` operator to check if the runtime type of the expression result exactly matches a given type. The following example demonstrates the difference between type checking performed with the `typeof` operator and the [is operator](#is-operator):

[!code-csharp[typeof vs is](~/samples/csharp/language-reference/operators/TypeTestingAndConversionOperators.cs#TypeCheckWithTypeOf)]

## Operator overloadability

The `is`, `as`, and `typeof` operators cannot be overloaded.

A user-defined type cannot overload the `()` operator, but can define custom type conversions that can be performed by a cast expression. For more information, see [User-defined conversion operators](user-defined-conversion-operators.md).

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [The is operator](~/_csharplang/spec/expressions.md#the-is-operator)
- [The as operator](~/_csharplang/spec/expressions.md#the-as-operator)
- [Cast expressions](~/_csharplang/spec/expressions.md#cast-expressions)
- [The typeof operator](~/_csharplang/spec/expressions.md#the-typeof-operator)

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [How to safely cast by using pattern matching and the is and as operators](../../how-to/safely-cast-using-pattern-matching-is-and-as-operators.md)
- [Generics in .NET](../../../standard/generics/index.md)
