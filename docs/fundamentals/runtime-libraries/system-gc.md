---
title: System.GC class
description: Learn about the System.GC class.
ms.date: 12/31/2023
ms.topic: article
---
# System.GC class

[!INCLUDE [context](includes/context.md)]

The <xref:System.GC> class controls the garbage collector. The garbage collector is a common language runtime component that controls the allocation and release of managed memory. The methods in this class influence when garbage collection is performed on an object and when resources allocated by an object are released. Properties in this class provide information about the total amount of memory available in the system and the age category, or generation, of memory allocated to an object.

The garbage collector tracks and reclaims objects allocated in managed memory. Periodically, the garbage collector performs garbage collection to reclaim memory allocated to objects for which there are no valid references. Garbage collection happens automatically when a request for memory cannot be satisfied using available free memory. Alternatively, an application can force garbage collection using the <xref:System.GC.Collect%2A> method.

Garbage collection consists of the following steps:

1. The garbage collector searches for managed objects that are referenced in managed code.
2. The garbage collector tries to finalize objects that are not referenced.
3. The garbage collector frees objects that are not referenced and reclaims their memory.

## Unmanaged resources

During a collection, the garbage collector will not free an object if it finds one or more references to the object in managed code. However, the garbage collector does not recognize references to an object from unmanaged code, and might free objects that are being used exclusively in unmanaged code unless explicitly prevented from doing so. The <xref:System.GC.KeepAlive%2A> method provides a mechanism that prevents the garbage collector from collecting objects that are still in use in unmanaged code.

Aside from managed memory allocations, implementations of the garbage collector do not maintain information about resources held by an object, such as file handles or database connections. When a type uses unmanaged resources that must be released before instances of the type are reclaimed, the type can implement a finalizer.

In most cases, finalizers are implemented by overriding the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method; however, types written in C# or C++ implement destructors, which compilers turn into an override of <xref:System.Object.Finalize%2A?displayProperty=nameWithType>. In most cases, if an object has a finalizer, the garbage collector calls it prior to freeing the object. However, the garbage collector is not required to call finalizers in all situations; for example, the <xref:System.GC.SuppressFinalize%2A> method explicitly prevents an object's finalizer from being called. Also, the garbage collector is not required to use a specific thread to finalize objects, or guarantee the order in which finalizers are called for objects that reference each other but are otherwise available for garbage collection.

In scenarios where resources must be released at a specific time, classes can implement the <xref:System.IDisposable> interface, which contains the <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> method that performs resource management and cleanup tasks. Classes that implement <xref:System.IDisposable.Dispose%2A> must specify, as part of their class contract, if and when class consumers call the method to clean up the object. The garbage collector does not, by default, call the <xref:System.IDisposable.Dispose%2A> method; however, implementations of the <xref:System.IDisposable.Dispose%2A> method can call methods in the <xref:System.GC> class to customize the finalization behavior of the garbage collector.

For more information on object finalization and the dispose pattern, see [Cleaning Up Unmanaged Resources](../../standard/garbage-collection/unmanaged.md).

## Object aging and generations

The garbage collector in the common language runtime supports object aging using generations. A generation is a unit of measure of the relative age of objects in memory. The generation number, or age, of an object indicates the generation to which an object belongs. Objects created more recently are part of newer generations, and have lower generation numbers than objects created earlier in the application life cycle. Objects in the most recent generation are in generation 0. This implementation of the garbage collector supports three generations of objects, generations 0, 1, and 2. You can retrieve the value of the <xref:System.GC.MaxGeneration> property to determine the maximum generation number supported by the system.

Object aging allows applications to target garbage collection at a specific set of generations rather than requiring the garbage collector to evaluate all generations. Overloads of the <xref:System.GC.Collect%2A> method that include a `generation` parameter allow you to specify the oldest generation to be garbage collected.

## Disallowing garbage collection

The garbage collector supports a no GC region latency mode that can be used during the execution of critical paths in which garbage collection can adversely affect an app's performance. The no GC region latency mode requires that you specify an amount of memory that can be allocated without interference from the garbage collector. If the runtime can allocate that memory, the runtime will not perform a garbage collection while code in the critical path is executing.

You define the beginning of the critical path of the no GC region by calling one of the overloads of the <xref:System.GC.TryStartNoGCRegion%2A>. You specify the end of its critical path by calling the <xref:System.GC.EndNoGCRegion%2A> method.

You cannot nest calls to the <xref:System.GC.TryStartNoGCRegion%2A> method, and you should only call the <xref:System.GC.EndNoGCRegion%2A> method if the runtime is currently in no GC region latency mode. In other words, you should not call <xref:System.GC.TryStartNoGCRegion%2A> multiple times (after the first method call, subsequent calls will not succeed), and you should not expect calls to <xref:System.GC.EndNoGCRegion%2A> to succeed just because the first call to <xref:System.GC.TryStartNoGCRegion%2A> succeeded.
