---
title: .NET garbage collection
description: Learn about garbage collection in .NET. The .NET garbage collector manages the allocation and release of memory for your application.
ms.date: 04/21/2020
helpviewer_keywords: 
  - "memory, garbage collection"
  - "garbage collection, automatic memory management"
  - "GC [.NET]"
  - "memory, allocating"
  - "common language runtime, garbage collection"
  - "garbage collector"
  - "cleanup operations"
  - "garbage collection"
  - "memory, releasing"
  - "common language runtime, automatic memory management"
  - "automatic memory management"
  - "runtime, automatic memory management"
  - "runtime, garbage collection"
  - "garbage collection, about"
ms.assetid: 22b6cb97-0c80-4eeb-a2cf-5ed7655e37f9
ms.topic: article
---
# Garbage collection

.NET's garbage collector manages the allocation and release of memory for your application. Each time you create a new object, the common language runtime allocates memory for the object from the managed heap. As long as address space is available in the managed heap, the runtime continues to allocate space for new objects. However, memory is not infinite. Eventually the garbage collector must perform a collection in order to free some memory. The garbage collector's optimizing engine determines the best time to perform a collection, based upon the allocations being made. When the garbage collector performs a collection, it checks for objects in the managed heap that are no longer being used by the application and performs the necessary operations to reclaim their memory.  
  
## In this section
  
|Title|Description|  
|-----------|-----------------|  
|[Fundamentals of garbage collection](fundamentals.md)|Describes how garbage collection works, how objects are allocated on the managed heap, and other core concepts.|  
|[Workstation and server garbage collection](workstation-server-gc.md)|Describes the differences between workstation garbage collection for client apps and server garbage collection for server apps.|
|[Background garbage collection](background-gc.md)|Describes background garbage collection, which is the collection of generation 0 and 1 objects while generation 2 collection is in progress.|
|[The large object heap](large-object-heap.md)|Describes the large object heap (LOH) and how large objects are garbage-collected.|
|[Garbage collection and performance](performance.md)|Describes the performance checks you can use to diagnose garbage collection and performance issues.|  
|[Induced collections](induced.md)|Describes how to make a garbage collection occur.|  
|[Latency modes](latency.md)|Describes the modes that determine the intrusiveness of garbage collection.|  
|[Optimization for shared web hosting](optimization-for-shared-web-hosting.md)|Describes how to optimize garbage collection on servers shared by several small Web sites.|  
|[Garbage collection notifications](notifications.md)|Describes how to determine when a full garbage collection is approaching and when it has completed.|  
|[Application domain resource monitoring](app-domain-resource-monitoring.md)|Describes how to monitor CPU and memory usage by an application domain.|  
|[Weak references](weak-references.md)|Describes features that permit the garbage collector to collect an object while still allowing the application to access that object.|  
  
## Reference

- <xref:System.GC?displayProperty=nameWithType>  
- <xref:System.GCCollectionMode?displayProperty=nameWithType>  
- <xref:System.GCNotificationStatus?displayProperty=nameWithType>  
- <xref:System.Runtime.GCLatencyMode?displayProperty=nameWithType>  
- <xref:System.Runtime.GCSettings?displayProperty=nameWithType>  
- <xref:System.Runtime.GCSettings.LargeObjectHeapCompactionMode%2A?displayProperty=nameWithType>  
- <xref:System.Object.Finalize%2A?displayProperty=nameWithType>  
- <xref:System.IDisposable?displayProperty=nameWithType>  
  
## See also

- [Clean up unmanaged resources](unmanaged.md)
