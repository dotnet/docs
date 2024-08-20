---
title: "The lambda operator - The `=>` operator is used to define a lambda expression"
description: "The C# => operator defines lambda expressions and expression bodied members. Lambda expressions define a block of code used as data."
ms.date: 11/28/2022
f1_keywords: 
  - "=>_CSharpKeyword"
helpviewer_keywords: 
  - "lambda operator [C#]"
  - "=> operator [C#]"
  - "lambda expressions [C#], => operator"
---
# Lambda expression (`=>`) operator defines a lambda expression

The `=>` token is supported in two forms: as the [lambda operator](#lambda-operator) and as a separator of a member name and the member implementation in an [expression body definition](#expression-body-definition).

## Lambda operator

In [lambda expressions](lambda-expressions.md), the lambda operator `=>` separates the input parameters on the left side from the lambda body on the right side.

The following example uses the [LINQ](/dotnet/csharp/linq/) feature with method syntax to demonstrate the usage of lambda expressions:

[!code-csharp-interactive[infer types of input variables](snippets/shared/LambdaOperator.cs#InferredTypes)]

Input parameters of a lambda expression are strongly typed at compile time. When the compiler can infer the types of input parameters, like in the preceding example, you may omit type declarations. If you need to specify the type of input parameters, you must do that for each parameter, as the following example shows:

[!code-csharp-interactive[specify types of input variables](snippets/shared/LambdaOperator.cs#ExplicitTypes)]

The following example shows how to define a lambda expression without input parameters:

[!code-csharp-interactive[without input variables](snippets/shared/LambdaOperator.cs#WithoutInput)]

For more information, see [Lambda expressions](lambda-expressions.md).

## Expression body definition

An expression body definition has the following general syntax:

```csharp
member => expression;
```

where `expression` is a valid expression. The return type of `expression` must be implicitly convertible to the member's return type. If the member:

- Has a `void` return type or
- Is a:
  - Constructor
  - Finalizer
  - Property or indexer `set` accessor

`expression` must be a [*statement expression*](~/_csharpstandard/standard/statements.md#137-expression-statements). Because the expression's result is discarded, the return type of that expression can be any type.

The following example shows an expression body definition for a `Person.ToString` method:

```csharp
public override string ToString() => $"{fname} {lname}".Trim();
```

It's a shorthand version of the following method definition:

```csharp
public override string ToString()
{
   return $"{fname} {lname}".Trim();
}
```

You can create expression body definitions for methods, operators, read-only properties, constructors, finalizers, and property and indexer accessors. For more information, see [Expression-bodied members](../../programming-guide/statements-expressions-operators/expression-bodied-members.md).

## Operator overloadability

The `=>` operator can't be overloaded.

## C# language specification

For more information about the lambda operator, see the [Anonymous function expressions](~/_csharpstandard/standard/expressions.md#1219-anonymous-function-expressions) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [C# operators and expressions](index.md)
