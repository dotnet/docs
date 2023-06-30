---
title: "Exception-handling statements - throw and try, catch, finally"
description: "Use the C# throw statement to signal an occurrence of an exception. Use the C# try statements to catch and process exceptions occurred in a block of code."
ms.date: 04/21/2023
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

You use the `throw` and `try` statements to work with exceptions. Use the [`throw` statement](#the-throw-statement) to throw an exception. Use the [`try` statement](#the-try-statement) to catch and handle exceptions that might occur during execution of a code block.

## The `throw` statement

The `throw` statement throws an exception:

:::code language="csharp" source="snippets/exception-handling-statements/Program.cs" id="Throw":::

In a `throw e;` statement, the result of expression `e` must be implicitly convertible to <xref:System.Exception?displayProperty=nameWithType>.

You can use the built-in exception classes, for example, <xref:System.ArgumentOutOfRangeException> or <xref:System.InvalidOperationException>. .NET also provides the helper methods to throw exceptions in certain conditions: <xref:System.ArgumentNullException.ThrowIfNull%2A?displayProperty=nameWithType> and <xref:System.ArgumentException.ThrowIfNullOrEmpty%2A?displayProperty=nameWithType>. You can also define your own exception classes that derive from <xref:System.Exception?displayProperty=nameWithType>. For more information, see [Creating and throwing exceptions](../../fundamentals/exceptions/creating-and-throwing-exceptions.md).

Inside a [`catch` block](#the-try-catch-statement), you can use a `throw;` statement to re-throw the exception that is handled by the `catch` block:

:::code language="csharp" source="snippets/exception-handling-statements/Program.cs" id="Rethrow":::

> [!NOTE]
> `throw;` preserves the original stack trace of the exception, which is stored in the <xref:System.Exception.StackTrace?displayProperty=nameWithType> property. Opposite to that, `throw e;` updates the <xref:System.Exception.StackTrace> property of `e`.

When an exception is thrown, the common language runtime (CLR) looks for the [`catch` block](#the-try-catch-statement) that can handle this exception. If the currently executed method doesn't contain such a `catch` block, the CLR looks at the method that called the current method, and so on up the call stack. If no `catch` block is found, the CLR terminates the executing thread. For more information, see the [How exceptions are handled](~/_csharpstandard/standard/exceptions.md#214-how-exceptions-are-handled) section of the [C# language specification](~/_csharpstandard/standard/README.md).

### The `throw` expression

You can also use `throw` as an expression. This might be convenient in a number of cases, which include:

- [the conditional operator](../operators/conditional-operator.md). The following example uses a `throw` expression to throw an <xref:System.ArgumentException> when the passed array `args` is empty:

  :::code language="csharp" source="snippets/exception-handling-statements/Program.cs" id="ThrowExpressionConditional":::

- [the null-coalescing operator](../operators/null-coalescing-operator.md). The following example uses a `throw` expression to throw an <xref:System.ArgumentNullException> when the string to assign to a property is `null`:

  :::code language="csharp" source="snippets/exception-handling-statements/ExampleClass.cs" id="ThrowExpressionCoalescing":::

- an expression-bodied [lambda](../operators/lambda-expressions.md) or method. The following example uses a `throw` expression to throw an <xref:System.InvalidCastException> to indicate that a conversion to a <xref:System.DateTime> value is not supported:

  :::code language="csharp" source="snippets/exception-handling-statements/Program.cs" id="ThrowExpressionExpressionBody":::

## The `try` statement

You can use the `try` statement in any of the following forms: [`try-catch`](#the-try-catch-statement) - to handle exceptions that might occur during execution of the code inside a `try` block, [`try-finally`](#the-try-finally-statement) - to specify the code that is executed when control leaves the `try` block, and [`try-catch-finally`](#the-try-catch-finally-statement) - as a combination of the preceding two forms.

### The `try-catch` statement

Use the `try-catch` statement to handle exceptions that might occur during execution of a code block. Place the code where an exception might occur inside a `try` block. Use a *catch clause* to specify the base type of exceptions you want to handle in the corresponding `catch` block:

:::code language="csharp" source="snippets/exception-handling-statements/Program.cs" id="TryCatch":::

You can provide several catch clauses:

:::code language="csharp" source="snippets/exception-handling-statements/Program.cs" id="TryMultipleCatch":::

When an exception occurs, catch clauses are examined in the specified order, from top to bottom. At maximum, only one `catch` block is executed for any thrown exception. As the preceding example also shows, you can omit declaration of an exception variable and specify only the exception type in a catch clause. A catch clause without any specified exception type matches any exception and, if present, must be the last catch clause.

If you want to re-throw a caught exception, use the [`throw` statement](#the-throw-statement), as the following example shows:

:::code language="csharp" source="snippets/exception-handling-statements/Program.cs" id="RethrowInCatch":::

> [!NOTE]
> `throw;` preserves the original stack trace of the exception, which is stored in the <xref:System.Exception.StackTrace?displayProperty=nameWithType> property. Opposite to that, `throw e;` updates the <xref:System.Exception.StackTrace> property of `e`.

#### A `when` exception filter

Along with an exception type, you can also specify an exception filter that further examines an exception and decides if the corresponding `catch` block handles that exception. An exception filter is a Boolean expression that follows the `when` keyword, as the following example shows:

:::code language="csharp" source="snippets/exception-handling-statements/Program.cs" id="WhenFilter":::

The preceding example uses an exception filter to provide a single `catch` block to handle exceptions of two specified types.

You can provide several `catch` clauses for the same exception type if they distinguish by exception filters. One of those clauses might have no exception filter. If such a clause exists, it must be the last of the clauses that specify that exception type.

If a `catch` clause has an exception filter, it can specify the exception type that is the same as or less derived than an exception type of a `catch` clause that appears after it. For example, if an exception filter is present, a `catch (Exception e)` clause doesn't need to be the last clause.

#### Exceptions in async and iterator methods

If an exception occurs in an [async function](../keywords/async.md), it propagates to the caller of the function when you [await](../operators/await.md) the result of the function, as the following example shows:

:::code language="csharp" source="snippets/exception-handling-statements/ExceptionFromAsyncExample.cs" id="ExceptionFromAsync":::

If an exception occurs in an [iterator method](../../iterators.md), it propagates to the caller only when the iterator advances to the next element.

### The `try-finally` statement

In a `try-finally` statement, the `finally` block is executed when control leaves the `try` block. Control might leave the `try` block as a result of

- normal execution,
- execution of a [jump statement](jump-statements.md) (that is, `return`, `break`, `continue`, or `goto`), or
- propagation of an exception out of the `try` block.

The following example uses the `finally` block to reset the state of an object before control leaves the method:

:::code language="csharp" source="snippets/exception-handling-statements/ExampleClass.cs" id="TryFinally":::

You can also use the `finally` block to clean up allocated resources used in the `try` block.

> [!NOTE]
> When the type of a resource implements the <xref:System.IDisposable> or <xref:System.IAsyncDisposable> interface, consider the [`using` statement](using.md). The `using` statement ensures that acquired resources are disposed when control leaves the `using` statement. The compiler transforms a `using` statement into a `try-finally` statement.

In almost all cases `finally` blocks are executed. The only cases where `finally` blocks aren't executed involve immediate termination of a program. For example, such a termination might happen because of the <xref:System.Environment.FailFast%2A?displayProperty=nameWithType> call or an <xref:System.OverflowException> or <xref:System.InvalidProgramException> exception. Most operating systems perform a reasonable resource clean-up as part of stopping and unloading the process.

### The `try-catch-finally` statement

You use a `try-catch-finally` statement both to handle exceptions that might occur during execution of the `try` block and specify the code that must be executed when control leaves the `try` statement:

:::code language="csharp" source="snippets/exception-handling-statements/ExampleClass.cs" id="TryCatchFinally":::

When an exception is handled by a `catch` block, the `finally` block is executed after execution of that `catch` block (even if another exception occurs during execution of the `catch` block). For information about `catch` and `finally` blocks, see [The `try-catch` statement](#the-try-catch-statement) and [The `try-finally` statement](#the-try-finally-statement) sections, respectively.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [The `throw` statement](~/_csharpstandard/standard/statements.md#13106-the-throw-statement)
- [The `try` statement](~/_csharpstandard/standard/statements.md#1311-the-try-statement)
- [Exceptions](~/_csharpstandard/standard/exceptions.md)

## See also

- [C# reference](../index.md)
- [Exceptions and exception handling](../../fundamentals/exceptions/index.md)
- [Handling and throwing exceptions in .NET](../../../standard/exceptions/index.md)
- [throw preferences (style rule IDE0016)](../../../fundamentals/code-analysis/style-rules/ide0016.md)
- <xref:System.AppDomain.FirstChanceException?displayProperty=nameWithType>
- <xref:System.AppDomain.UnhandledException?displayProperty=nameWithType>
- <xref:System.Threading.Tasks.TaskScheduler.UnobservedTaskException?displayProperty=nameWithType>
