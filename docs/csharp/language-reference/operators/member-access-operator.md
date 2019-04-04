---
title: ". operator - C# Reference"
ms.custom: seodec18
ms.date: 02/25/2019
f1_keywords: 
  - "._CSharpKeyword"
helpviewer_keywords: 
  - "member access operator (.) [C#]"
  - ". operator [C#]"
  - "dot operator (.) [C#]"
ms.assetid: a1f54b52-b686-4ae5-a48e-a2a9ebd0eb7b
---
# . operator (C# Reference)

The dot, `.`, is typically used for member access.

You use the `.` token to access a member of a namespace or a type, as the following examples demonstrate:

- Use `.` to access a nested namespace within a namespace, as the following example of a [`using` directive](../keywords/using-directive.md) shows:

  [!code-csharp[nested namespaces](~/samples/snippets/csharp/language-reference/operators/MemberAccessExamples.cs#NestedNamespace)]

- Use `.` to form a *qualified name* to access a type within a namespace, as the following code shows:

  [!code-csharp[qualified name](~/samples/snippets/csharp/language-reference/operators/MemberAccessExamples.cs#QualifiedName)]

  Use the [`using` directive](../keywords/using-directive.md) to make the use of qualified names optional.

- Use `.` to access [type members](../../programming-guide/classes-and-structs/index.md#members), static and non-static, as the following code shows:

  [!code-csharp-interactive[type members](~/samples/snippets/csharp/language-reference/operators/MemberAccessExamples.cs#TypeMemberAccess)]

You can also use `.` to invoke an [extension method](../../programming-guide/classes-and-structs/extension-methods.md).

## Operator overloadability

The operator `.` cannot be overloaded.

## C# language specification

For more information, see the [Member access](~/_csharplang/spec/expressions.md#member-access) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [?. and ?[] operators](null-conditional-operators.md)