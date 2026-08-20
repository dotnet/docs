---
title: "The lambda operator - The `=>` operator is used to define a lambda expression"
description: "The C# => operator defines lambda expressions and expression bodied members. Lambda expressions define a block of code used as data."
ms.date: 08/20/2026
ai-usage: ai-assisted
f1_keywords: 
  - "=>_CSharpKeyword"
helpviewer_keywords: 
  - "lambda operator [C#]"
  - "=> operator [C#]"
  - "lambda expressions [C#], => operator"
---
# Lambda expression (`=>`) operator defines a lambda expression

The `=>` token is supported in two forms: as the [lambda operator](#lambda-operator) and as a separator of a member name and the member implementation in an [expression body definition](#expression-body-definition).

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

## Lambda operator

In [lambda expressions](lambda-expressions.md), the lambda operator `=>` separates the input parameters on the left side from the lambda body on the right side.

The following example uses the [LINQ](../../linq/index.md) feature with method syntax to demonstrate the usage of lambda expressions:

:::code language="csharp" source="snippets/shared/LambdaOperator.cs" id="InferredTypes":::

Input parameters of a lambda expression are strongly typed at compile time. When the compiler infers the types of input parameters, like in the preceding example, you can omit type declarations. If you need to specify the type of input parameters, you must specify the type for each parameter, as the following example shows:

:::code language="csharp" source="snippets/shared/LambdaOperator.cs" id="ExplicitTypes":::

The following example shows how to define a lambda expression without input parameters:

:::code language="csharp" source="snippets/shared/LambdaOperator.cs" id="WithoutInput":::

For more information, see [Lambda expressions](lambda-expressions.md).

## Expression body definition

An expression body definition uses the following general syntax:

```csharp
member => expression;
```

For a member that returns a value, the expression's result must be implicitly convertible to the member's return type. For a `void` member, constructor, finalizer, or `set`, `init`, `add`, or `remove` accessor, the body must be a [*statement expression*](~/_csharpstandard/standard/statements.md#137-expression-statements). A statement expression can be an assignment, method invocation, object creation, increment or decrement operation, or `await` expression. Its result, if any, is discarded.

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

You can use expression body definitions for the following members:

- **Methods and local functions:** A member that returns a value has the form `T M() => expression;`. A `void` member has the form `void M() => statementExpression;`. For more information, see [Methods](../../programming-guide/classes-and-structs/methods.md) and [Local functions](../../programming-guide/classes-and-structs/local-functions.md).
- **Operators:** An operator has the form `public static T operator +(T left, T right) => expression;`. For more information, see [Operator overloading](operator-overloading.md).
- **Properties and indexers:** A read-only property or indexer has the form `T P => expression;` or `T this[int i] => expression;`. You can also use expression bodies for individual accessors. A `get` accessor has the form `get => expression;`. A `set` or `init` accessor has the form `set => statementExpression;` or `init => statementExpression;`. For more information, see [Properties](../../programming-guide/classes-and-structs/properties.md) and [Indexers](../../programming-guide/indexers/index.md).
- **Constructors and finalizers:** These members have the form `C() => statementExpression;` or `~C() => statementExpression;`. For more information, see [Constructors](../../programming-guide/classes-and-structs/constructors.md) and [Finalizers](../../programming-guide/classes-and-structs/finalizers.md).
- **Event accessors:** An `add` or `remove` accessor has the form `add => statementExpression;` or `remove => statementExpression;`. For more information, see [Events](../../programming-guide/events/index.md).

## Operator overloadability

You can't overload the `=>` operator.

## C# language specification

For more information about the lambda operator, see the [Anonymous function expressions](~/_csharpstandard/standard/expressions.md#1222-anonymous-function-expressions) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [C# operators and expressions](index.md)
