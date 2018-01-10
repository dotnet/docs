---
title: "Implementing a Dispose method"
ms.custom: ""
ms.date: "04/07/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Dispose method"
  - "garbage collection, Dispose method"
ms.assetid: eb4e1af0-3b48-4fbc-ad4e-fc2f64138bf9
caps.latest.revision: 44
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Implementing a Dispose method

You implement a <xref:System.IDisposable.Dispose%2A> method to release unmanaged resources used by your application. The .NET garbage collector does not allocate or release unmanaged memory.  
  
The pattern for disposing an object, referred to as a [dispose pattern](../../../docs/standard/design-guidelines/dispose-pattern.md), imposes order on the lifetime of an object. The dispose pattern is used only for objects that access unmanaged resources, such as file and pipe handles, registry handles, wait handles, or pointers to blocks of unmanaged memory. This is because the garbage collector is very efficient at reclaiming unused managed objects, but it is unable to reclaim unmanaged objects.  
  
The dispose pattern has two variations:  
  
* You wrap each unmanaged resource that a type uses in a safe handle (that is, in a class derived from <xref:System.Runtime.InteropServices.SafeHandle?displayProperty=nameWithType>). In this case, you implement the <xref:System.IDisposable> interface and an additional `Dispose(Boolean)` method. This is the recommended variation and doesn't require overriding the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method.  
  
  > [!NOTE]
  > The <xref:Microsoft.Win32.SafeHandles?displayProperty=nameWithType> namespace provides a set of classes derived from <xref:System.Runtime.InteropServices.SafeHandle>, which are listed in the [Using safe handles](#SafeHandles) section. If you can't find a class that is suitable for releasing your unmanaged resource, you can implement your own subclass of <xref:System.Runtime.InteropServices.SafeHandle>.  
  
* You implement the <xref:System.IDisposable> interface and an additional `Dispose(Boolean)` method, and you also override the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method. You must override <xref:System.Object.Finalize%2A> to ensure that unmanaged resources are disposed of if your <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> implementation is not called by a consumer of your type. If you use the recommended technique discussed in the previous bullet, the <xref:System.Runtime.InteropServices.SafeHandle?displayProperty=nameWithType> class does this on your behalf.  
  
To help ensure that resources are always cleaned up appropriately, a <xref:System.IDisposable.Dispose%2A> method should be callable multiple times without throwing an exception.  
  
The code example provided for the <xref:System.GC.KeepAlive%2A?displayProperty=nameWithType> method shows how aggressive garbage collection can cause a finalizer to run while a member of the reclaimed object is still executing. It is a good idea to call the <xref:System.GC.KeepAlive%2A> method at the end of a lengthy <xref:System.IDisposable.Dispose%2A> method.  
  
<a name="Dispose2"></a>
## Dispose() and Dispose(Boolean)  

The <xref:System.IDisposable> interface requires the implementation of a single parameterless method, <xref:System.IDisposable.Dispose%2A>. However, the dispose pattern requires two `Dispose` methods to be implemented:  
  
* A public non-virtual (`NonInheritable` in Visual Basic) <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> implementation that has no parameters.  
  
* A protected virtual (`Overridable` in Visual Basic) `Dispose` method whose signature is:  
  
  [!code-csharp[Conceptual.Disposable#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/dispose1.cs#8)]
  [!code-vb[Conceptual.Disposable#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.disposable/vb/dispose1.vb#8)]  
  
### The Dispose() overload

Because the public, non-virtual (`NonInheritable` in Visual Basic), parameterless `Dispose` method is called by a consumer of the type, its purpose is to free unmanaged resources and to indicate that the finalizer, if one is present, doesn't have to run. Because of this, it has a standard implementation:  
  
[!code-csharp[Conceptual.Disposable#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/dispose1.cs#7)]
[!code-vb[Conceptual.Disposable#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.disposable/vb/dispose1.vb#7)]  
  
The `Dispose` method performs all object cleanup, so the garbage collector no longer needs to call the objects' <xref:System.Object.Finalize%2A?displayProperty=nameWithType> override. Therefore, the call to the <xref:System.GC.SuppressFinalize%2A> method prevents the garbage collector from running the finalizer. If the type has no finalizer, the call to <xref:System.GC.SuppressFinalize%2A?displayProperty=nameWithType> has no effect. Note that the actual work of releasing unmanaged resources is performed by the second overload of the `Dispose` method.  
  
### The Dispose(Boolean) overload

In the second overload, the *disposing* parameter is a <xref:System.Boolean> that indicates whether the method call comes from a <xref:System.IDisposable.Dispose%2A> method (its value is `true`) or from a finalizer (its value is `false`).  
  
The body of the method consists of two blocks of code:  
  
* A block that frees unmanaged resources. This block executes regardless of the value of the `disposing` parameter.  
  
* A conditional block that frees managed resources. This block executes if the value of `disposing` is `true`. The managed resources that it frees can include:  
  
  **Managed objects that implement <xref:System.IDisposable>.** The conditional block can be used to call their <xref:System.IDisposable.Dispose%2A> implementation. If you have used a safe handle to wrap your unmanaged resource, you should call the <xref:System.Runtime.InteropServices.SafeHandle.Dispose%28System.Boolean%29?displayProperty=nameWithType> implementation here.  
  
  **Managed objects that consume large amounts of memory or consume scarce resources.** Freeing these objects explicitly in the `Dispose` method releases them faster than if they were reclaimed non-deterministically by the garbage collector.  
  
If the method call comes from a finalizer (that is, if *disposing* is `false`), only the code that frees unmanaged resources executes. Because the order in which the garbage collector destroys managed objects during finalization is not defined, calling this `Dispose` overload with a value of `false` prevents the finalizer from trying to release managed resources that may have already been reclaimed.  
  
## Implementing the dispose pattern for a base class

If you implement the dispose pattern for a base class, you must provide the following:  
  
> [!IMPORTANT]
> You should implement this pattern for all base classes that implement <xref:System.IDisposable.Dispose> and are not `sealed` (`NotInheritable` in Visual Basic).  
  
* A <xref:System.IDisposable.Dispose%2A> implementation that calls the `Dispose(Boolean)` method.  
  
* A `Dispose(Boolean)` method that performs the actual work of releasing resources.  
  
* Either a class derived from <xref:System.Runtime.InteropServices.SafeHandle> that wraps your unmanaged resource (recommended), or an override to the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method. The <xref:System.Runtime.InteropServices.SafeHandle> class provides a finalizer that frees you from having to code one.  
  
Here's the general pattern for implementing the dispose pattern for a base class that uses a safe handle.  
  
[!code-csharp[System.IDisposable#3](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.idisposable/cs/base1.cs#3)]
[!code-vb[System.IDisposable#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.idisposable/vb/base1.vb#3)]  
  
> [!NOTE]
> The previous example uses a <xref:Microsoft.Win32.SafeHandles.SafeFileHandle> object to illustrate the pattern; any object derived from <xref:System.Runtime.InteropServices.SafeHandle> could be used instead. Note that the example does not properly instantiate its <xref:Microsoft.Win32.SafeHandles.SafeFileHandle> object.  
  
Here's the general pattern for implementing the dispose pattern for a base class that overrides <xref:System.Object.Finalize%2A?displayProperty=nameWithType>.  
  
[!code-csharp[System.IDisposable#5](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.idisposable/cs/base2.cs#5)]
[!code-vb[System.IDisposable#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.idisposable/vb/base2.vb#5)]  
  
> [!NOTE]
> In C#, you override <xref:System.Object.Finalize%2A?displayProperty=nameWithType> by defining a [destructor](~/docs/csharp/programming-guide/classes-and-structs/destructors.md).  
  
## Implementing the dispose pattern for a derived class

A class derived from a class that implements the <xref:System.IDisposable> interface shouldn't implement <xref:System.IDisposable>, because the base class implementation of <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> is inherited by its derived classes. Instead, to implement the dispose pattern for a derived class, you provide the following:  
  
* A `protected Dispose(Boolean)` method that overrides the base class method and performs the actual work of releasing the resources of the derived class. This method should also call the `Dispose(Boolean)` method of the base class and pass it a value of `true` for the *disposing* argument.  
  
* Either a class derived from <xref:System.Runtime.InteropServices.SafeHandle> that wraps your unmanaged resource (recommended), or an override to the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method. The <xref:System.Runtime.InteropServices.SafeHandle> class provides a finalizer that frees you from having to code one. If you do provide a finalizer, it should call the `Dispose(Boolean)` overload with a *disposing* argument of `false`.  
  
Here's the general pattern for implementing the dispose pattern for a derived class that uses a safe handle:  
  
[!code-csharp[System.IDisposable#4](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.idisposable/cs/derived1.cs#4)]
[!code-vb[System.IDisposable#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.idisposable/vb/derived1.vb#4)]  
  
> [!NOTE]
> The previous example uses a <xref:Microsoft.Win32.SafeHandles.SafeFileHandle> object to illustrate the pattern; any object derived from <xref:System.Runtime.InteropServices.SafeHandle> could be used instead. Note that the example does not properly instantiate its <xref:Microsoft.Win32.SafeHandles.SafeFileHandle> object.  
  
Here's the general pattern for implementing the dispose pattern for a derived class that overrides <xref:System.Object.Finalize%2A?displayProperty=nameWithType>:  
  
[!code-csharp[System.IDisposable#6](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.idisposable/cs/derived2.cs#6)]
[!code-vb[System.IDisposable#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.idisposable/vb/derived2.vb#6)]  
  
> [!NOTE]
> In C#, you override <xref:System.Object.Finalize%2A?displayProperty=nameWithType> by defining a [destructor](~/docs/csharp/programming-guide/classes-and-structs/destructors.md).  
  
<a name="SafeHandles"></a>   
## Using safe handles

Writing code for an object's finalizer is a complex task that can cause problems if not done correctly. Therefore, we recommend that you construct <xref:System.Runtime.InteropServices.SafeHandle?displayProperty=nameWithType> objects instead of implementing a finalizer.  
  
Classes derived from the <xref:System.Runtime.InteropServices.SafeHandle?displayProperty=nameWithType> class simplify object lifetime issues by assigning and releasing handles without interruption. They contain a critical finalizer that is guaranteed to run while an application domain is unloading. For more information about the advantages of using a safe handle, see <xref:System.Runtime.InteropServices.SafeHandle?displayProperty=nameWithType>. The following derived classes in the <xref:Microsoft.Win32.SafeHandles> namespace provide safe handles:  
  
* The <xref:Microsoft.Win32.SafeHandles.SafeFileHandle>, <xref:Microsoft.Win32.SafeHandles.SafeMemoryMappedFileHandle>, and <xref:Microsoft.Win32.SafeHandles.SafePipeHandle> class, for files, memory mapped files, and pipes.  
  
* The <xref:Microsoft.Win32.SafeHandles.SafeMemoryMappedViewHandle> class, for memory views.  
  
* The <xref:Microsoft.Win32.SafeHandles.SafeNCryptKeyHandle>, <xref:Microsoft.Win32.SafeHandles.SafeNCryptProviderHandle>, and <xref:Microsoft.Win32.SafeHandles.SafeNCryptSecretHandle> classes, for cryptography constructs.  
  
* The <xref:Microsoft.Win32.SafeHandles.SafeRegistryHandle> class, for registry keys.  
  
* The <xref:Microsoft.Win32.SafeHandles.SafeWaitHandle> class, for wait handles.  
  
<a name="base"></a>   
## Using a safe handle to implement the dispose pattern for a base class

The following example illustrates the dispose pattern for a base class, `DisposableStreamResource`, that uses a safe handle to encapsulate unmanaged resources. It defines a `DisposableResource` class that uses a <xref:Microsoft.Win32.SafeHandles.SafeFileHandle> to wrap a <xref:System.IO.Stream> object that represents an open file. The `DisposableResource` method also includes a single property, `Size`, that returns the total number of bytes in the file stream.  
  
[!code-csharp[Conceptual.Disposable#9](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/base1.cs#9)]
[!code-vb[Conceptual.Disposable#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.disposable/vb/base1.vb#9)]  
  
<a name="derived"></a>   
## Using a safe handle to implement the dispose pattern for a derived class

The following example illustrates the dispose pattern for a derived class, `DisposableStreamResource2`, that inherits from the `DisposableStreamResource` class presented in the previous example. The class adds an additional method, `WriteFileInfo`, and uses a <xref:Microsoft.Win32.SafeHandles.SafeFileHandle> object to wrap the handle of the writable file.  
  
[!code-csharp[Conceptual.Disposable#10](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/derived1.cs#10)]
[!code-vb[Conceptual.Disposable#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.disposable/vb/derived1.vb#10)]  
  
## See also

<xref:System.GC.SuppressFinalize%2A>   
<xref:System.IDisposable>   
<xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType>   
<xref:Microsoft.Win32.SafeHandles>   
<xref:System.Runtime.InteropServices.SafeHandle?displayProperty=nameWithType>   
<xref:System.Object.Finalize%2A?displayProperty=nameWithType>   
[How to: Define and Consume Classes and Structs (C++/CLI)](/cpp/dotnet/how-to-define-and-consume-classes-and-structs-cpp-cli)   
[Dispose Pattern](../../../docs/standard/design-guidelines/dispose-pattern.md)
