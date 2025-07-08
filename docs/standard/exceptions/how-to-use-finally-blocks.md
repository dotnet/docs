---
description: "Learn more about: How to use finally blocks"
title: "How to: Use Finally Blocks"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "exceptions, try/catch blocks"
  - "exceptions, finally blocks"
  - "try/catch blocks"
  - "finally blocks"
  - "ArgumentOutOfRangeException class"
---
# How to use finally blocks

When an exception occurs, execution stops and control is given to the appropriate exception handler. This often means that lines of code you expect to be executed are bypassed. Some resource cleanup, such as closing a file, needs to be done even if an exception is thrown. To do this, you can use a `finally` block. A `finally` block always executes, regardless of whether an exception is thrown.

The following code example uses a `try`/`catch` block to catch an <xref:System.ArgumentOutOfRangeException>. The `Main` method creates two arrays and attempts to copy one to the other. The action generates an <xref:System.ArgumentOutOfRangeException> because `length` is specified as -1, and the error is written to the console. The `finally` block executes regardless of the outcome of the copy action.
[!code-csharp[CodeTryCatchFinallyExample#3](./snippets/how-to-use-finally-blocks/csharp/source2.cs#3)]
[!code-vb[CodeTryCatchFinallyExample#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CodeTryCatchFinallyExample/VB/source2.vb#3)]

## See also

- [Exceptions](index.md)
