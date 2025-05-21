---
title: System.IDisposable interface
description: Learn about the System.IDisposable interface.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.IDisposable interface

[!INCLUDE [context](includes/context.md)]

The primary use of the <xref:System.IDisposable> interface is to release unmanaged resources. The garbage collector automatically releases the memory allocated to a managed object when that object is no longer used. However, it's not possible to predict when garbage collection will occur. Furthermore, the garbage collector has no knowledge of unmanaged resources such as window handles, or open files and streams.

Use the <xref:System.IDisposable.Dispose%2A> method of this interface to explicitly release unmanaged resources in conjunction with the garbage collector. The consumer of an object can call this method when the object is no longer needed.

> [!WARNING]
> It is a breaking change to add the <xref:System.IDisposable> interface to an existing class. Because pre-existing consumers of your type cannot call <xref:System.IDisposable.Dispose%2A>, you cannot be certain that unmanaged resources held by your type will be released.

Because the <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> implementation is called by the consumer of a type when the resources owned by an instance are no longer needed, you should either wrap the managed object in a <xref:System.Runtime.InteropServices.SafeHandle> (the recommended alternative), or you should override <xref:System.Object.Finalize%2A?displayProperty=nameWithType> to free unmanaged resources in the event that the consumer forgets to call <xref:System.IDisposable.Dispose%2A>.

> [!IMPORTANT]
> In .NET Framework, the C++ compiler supports deterministic disposal of resources and does not allow direct implementation of the <xref:System.IDisposable.Dispose%2A> method.

For a detailed discussion about how this interface and the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method are used, see the [Garbage Collection](../../standard/garbage-collection/index.md) and [Implementing a Dispose Method](../../standard/garbage-collection/implementing-dispose.md) topics.

## Use an object that implements IDisposable

If your app simply uses an object that implements the <xref:System.IDisposable> interface, you should call the object's <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> implementation when you are finished using it. Depending on your programming language, you can do this in one of two ways:

- By using a language construct such as the `using` statement in C# and Visual Basic, and the `use` statement or `using` function in F#.
- By wrapping the call to the <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> implementation in a `try`/`finally` block.

> [!NOTE]
> Documentation for types that implement <xref:System.IDisposable> note that fact and include a reminder to call its <xref:System.IDisposable.Dispose%2A> implementation.

### The C#, F#, and Visual Basic Using statement

If your language supports a construct such as the [using](../../csharp/language-reference/keywords/using.md) statement in C#, the [Using](../../visual-basic/language-reference/statements/using-statement.md) statement in Visual Basic, or the [use](../../fsharp/language-reference/resource-management-the-use-keyword.md) statement in F#, you can use it instead of explicitly calling <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> yourself. The following example uses this approach in defining a `WordCount` class that preserves information about a file and the number of words in it.

:::code language="csharp" source="./snippets/System/IDisposable/Overview/csharp/calling1.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/IDisposable/Overview/fsharp/calling1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/IDisposable/Overview/vb/calling1.vb" id="Snippet1":::

The `using` statement (`use` expression in F#) is actually a syntactic convenience. At compile time, the language compiler implements the intermediate language (IL) for a `try`/`finally` block.

For more information about the `using` statement, see the [Using Statement](../../visual-basic/language-reference/statements/using-statement.md) or [using Statement](/dotnet/csharp/language-reference/keywords/using-statement) topics.

### The Try/Finally block

If your programming language does not support a construct like the `using` statement in C# or Visual Basic, or the `use` statement in F#, or if you prefer not to use it, you can call the <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> implementation from the `finally` block of a `try`/`finally` statement. The following example replaces the `using` block in the previous example with a `try`/`finally` block.

:::code language="csharp" source="./snippets/System/IDisposable/Overview/csharp/calling2.cs" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/IDisposable/Overview/fsharp/calling2.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/IDisposable/Overview/vb/calling2.vb" id="Snippet2":::

For more information about the `try`/`finally` pattern, see [Try...Catch...Finally Statement](../../visual-basic/language-reference/statements/try-catch-finally-statement.md), [try-finally](/dotnet/csharp/language-reference/keywords/try-finally), [try...finally Expression](../../fsharp/language-reference/exception-handling/the-try-finally-expression.md), or [try-finally Statement](/cpp/c-language/try-finally-statement-c).

## Implement IDisposable

You should implement <xref:System.IDisposable> if your type uses unmanaged resources directly or if you wish to use disposable resources yourself. The consumers of your type can call your <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> implementation to free resources when the instance is no longer needed. To handle cases in which they fail to call <xref:System.IDisposable.Dispose%2A>, you should either use a class derived from <xref:System.Runtime.InteropServices.SafeHandle> to wrap the unmanaged resources, or you should override the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method for a reference type. In either case, you use the <xref:System.IDisposable.Dispose%2A> method to perform whatever cleanup is necessary after using the unmanaged resources, such as freeing, releasing, or resetting the unmanaged resources. For more information about implementing <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType>, see [the Dispose(bool) method overload](../../standard/garbage-collection/implementing-dispose.md#the-disposebool-method-overload).

> [!IMPORTANT]
> If you are defining a base class that uses unmanaged resources and that either has, or is likely to have, subclasses that should be disposed, you should implement the <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> method and provide a second overload of `Dispose`, as discussed in the next section.

## IDisposable and the inheritance hierarchy

A base class with subclasses that should be disposable must implement <xref:System.IDisposable> as follows. You should use this pattern whenever you implement <xref:System.IDisposable> on any type that isn't `sealed` (`NotInheritable` in Visual Basic).

- It should provide one public, non-virtual <xref:System.IDisposable.Dispose> method and a protected virtual `Dispose(Boolean disposing)` method.
- The <xref:System.IDisposable.Dispose> method must call `Dispose(true)` and should suppress finalization for performance.
- The base type should not include any finalizers.

The following code fragment reflects the dispose pattern for base classes. It assumes that your type does not override the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method.

:::code language="csharp" source="./snippets/System/IDisposable/Overview/csharp/base1.cs" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/IDisposable/Overview/fsharp/base1.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/IDisposable/Overview/vb/base1.vb" id="Snippet3":::

If you do override the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method, your class should implement the following pattern.

:::code language="csharp" source="./snippets/System/IDisposable/Overview/csharp/base2.cs" id="Snippet5":::
:::code language="fsharp" source="./snippets/System/IDisposable/Overview/fsharp/base2.fs" id="Snippet5":::
:::code language="vb" source="./snippets/System/IDisposable/Overview/vb/base2.vb" id="Snippet5":::

Subclasses should implement the disposable pattern as follows:

- They must override `Dispose(Boolean)` and call the base class `Dispose(Boolean)` implementation.
- They can provide a finalizer if needed. The finalizer must call `Dispose(false)`.

Note that derived classes do not themselves implement the <xref:System.IDisposable> interface and do not include a parameterless <xref:System.IDisposable.Dispose%2A> method. They only override the base class `Dispose(Boolean)` method.

The following code fragment reflects the dispose pattern for derived classes. It assumes that your type does not override the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method.

:::code language="csharp" source="./snippets/System/IDisposable/Overview/csharp/derived1.cs" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/IDisposable/Overview/fsharp/derived1.fs" id="Snippet4":::
:::code language="vb" source="./snippets/System/IDisposable/Overview/vb/derived1.vb" id="Snippet4":::
