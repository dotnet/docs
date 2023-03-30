---
title: "Exception-handling statements - throw and try"
description: "Use the C# throw statement to signal an occurrence of an exception. Use the C# try statements to catch and process exceptions occurred in a block of code."
ms.date: 04/01/2023
f1_keywords:
  - "throw_CSharpKeyword"
  - "try_CSharpKeyword"
  - "catch_CSharpKeyword"
  - "finally_CSharpKeyword"
  - "catch-finally_CSharpKeyword"
helpviewer_keywords:
  - "throw statement [C#]"
  - "throw expression [C#]"
  - "throw keyword [C#]"
  - "try statement [C#]"
  - "try-catch statement [C#]"
  - "try-finally statement [C#]"
  - "try-catch-finally statement [C#]"
  - "try keyword [C#]"
  - "catch keyword [C#]"
  - "finally keyword [C#]"
  - "when keyword [C#]"
---
# Exception-handling statements - `throw`, `try-catch`, `try-finally`, and `try-catch-finally`

You use the `throw` and `try` statements to work with exceptions. Use the [`throw` statement](#the-throw-statement) to throw an exception, that is, to signal an occurrence of an exception. Use the [`try` statement](#the-try-statement) to catch and handle exceptions that might occur during execution of a code block.

> [!NOTE]
> For more information about how to work with exceptions in C#, see [Exceptions and exception handling](../../fundamentals/exceptions/index.md).

## The `throw` statement

The `throw` statement throws an exception:

:::code language="csharp" source="snippets/exception-handling-statements/Program.cs" id="Throw":::

In `throw e;` statement, the result of expression `e` must be implicitly convertible to <xref:System.Exception?displayProperty=nameWithType>. You can use the built-in exception classes, for example, <xref:System.ArgumentOutOfRangeException> or <xref:System.InvalidOperationException>. You can also define your own exception classes that derive from <xref:System.Exception>. For more information, see [Creating and throwing exceptions](../../fundamentals/exceptions/creating-and-throwing-exceptions.md).

In a `catch` block of the [`try` statement](#the-try-statement), you can use a `throw;` statement to re-throw the exception that is handled by the `catch` block:

:::code language="csharp" source="snippets/exception-handling-statements/Program.cs" id="Rethrow":::

> [!NOTE]
> `throw;` preserves the original stack trace of a re-thrown exception, which is stored in the <xref:System.Exception.StackTrace?displayProperty=nameWithType> property. Opposite to that, `throw e;` updates the <xref:System.Exception.StackTrace> property of `e`.

### The `throw` expression

You can also use `throw` as an expression. This might be convenient in a number of cases, which include:

- [the conditional operator](../operators/conditional-operator.md). The following example uses a `throw` expression to throw an <xref:System.ArgumentException> if the passed string array is empty:

  :::code language="csharp" source="snippets/exception-handling-statements/Program.cs" id="ThrowExpressionConditional":::

- [the null-coalescing operator](../operators/null-coalescing-operator.md). The following example uses a `throw` expression to throw an <xref:System.ArgumentNullException> if the string to assign to a property is `null`:

  :::code language="csharp" source="snippets/exception-handling-statements/ExampleClass.cs" id="ThrowExpressionCoalescing":::

- an expression-bodied [lambda](../operators/lambda-expressions.md) or method. The following example uses a `throw` expression to throw an <xref:System.InvalidCastException> to indicate that a conversion to a <xref:System.DateTime> value is not supported:

  :::code language="csharp" source="snippets/exception-handling-statements/Program.cs" id="ThrowExpressionExpressionBody":::

## The `try` statement

You use the `try` statement in any of the following forms: [`try-catch`](#the-try-catch-statement) - to handle an exception that might occur during execution of the code inside a `try` block, [`try-finally`](#the-try-finally-statement) - to specify the code that is always executed when control leaves the `try` statement, and [`try-catch-finally`](#the-try-catch-finally-statement) - that is a combination of the preceding two forms.

### The `try-catch` statement

try-catch. Schematic example.
Multiple catch blocks.
Mention `throw;`
when condition

### The `try-finally` statement

try-finally (recommend `using`)

### The `try-catch-finally` statement

try-catch-finally

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [The `throw` statement](~/_csharpstandard/standard/statements.md#12106-the-throw-statement)
- [The `try` statement](~/_csharpstandard/standard/statements.md#1211-the-try-statement)

## See also

- [C# reference](../index.md)
- [Exceptions and exception handling](../../fundamentals/exceptions/index.md)
- [Handling and throwing exceptions in .NET](../../../standard/exceptions/index.md)
- [throw preferences (style rule IDE0016)](../../../fundamentals/code-analysis/style-rules/ide0016.md)
- <xref:System.AppDomain.FirstChanceException?displayProperty=nameWithType>
- <xref:System.AppDomain.UnhandledException?displayProperty=nameWithType>
