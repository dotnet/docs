---
description: "when contextual keyword - C# reference"
title: "when contextual keyword - C# reference"
ms.date: 03/07/2017
f1_keywords: 
  - "when_CSharpKeyword"
  - "when"
helpviewer_keywords: 
  - "when keyword [C#]"
ms.assetid: dd543335-ae37-48ac-9560-bd5f047b9aea
---
# when (C# reference)

You use the `when` contextual keyword to specify a filter condition in the following contexts:

- In the `catch` statement of a [try/catch](try-catch.md) or [try/catch/finally](try-catch-finally.md) block.
- As a [case guard](../statements/selection-statements.md#case-guards) in the [`switch` statement](../statements/selection-statements.md#the-switch-statement).
- As a [case guard](../operators/switch-expression.md#case-guards) in the [`switch` expression](../operators/switch-expression.md).

## `when` in a `catch` statement

Starting with C# 6, `when` can be used in a `catch` statement to specify a condition that must be true for the handler for a specific exception to execute. Its syntax is:

```csharp
catch (ExceptionType [e]) when (expr)
```

where *expr* is an expression that evaluates to a Boolean value. If it returns `true`, the exception handler executes; if `false`, it does not.

The following example uses the `when` keyword to conditionally execute handlers for an <xref:System.Net.Http.HttpRequestException> depending on the text of the exception message.

[!code-csharp[when-with-catch](~/samples/snippets/csharp/language-reference/keywords/when/catch.cs)]

## See also

- [try/catch statement](try-catch.md)
- [try/catch/finally statement](try-catch-finally.md)
