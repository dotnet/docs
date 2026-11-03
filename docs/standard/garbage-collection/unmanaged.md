---
title: "Cleaning up unmanaged resources"
description: See how to clean up unmanaged resources not handled by the .NET garbage collector, such as files, windows, & network or database connections.
ms.date: 08/20/2021
helpviewer_keywords:
  - "Close method"
  - "Dispose method"
  - "garbage collector"
  - "garbage collection, unmanaged resources"
  - "cleanup operations"
  - "explicit cleanups"
  - "unmanaged resource cleanup"
  - "Finalize method"
ms.assetid: a17b0066-71c2-4ba4-9822-8e19332fc213
---

# Cleaning up unmanaged resources

For a majority of the objects that your app creates, you can rely on the [.NET garbage collector](index.md) to handle memory management. However, when you create objects that include unmanaged resources, you **must** explicitly release those resources when you finish using them. The most common types of unmanaged resources are objects that wrap operating system resources, such as files, windows, network connections, or database connections. Although the garbage collector is able to track the lifetime of an object that encapsulates an unmanaged resource, it doesn't know how to release and clean up the unmanaged resource.

If your types use unmanaged resources, you should do the following:

- Implement the [dispose pattern](implementing-dispose.md). This requires that you provide an <xref:System.IDisposable.Dispose*?displayProperty=nameWithType> implementation to enable the deterministic release of unmanaged resources. A consumer of your type calls <xref:System.IDisposable.Dispose*> when the object (and the resources it uses) are no longer needed. The <xref:System.IDisposable.Dispose*> method immediately releases the unmanaged resources.

- In the event that a consumer of your type forgets to call <xref:System.IDisposable.Dispose*>, provide a way for your unmanaged resources to be released. There are two ways to do this:

  - Use a safe handle to wrap your unmanaged resource. This is the recommended technique. Safe handles are derived from the <xref:System.Runtime.InteropServices.SafeHandle?displayProperty=nameWithType> abstract class and include a robust <xref:System.Object.Finalize*> method. When you use a safe handle, you simply implement the <xref:System.IDisposable> interface and call your safe handle's <xref:System.Runtime.InteropServices.SafeHandle.Dispose*> method in your <xref:System.IDisposable.Dispose*?displayProperty=nameWithType> implementation. The safe handle's finalizer is called automatically by the garbage collector if its <xref:System.IDisposable.Dispose*> method is not called.

    —**or**—

  - Define a [finalizer](../../csharp/programming-guide/classes-and-structs/finalizers.md). Finalization enables the non-deterministic release of unmanaged resources when the consumer of a type fails to call <xref:System.IDisposable.Dispose*?displayProperty=nameWithType> to dispose of them deterministically.

    > [!WARNING]
    > Object finalization can be a complex and error-prone operation, we recommend that you use a safe handle instead of providing your own finalizer.

Consumers of your type can then call your <xref:System.IDisposable.Dispose*?displayProperty=nameWithType> implementation directly to free memory used by unmanaged resources. When you properly implement a <xref:System.IDisposable.Dispose*> method, either your safe handle's <xref:System.Object.Finalize*> method or your own override of the <xref:System.Object.Finalize*?displayProperty=nameWithType> method becomes a safeguard to clean up resources in the event that the <xref:System.IDisposable.Dispose*> method is not called.

## In this section

[Implementing a Dispose method](implementing-dispose.md) describes how to implement the dispose pattern for releasing unmanaged resources.

[Using objects that implement `IDisposable`](using-objects.md) describes how consumers of a type ensure that its <xref:System.IDisposable.Dispose*> implementation is called. We strongly recommend using the C# `using` (or the Visual Basic `Using`) statement to do this.

## Reference

| Type / Member | Description |
|--|--|
| <xref:System.IDisposable?displayProperty=nameWithType> | Defines the <xref:System.IDisposable.Dispose*> method for releasing unmanaged resources. |
| <xref:System.Object.Finalize*?displayProperty=nameWithType> | Provides for object finalization if unmanaged resources are not released by the <xref:System.IDisposable.Dispose*> method. |
| <xref:System.GC.SuppressFinalize*?displayProperty=nameWithType> | Suppresses finalization. This method is customarily called from a `Dispose` method to prevent a finalizer from executing. |
