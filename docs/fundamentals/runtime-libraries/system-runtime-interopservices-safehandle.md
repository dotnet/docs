---
title: System.Runtime.InteropServices.SafeHandle class
description: Learn about the System.Runtime.InteropServices.SafeHandle class.
ms.date: 12/31/2023
---
# System.Runtime.InteropServices.SafeHandle class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Runtime.InteropServices.SafeHandle> class provides critical finalization of handle resources, preventing handles from being reclaimed prematurely by garbage collection and from being recycled by the operating system to reference unintended unmanaged objects.

## Why SafeHandle?

Although overrides to the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method allow cleanup of unmanaged resources when an object is being garbage collected, in some circumstances, finalizable objects can be reclaimed by garbage collection while executing a method within a platform invoke call. If a finalizer frees the handle passed to that platform invoke call, it could lead to handle corruption. The handle could also be reclaimed while your method is blocked during a platform invoke call, such as while reading a file.

More critically, because Windows aggressively recycles handles, a handle could be recycled and point to another resource that might contain sensitive data. This is known as a recycle attack and can potentially corrupt data and be a security threat.

## What SafeHandle does

The <xref:System.Runtime.InteropServices.SafeHandle> class simplifies several of these object lifetime issues, and is integrated with platform invoke so that operating system resources are not leaked. The <xref:System.Runtime.InteropServices.SafeHandle> class resolves object lifetime issues by assigning and releasing handles without interruption. It contains a critical finalizer that ensures that the handle is closed and is guaranteed to run during unexpected <xref:System.AppDomain> unloads, even in cases when the platform invoke call is assumed to be in a corrupted state.

Because <xref:System.Runtime.InteropServices.SafeHandle> inherits from <xref:System.Runtime.ConstrainedExecution.CriticalFinalizerObject>, all the noncritical finalizers are called before any of the critical finalizers. The finalizers are called on objects that are no longer live during the same garbage collection pass. For example, a <xref:System.IO.FileStream> object can run a normal finalizer to flush out existing buffered data without the risk of the handle being leaked or recycled. This very weak ordering between critical and noncritical finalizers is not intended for general use. It exists primarily to assist in the migration of existing libraries by allowing those libraries to use <xref:System.Runtime.InteropServices.SafeHandle> without altering their semantics. Additionally, the critical finalizer and anything it calls, such as the <xref:System.Runtime.InteropServices.SafeHandle.ReleaseHandle?displayProperty=nameWithType> method, must be in a constrained execution region. This imposes constraints on what code can be written within the finalizer's call graph.

Platform invoke operations automatically increment the reference count of handles encapsulated by a <xref:System.Runtime.InteropServices.SafeHandle> and decrement them upon completion. This ensures that the handle will not be recycled or closed unexpectedly.

You can specify ownership of the underlying handle when constructing <xref:System.Runtime.InteropServices.SafeHandle> objects by supplying a value to the `ownsHandle` argument in the <xref:System.Runtime.InteropServices.SafeHandle> class constructor. This controls whether the <xref:System.Runtime.InteropServices.SafeHandle> object will release the handle after the object has been disposed. This is useful for handles with peculiar lifetime requirements or for consuming a handle whose lifetime is controlled by someone else.

## Classes derived from SafeHandle

<xref:System.Runtime.InteropServices.SafeHandle> is an abstract wrapper class for operating system handles. Deriving from this class is difficult. Instead, use the derived classes in the <xref:Microsoft.Win32.SafeHandles> namespace that provide safe handles for the following:

- Files (the <xref:Microsoft.Win32.SafeHandles.SafeFileHandle> class).
- Memory mapped files (the <xref:Microsoft.Win32.SafeHandles.SafeMemoryMappedFileHandle> class).
- Pipes (the <xref:Microsoft.Win32.SafeHandles.SafePipeHandle> class).
- Memory views (the <xref:Microsoft.Win32.SafeHandles.SafeMemoryMappedViewHandle> class).
- Cryptography constructs (the <xref:Microsoft.Win32.SafeHandles.SafeNCryptHandle>, <xref:Microsoft.Win32.SafeHandles.SafeNCryptKeyHandle>, <xref:Microsoft.Win32.SafeHandles.SafeNCryptProviderHandle>, and <xref:Microsoft.Win32.SafeHandles.SafeNCryptSecretHandle> classes).
- Processes (the <xref:Microsoft.Win32.SafeHandles.SafeProcessHandle> class).
- Registry keys (the <xref:Microsoft.Win32.SafeHandles.SafeRegistryHandle> class).
- Wait handles (the <xref:Microsoft.Win32.SafeHandles.SafeWaitHandle> class).
