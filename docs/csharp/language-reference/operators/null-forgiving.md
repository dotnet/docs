---
description: "! (null-forgiving) operator - C# reference"
title: "! (null-forgiving) operator - C# reference"
ms.date: 10/11/2019
f1_keywords: 
  - "nullForgiving_CSharpKeyword"
helpviewer_keywords: 
  - "null-forgiving operator [C#]"
  - "! operator [C#]"
---
# ! (null-forgiving) operator (C# reference)

Available in C# 8.0 and later, the unary postfix `!` operator is the null-forgiving operator. In an enabled [nullable annotation context](../../nullable-references.md#nullable-annotation-context), you use the null-forgiving operator to declare that expression `x` of a reference type isn't `null`: `x!`. The unary prefix `!` operator is the [logical negation operator](boolean-logical-operators.md#logical-negation-operator-).

The null-forgiving operator has no effect at run time. It only affects the compiler's static flow analysis by changing the null state of the expression. At run time, expression `x!` evaluates to the result of the underlying expression `x`.

> [!NOTE]
> In C# 8, the null-forgiving operator terminates the list of preceding [null-conditional](member-access-operators.md#null-conditional-operators--and-) operations. For example, the expression `x?.y!.z` is parsed as `(x?.y)!.z`. Due to this interpretation, `z` is evaluated even if `x` is `null`, which may result in a <xref:System.NullReferenceException>.

For more information about the nullable reference types feature, see [Nullable reference types](../builtin-types/nullable-reference-types.md).

## Examples

One of the use cases of the null-forgiving operator is in testing the argument validation logic. For example, consider the following class:

[!code-csharp[Person class](snippets/shared/NullForgivingOperator.cs#PersonClass)]

Using the [MSTest test framework](../../../core/testing/unit-testing-with-mstest.md), you can create the following test for the validation logic in the constructor:

[!code-csharp[Person test](snippets/shared/NullForgivingOperator.cs#TestPerson)]

Without the null-forgiving operator, the compiler generates the following warning for the preceding code: `Warning CS8625: Cannot convert null literal to non-nullable reference type`. By using the null-forgiving operator, you inform the compiler that passing `null` is expected and shouldn't be warned about.

You can also use the null-forgiving operator when you definitely know that an expression cannot be `null` but the compiler doesn't manage to recognize that. In the following example, if the `IsValid` method returns `true`, its argument is not `null` and you can safely dereference it:

[!code-csharp[Use null-forgiving operator](snippets/shared/NullForgivingOperator.cs#UseNullForgiving)]

Without the null-forgiving operator, the compiler generates the following warning for the `p.Name` code: `Warning CS8602: Dereference of a possibly null reference`.

If you can modify the `IsValid` method, you can use the [NotNullWhen](xref:System.Diagnostics.CodeAnalysis.NotNullWhenAttribute) attribute to inform the compiler that an argument of the `IsValid` method cannot be `null` when the method returns `true`:

[!code-csharp[Use an attribute](snippets/shared/NullForgivingOperator.cs#UseAttribute)]

In the preceding example, you don't need to use the null-forgiving operator because the compiler has enough information to find out that `p` cannot be `null` inside the `if` statement. For more information about the attributes that allow you to provide additional information about the null state of a variable, see [Upgrade APIs with attributes to define null expectations](../attributes/nullable-analysis.md).

## C# language specification

For more information, see [The null-forgiving operator](~/_csharplang/proposals/csharp-8.0/nullable-reference-types-specification.md#the-null-forgiving-operator) section of the [draft of the nullable reference types specification](~/_csharplang/proposals/csharp-8.0/nullable-reference-types-specification.md).

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [Tutorial: Design with nullable reference types](../../tutorials/nullable-reference-types.md)
