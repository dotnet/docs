---
title: Induced collections
description: Induced collections
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 08/16/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 3e09b9dd-a800-4e56-b468-619f910ae22e
---

# Induced collections

In most cases, the garbage collector can determine the best time to perform a collection, and you should let it run independently. There are rare situations when a forced collection might improve your application's performance. In these cases, you can induce garbage collection by using the [GC.Collect](xref:System.GC.Collect) method to force a garbage collection. 

Use the [Collect](xref:System.GC.Collect) method when there is a significant reduction in the amount of memory being used at a specific point in your application's code. For example, if your application uses a complex dialog box that has several controls, calling [Collect](xref:System.GC.Collect) when the dialog box is closed could improve performance by immediately reclaiming the memory used by the dialog box. Be sure that your application is not inducing garbage collection too frequently, because that can decrease performance if the garbage collector is trying to reclaim objects at non-optimal times. You can supply a [GCCollectionMode.Optimized](xref:System.GCCollectionMode.Optimized) enumeration value to the [Collect](xref:System.GC.Collect) method to collect only when collection would be productive, as discussed in the next section.

## GC collection mode

You can use one of the [GC.Collect](xref:System.GC.Collect) method overloads that includes a [GCCollectionMode](xref:System.GCCollectionMode) value to specify the behavior for a forced collection as follows.

GCCollectionMode value | Description
---------------------- | ----------- 
[Default](xref:System.GCCollectionMode.Default) | Uses the default garbage collection setting for the running version of the .NET Framework.
[Forced](xref:System.GCCollectionMode.Forced) | Forces garbage collection to occur immediately. This is equivalent to calling the [GC.Collect()](xref:System.GC.Collect) overload. It results in a full blocking collection of all generations. You can also compact the large object heap by setting the [GCSettings.LargeObjectHeapCompactionMode](xref:System.Runtime.GCSettings.LargeObjectHeapCompactionMode) property to [GCLargeObjectHeapCompactionMode.CompactOnce](xref:System.Runtime.GCLargeObjectHeapCompactionMode.CompactOnce) before forcing an immediate full blocking garbage collection. 
[Optimized](xref:System.GCCollectionMode.Optimized) | Enables the garbage collector to determine whether the current time is optimal to reclaim objects. The garbage collector could determine that a collection would not be productive enough to be justified, in which case it will return without reclaiming objects.
 
## Background or blocking collections

You can call the [GC.Collect(Int32, GCCollectionMode, Boolean)](xref:System.GC.Collect(System.Int32,System.GCCollectionMode,System.Boolean)) method overload to specify whether an induced collection is blocking or not. The type of collection performed depends on a combination of the method's *mode* and *blocking* parameters. *mode* is a member of the [GCCollectionMode](xref:System.GCCollectionMode) enumeration, and *blocking* is a [Boolean](xref:System.Boolean) value. The following table summarizes the interaction of the mode and blocking arguments. 

*mode* | *blocking* = true | *blocking* = false
------ | ----------------- | ------------------
[Forced](xref:System.GCCollectionMode.Forced) or [Default](xref:System.GCCollectionMode.Default) | A blocking collection is performed as soon as possible. If a background collection is in progress and generation is 0 or 1, the [Collect(Int32, GCCollectionMode, Boolean)](xref:System.GC.Collect(System.Int32,System.GCCollectionMode,System.Boolean)) method immediately triggers a blocking collection and returns when the collection is finished. If a background collection is in progress and the generation parameter is 2, the method waits until the background collection is finished, triggers a blocking generation 2 collection, and then returns. | A collection is performed as soon as possible. The [Collect(Int32, GCCollectionMode, Boolean)](xref:System.GC.Collect(System.Int32,System.GCCollectionMode,System.Boolean)) method requests a background collection, but this is not guaranteed; depending on the circumstances, a blocking collection may still be performed. If a background collection is already in progress, the method returns immediately. 
[Optimized](xref:System.GCCollectionMode.Optimized) | A blocking collection may be performed, depending on the state of the garbage collector and the generation parameter. The garbage collector tries to provide optimal performance. | A collection may be performed, depending on the state of the garbage collector. The [Collect(Int32, GCCollectionMode, Boolean)](xref:System.GC.Collect(System.Int32,System.GCCollectionMode,System.Boolean)) method requests a background collection, but this is not guaranteed; depending on the circumstances, a blocking collection may still be performed. The garbage collector tries to provide optimal performance. If a background collection is already in progress, the method returns immediately. 
 
## See Also

[Latency modes](latency.md)

[Garbage collection in .NET](index.md)
