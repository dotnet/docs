---
title: "delegate operator - C# reference"
description: "Learn about the C# delegate operator that is used to create anonymous methods."
ms.date: 09/25/2020
helpviewer_keywords:
  - "delegate [C#]"
  - "anonymous method [C#]"
---
# delegate operator (C# reference)

The `delegate` operator creates an anonymous method that can be converted to a delegate type:

[!code-csharp-interactive[anonymous method](snippets/shared/DelegateOperator.cs#AnonymousMethod)]

> [!NOTE]
> Beginning with C# 3, lambda expressions provide a more concise and expressive way to create an anonymous function. Use the [=> operator](lambda-operator.md) to construct a lambda expression:
>
> [!code-csharp-interactive[lambda expression](snippets/shared/DelegateOperator.cs#Lambda)]
>
> For more information about features of lambda expressions, for example, capturing outer variables, see [Lambda expressions](lambda-expressions.md).

When you use the `delegate` operator, you might omit the parameter list. If you do that, the created anonymous method can be converted to a delegate type with any list of  parameters, as the following example shows:

[!code-csharp-interactive[no parameter list](snippets/shared/DelegateOperator.cs#WithoutParameterList)]

That's the only functionality of anonymous methods that is not supported by lambda expressions. In all other cases, a lambda expression is a preferred way to write inline code.

Beginning with C# 9.0, you can use [discards](../../fundamentals/functional/discards.md) to specify two or more input parameters of an anonymous method that aren't used by the method:

:::code language="csharp" source="snippets/shared/DelegateOperator.cs" id="SnippetDiscards" :::

For backwards compatibility, if only a single parameter is named `_`, `_` is treated as the name of that parameter within an anonymous method.

Also beginning with C# 9.0, you can use the `static` modifier at the declaration of an anonymous method:

:::code language="csharp" source="snippets/shared/DelegateOperator.cs" id="SnippetStatic" :::

A static anonymous method can't capture local variables or instance state from enclosing scopes.

You also use the `delegate` keyword to declare a [delegate type](../builtin-types/reference-types.md#the-delegate-type).

## C# language specification

For more information, see the [Anonymous function expressions](~/_csharplang/spec/expressions.md#anonymous-function-expressions) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [=> operator](lambda-operator.md)
