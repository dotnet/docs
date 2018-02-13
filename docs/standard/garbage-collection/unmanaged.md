---
title: "Cleaning Up Unmanaged Resources"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Close method"
  - "Dispose method"
  - "garbage collector"
  - "garbage collection, unmanaged resources"
  - "cleanup operations"
  - "explicit cleanups"
  - "unmanaged resource cleanup"
  - "Finalize method"
ms.assetid: a17b0066-71c2-4ba4-9822-8e19332fc213
caps.latest.revision: 19
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Cleaning Up Unmanaged Resources
For the majority of the objects that your app creates, you can rely on .NET's garbage collector to handle memory management. However, when you create objects that include unmanaged resources, you must explicitly release those resources when you finish using them in your app. The most common types of unmanaged resource are objects that wrap operating system resources, such as files, windows, network connections, or database connections. Although the garbage collector is able to track the lifetime of an object that encapsulates an unmanaged resource, it doesn't know how to release and clean up the unmanaged resource.  
  
 If your types use unmanaged resources, you should do the following:  
  
-   Implement the [dispose pattern](../../../docs/standard/design-guidelines/dispose-pattern.md). This requires that you provide an <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> implementation to enable the deterministic release of  unmanaged resources. A consumer of your type calls <xref:System.IDisposable.Dispose%2A> when the object (and the resources it uses) is no longer needed. The <xref:System.IDisposable.Dispose%2A> method immediately releases the unmanaged resources.  
  
-   Provide for your unmanaged resources to be released in the event that a consumer of your type forgets to call <xref:System.IDisposable.Dispose%2A>. There are two ways to do this:  
  
    -   Use a safe handle to wrap your unmanaged resource. This is the recommended technique. Safe handles are derived from the <xref:System.Runtime.InteropServices.SafeHandle?displayProperty=nameWithType> class and include a robust <xref:System.Object.Finalize%2A> method. When you use a safe handle, you simply implement the <xref:System.IDisposable> interface and call your safe handle's <xref:System.Runtime.InteropServices.SafeHandle.Dispose%2A> method in your <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> implementation. The safe handle's finalizer is called automatically by the garbage collector if its <xref:System.IDisposable.Dispose%2A> method is not called.  
  
         —or—  
  
    -   Override the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method. Finalization enables the non-deterministic release of unmanaged resources when the consumer of a type fails to call <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> to dispose of them deterministically. However, because object finalization can be a complex and error-prone operation, we recommend that you use a safe handle instead of providing your own finalizer.  
  
 Consumers of your type can then call your <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> implementation directly to free memory used by unmanaged resources. When you properly implement a <xref:System.IDisposable.Dispose%2A> method, either your safe handle's <xref:System.Object.Finalize%2A> method or your own override of the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method becomes a safeguard to clean up resources in the event that the <xref:System.IDisposable.Dispose%2A> method is not called.  
  
## In This Section  
 [Implementing a Dispose Method](../../../docs/standard/garbage-collection/implementing-dispose.md)  
 Describes how to implement the [dispose pattern](../../../docs/standard/design-guidelines/dispose-pattern.md) for releasing unmanaged resources.  
  
 [Using Objects That Implement IDisposable](../../../docs/standard/garbage-collection/using-objects.md)  
 Describes how consumers of a type ensure that its <xref:System.IDisposable.Dispose%2A> implementation is called. We recommend using the C# `using` statement or the Visual Basic `Using` statement to do this.  
  
## Reference  
 <xref:System.IDisposable?displayProperty=nameWithType>  
 Defines the <xref:System.IDisposable.Dispose%2A> method for releasing unmanaged resources.  
  
 <xref:System.Object.Finalize%2A?displayProperty=nameWithType>  
 Provides for object finalization if unmanaged resources are not released by the <xref:System.IDisposable.Dispose%2A> method.  
  
 <xref:System.GC.SuppressFinalize%2A?displayProperty=nameWithType>  
 Suppresses finalization. This method is customarily called from a `Dispose` method to prevent a finalizer from executing.
