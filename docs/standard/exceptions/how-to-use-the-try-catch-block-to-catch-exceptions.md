---
title: "How to: Use the Try-Catch Block to Catch Exceptions"
description: Use the try block to contain statements that might raise or throw an exception. Place statements to handle exceptions in one or more catch blocks.
ms.date: "02/06/2019"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "exceptions, try/catch blocks"
  - "try blocks"
  - "try/catch blocks"
  - "catch blocks"
ms.assetid: a3ce6dfd-1f64-471b-8ad8-8cfaf406275d
---
# How to use the try/catch block to catch exceptions

Place any code statements that might raise or throw an exception in a `try` block, and place statements used to handle the exception or exceptions in one or more `catch` blocks below the `try` block. Each `catch` block includes the exception type and can contain additional statements needed to handle that exception type.

In the following example, a <xref:System.IO.StreamReader> opens a file called *data.txt* and retrieves a line from the file. Since the code might throw any of three exceptions, it's placed in a `try` block. Three `catch` blocks catch the exceptions and handle them by displaying the results to the console.

:::code language="cpp" source="./snippets/how-to-use-the-try-catch-block-to-catch-exceptions/cpp/catchexception.cpp" id="Snippet3":::
:::code language="csharp" source="./snippets/how-to-use-the-try-catch-block-to-catch-exceptions/csharp/catchexception.cs" id="Snippet3":::
:::code language="vb" source="./snippets/how-to-use-the-try-catch-block-to-catch-exceptions/vb/catchexception.vb" id="Snippet3":::

The Common Language Runtime (CLR) catches exceptions not handled by `catch` blocks. If an exception is caught by the CLR, one of the following results may occur depending on your CLR configuration:

- A **Debug** dialog box appears.
- The program stops execution and a dialog box with exception information appears.
- An error prints out to the [standard error output stream](xref:System.Console.Error).

> [!NOTE]
> Most code can throw an exception, and some exceptions, like <xref:System.OutOfMemoryException>, can be thrown by the CLR itself at any time. While applications aren't required to deal with these exceptions, be aware of the possibility when writing libraries to be used by others. For suggestions on when to set code in a `try` block, see [Best Practices for Exceptions](best-practices-for-exceptions.md).

## See also

- [Exceptions](index.md)
- [Handling I/O errors in .NET](../io/handling-io-errors.md)
