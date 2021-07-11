---
title: "Finalizers - C# Programming Guide"
description: Finalizers in C# perform any necessary final clean-up when a class instance is being collected by the garbage collector.
ms.date: 06/09/2021
helpviewer_keywords: 
  - "~ [C#], in finalizers"
  - "C# language, finalizers"
  - "finalizers [C#]"
---
# Finalizers (C# Programming Guide)

Finalizers (historically referred to as **destructors**) are used to perform any necessary final clean-up when a class instance is being collected by the garbage collector. In most cases, you can avoid writing a finalizer by using the  <xref:System.Runtime.InteropServices.SafeHandle?displayProperty=fullName> or derived classes to wrap any unmanaged handle.

## Remarks  

- Finalizers cannot be defined in structs. They are only used with classes.
- A class can only have one finalizer.
- Finalizers cannot be inherited or overloaded.
- Finalizers cannot be called. They are invoked automatically.
- A finalizer does not take modifiers or have parameters.

For example, the following is a declaration of a finalizer for the `Car` class.

:::code language="csharp" source="snippets/destructors/Program.cs" ID="Snippet2":::

A finalizer can also be implemented as an expression body definition, as the following example shows.

:::code language="csharp" source="snippets/destructors/expr-bodied-destructor.cs" ID="Snippet1":::

The finalizer implicitly calls <xref:System.Object.Finalize%2A> on the base class of the object. Therefore, a call to a finalizer is implicitly translated to the following code:

```csharp
protected override void Finalize()
{
    try
    {
        // Cleanup statements...
    }
    finally
    {
        base.Finalize();
    }
}
```

This design means that the `Finalize` method is called recursively for all instances in the inheritance chain, from the most-derived to the least-derived.

> [!NOTE]
> Empty finalizers should not be used. When a class contains a finalizer, an entry is created in the `Finalize` queue. When the finalizer is called, the garbage collector is invoked to process the queue. An empty finalizer just causes a needless loss of performance.

The programmer has no control over when the finalizer is called; the garbage collector decides when to call it. The garbage collector checks for objects that are no longer being used by the application. If it considers an object eligible for finalization, it calls the finalizer (if any) and reclaims the memory used to store the object. It's possible to force garbage collection by calling <xref:System.GC.Collect%2A>, but most of the time, this call should be avoided because it may create performance issues.

Whether or not finalizers are run as part of application termination is implementation-specific.

> [!NOTE]
> The .NET Framework implementation makes every reasonable effort to call finalizers for all of its objects that have not yet been garbage collected, unless such cleanup has been suppressed (by a call to the library method `GC.SuppressFinalize`, for example).
  
 If you need to perform cleanup reliably when an application exist, register a handler for the <xref:System.AppDomain.ProcessExit?displayProperty=fullName> event. That handler would ensure <xref:System.IDisposable.Dispose?displayProperty=nameWithType> (or, <xref:System.IAsyncDisposable.DisposeAsync?displayProperty=nameWithType>) has been called for all objects that require cleanup before application exit. Because you can't call *Finalize* directly, and you can't guarantee the garbage collector calls all finalizers before exit, you must use `Dispose` or `DisposeAsync` to ensure resources are freed.

## Using finalizers to release resources

In general, C# does not require as much memory management on the part of the developer as languages that don't target a runtime with garbage collection. This is because the .NET garbage collector implicitly manages the allocation and release of memory for your objects. However, when your application encapsulates unmanaged resources, such as windows, files, and network connections, you should use finalizers to free those resources. When the object is eligible for finalization, the garbage collector runs the `Finalize` method of the object.

## Explicit release of resources

If your application is using an expensive external resource, we also recommend that you provide a way to explicitly release the resource before the garbage collector frees the object. To release the resource, implement a `Dispose` method from the <xref:System.IDisposable> interface that performs the necessary cleanup for the object. This can considerably improve the performance of the application. Even with this explicit control over resources, the finalizer becomes a safeguard to clean up resources if the call to the `Dispose` method fails.

For more information about cleaning up resources, see the following articles:  

- [Cleaning Up Unmanaged Resources](../../../standard/garbage-collection/unmanaged.md)
- [Implementing a Dispose Method](../../../standard/garbage-collection/implementing-dispose.md)
- [Implementing a DisposeAsync Method](../../../standard/garbage-collection/implementing-disposeasync.md)
- [using Statement](../../language-reference/keywords/using-statement.md)

## Example

The following example creates three classes that make a chain of inheritance. The class `First` is the base class, `Second` is derived from `First`, and `Third` is derived from `Second`. All three have finalizers. In `Main`, an instance of the most-derived class is created. When the program runs, notice that the finalizers for the three classes are called automatically, and in order, from the most-derived to the least-derived.

:::code language="csharp" source="snippets/destructors/Program.cs" ID="Snippet1":::
  
## C# language specification  

For more information, see the [Destructors](~/_csharplang/spec/classes.md#destructors) section of the [C# language specification](/dotnet/csharp/language-reference/language-specification/introduction).
  
## See also

- <xref:System.IDisposable>
- [C# Programming Guide](../index.md)
- [Constructors](./constructors.md)
- [Garbage Collection](../../../standard/garbage-collection/index.md)
