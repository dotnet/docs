# Garbage Collection

The .NET Framework's garbage collector manages the allocation and release of memory for your application. Each time you create a new object, the common language runtime allocates memory for the object from the managed heap. As long as address space is available in the managed heap, the runtime continues to allocate space for new objects. However, memory is not infinite. Eventually the garbage collector must perform a collection in order to free some memory. The garbage collector's optimizing engine determines the best time to perform a collection, based upon the allocations being made. When the garbage collector performs a collection, it checks for objects in the managed heap that are no longer being used by the application and performs the necessary operations to reclaim their memory.

## Related Topics

Title | Description
----- | -----------
[Fundamentals of Garbage Collection](essentials\gc\garbage\fundamentals.md) | Describes how garbage collection works, how objects are allocated on the managed heap, and other core concepts.
[Induced Collections](essentials\gc\garbage\inducedcollections.md) | Describes how to make a garbage collection occur.
[Latency Modes](essentials\gc\garbage\latencymodes.md) | Describes the modes that determine the intrusiveness of garbage collection.
[Optimization for Shared Web Hosting](essentials\gc\garbage\optimization.md) | Describes how to optimize garbage collection on servers shared by several small Web sites.
[Weak References](essentials\gc\garbage\weakreference.md) | Describes features that permit the garbage collector to collect an object while still allowing the application to access that object.

## Reference

[System.GC](http://dotnet.github.io/api/System.GC.html)

[System.GCCollectionMode](http://dotnet.github.io/api/System.GCCollectionMode.html)

[System.Runtime.GCLatencyMode](http://dotnet.github.io/api/System.Runtime.GCLatencyMode.html)

[System.Runtime.GCSettings](http://dotnet.github.io/api/System.Runtime.GCSettings.html)

[System.Runtime.GCLargeObjectHeapCompactionMode](http://dotnet.github.io/api/System.Runtime.GCLargeObjectHeapCompactionMode.html)

[System.Object.Finalize](http://dotnet.github.io/api/System.Object.html#System_Object_Finalize)

[System.IDisposable](http://dotnet.github.io/api/System.IDisposable.html)

## See Also

[Cleaning Up Unmanaged Resources](essentials\gc\unmanagedresources.md)



