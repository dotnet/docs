---
title: "! (null-forgiving) operator - C# reference"
ms.date: 10/11/2019
f1_keywords: 
  - "!_CSharpKeyword"
helpviewer_keywords: 
  - "null-forgiving operator [C#]"
  - "! operator [C#]"
---
# ! (null-forgiving) operator (C# reference)

Available in C# 8.0 and later, the unary postfix `!` operator is the null-forgiving operator. In an enabled [nullable annotation context](../../nullable-references.md#nullable-annotation-context), you use the null-forgiving operator to declare that expression `x` of a reference type isn't null: `x!`. The unary prefix `!` operator is the [logical negation operator](boolean-logical-operators.md#logical-negation-operator-).

The null-forgiving operator has no effect at run time. It only affects the compiler's static flow analysis by changing the null state of the expression. At run time, expression `x!` evaluates to the result of the underlying expression `x`.

For more information about the nullable reference types feature, see [Nullable reference types](../../nullable-references.md).

## Examples

One of the use cases of the null-forgiving operator is in testing the argument validation logic. For example, consider the following class:

[!code-csharp[Person class](~/samples/csharp/language-reference/operators/NullForgivingOperator.cs#PersonClass)]

Using the [MSTest test framework](../../../core/testing/unit-testing-with-mstest.md), you can create the following test for the validation logic in the constructor:

[!code-csharp[Person test](~/samples/csharp/language-reference/operators/NullForgivingOperator.cs#TestPerson)]

Without the null-forgiving operator, the compiler generates the following warning for the preceding code: `Warning CS8625: Cannot convert null literal to non-nullable reference type`. With the use of the null-forgiving operator, you let the compiler know that passing `null` is expected and shouldn't be warned about.

You also can use the null-forgiving operator when you definitely know that an expression cannot be `null` but the compiler doesn't manage to recognize that. In the following example, if the `IsValid` method returns `true`, its argument is not `null` and you can safely dereference it:

[!code-csharp[Use null-forgiving operator](~/samples/csharp/language-reference/operators/NullForgivingOperator.cs#UseNullForgiving)]

Without the null-forgiving operator, the compiler generates the following warning for the `p.Name` code: `Warning CS8602: Dereference of a possibly null reference`.

If you can modify the `IsValid` method, you can use the [NotNullWhen](xref:System.Diagnostics.CodeAnalysis.NotNullWhenAttribute) attribute to let the compiler know that an argument of the `IsValid` method cannot be `null` when the method returns `true`:

[!code-csharp[Use an attribute](~/samples/csharp/language-reference/operators/NullForgivingOperator.cs#UseAttribute)]

In the preceding example, you don't need to use the null-forgiving operator because the compiler has enough information to find out that `p` cannot be `null` inside the `if` statement. For more information about the attributes that allow you to specify additional information about the null state of a variable, see [Upgrade APIs with attributes to define null expectations](../../nullable-attributes.md).

## C# language specification

For more information, see [The null-forgiving operator](~/_csharplang/proposals/csharp-8.0/nullable-reference-types-specification.md#the-null-forgiving-operator) section of the [draft of the nullable reference types specification](~/_csharplang/proposals/csharp-8.0/nullable-reference-types-specification.md).

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [Tutorial: Design with nullable reference types](../../tutorials/nullable-reference-types.md)
