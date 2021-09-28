---
title: Using objects that implement IDisposable
description: Learn how to use objects that implement the IDisposable interface in .NET. Types that use unmanaged resources implement IDisposable to allow resource reclaiming.
ms.date: 05/18/2021
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "Dispose method"
  - "try/finally block"
  - "garbage collection, encapsulating resources"
ms.assetid: 81b2cdb5-c91a-4a31-9c83-eadc52da5cf0
---

# Using objects that implement IDisposable

The common language runtime's garbage collector (GC) reclaims the memory used by managed objects. Typically, types that use unmanaged resources implement the <xref:System.IDisposable> or <xref:System.IAsyncDisposable> interface to allow the unmanaged resources to be reclaimed. When you finish using an object that implements <xref:System.IDisposable>, you call the object's <xref:System.IDisposable.Dispose%2A> or <xref:System.IAsyncDisposable.DisposeAsync%2A> implementation to explicitly perform cleanup. You can do this in one of two ways:

- With the C# `using` statement or declaration (`Using` in Visual Basic).
- By implementing a `try/finally` block, and calling the <xref:System.IDisposable.Dispose%2A> or <xref:System.IAsyncDisposable.DisposeAsync%2A> method in the `finally`.

> [!IMPORTANT]
> The GC does ***not*** dispose your objects, as it has no knowledge of <xref:System.IDisposable.Dispose?displayProperty=nameWithType> or <xref:System.IAsyncDisposable.DisposeAsync?displayProperty=nameWithType>. The GC only knows whether an object is finalizable (that is, it defines an <xref:System.Object.Finalize?displayProperty=nameWithType> method), and when the object's finalizer needs to be called. For more information, see [How finalization works](/dotnet/api/system.object.finalize#how-finalization-works). For additional details on implementing `Dispose` and `DisposeAsync`, see:
>
> - [Implement a Dispose method](implementing-dispose.md)
> - [Implement a DisposeAsync method](implementing-disposeasync.md)

Objects that implement <xref:System.IDisposable?displayProperty=fullName> or <xref:System.IAsyncDisposable?displayProperty=fullName> should always be properly disposed of, regardless of variable scoping, unless otherwise explicitly stated. Types that define a finalizer to release unmanaged resources usually call <xref:System.GC.SuppressFinalize%2A?displayProperty=nameWithType> from either their `Dispose` or `DisposeAsync` implementation. Calling <xref:System.GC.SuppressFinalize%2A> indicates to the GC that the finalizer has already been run and the object shouldn't be promoted for finalization.

## The using statement

The [`using` statement](../../csharp/language-reference/keywords/using-statement.md) in C# and the [`Using` statement](../../visual-basic/language-reference/statements/using-statement.md) in Visual Basic simplify the code that you must write to cleanup an object. The `using` statement obtains one or more resources, executes the statements that you specify, and automatically disposes of the object. However, the `using` statement is useful only for objects that are used within the scope of the method in which they are constructed.

The following example uses the `using` statement to create and release a <xref:System.IO.StreamReader?displayProperty=nameWithType> object.

:::code language="csharp" source="../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/UsingStatement.cs":::
:::code language="vb" source="../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.disposable/vb/UsingStatement.vb":::

With C# 8, a [`using` declaration](../../csharp/whats-new/csharp-8.md#using-declarations) is an alternative syntax available where the braces are removed, and scoping is implicit.

:::code language="csharp" source="../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/UsingDeclaration.cs":::

Although the <xref:System.IO.StreamReader> class implements the <xref:System.IDisposable> interface, which indicates that it uses an unmanaged resource, the example doesn't explicitly call the <xref:System.IO.StreamReader.Dispose%2A?displayProperty=nameWithType> method. When the C# or Visual Basic compiler encounters the `using` statement, it emits intermediate language (IL) that is equivalent to the following code that explicitly contains a `try/finally` block.

:::code language="csharp" source="../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/TryFinallyGenerated.cs":::
:::code language="vb" source="../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.disposable/vb/TryFinallyGenerated.vb":::

The C# `using` statement also allows you to acquire multiple resources in a single statement, which is internally equivalent to nested `using` statements. The following example instantiates two <xref:System.IO.StreamReader> objects to read the contents of two different files.

:::code language="csharp" source="../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/SingleStatementMultiple.cs":::

## Try/finally block

Instead of wrapping a `try/finally` block in a `using` statement, you may choose to implement the `try/finally` block directly. It may be your personal coding style, or you might want to do this for one of the following reasons:

- To include a `catch` block to handle exceptions thrown in the `try` block. Otherwise, any exceptions thrown within the `using` statement are unhandled.
- To instantiate an object that implements <xref:System.IDisposable> whose scope is not local to the block within which it is declared.

The following example is similar to the previous example, except that it uses a `try/catch/finally` block to instantiate, use, and dispose of a <xref:System.IO.StreamReader> object, and to handle any exceptions thrown by the <xref:System.IO.StreamReader> constructor and its <xref:System.IO.StreamReader.ReadToEnd%2A> method. The code in the `finally` block checks that the object that implements <xref:System.IDisposable> isn't `null` before it calls the <xref:System.IDisposable.Dispose%2A> method. Failure to do this can result in a <xref:System.NullReferenceException> exception at run time.

:::code language="csharp" source="../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/TryExplicitCatchFinally.cs":::
:::code language="vb" source="../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.disposable/vb/TryExplicitCatchFinally.vb":::

You can follow this basic pattern if you choose to implement or must implement a `try/finally` block, because your programming language doesn't support a `using` statement but does allow direct calls to the <xref:System.IDisposable.Dispose%2A> method.

## IDisposable instance members

If a class holds an <xref:System.IDisposable> implementation as an instance member, either a field or a property, the class should also implement <xref:System.IDisposable>. For more information, see [implement a cascade dispose](implementing-dispose.md#cascade-dispose-calls).

## See also

- [Cleaning up unmanaged resources](unmanaged.md)
- [using Statement (C# Reference)](../../csharp/language-reference/keywords/using-statement.md)
- [Using Statement (Visual Basic)](../../visual-basic/language-reference/statements/using-statement.md)
