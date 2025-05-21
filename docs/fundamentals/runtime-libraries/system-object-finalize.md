---
title: System.Object.Finalize method
description: Learn about the System.Object.Finalize method.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Object.Finalize method

[!INCLUDE [context](includes/context.md)]

The <xref:System.Object.Finalize%2A> method is used to perform cleanup operations on unmanaged resources held by the current object before the object is destroyed. The method is protected and therefore is accessible only through this class or through a derived class.

## How finalization works

The <xref:System.Object> class provides no implementation for the <xref:System.Object.Finalize%2A> method, and the garbage collector does not mark types derived from <xref:System.Object> for finalization unless they override the <xref:System.Object.Finalize%2A> method.

If a type does override the <xref:System.Object.Finalize%2A> method, the garbage collector adds an entry for each instance of the type to an internal structure called the finalization queue. The finalization queue contains entries for all the objects in the managed heap whose finalization code must run before the garbage collector can reclaim their memory. The garbage collector then calls the <xref:System.Object.Finalize%2A> method automatically under the following conditions:

- After the garbage collector has discovered that an object is inaccessible, unless the object has been exempted from finalization by a call to the <xref:System.GC.SuppressFinalize%2A?displayProperty=nameWithType> method.
- **On .NET Framework only**, during shutdown of an application domain, unless the object is exempt from finalization. During shutdown, even objects that are still accessible are finalized.

<xref:System.Object.Finalize%2A> is automatically called only once on a given instance, unless the object is re-registered by using a mechanism such as <xref:System.GC.ReRegisterForFinalize%2A?displayProperty=nameWithType> and the <xref:System.GC.SuppressFinalize%2A?displayProperty=nameWithType> method has not been subsequently called.

<xref:System.Object.Finalize%2A> operations have the following limitations:

- The exact time when the finalizer executes is undefined. To ensure deterministic release of resources for instances of your class, implement a `Close` method or provide a <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> implementation.
- The finalizers of two objects are not guaranteed to run in any specific order, even if one object refers to the other. That is, if Object A has a reference to Object B and both have finalizers, Object B might have already been finalized when the finalizer of Object A starts.
- The thread on which the finalizer runs is unspecified.

The <xref:System.Object.Finalize%2A> method might not run to completion or might not run at all under the following exceptional circumstances:

- If another finalizer blocks indefinitely (goes into an infinite loop, tries to obtain a lock it can never obtain, and so on). Because the runtime tries to run finalizers to completion, other finalizers might not be called if a finalizer blocks indefinitely.
- If the process terminates without giving the runtime a chance to clean up. In this case, the runtime's first notification of process termination is a DLL_PROCESS_DETACH notification.

The runtime continues to finalize objects during shutdown only while the number of finalizable objects continues to decrease.

If <xref:System.Object.Finalize%2A> or an override of <xref:System.Object.Finalize%2A> throws an exception, and the runtime is not hosted by an application that overrides the default policy, the runtime terminates the process and no active `try`/`finally` blocks or finalizers are executed. This behavior ensures process integrity if the finalizer cannot free or destroy resources.

## Overriding the Finalize method

You should override <xref:System.Object.Finalize%2A> for a class that uses unmanaged resources, such as file handles or database connections that must be released when the managed object that uses them is discarded during garbage collection. You shouldn't implement a <xref:System.Object.Finalize%2A> method for managed objects because the garbage collector releases managed resources automatically.

> [!IMPORTANT]
> If a <xref:System.Runtime.InteropServices.SafeHandle> object is available that wraps your unmanaged resource, the recommended alternative is to implement the dispose pattern with a safe handle and not override <xref:System.Object.Finalize%2A>. For more information, see [The SafeHandle alternative](#the-safehandle-alternative) section.

The <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method does nothing by default, but you should override <xref:System.Object.Finalize%2A> only if necessary, and only to release unmanaged resources. Reclaiming memory tends to take much longer if a finalization operation runs, because it requires at least two garbage collections. In addition, you should override the <xref:System.Object.Finalize%2A> method for reference types only. The common language runtime only finalizes reference types. It ignores finalizers on value types.

The scope of the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method is `protected`. You should maintain this limited scope when you override the method in your class. By keeping a <xref:System.Object.Finalize%2A> method protected, you prevent users of your application from calling an object's <xref:System.Object.Finalize%2A> method directly.

Every implementation of <xref:System.Object.Finalize%2A> in a derived type must call its base type's implementation of <xref:System.Object.Finalize%2A>. This is the only case in which application code is allowed to call <xref:System.Object.Finalize%2A>. An object's <xref:System.Object.Finalize%2A> method shouldn't call a method on any objects other than that of its base class. This is because the other objects being called could be collected at the same time as the calling object, such as in the case of a common language runtime shutdown.

> [!NOTE]
> The C# compiler does not allow you to override the <xref:System.Object.Finalize%2A> method. Instead, you provide a finalizer by implementing a [destructor](/dotnet/csharp/programming-guide/classes-and-structs/destructors) for your class. A C# destructor automatically calls the destructor of its base class.
>
> Visual C++ also provides its own syntax for implementing the <xref:System.Object.Finalize%2A> method. For more information, see the "Destructors and finalizers" section of [How to: Define and Consume Classes and Structs (C++/CLI)](/cpp/dotnet/how-to-define-and-consume-classes-and-structs-cpp-cli).

Because garbage collection is non-deterministic, you do not know precisely when the garbage collector performs finalization. To release resources immediately, you can also choose to implement the [dispose pattern](../../standard/garbage-collection/implementing-dispose.md)
and the <xref:System.IDisposable> interface. The <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> implementation can be called by consumers of your class to free unmanaged resources, and you can use the <xref:System.Object.Finalize%2A> method to free unmanaged resources in the event that the <xref:System.IDisposable.Dispose%2A> method is not called.

<xref:System.Object.Finalize%2A> can take almost any action, including resurrecting an object (that is, making the object accessible again) after it has been cleaned up during garbage collection. However, the object can only be resurrected once; <xref:System.Object.Finalize%2A> cannot be called on resurrected objects during garbage collection.

## The SafeHandle alternative

Creating reliable finalizers is often difficult, because you cannot make assumptions about the state of your application, and because unhandled system exceptions such as <xref:System.OutOfMemoryException> and <xref:System.StackOverflowException> terminate the finalizer. Instead of implementing a finalizer for your class to release unmanaged resources, you can use an object that is derived from the <xref:System.Runtime.InteropServices.SafeHandle?displayProperty=nameWithType> class to wrap your unmanaged resources, and then implement the dispose pattern without a finalizer. The .NET Framework provides the following classes in the <xref:Microsoft.Win32?displayProperty=nameWithType> namespace that are derived from <xref:System.Runtime.InteropServices.SafeHandle?displayProperty=nameWithType>:

- <xref:Microsoft.Win32.SafeHandles.SafeFileHandle> is a wrapper class for a file handle.
- <xref:Microsoft.Win32.SafeHandles.SafeMemoryMappedFileHandle> is a wrapper class for memory-mapped file handles.
- <xref:Microsoft.Win32.SafeHandles.SafeMemoryMappedViewHandle> is a wrapper class for a pointer to a block of unmanaged memory.
- <xref:Microsoft.Win32.SafeHandles.SafeNCryptKeyHandle>, <xref:Microsoft.Win32.SafeHandles.SafeNCryptProviderHandle>, and <xref:Microsoft.Win32.SafeHandles.SafeNCryptSecretHandle> are wrapper classes for cryptographic handles.
- <xref:Microsoft.Win32.SafeHandles.SafePipeHandle> is a wrapper class for pipe handles.
- <xref:Microsoft.Win32.SafeHandles.SafeRegistryHandle> is a wrapper class for a handle to a registry key.
- <xref:Microsoft.Win32.SafeHandles.SafeWaitHandle> is a wrapper class for a wait handle.

The following example uses the [dispose pattern](../../standard/garbage-collection/implementing-dispose.md) with safe handles instead of overriding the <xref:System.Object.Finalize%2A> method. It defines a `FileAssociation` class that wraps registry information about the application that handles files with a particular file extension. The two registry handles returned as `out` parameters by Windows [RegOpenKeyEx](/windows/win32/api/winreg/nf-winreg-regopenkeyexa) function calls are passed to the <xref:Microsoft.Win32.SafeHandles.SafeRegistryHandle> constructor. The type's protected `Dispose` method then calls the `SafeRegistryHandle.Dispose` method to free these two handles.

:::code language="csharp" source="./snippets/System/Object/Finalize/csharp/finalize_safe.cs" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Object/Finalize/fsharp/finalize_safe.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Object/Finalize/vb/finalize_safe.vb" id="Snippet2":::
