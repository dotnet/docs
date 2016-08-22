---
title: Garbage collection in .NET
description: Garbage collection in .NET
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 08/16/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 468fbd4b-729b-468c-b23f-3e6a2b35e27b
---

# Garbage collection

The .NET garbage collector manages the allocation and release of memory for your application. Each time you create a new object, the Common Language Runtime allocates memory for the object from the managed heap. As long as address space is available in the managed heap, the runtime continues to allocate space for new objects. However, memory is not infinite. Eventually the garbage collector must perform a collection in order to free some memory. The garbage collector's optimizing engine determines the best time to perform a collection, based upon the allocations being made. When the garbage collector performs a collection, it checks for objects in the managed heap that are no longer being used by the application and performs the necessary operations to reclaim their memory.

## Related Topics

Title | Description
----- | ----------- 
[Fundamentals of garbage collection](fundamentals.md) | Describes how garbage collection works, how objects are allocated on the managed heap, and other core concepts.
[Induced collections](induced.md) | Describes how to make a garbage collection occur.
[Latency modes](latency.md) | Describes the modes that determine the intrusiveness of garbage collection.
[Weak references](weak-references.md) | Describes features that permit the garbage collector to collect an object while still allowing the application to access that object.
 
## Reference

[System.GC](xref:System.GC)

[System.GCCollectionMode](xref:System.GCCollectionMode)

[System.Runtime.GCLatencyMode](xref:System.Runtime.GCLatencyMode)

[System.Runtime.GCSettings](xref:System.Runtime.GCSettings)

[GCSettings.LargeObjectHeapCompactionMode](xref:System.Runtime.GCSettingsGCSettings.LargeObjectHeapCompactionMode)

[Object.Finalize](xref:System.Object#System_Object_Finalize)

[System.IDisposable](xref:System.IDisposable)

## See Also

[Cleaning up unmanaged resources](unmanaged.md)
