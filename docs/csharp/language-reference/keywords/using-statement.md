---
description: "using statement - C# Reference"
title: "using statement - C# Reference"
ms.date: 11/15/2021
f1_keywords:
  - "using-statement_CSharpKeyword"
helpviewer_keywords:
  - "using statement [C#]"
ms.assetid: afc355e6-f0b9-4240-94dd-0d93f17d9fc3
---
# using statement (C# Reference)

Provides a convenient syntax that ensures the correct use of <xref:System.IDisposable> objects. Beginning in C# 8.0, the `using` statement ensures the correct use of <xref:System.IAsyncDisposable> objects.

## Example

The following example shows how to use the `using` statement.

:::code language="csharp" source="snippets/usings.cs" id="SnippetFirstExample":::

Beginning with C# 8.0, you can use the following alternative syntax for the `using` statement that doesn't require braces:

:::code language="csharp" source="snippets/usings.cs" id="SnippetModernUsing":::

## Remarks

<xref:System.IO.File> and <xref:System.Drawing.Font> are examples of managed types that access unmanaged resources (in this case file handles and device contexts). There are many other kinds of unmanaged resources and class library types that encapsulate them. All such types must implement the <xref:System.IDisposable> interface, or the <xref:System.IAsyncDisposable> interface.

When the lifetime of an `IDisposable` object is limited to a single method, you should declare and instantiate it in the `using` statement. The `using` statement calls the <xref:System.IDisposable.Dispose%2A> method on the object in the correct way, and (when you use it as shown earlier) it also causes the object itself to go out of scope as soon as <xref:System.IDisposable.Dispose%2A> is called. Within the `using` block, the object is read-only and can't be modified or reassigned. If the object implements `IAsyncDisposable` instead of `IDisposable`, the `using` statement calls the <xref:System.IAsyncDisposable.DisposeAsync%2A> and `awaits` the returned <xref:System.Threading.Tasks.ValueTask>. For more information on <xref:System.IAsyncDisposable>, see [Implement a DisposeAsync method](../../../standard/garbage-collection/implementing-disposeasync.md).

The `using` statement ensures that <xref:System.IDisposable.Dispose%2A> (or <xref:System.IAsyncDisposable.DisposeAsync%2A>) is called even if an exception occurs within the `using` block. You can achieve the same result by putting the object inside a `try` block and then calling <xref:System.IDisposable.Dispose%2A> (or <xref:System.IAsyncDisposable.DisposeAsync%2A>) in a `finally` block; in fact, this is how the `using` statement is translated by the compiler. The code example earlier expands to the following code at compile time (note the extra curly braces to create the limited scope for the object):

:::code language="csharp" source="snippets/usings.cs" id="SnippetTryFinallyExample":::

The newer `using` statement syntax translates to similar code. The `try` block opens where the variable is declared. The `finally` block is added at the close of the enclosing block, typically at the end of a method.

For more information about the `try`-`finally` statement, see the [try-finally](try-finally.md) article.

Multiple instances of a type can be declared in a single `using` statement, as shown in the following example. Notice that you can't use implicitly typed variables (`var`) when you declare multiple variables in a single statement:

:::code language="csharp" source="snippets/usings.cs" id="SnippetDeclareMultipleVariables":::

You can combine multiple declarations of the same type using the new syntax introduced with C# 8 as well, as shown in the following example:

:::code language="csharp" source="snippets/usings.cs" id="SnippetModernMultipleVariables":::

You can instantiate the resource object and then pass the variable to the `using` statement, but this isn't a best practice. In this case, after control leaves the `using` block, the object remains in scope but probably has no access to its unmanaged resources. In other words, it's not fully initialized anymore. If you try to use the object outside the `using` block, you risk causing an exception to be thrown. For this reason, it's better to instantiate the object in the `using` statement and limit its scope to the `using` block.

:::code language="csharp" source="snippets/usings.cs" id="SnippetDeclareBeforeUsing":::

For more information about disposing of `IDisposable` objects, see [Using objects that implement IDisposable](../../../standard/garbage-collection/using-objects.md).

## C# language specification

For more information, see [The using statement](~/_csharplang/spec/statements.md#the-using-statement) in the [C# Language Specification](/dotnet/csharp/language-reference/language-specification/introduction). The language specification is the definitive source for C# syntax and usage.

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [using Directive](using-directive.md)
- [Garbage Collection](../../../standard/garbage-collection/index.md)
- [Using objects that implement IDisposable](../../../standard/garbage-collection/using-objects.md)
- [IDisposable interface](xref:System.IDisposable)
- [using statement in C# 8.0](~/_csharplang/proposals/csharp-8.0/using.md)
