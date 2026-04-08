---
title: "Asynchronous wrappers for synchronous methods"
description: Learn why you should avoid exposing asynchronous wrappers for synchronous methods in .NET libraries, and when consumers should use Task.Run instead.
ms.date: 04/06/2026
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "async over sync"
  - "Task.Run wrapper"
  - "asynchronous programming, wrappers"
  - "TAP, async wrappers"
---
# Asynchronous wrappers for synchronous methods

When you have a synchronous method in a library, you might be tempted to expose an asynchronous counterpart that wraps it in <xref:System.Threading.Tasks.Task.Run*?displayProperty=nameWithType>:

```csharp
public T Foo() { /* synchronous work */ }

// Don't do this in a library:
public Task<T> FooAsync()
{
    return Task.Run(() => Foo());
}
```

This article explains why that approach is almost always wrong for libraries and how to think about the tradeoffs.

## Scalability vs. offloading

Asynchronous programming provides two distinct benefits:

- **Scalability** — Reduce resource consumption by freeing threads during I/O waits.
- **Offloading** — Move work to a different thread to maintain responsiveness (for example, keeping a UI thread free) or achieve parallelism.

These benefits require different approaches. The critical distinction: **wrapping a synchronous method in `Task.Run` helps with offloading but does nothing for scalability.**

### Why `Task.Run` doesn't improve scalability

A truly asynchronous implementation reduces the number of threads consumed during a long-running operation. A `Task.Run` wrapper still blocks a thread — it just moves the blocking from one thread to another:

:::code language="csharp" source="./snippets/async-wrappers-for-synchronous-methods/csharp/Program.cs" id="ScalabilityWrong":::
:::code language="vb" source="./snippets/async-wrappers-for-synchronous-methods/vb/Program.vb" id="ScalabilityWrong":::

Compare that approach with a truly asynchronous implementation that consumes no threads while waiting:

:::code language="csharp" source="./snippets/async-wrappers-for-synchronous-methods/csharp/Program.cs" id="ScalabilityRight":::
:::code language="vb" source="./snippets/async-wrappers-for-synchronous-methods/vb/Program.vb" id="ScalabilityRight":::

Both implementations complete after the specified delay, but the second implementation doesn't block any thread while waiting. For server applications handling many concurrent requests, that difference directly affects how many requests a server can process simultaneously.

### Offloading is the consumer's responsibility

Wrapping synchronous calls in `Task.Run` is useful for offloading work from a UI thread. However, the consumer, not the library, should handle this wrapping:

:::code language="csharp" source="./snippets/async-wrappers-for-synchronous-methods/csharp/Program.cs" id="OffloadFromUI":::
:::code language="vb" source="./snippets/async-wrappers-for-synchronous-methods/vb/Program.vb" id="OffloadFromUI":::

The consumer knows their context: whether they're on a UI thread, how much granularity they need, and whether offloading adds value. The library doesn't.

## Why libraries shouldn't expose async-over-sync wrappers

When a library exposes only the synchronous method (and not an async wrapper), consumers benefit in several ways:

- **Reduced API surface area**: Fewer methods to learn, test, and maintain.
- **No misleading scalability expectations**: Users know that only the methods exposed as asynchronous actually provide scalability benefits.
- **Consumer control**: Callers choose *whether* and *how* to offload, at the right level of granularity. A high-throughput server application can call the synchronous method directly, avoiding unnecessary overhead from `Task.Run`.
- **Better performance**: Asynchronous wrappers add overhead through allocations, context switches, and thread pool scheduling. For fine-grained operations, that overhead can be significant.

## Exceptions to the rule

Some base classes expose asynchronous methods so that derived classes can override them with truly asynchronous implementations. The base class provides an async-over-sync default.

For example, <xref:System.IO.Stream> exposes <xref:System.IO.Stream.ReadAsync*> and <xref:System.IO.Stream.WriteAsync*>. The base implementations wrap the synchronous <xref:System.IO.Stream.Read*> and <xref:System.IO.Stream.Write*> methods. Derived classes like <xref:System.IO.FileStream> and <xref:System.Net.Sockets.NetworkStream> override these methods with asynchronous I/O implementations that provide real scalability benefits.

Similarly, <xref:System.IO.TextReader> provides <xref:System.IO.TextReader.ReadToEndAsync*> on the base class as a wrapper, and <xref:System.IO.StreamReader> overrides it with a truly asynchronous implementation that calls <xref:System.IO.Stream.ReadAsync*> internally.

These exceptions are valid because:

- The pattern is designed for polymorphism. Callers interact with the base type.
- Derived types provide truly asynchronous overrides.

## Guideline

Expose asynchronous methods from a library only when the implementation provides real scalability benefits over its synchronous counterpart. Don't expose asynchronous methods purely for offloading. Leave that choice to the consumer.

## See also

- [Task-based asynchronous pattern (TAP)](task-based-asynchronous-pattern-tap.md)
- [Implement the task-based asynchronous pattern](implementing-the-task-based-asynchronous-pattern.md)
- [Synchronous wrappers for asynchronous methods](synchronous-wrappers-for-asynchronous-methods.md)
