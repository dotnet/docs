---
title: "How to execute cleanup code using finally"
description: Learn how to execute cleanup code using a 'finally' statement. Finally statements ensure that any necessary cleanup of objects occurs immediately.
ms.topic: how-to
ms.date: 05/14/2021
helpviewer_keywords: 
  - "try/finally blocks [C#]"
  - "exceptions [C#], try/finally block"
  - "exception handling [C#], try/finally block"
---
# How to execute cleanup code using finally

The purpose of a `finally` statement is to ensure that the necessary cleanup of objects, usually objects that are holding external resources, occurs immediately, even if an exception is thrown. One example of such cleanup is calling <xref:System.IO.Stream.Close%2A> on a <xref:System.IO.FileStream> immediately after use instead of waiting for the object to be garbage collected by the common language runtime, as follows:

:::code language="csharp" source="snippets/exceptions/Program.cs" ID="NoCleanup":::

## Example

To turn the previous code into a `try-catch-finally` statement, the cleanup code is separated from the working code, as follows.

:::code language="csharp" source="snippets/exceptions/Program.cs" ID="WithCleanup":::

Because an exception can occur at any time within the `try` block before the `OpenWrite()` call, or the `OpenWrite()` call itself could fail, we aren't guaranteed that the file is open when we try to close it. The `finally` block adds a check to make sure that the <xref:System.IO.FileStream> object isn't `null` before you call the <xref:System.IO.Stream.Close%2A> method. Without the `null` check, the `finally` block could throw its own <xref:System.NullReferenceException>, but throwing exceptions in `finally` blocks should be avoided if it's possible.

A database connection is another good candidate for being closed in a `finally` block. Because the number of connections allowed to a database server is sometimes limited, you should close database connections as quickly as possible. If an exception is thrown before you can close your connection, using the `finally` block is better than waiting for garbage collection.

## See also

- [using Statement](../../language-reference/keywords/using-statement.md)
- [try-catch](../../language-reference/keywords/try-catch.md)
- [try-finally](../../language-reference/keywords/try-finally.md)
- [try-catch-finally](../../language-reference/keywords/try-catch-finally.md)
