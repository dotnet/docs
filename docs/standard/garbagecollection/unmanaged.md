---
title: Cleaning up unmanaged resources
description: Cleaning up unmanaged resources
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 08/18/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 8c97c3e2-8619-47ce-ae29-d6a3140bfa83
---

# Cleaning up unmanaged resources

For the majority of the objects that your app creates, you can rely on the .NET garbage collector to handle memory management. However, when you create objects that include unmanaged resources, you must explicitly release those resources when you finish using them in your app. The most common types of unmanaged resource are objects that wrap operating system resources, such as files, windows, network connections, or database connections. Although the garbage collector is able to track the lifetime of an object that encapsulates an unmanaged resource, it doesn't know how to release and clean up the unmanaged resource. 

If your types use unmanaged resources, you should do the following: 

* Implement the dispose pattern. This requires that you provide an [IDisposable.Dispose](xref:System.IDisposable.Dispose) implementation to enable the deterministic release of unmanaged resources. A consumer of your type calls [Dispose](xref:System.IDisposable.Dispose) when the object (and the resources it uses) is no longer needed. The [Dispose](xref:System.IDisposable.Dispose) method immediately releases the unmanaged resources. 

* Provide for your unmanaged resources to be released in the event that a consumer of your type forgets to call [Dispose](xref:System.IDisposable.Dispose). There are two ways to do this: 

	* Use a safe handle to wrap your unmanaged resource. This is the recommended technique. Safe handles are derived from the [System.Runtime.InteropServices.SafeHandle](xref:System.Runtime.InteropServices.SafeHandle) class and include a robust [Finalize](xref:System.Object.Finalize) method. When you use a safe handle, you simply implement the [IDisposable](xref:System.IDisposable) interface and call your safe handle's [Dispose](xref:System.IDisposable.Dispose) method in your [IDisposable.Dispose](xref:System.IDisposable.Dispose) implementation. The safe handle's finalizer is called automatically by the garbage collector if its [Dispose](xref:System.IDisposable.Dispose) method is not called. 

      —or—

	* Override the [Object.Finalize](xref:System.Object.Finalize) method. Finalization enables the non-deterministic release of unmanaged resources when the consumer of a type fails to call [IDisposable.Dispose](xref:System.IDisposable.Dispose) to dispose of them deterministically. However, because object finalization can be a complex and error-prone operation, we recommend that you use a safe handle instead of providing your own finalizer. 

Consumers of your type can then call your [IDisposable.Dispose](xref:System.IDisposable.Dispose) implementation directly to free memory used by unmanaged resources. When you properly implement a [Dispose](xref:System.IDisposable.Dispose) method, either your safe handle's [Finalize](xref:System.Object.Finalize) method or your own override of the [Object.Finalize](xref:System.Object.Finalize) method becomes a safeguard to clean up resources in the event that the [Dispose](xref:System.IDisposable.Dispose) method is not called. 

## In This Section

[Implementing a dispose method](implementing-dispose.md) - Describes how to implement the dispose pattern for releasing unmanaged resources.

[Using objects that implement IDisposable](using-objects.md) - Describes how consumers of a type ensure that its Dispose implementation is called. We recommend using the C# using statement or the Visual Basic Using statement to do this.

## Reference

[System.IDisposable](xref:System.IDisposable) - Defines the `Dispose` method for releasing unmanaged resources.

[Object.Finalize](xref:System.Object.Finalize) - Provides for object finalization if unmanaged resources are not released by the `Dispose` method. 

[GC.SuppressFinalize](xref:System.GC#System_GC_SuppressFinalize_System_Object_) - Suppresses finalization. This method is customarily called from a `Dispose` method to prevent a finalizer from executing. 
