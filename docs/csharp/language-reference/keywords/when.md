---
description: "when contextual keyword - C# reference"
title: "when contextual keyword"
ms.date: 01/22/2026
f1_keywords: 
  - "when_CSharpKeyword"
  - "when"
helpviewer_keywords: 
  - "when keyword [C#]"
---
# when (C# reference)

Use the `when` contextual keyword to specify a filter condition in the following contexts:

- In a catch clause of a [`try-catch`](../statements/exception-handling-statements.md#the-try-catch-statement) or [`try-catch-finally`](../statements/exception-handling-statements.md#the-try-catch-finally-statement) statement.
- As a [case guard](../statements/selection-statements.md#case-guards) in the [`switch` statement](../statements/selection-statements.md#the-switch-statement).
- As a [case guard](../operators/switch-expression.md#case-guards) in the [`switch` expression](../operators/switch-expression.md).

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

## `when` in a catch clause

Use the `when` keyword in a catch clause to specify a condition that must be true for the handler for a specific exception to execute. Its syntax is:

```csharp
catch (ExceptionType [e]) when (expr)
```

where *expr* is an expression that evaluates to a Boolean value. If it returns `true`, the exception handler executes; if `false`, it doesn't.

Exception filters with the `when` keyword provide several advantages over traditional exception handling approaches, including better debugging support and performance benefits. For a detailed explanation of how exception filters preserve the call stack and improve debugging, see [Exception filters vs. traditional exception handling](../statements/exception-handling-statements.md#exception-filters-vs-traditional-exception-handling).

The following example uses the `when` keyword to conditionally execute handlers for an <xref:System.Net.Http.HttpRequestException> depending on the text of the exception message.

:::code language="csharp" source="./snippets/catch.cs":::

## See also

- [C# keywords](index.md)
