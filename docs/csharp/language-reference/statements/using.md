---
title: "using statement - ensure the correct use of disposable objects"
description: "Use the C# using statement or declaration to ensure the correct use of disposable objects"
ms.date: 03/13/2023
f1_keywords:
  - "using-statement_CSharpKeyword"
helpviewer_keywords:
  - "using statement [C#]"
---
# using statement - ensure the correct use of disposable objects

The `using` statement ensures the correct use of an <xref:System.IDisposable> instance:

:::code language="csharp" source="snippets/using/Program.cs" id="Using":::

When the control leaves the block of the `using` statement, an acquired <xref:System.IDisposable> instance is disposed. In particular, the `using` statement ensures that a disposable instance is disposed even if an exception occurs within the block of the `using` statement. In the preceding example, an opened file is closed after all lines are processed.

Use the `await using` statement to correctly use an <xref:System.IAsyncDisposable> instance:

:::code language="csharp" source="snippets/using/Program.cs" id="AwaitUsing":::

For more information about using of <xref:System.IAsyncDisposable> instances, see the [Using async disposable](../../../standard/garbage-collection/implementing-disposeasync.md#using-async-disposable) section of the [Implement a DisposeAsync method](../../../standard/garbage-collection/implementing-disposeasync.md) article.

You can also use a `using` *declaration* that doesn't require braces:

:::code language="csharp" source="snippets/using/Program.cs" id="UsingDeclaration":::

When declared in a `using` declaration, a local variable is disposed at the end of the scope in which it's declared. In the preceding example, disposal happens at the end of a method.

A variable declared by the `using` statement or declaration is readonly. You cannot reassign it or pass it as a [`ref`](../keywords/ref.md) or [`out`](../keywords/out-parameter-modifier.md) parameter.

You can declare several instances of the same type in one `using` statement, as the following example shows:

:::code language="csharp" source="snippets/using/Program.cs" id="MultipleResources":::

When you declare several instances in one `using` statement, they are disposed in reverse order of declaration.

You can also use the `using` statement and declaration with an instance of a [ref struct](../builtin-types/ref-struct.md) that fits the disposable pattern. That is, it has an instance `Dispose` method, which is accessible, parameterless and has a `void` return type.

The `using` statement can also be of the following form:

```csharp
using (expression)
{
    // ...
}
```

where `expression` produces a disposable instance. The following example demonstrates that:

:::code language="csharp" source="snippets/using/Program.cs" id="UsingWithExpression":::

> [!WARNING]
> In the preceding example, a disposable instance remains in scope after the `using` statement while it's already disposed. If you use that instance further, you might encounter an exception, for example, <xref:System.ObjectDisposedException>. That's why we recommend declaring a disposable variable within the `using` statement or using the `using` declaration.

## C# language specification

For more information, see [The using statement](~/_csharpstandard/standard/statements.md#1214-the-using-statement) section of the [C# language specification](~/_csharpstandard/standard/README.md) and the proposal note about ["pattern-based using" and "using declarations"](~/_csharplang/proposals/csharp-8.0/using.md).

## See also

- [C# reference](../index.md)
- <xref:System.IDisposable?displayProperty=nameWithType>
- <xref:System.IAsyncDisposable?displayProperty=nameWithType>
- [Using objects that implement IDisposable](../../../standard/garbage-collection/using-objects.md)
- [Implement a Dispose method](../../../standard/garbage-collection/implementing-dispose.md)
- [Implement a DisposeAsync method](../../../standard/garbage-collection/implementing-disposeasync.md)
- [Use simple 'using' statement (style rule IDE0063)](../../../fundamentals/code-analysis/style-rules/ide0063.md)
- [`using` directive](../keywords/using-directive.md)
