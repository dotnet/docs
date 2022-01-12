---
title: "Exception Handling - C# Programming Guide"
description: Learn about exception handling. See examples of try-catch, try-finally, and try-catch-finally statements.
ms.date: 05/14/2021
helpviewer_keywords: 
  - "exception handling [C#], about exception handling"
  - "exceptions [C#], handling"
ms.assetid: b4e4ecf2-b907-4e58-891f-2563762258e9
---
# Exception Handling (C# Programming Guide)

A [try](../../language-reference/keywords/try-catch.md) block is used by C# programmers to partition code that might be affected by an exception. Associated [catch](../../language-reference/keywords/try-catch.md) blocks are used to handle any resulting exceptions. A [finally](../../language-reference/keywords/try-finally.md) block contains code that is run whether or not an exception is thrown in the `try` block, such as releasing resources that are allocated in the `try` block. A `try` block requires one or more associated `catch` blocks, or a `finally` block, or both.

The following examples show a `try-catch` statement, a `try-finally` statement, and a `try-catch-finally` statement.

:::code language="csharp" source="snippets/exceptions/Program.cs" ID="TryCatchStructure":::

:::code language="csharp" source="snippets/exceptions/Program.cs" ID="TryFinallyStructure":::

:::code language="csharp" source="snippets/exceptions/Program.cs" ID="TryCatchFinallyStructure":::

A `try` block without a `catch` or `finally` block causes a compiler error.

## Catch Blocks

A `catch` block can specify the type of exception to catch. The type specification is called an *exception filter*. The exception type should be derived from <xref:System.Exception>. In general, don't specify <xref:System.Exception> as the exception filter unless either you know how to handle all exceptions that might be thrown in the `try` block, or you've included a [throw](../../language-reference/keywords/throw.md) statement at the end of your `catch` block.

Multiple `catch` blocks with different exception classes can be chained together. The `catch` blocks are evaluated from top to bottom in your code, but only one `catch` block is executed for each exception that is thrown. The first `catch` block that specifies the exact type or a base class of the thrown exception is executed. If no `catch` block specifies a matching exception class, a `catch` block that doesn't have any type is selected, if one is present in the statement. It's important to position `catch` blocks with the most specific (that is, the most derived) exception classes first.

Catch exceptions when the following conditions are true:

- You have a good understanding of why the exception might be thrown, and you can implement a specific recovery, such as prompting the user to enter a new file name when you catch a <xref:System.IO.FileNotFoundException> object.
- You can create and throw a new, more specific exception.
  :::code language="csharp" source="snippets/exceptions/Program.cs" ID="ThrowMoreSpecificException":::
- You want to partially handle an exception before passing it on for more handling. In the following example, a `catch` block is used to add an entry to an error log before rethrowing the exception.
  :::code language="csharp" source="snippets/exceptions/Program.cs" ID="RethrowError":::

You can also specify *exception filters* to add a boolean expression to a catch clause. Exception filters indicate that a specific catch clause matches only when that condition is true. In the following example, both catch clauses use the same exception class, but an extra condition is checked to create a different error message:

:::code language="csharp" source="snippets/exceptions/ExceptionFilter.cs" ID="DemonstrateExceptionFilter":::

An exception filter that always returns `false` can be used to examine all exceptions but not process them. A typical use is to log exceptions:

:::code language="csharp" source="snippets/exceptions/ExceptionFilter.cs" ID="ShowExceptionFilter":::

The `LogException` method always returns `false`, no `catch` clause using this exception filter matches. The catch clause can be general, using <xref:System.Exception?displayProperty=nameWithType>, and later clauses can process more specific exception classes.

## Finally Blocks

A `finally` block enables you to clean up actions that are performed in a `try` block. If present, the `finally` block executes last, after the `try` block and any matched `catch` block. A `finally` block always runs, whether an exception is thrown or a `catch` block matching the exception type is found.

The `finally` block can be used to release resources such as file streams, database connections, and graphics handles without waiting for the garbage collector in the runtime to finalize the objects. For more information See the [using Statement](../../language-reference/keywords/using-statement.md).

In the following example, the `finally` block is used to close a file that is opened in the `try` block. Notice that the state of the file handle is checked before the file is closed. If the `try` block can't open the file, the file handle still has the value `null` and the `finally` block doesn't try to close it. Instead, if the file is opened successfully in the `try` block, the `finally` block closes the open file.

:::code language="csharp" source="snippets/exceptions/Program.cs" ID="CleanupIfNotNull":::

## C# Language Specification

For more information, see [Exceptions](~/_csharpstandard/standard/exceptions.md) and [The try statement](~/_csharpstandard/standard/statements.md#1311-the-try-statement) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.
  
## See also

- [C# Reference](../../language-reference/index.md)
- [try-catch](../../language-reference/keywords/try-catch.md)
- [try-finally](../../language-reference/keywords/try-finally.md)
- [try-catch-finally](../../language-reference/keywords/try-catch-finally.md)
- [using Statement](../../language-reference/keywords/using-statement.md)
