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

The following table summarizes where you can use expression body definitions:

| Member | Syntax and body requirement | More information |
|---|---|---|
| Method or local function that returns a value | `T M() => expression;` The result must convert to `T`. | [Methods](../../programming-guide/classes-and-structs/methods.md), [local functions](../../programming-guide/classes-and-structs/local-functions.md) |
| `void` method or local function | `void M() => statementExpression;` | [Methods](../../programming-guide/classes-and-structs/methods.md), [local functions](../../programming-guide/classes-and-structs/local-functions.md) |
| Operator | `public static T operator +(T left, T right) => expression;` The result must convert to `T`. | [Operator overloading](operator-overloading.md) |
| Read-only property or indexer | `T P => expression;` or `T this[int i] => expression;` The result must convert to `T`. | [Properties](../../programming-guide/classes-and-structs/properties.md), [indexers](../../programming-guide/indexers/index.md) |
| Property or indexer accessor | `get => expression;` returns the value. `set => statementExpression;` and `init => statementExpression;` perform an operation. | [Properties](../../programming-guide/classes-and-structs/properties.md), [indexers](../../programming-guide/indexers/index.md) |
| Constructor or finalizer | `C() => statementExpression;` or `~C() => statementExpression;` | [Constructors](../../programming-guide/classes-and-structs/constructors.md), [finalizers](../../programming-guide/classes-and-structs/finalizers.md) |
| Event accessor | `add => statementExpression;` or `remove => statementExpression;` | [Events](../../programming-guide/events/index.md) |

## Operator overloadability

You can't overload the `=>` operator.

## C# language specification

For more information about the lambda operator, see the [Anonymous function expressions](~/_csharpstandard/standard/expressions.md#1222-anonymous-function-expressions) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [C# operators and expressions](index.md)
