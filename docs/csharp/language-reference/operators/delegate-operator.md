---
title: "delegate operator - Create an anonymous method that can be converted to a delegate type."
description: "The C# delegate operator that is used to create anonymous methods. These types can be used for `Func<>` and `Action<>` parameters in many .NET APIs."
ms.date: 11/29/2022
helpviewer_keywords:
  - "delegate [C#]"
  - "anonymous method [C#]"
---
# delegate operator

The `delegate` operator creates an anonymous method that can be converted to a delegate type. An anonymous method can be converted to types such as <xref:System.Action?displayProperty=nameWithType> and <xref:System.Func%601?displayProperty=nameWithType> types used as arguments to many methods.

[!code-csharp-interactive[anonymous method](snippets/shared/DelegateOperator.cs#AnonymousMethod)]

> [!NOTE]
> Lambda expressions provide a more concise and expressive way to create an anonymous function. Use the [=> operator](lambda-operator.md) to construct a lambda expression:
>
> [!code-csharp-interactive[lambda expression](snippets/shared/DelegateOperator.cs#Lambda)]
>
> For more information about features of lambda expressions, for example, capturing outer variables, see [Lambda expressions](lambda-expressions.md).

When you use the `delegate` operator, you might omit the parameter list. If you do that, the created anonymous method can be converted to a delegate type with any list of  parameters, as the following example shows:

[!code-csharp-interactive[no parameter list](snippets/shared/DelegateOperator.cs#WithoutParameterList)]

That's the only functionality of anonymous methods that isn't supported by lambda expressions. In all other cases, a lambda expression is a preferred way to write inline code.

Beginning with C# 9.0, you can use [discards](../../fundamentals/functional/discards.md) to specify two or more input parameters of an anonymous method that aren't used by the method:

:::code language="csharp" source="snippets/shared/DelegateOperator.cs" id="SnippetDiscards" :::

For backwards compatibility, if only a single parameter is named `_`, `_` is treated as the name of that parameter within an anonymous method.

Also beginning with C# 9.0, you can use the `static` modifier at the declaration of an anonymous method:

:::code language="csharp" source="snippets/shared/DelegateOperator.cs" id="SnippetStatic" :::

A static anonymous method can't capture local variables or instance state from enclosing scopes.

You also use the `delegate` keyword to declare a [delegate type](../builtin-types/reference-types.md#the-delegate-type).

Beginning with C# 11, the compiler may cache the delegate object created from a method group. Consider the following method:

```csharp
static void StaticFunction() { }
```

When you assign the method group to a delegate, the compiler will cache the delegate:

```csharp
Action a = StaticFunction;
```

Before C# 11, you'd need to use a lambda expression to reuse a single delegate object:

```csharp
Action a = () => StaticFunction();
```

## C# language specification

For more information, see the [Anonymous function expressions](~/_csharpstandard/standard/expressions.md#1117-anonymous-function-expressions) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [=> operator](lambda-operator.md)
