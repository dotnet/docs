---
title: "Implement a Dispose method"
description: In this article, learn to implement the Dispose method, which releases unmanaged resources used by your code in .NET.
ms.date: 09/29/2021
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "Dispose method"
  - "garbage collection, Dispose method"
ms.topic: how-to
---

# Implement a Dispose method

Implementing the <xref:System.IDisposable.Dispose%2A> method is primarily for releasing unmanaged resources. When working with instance members that are <xref:System.IDisposable> implementations, it's common to cascade <xref:System.IDisposable.Dispose%2A> calls. There are additional reasons for implementing <xref:System.IDisposable.Dispose%2A>, for example, to free memory that was allocated, remove an item that was added to a collection, or signal the release of a lock that was acquired.

The [.NET garbage collector](index.md) does not allocate or release unmanaged memory. The pattern for disposing an object, referred to as the dispose pattern, imposes order on the lifetime of an object. The dispose pattern is used for objects that implement the <xref:System.IDisposable> interface, and is common when interacting with file and pipe handles, registry handles, wait handles, or pointers to blocks of unmanaged memory. This is because the garbage collector is unable to reclaim unmanaged objects.

To help ensure that resources are always cleaned up appropriately, a <xref:System.IDisposable.Dispose%2A> method should be idempotent, such that it is callable multiple times without throwing an exception. Furthermore, subsequent invocations of <xref:System.IDisposable.Dispose%2A> should do nothing.

The code example provided for the <xref:System.GC.KeepAlive%2A?displayProperty=nameWithType> method shows how garbage collection can cause a finalizer to run, while an unmanaged reference to the object or its members is still in use. It may make sense to utilize <xref:System.GC.KeepAlive%2A?displayProperty=nameWithType> to make the object ineligible for garbage collection from the start of the current routine to the point where this method is called.

[!INCLUDE [disposables-and-dependency-injection](includes/disposables-and-dependency-injection.md)]

## Safe handles

Writing code for an object's finalizer is a complex task that can cause problems if not done correctly. Therefore, we recommend that you construct <xref:System.Runtime.InteropServices.SafeHandle?displayProperty=nameWithType> objects instead of implementing a finalizer.

A <xref:System.Runtime.InteropServices.SafeHandle?displayProperty=nameWithType> is an abstract managed type that wraps an <xref:System.IntPtr?displayProperty=nameWithType> that identifies an unmanaged resource. On Windows it might identify a handle while on Unix, a file descriptor. It provides all of the logic necessary to ensure that this resource is released once and only once, when the `SafeHandle` is disposed of or when all references to the `SafeHandle` have been dropped and the `SafeHandle` instance is finalized.

The <xref:System.Runtime.InteropServices.SafeHandle?displayProperty=nameWithType> is an abstract base class. Derived classes provide specific instances for different kinds of handle. These derived classes validate what values for the <xref:System.IntPtr?displayProperty=nameWithType> are considered invalid and how to actually free the handle. For example, <xref:Microsoft.Win32.SafeHandles.SafeFileHandle> derives from `SafeHandle` to wrap `IntPtrs` that identify open file handles/descriptors, and overrides its <xref:System.Runtime.InteropServices.SafeHandle.ReleaseHandle?displayProperty=nameWithType> method to close it (via the `close` function on Unix or `CloseHandle` function on Windows). Most APIs in .NET libraries that create an unmanaged resource will wrap it in a `SafeHandle` and return that `SafeHandle` to you as needed, rather than handing back the raw pointer. In situations where you interact with an unmanaged component and get an `IntPtr` for an unmanaged resource, you can create your own `SafeHandle` type to wrap it. As a result, few non-`SafeHandle` types need to implement finalizers; most disposable pattern implementations only end up wrapping other managed resources, some of which may be `SafeHandle`s.

The following derived classes in the <xref:Microsoft.Win32.SafeHandles> namespace provide safe handles:

- The <xref:Microsoft.Win32.SafeHandles.SafeFileHandle>, <xref:Microsoft.Win32.SafeHandles.SafeMemoryMappedFileHandle>, and <xref:Microsoft.Win32.SafeHandles.SafePipeHandle> class, for files, memory mapped files, and pipes.
- The <xref:Microsoft.Win32.SafeHandles.SafeMemoryMappedViewHandle> class, for memory views.
- The <xref:Microsoft.Win32.SafeHandles.SafeNCryptKeyHandle>, <xref:Microsoft.Win32.SafeHandles.SafeNCryptProviderHandle>, and <xref:Microsoft.Win32.SafeHandles.SafeNCryptSecretHandle> classes, for cryptography constructs.
- The <xref:Microsoft.Win32.SafeHandles.SafeRegistryHandle> class, for registry keys.
- The <xref:Microsoft.Win32.SafeHandles.SafeWaitHandle> class, for wait handles.

## Dispose() and Dispose(bool)

The <xref:System.IDisposable> interface requires the implementation of a single parameterless method, <xref:System.IDisposable.Dispose%2A>. Also, any non-sealed class should have an additional `Dispose(bool)` overload method.

Method signatures are:

- `public` non-virtual (`NotOverridable` in Visual Basic) (<xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> implementation).
- `protected virtual` (`Overridable` in Visual Basic) `Dispose(bool)`.

### The Dispose() method

Because the `public`, non-virtual (`NotOverridable` in Visual Basic), parameterless `Dispose` method is called when it is no longer needed (by a consumer of the type), its purpose is to free unmanaged resources, perform general cleanup, and to indicate that the finalizer, if one is present, doesn't have to run. Freeing the actual memory associated with a managed object is always the domain of the [garbage collector](index.md). Because of this, it has a standard implementation:

:::code language="csharp" source="../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/Disposable.cs" id="Dispose":::
:::code language="vb" source="../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.disposable/vb/Disposable.vb" id="Dispose":::

The `Dispose` method performs all object cleanup, so the garbage collector no longer needs to call the objects' <xref:System.Object.Finalize%2A?displayProperty=nameWithType> override. Therefore, the call to the <xref:System.GC.SuppressFinalize%2A> method prevents the garbage collector from running the finalizer. If the type has no finalizer, the call to <xref:System.GC.SuppressFinalize%2A?displayProperty=nameWithType> has no effect. Note that the actual cleanup is performed by the `Dispose(bool)` method overload.

### The Dispose(bool) method overload

In the overload, the `disposing` parameter is a <xref:System.Boolean> that indicates whether the method call comes from a <xref:System.IDisposable.Dispose%2A> method (its value is `true`) or from a finalizer (its value is `false`).

  :::code language="csharp" source="../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/Disposable.cs" id="DisposeBool":::
  :::code language="vb" source="../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.disposable/vb/Disposable.vb" id="DisposeBool":::

  > [!IMPORTANT]
  > The `disposing` parameter should be `false` when called from a finalizer, and `true` when called from the <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> method. In other words, it is `true` when deterministically called and `false` when non-deterministically called.

The body of the method consists of three blocks of code:

- A block for conditional return if object is already disposed.
- A block that frees unmanaged resources. This block executes regardless of the value of the `disposing` parameter.
- A conditional block that frees managed resources. This block executes if the value of `disposing` is `true`. The managed resources that it frees can include:

  - **Managed objects that implement <xref:System.IDisposable>.** The conditional block can be used to call their <xref:System.IDisposable.Dispose%2A> implementation (cascade dispose). If you have used a derived class of <xref:System.Runtime.InteropServices.SafeHandle?displayProperty=nameWithType> to wrap your unmanaged resource, you should call the <xref:System.Runtime.InteropServices.SafeHandle.Dispose?displayProperty=nameWithType> implementation here.

  - **Managed objects that consume large amounts of memory or consume scarce resources.** Assign large managed object references to `null` to make them more likely to be unreachable. This releases them faster than if they were reclaimed non-deterministically.

If the method call comes from a finalizer, only the code that frees unmanaged resources should execute. The implementer is responsible for ensuring that the false path doesn't interact with managed objects that may have been disposed. This is important because the order in which the garbage collector disposes managed objects during finalization is non-deterministic.

## Cascade dispose calls

If your class owns a field or property, and its type implements <xref:System.IDisposable>, the containing class itself should also implement <xref:System.IDisposable>. A class that instantiates an <xref:System.IDisposable> implementation and storing it as an instance member, is also responsible for its cleanup. This is to help ensure that the referenced disposable types are given the opportunity to deterministically perform cleanup through the <xref:System.IDisposable.Dispose%2A> method. In this example, the class is `sealed` (or `NotInheritable` in Visual Basic).

:::code language="csharp" source="../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/Foo.cs":::
:::code language="vb" source="../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.disposable/vb/Foo.vb":::

> [!TIP]
> There are cases when you may want to perform `null`-checking in a finalizer (which includes the `Dispose(false)` method invoked by a finalizer), one of the primary reasons is if you're unsure whether the instance got fully initialized (for example, an exception may be thrown in a constructor).

## Implement the dispose pattern

All non-sealed classes (or Visual Basic classes not modified as `NotInheritable`) should be considered a potential base class, because they could be inherited. If you implement the dispose pattern for any potential base class, you must provide the following:

- A <xref:System.IDisposable.Dispose%2A> implementation that calls the `Dispose(bool)` method.
- A `Dispose(bool)` method that performs the actual cleanup.
- Either a class derived from <xref:System.Runtime.InteropServices.SafeHandle> that wraps your unmanaged resource (recommended), or an override to the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method. The <xref:System.Runtime.InteropServices.SafeHandle> class provides a finalizer, so you do not have to write one yourself.

> [!IMPORTANT]
> It is possible for a base class to only reference managed objects, and implement the dispose pattern. In these cases, a finalizer is unnecessary. A finalizer is only required if you directly reference unmanaged resources.

Here's an example of the general pattern for implementing the dispose pattern for a base class that uses a safe handle.

:::code language="csharp" source="../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.idisposable/cs/base1.cs":::
:::code language="vb" source="../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.idisposable/vb/base1.vb":::

> [!NOTE]
> The previous example uses a <xref:Microsoft.Win32.SafeHandles.SafeFileHandle> object to illustrate the pattern; any object derived from <xref:System.Runtime.InteropServices.SafeHandle> could be used instead. Note that the example does not properly instantiate its <xref:Microsoft.Win32.SafeHandles.SafeFileHandle> object.

Here's the general pattern for implementing the dispose pattern for a base class that overrides <xref:System.Object.Finalize%2A?displayProperty=nameWithType>.

:::code language="csharp" source="../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.idisposable/cs/base2.cs":::
:::code language="vb" source="../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.idisposable/vb/base2.vb":::

> [!TIP]
> In C#, you implement a finalization by providing a [finalizer](../../csharp/programming-guide/classes-and-structs/finalizers.md), not by overriding <xref:System.Object.Finalize%2A?displayProperty=nameWithType>. In Visual Basic, you create a finalizer with `Protected Overrides Sub Finalize()`.

## Implement the dispose pattern for a derived class

A class derived from a class that implements the <xref:System.IDisposable> interface shouldn't implement <xref:System.IDisposable>, because the base class implementation of <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> is inherited by its derived classes. Instead, to clean up a derived class, you provide the following:

- A `protected override void Dispose(bool)` method that overrides the base class method and performs the actual cleanup of the derived class. This method must also call the `base.Dispose(bool)` (`MyBase.Dispose(bool)` in Visual Basic) method passing it the disposing status (`bool disposing` parameter) as an argument.
- Either a class derived from <xref:System.Runtime.InteropServices.SafeHandle> that wraps your unmanaged resource (recommended), or an override to the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method. The <xref:System.Runtime.InteropServices.SafeHandle> class provides a finalizer that frees you from having to code one. If you do provide a finalizer, it must call the `Dispose(bool)` overload with `false` argument.

Here's an example of the general pattern for implementing the dispose pattern for a derived class that uses a safe handle:

:::code language="csharp" source="../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.idisposable/cs/derived1.cs":::
:::code language="vb" source="../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.idisposable/vb/derived1.vb":::

> [!NOTE]
> The previous example uses a <xref:Microsoft.Win32.SafeHandles.SafeFileHandle> object to illustrate the pattern; any object derived from <xref:System.Runtime.InteropServices.SafeHandle> could be used instead. Note that the example does not properly instantiate its <xref:Microsoft.Win32.SafeHandles.SafeFileHandle> object.

Here's the general pattern for implementing the dispose pattern for a derived class that overrides <xref:System.Object.Finalize%2A?displayProperty=nameWithType>:

:::code language="csharp" source="../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.idisposable/cs/derived2.cs":::
:::code language="vb" source="../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.idisposable/vb/derived2.vb":::

## See also

- [Disposal of services](../../core/extensions/dependency-injection-guidelines.md#disposal-of-services)
- <xref:System.GC.SuppressFinalize%2A>
- <xref:System.IDisposable>
- <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType>
- <xref:Microsoft.Win32.SafeHandles>
- <xref:System.Runtime.InteropServices.SafeHandle?displayProperty=nameWithType>
- <xref:System.Object.Finalize%2A?displayProperty=nameWithType>
- [Define and consume classes and structs (C++/CLI)](/cpp/dotnet/how-to-define-and-consume-classes-and-structs-cpp-cli)
