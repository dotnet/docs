# Cleaning Up Unmanaged Resources

For the majority of the objects that your app creates, you can rely on the .NET Framework's garbage collector to handle memory management. However, when you create objects that include unmanaged resources, you must explicitly release those resources when you finish using them in your app. The most common types of unmanaged resource are objects that wrap operating system resources, such as files, windows, network connections, or database connections. Although the garbage collector is able to track the lifetime of an object that encapsulates an unmanaged resource, it doesn't know how to release and clean up the unmanaged resource. 

If your types use unmanaged resources, you should do the following: 

* Implement the dispose pattern. This requires that you provide an [IDisposable.Dispose](http://dotnet.github.io/api/System.IDisposable.html#System_IDisposable_Dispose) implementation to enable the deterministic release of unmanaged resources. A consumer of your type calls `Dispose` when the object (and the resources it uses) is no longer needed. The `Dispose` method immediately releases the unmanaged resources. 

* Provide for your unmanaged resources to be released in the event that a consumer of your type forgets to call `Dispose`. There are two ways to do this: 

    * Use a safe handle to wrap your unmanaged resource. This is the recommended technique. Safe handles are derived from the [System.Runtime.InteropServices.SafeHandle](http://dotnet.github.io/api/System.Runtime.InteropServices.SafeHandle.html) class and include a robust [Finalize()](http://dotnet.github.io/api/System.Runtime.InteropServices.SafeHandle.html#System_Runtime_InteropServices_SafeHandle_Finalize) method. When you use a safe handle, you simply implement the `IDisposable` interface and call your safe handle's `Dispose` method in your `Disposable.Dispose` implementation. The safe handle's finalizer is called automatically by the garbage collector if its `Dispose` method is not called. 

    — or —

    * Override the [Object.Finalize()](http://dotnet.github.io/api/System.Object.html#System_Object_Finalize) method. Finalization enables the non-deterministic release of unmanaged resources when the consumer of a type fails to call `IDisposable.Dispose` to dispose of them deterministically. However, because object finalization can be a complex and error-prone operation, we recommend that you use a safe handle instead of providing your own finalizer.
    
Consumers of your type can then call your `IDisposable.Dispose` implementation directly to free memory used by unmanaged resources. When you properly implement a `Dispose` method, either your safe handle's `Finalize` method or your own override of the `Object.Finalize` method becomes a safeguard to clean up resources in the event that the `Dispose` method is not called. 

## In This Section

Title | Description
----- | -----------
[Implementing a Dispose Method](essentials\gc\unmanaged\implementingdispose.md) | Describes how to implement the dispose pattern for releasing unmanaged resources.
[Using Objects That Implement IDisposable](essentials\gc\unmanaged\usingobjects.md) | Describes how consumers of a type ensure that its `Dispose` implementation is called. 
    
## Reference

[System.IDisposable](http://dotnet.github.io/api/System.IDisposable.html) 

[Object.Finalize()](http://dotnet.github.io/api/System.Object.html#System_Object_Finalize)

[GC.SuppressFinalize](http://dotnet.github.io/api/System.GC.html#System_GC_SuppressFinalize_System_Object_)   

    