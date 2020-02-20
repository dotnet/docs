---
title: "using statement - C# Reference"
ms.date: 10/15/2019
helpviewer_keywords:
  - "using statement [C#]"
ms.assetid: afc355e6-f0b9-4240-94dd-0d93f17d9fc3
---
# using statement (C# Reference)

Provides a convenient syntax that ensures the correct use of <xref:System.IDisposable> objects.

## Example

The following example shows how to use the `using` statement.

[!code-csharp[csrefKeywordsNamespace#4](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsNamespace/CS/csrefKeywordsNamespace.cs#4)]

Beginning with C# 8.0, you can use the following alternative syntax for the `using` statement that doesn't require braces:

[!code-csharp[csrefKeywordsNamespace#New](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsNamespace/CS/csrefKeywordsNamespace.cs#ModernUsing)]

## Remarks

<xref:System.IO.File> and <xref:System.Drawing.Font> are examples of managed types that access unmanaged resources (in this case file handles and device contexts). There are many other kinds of unmanaged resources and class library types that encapsulate them. All such types must implement the <xref:System.IDisposable> interface.

When the lifetime of an `IDisposable` object is limited to a single method, you should declare and instantiate it in the `using` statement. The `using` statement calls the <xref:System.IDisposable.Dispose%2A> method on the object in the correct way, and (when you use it as shown earlier) it also causes the object itself to go out of scope as soon as <xref:System.IDisposable.Dispose%2A> is called. Within the `using` block, the object is read-only and cannot be modified or reassigned.

The `using` statement ensures that <xref:System.IDisposable.Dispose%2A> is called even if an exception occurs within the `using` block. You can achieve the same result by putting the object inside a `try` block and then calling <xref:System.IDisposable.Dispose%2A> in a `finally` block; in fact, this is how the `using` statement is translated by the compiler. The code example earlier expands to the following code at compile time (note the extra curly braces to create the limited scope for the object):

[!code-csharp[csrefKeywordsNamespace#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsNamespace/CS/csrefKeywordsNamespace.cs#5)]

The newer `using` statement syntax translates to very similar code. The `try` block opens where the variable is declared. The `finally` block is added at the close of the enclosing block, typically at the end of a method.

For more information about the `try`-`finally` statement, see the [try-finally](try-finally.md) topic.

Multiple instances of a type can be declared in the `using` statement, as shown in the following example:

[!code-csharp[csrefKeywordsNamespace#6](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsNamespace/CS/csrefKeywordsNamespace.cs#6)]

You can combine multiple declarations of the same type using the new syntax introduced with C# 8 as well. This is shown in the following example:

[!code-csharp[csrefKeywordsNamespace#6](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsNamespace/CS/csrefKeywordsNamespace.cs#MultipleUsing)]

You can instantiate the resource object and then pass the variable to the `using` statement, but this is not a best practice. In this case, after control leaves the `using` block, the object remains in scope but probably has no access to its unmanaged resources. In other words, it's not fully initialized anymore. If you try to use the object outside the `using` block, you risk causing an exception to be thrown. For this reason, it's generally better to instantiate the object in the `using` statement and limit its scope to the `using` block.

[!code-csharp[csrefKeywordsNamespace#7](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsNamespace/CS/csrefKeywordsNamespace.cs#7)]

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
