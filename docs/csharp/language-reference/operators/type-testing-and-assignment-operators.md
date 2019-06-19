---
title: "Type-testing and assignment operators - C# reference"
description: "Learn about C# operators that you can use to check the type of an expression and assign an expression result to a variable, a property, or an indexer element."
ms.date: 06/21/2019
author: pkulikov
f1_keywords: 
  - "=_CSharpKeyword"
  - "()_CSharpKeyword"
  - "is_CSharpKeyword"
  - "as_CSharpKeyword"
helpviewer_keywords: 
  - "type-testing operators [C#]"
  - "assignment operator [C#]"
  - "ref assignment operator [C#]"
  - "= operator [C#]"
  - "type conversion [C#]"
  - "cast operator [C#]"
  - "cast expression [C#]"
  - "() operator [C#]"
  - "is operator [C#]"
  - "as operator [C#]"
---
# Type-testing and assignment operators (C# reference)

Introduction.

## is operator

The `is` operator checks if a runtime type of an expression result is compatible with a given type. Starting with C# 7.0, the `is` operator also tests an expression result against a pattern.

The expression with the type-testing `is` operator has the following form

```csharp
E is T
```

where `E` is an expression that returns a value and `T` is a name of a type or a type argument. `E` cannot be an anonymous method or a lambda expression.

The `E is T` expression returns `true` if the result of `E` is non-null and can be converted to type `T` by a reference conversion, a boxing conversion, or an unboxing conversion; otherwise, it returns `false`. In particular, the `is` operator doesn't consider user-defined conversions and numeric conversions.

The following example demonstrates that the `is` operator returns `true` if a runtime type of an expression result derives from a given type, that is, there exists a reference conversion:

[!code-csharp[is with reference conversion](~/samples/csharp/language-reference/operators/TypeTestingAndConversionOperators.cs#IsWithReferenceConversion)]

The next example shows that the `is` operator doesn't consider numeric conversions but takes into account boxing and unboxing conversions:

[!code-csharp-interactive[is with int](~/samples/csharp/language-reference/operators/TypeTestingAndConversionOperators.cs#IsWithInt)]

For information about C# conversions, see the [Conversions](~/_csharplang/spec/conversions.md) chapter of the [C# language specification](~/_csharplang/spec/introduction.md).

### Type-testing with pattern matching

Starting with C# 7.0, the `is` operator also tests an expression result against a pattern. In particular, it supports the type pattern in the following form:

```csharp
E is T v
```

where `E` is an expression that returns a value, `T` is a name of a type or a type argument, and `v` is a new local variable of type `T`. If the result of `E` is non-null and can be converted to `T` by a reference, boxing, or unboxing conversion, the `E is T v` expression returns `true` and the converted value of the result of `E` is assigned to variable `v`.

The following example demonstrates the usage of the `is` operator with the type pattern:

[!code-csharp-interactive[is with type pattern](~/samples/csharp/language-reference/operators/TypeTestingAndConversionOperators.cs#IsTypePattern)]

For more information about the type pattern and other supported patterns, see [Pattern matching with is](../keywords/is.md#pattern-matching-with-is).

## as operator

The `as` operator explicitly converts the result of an expression to a given reference or nullable value type. If the conversion is not possible, the `as` operator returns `null`. Unlike the [cast operator ()](#cast-operator-), the `as` operator never throws an exception.

The expression of the form

```csharp
E as T
```

where `E` is an expression that returns a value and `T` is a name of a type or a type argument, produces the same result as

```csharp
E is T ? (T)(E) : (T)null
```

except that `E` is only evaluated once.

The `as` operator considers only reference, nullable, boxing, and unboxing conversions. In particular, you cannot use the `as` operator to perform a user-defined conversion. To do that, use the [cast operator ()](#cast-operator-).

The following example demonstrates the usage of the `as` operator:

[!code-csharp-interactive[as operator](~/samples/csharp/language-reference/operators/TypeTestingAndConversionOperators.cs#AsOperator)]

> [!NOTE]
> As the preceding example shows, you need to compare the result of the `as` expression with `null` to check if the conversion is successful. Starting with C# 7.0, you can use the [is operator](#type-testing-with-pattern-matching) both to test if the conversion succeeds and, if it succeeds, assign its result to a new variable.

## Cast operator ()

A cast expression of the form `(T)E` performs an explicit conversion of the value of expression `E` to type `T`. If no explicit conversion exists from the type of `E` to type `T`, a compile-time error occurs. At run time, an explicit conversion might not succeed and a cast expression might throw an exception.

The following example demonstrates explicit numeric and reference conversions:

[!code-csharp-interactive[cast expression](~/samples/csharp/language-reference/operators/TypeTestingAndConversionOperators.cs#Cast)]

For information about supported explicit conversions, see the [Explicit conversions](~/_csharplang/spec/conversions.md#explicit-conversions) section of the [C# language specification](~/_csharplang/spec/introduction.md). For information about how to define a custom explicit or implicit type conversion, see the [explicit](../keywords/explicit.md) or [implicit](../keywords/implicit.md) keyword article, respectively.

### Other usages of ()

You also use parentheses to [call a method or invoke a delegate](member-access-operators.md#invocation-operator-).

Other use of parentheses is to specify the order in which to evaluate operations in an expression. For more information, see the [Adding parentheses](../../programming-guide/statements-expressions-operators/operators.md#adding-parentheses) section of the [Operators](../../programming-guide/statements-expressions-operators/operators.md) article. For the list of operators ordered by precedence level, see [C# operators](index.md).

## typeof operator

Text.

## Assignment operator =

The `=` operator assigns the value of its right-hand operand to a variable, a [property](../../programming-guide/classes-and-structs/properties.md), or an [indexer](../../../csharp/programming-guide/indexers/index.md) element given by its left-hand operand. The result of an assignment expression is the value assigned to the left-hand operand. The type of the right-hand operand must be the same as the type of the left-hand operand or implicitly convertible to it.

The assignment operator is right-associative, that is, an expression of the form

```csharp
a = b = c
```

is evaluated as

```csharp
a = (b = c)
```

The following example demonstrates the usage of the assignment operator with a local variable, a property, and an indexer element as its left-hand operand:

[!code-csharp-interactive[simple assignment](~/samples/csharp/language-reference/operators/AssignmentOperator.cs#Simple)]

## ref assignment operator

Beginning with C# 7.3, you can use the ref assignment operator `= ref` to reassign a [ref local](../keywords/ref.md#ref-locals) or [ref readonly local](../keywords/ref.md#ref-readonly-locals) variable. The following example demonstrates the usage of the ref assignment operator:

[!code-csharp[ref assignment operator](~/samples/csharp/language-reference/operators/AssignmentOperator.cs#RefAssignment)]

In the case of the ref assignment operator, the type of its both operands must be the same.

For more information, see the [feature proposal note](~/_csharplang/proposals/csharp-7.3/ref-local-reassignment.md).

## Compound assignment

For a binary operator `op`, a compound assignment expression of the form

```csharp
x op= y
```

is equivalent to

```csharp
x = x op y
```

except that `x` is only evaluated once.

Compound assignment is supported by [arithmetic](arithmetic-operators.md#compound-assignment), [Boolean logical](boolean-logical-operators.md#compound-assignment), and [bitwise logical and shift](bitwise-and-shift-operators.md#compound-assignment) operators.

## Operator overloadability

The `is`, `as`, and `typeof` operators are not overloadable.

A user-defined type cannot overload the `()` operator, but can define custom type conversions which can be performed by a cast expression. For more information, see the [explicit](../keywords/explicit.md) and [implicit](../keywords/implicit.md) keyword articles.

A user-defined type cannot overload the assignment operator `=`. However, a user-defined type can define an implicit conversion to another type. That way, the value of a user-defined type can be assigned to a variable, a property, or an indexer element of another type. For more information, see the [implicit](../keywords/implicit.md) keyword article.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [The is operator](~/_csharplang/spec/expressions.md#the-is-operator)
- [The as operator](~/_csharplang/spec/expressions.md#the-as-operator)
- [Cast expressions](~/_csharplang/spec/expressions.md#cast-expressions)
- [Assignment operators](~/_csharplang/spec/expressions.md#assignment-operators)

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [How to: safely cast by using pattern matching and the is and as operators](../../how-to/safely-cast-using-pattern-matching-is-and-as-operators.md)
