---
title: "Lazy Initialization"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "lazy initialization in .NET, introduction"
ms.assetid: 56b4ae5c-4745-44ff-ad78-ffe4fcde6b9b
caps.latest.revision: 22
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Lazy Initialization
*Lazy initialization* of an object means that its creation is deferred until it is first used. (For this topic, the terms *lazy initialization* and *lazy instantiation* are synonymous.) Lazy initialization is primarily used to improve performance, avoid wasteful computation, and reduce program memory requirements. These are the most common scenarios:  
  
-   When you have an object that is expensive to create, and the program might not use it. For example, assume that you have in memory a `Customer` object that has an `Orders` property that contains a large array of `Order` objects that, to be initialized, requires a database connection. If the user never asks to display the Orders or use the data in a computation, then there is no reason to use system memory or computing cycles to create it. By using `Lazy<Orders>` to declare the `Orders` object for lazy initialization, you can avoid wasting system resources when the object is not used.  
  
-   When you have an object that is expensive to create, and you want to defer its creation until after other expensive operations have been completed. For example, assume that your program loads several object instances when it starts, but only some of them are required immediately. You can improve the startup performance of the program by deferring initialization of the objects that are not required until the required objects have been created.  
  
 Although you can write your own code to perform lazy initialization, we recommend that you use <xref:System.Lazy%601> instead. <xref:System.Lazy%601> and its related types also support thread-safety and provide a consistent exception propagation policy.  
  
 The following table lists the types that the .NET Framework version 4 provides to enable lazy initialization in different scenarios.  
  
|Type|Description|  
|----------|-----------------|  
|<xref:System.Lazy%601>|A wrapper class that provides lazy initialization semantics for any class library or user-defined type.|  
|<xref:System.Threading.ThreadLocal%601>|Resembles <xref:System.Lazy%601> except that it provides lazy initialization semantics on a thread-local basis. Every thread has access to its own unique value.|  
|<xref:System.Threading.LazyInitializer>|Provides advanced `static` (`Shared` in Visual Basic) methods for lazy initialization of objects without the overhead of a class.|  
  
## Basic Lazy Initialization  
 To define a lazy-initialized type, for example, `MyType`, use `Lazy<MyType>` (`Lazy(Of MyType)` in Visual Basic), as shown in the following example. If no delegate is passed in the <xref:System.Lazy%601> constructor, the wrapped type is created by using <xref:System.Activator.CreateInstance%2A?displayProperty=nameWithType> when the value property is first accessed. If the type does not have a default constructor, a run-time exception is thrown.  
  
 In the following example, assume that `Orders` is a class that contains an array of `Order` objects retrieved from a database. A `Customer` object contains an instance of `Orders`, but depending on user actions, the data from the `Orders` object might not be required.  
  
 [!code-csharp[Lazy#1](../../../samples/snippets/csharp/VS_Snippets_Misc/lazy/cs/cs_lazycodefile.cs#1)]
 [!code-vb[Lazy#1](../../../samples/snippets/visualbasic/VS_Snippets_Misc/lazy/vb/lazy_vb.vb#1)]  
  
 You can also pass a delegate in the <xref:System.Lazy%601> constructor that invokes a specific constructor overload on the wrapped type at creation time, and perform any other initialization steps that are required, as shown in the following example.  
  
 [!code-csharp[Lazy#2](../../../samples/snippets/csharp/VS_Snippets_Misc/lazy/cs/cs_lazycodefile.cs#2)]
 [!code-vb[Lazy#2](../../../samples/snippets/visualbasic/VS_Snippets_Misc/lazy/vb/lazy_vb.vb#2)]  
  
 After the Lazy object is created, no instance of `Orders` is created until the <xref:System.Lazy%601.Value%2A> property of the Lazy variable is accessed for the first time. On first access, the wrapped type is created and returned, and stored for any future access.  
  
 [!code-csharp[Lazy#3](../../../samples/snippets/csharp/VS_Snippets_Misc/lazy/cs/cs_lazycodefile.cs#3)]
 [!code-vb[Lazy#3](../../../samples/snippets/visualbasic/VS_Snippets_Misc/lazy/vb/lazy_vb.vb#3)]  
  
 A <xref:System.Lazy%601> object always returns the same object or value that it was initialized with. Therefore, the <xref:System.Lazy%601.Value%2A> property is read-only. If <xref:System.Lazy%601.Value%2A> stores a reference type, you cannot assign a new object to it. (However, you can change the value of its settable public fields and properties.) If <xref:System.Lazy%601.Value%2A> stores a value type, you cannot modify its value. Nevertheless, you can create a new variable by invoking the variable constructor again by using new arguments.  
  
 [!code-csharp[Lazy#4](../../../samples/snippets/csharp/VS_Snippets_Misc/lazy/cs/cs_lazycodefile.cs#4)]
 [!code-vb[Lazy#4](../../../samples/snippets/visualbasic/VS_Snippets_Misc/lazy/vb/lazy_vb.vb#4)]  
  
 The new lazy instance, like the earlier one, does not instantiate `Orders` until its <xref:System.Lazy%601.Value%2A> property is first accessed.  
  
### Thread-Safe Initialization  
 By default, <xref:System.Lazy%601> objects are thread-safe. That is, if the constructor does not specify the kind of thread safety, the <xref:System.Lazy%601> objects it creates are thread-safe. In multi-threaded scenarios, the first thread to access the <xref:System.Lazy%601.Value%2A> property of a thread-safe <xref:System.Lazy%601> object initializes it for all subsequent accesses on all threads, and all threads share the same data. Therefore, it does not matter which thread initializes the object, and race conditions are benign.  
  
> [!NOTE]
>  You can extend this consistency to error conditions by using exception caching. For more information, see the next section, [Exceptions in Lazy Objects](../../../docs/framework/performance/lazy-initialization.md#ExceptionsInLazyObjects).  
  
 The following example shows that the same `Lazy<int>` instance has the same value for three separate threads.  
  
 [!code-csharp[Lazy#8](../../../samples/snippets/csharp/VS_Snippets_Misc/lazy/cs/cs_lazycodefile.cs#8)]
 [!code-vb[Lazy#8](../../../samples/snippets/visualbasic/VS_Snippets_Misc/lazy/vb/lazy_vb.vb#8)]  
  
 If you require separate data on each thread, use the <xref:System.Threading.ThreadLocal%601> type, as described later in this topic.  
  
 Some <xref:System.Lazy%601> constructors have a Boolean parameter named `isThreadSafe` that is used to specify whether the <xref:System.Lazy%601.Value%2A> property will be accessed from multiple threads. If you intend to access the property from just one thread, pass in `false` to obtain a modest performance benefit. If you intend to access the property from multiple threads, pass in `true` to instruct the <xref:System.Lazy%601> instance to correctly handle race conditions in which one thread throws an exception at initialization time.  
  
 Some <xref:System.Lazy%601> constructors have a <xref:System.Threading.LazyThreadSafetyMode> parameter named `mode`. These constructors provide an additional thread safety mode. The following table shows how the thread safety of a <xref:System.Lazy%601> object is affected by constructor parameters that specify thread safety. Each constructor has at most one such parameter.  
  
|Thread safety of the object|`LazyThreadSafetyMode` `mode` parameter|Boolean `isThreadSafe` parameter|No thread safety parameters|  
|---------------------------------|---------------------------------------------|--------------------------------------|---------------------------------|  
|Fully thread-safe; only one thread at a time tries to initialize the value.|<xref:System.Threading.LazyThreadSafetyMode.ExecutionAndPublication>|`true`|Yes.|  
|Not thread-safe.|<xref:System.Threading.LazyThreadSafetyMode.None>|`false`|Not applicable.|  
|Fully thread-safe; threads race to initialize the value.|<xref:System.Threading.LazyThreadSafetyMode.PublicationOnly>|Not applicable.|Not applicable.|  
  
 As the table shows, specifying <xref:System.Threading.LazyThreadSafetyMode.ExecutionAndPublication?displayProperty=nameWithType> for the `mode` parameter is the same as specifying `true` for the `isThreadSafe` parameter, and specifying <xref:System.Threading.LazyThreadSafetyMode.None?displayProperty=nameWithType> is the same as specifying `false`.  
  
 Specifying <xref:System.Threading.LazyThreadSafetyMode.PublicationOnly?displayProperty=nameWithType> allows multiple threads to attempt to initialize the <xref:System.Lazy%601> instance. Only one thread can win this race, and all the other threads receive the value that was initialized by the successful thread. If an exception is thrown on a thread during initialization, that thread does not receive the value set by the successful thread. Exceptions are not cached, so a subsequent attempt to access the <xref:System.Lazy%601.Value%2A> property can result in successful initialization. This differs from the way exceptions are treated in other modes, which is described in the following section. For more information, see the <xref:System.Threading.LazyThreadSafetyMode> enumeration.  
  
<a name="ExceptionsInLazyObjects"></a>   
## Exceptions in Lazy Objects  
 As stated earlier, a <xref:System.Lazy%601> object always returns the same object or value that it was initialized with, and therefore the <xref:System.Lazy%601.Value%2A> property is read-only. If you enable exception caching, this immutability also extends to exception behavior. If a lazy-initialized object has exception caching enabled and throws an exception from its initialization method when the <xref:System.Lazy%601.Value%2A> property is first accessed, that same exception is thrown on every subsequent attempt to access the <xref:System.Lazy%601.Value%2A> property. In other words, the constructor of the wrapped type is never re-invoked, even in multithreaded scenarios. Therefore, the <xref:System.Lazy%601> object cannot throw an exception on one access and return a value on a subsequent access.  
  
 Exception caching is enabled when you use any <xref:System.Lazy%601?displayProperty=nameWithType> constructor that takes an initialization method (`valueFactory` parameter); for example, it is enabled when you use the `Lazy(T)(Func(T))`constructor. If the constructor also takes a <xref:System.Threading.LazyThreadSafetyMode> value (`mode` parameter), specify <xref:System.Threading.LazyThreadSafetyMode.ExecutionAndPublication?displayProperty=nameWithType> or <xref:System.Threading.LazyThreadSafetyMode.None?displayProperty=nameWithType>. Specifying an initialization method enables exception caching for these two modes. The initialization method can be very simple. For example, it might call the default constructor for `T`: `new Lazy<Contents>(() => new Contents(), mode)` in C#, or `New Lazy(Of Contents)(Function() New Contents())` in Visual Basic. If you use a <xref:System.Lazy%601?displayProperty=nameWithType> constructor that does not specify an initialization method, exceptions that are thrown by the default constructor for `T` are not cached. For more information, see the <xref:System.Threading.LazyThreadSafetyMode> enumeration.  
  
> [!NOTE]
>  If you create a <xref:System.Lazy%601> object with the `isThreadSafe` constructor parameter set to `false` or the `mode` constructor parameter set to <xref:System.Threading.LazyThreadSafetyMode.None?displayProperty=nameWithType>, you must access the <xref:System.Lazy%601> object from a single thread or provide your own synchronization. This applies to all aspects of the object, including exception caching.  
  
 As noted in the previous section, <xref:System.Lazy%601> objects created by specifying <xref:System.Threading.LazyThreadSafetyMode.PublicationOnly?displayProperty=nameWithType> treat exceptions differently. With <xref:System.Threading.LazyThreadSafetyMode.PublicationOnly>, multiple threads can compete to initialize the <xref:System.Lazy%601> instance. In this case, exceptions are not cached, and attempts to access the <xref:System.Lazy%601.Value%2A> property can continue until initialization is successful.  
  
 The following table summarizes the way the <xref:System.Lazy%601> constructors control exception caching.  
  
|Constructor|Thread safety mode|Uses initialization method|Exceptions are cached|  
|-----------------|------------------------|--------------------------------|---------------------------|  
|Lazy(T)()|(<xref:System.Threading.LazyThreadSafetyMode.ExecutionAndPublication>)|No|No|  
|Lazy(T)(Func(T))|(<xref:System.Threading.LazyThreadSafetyMode.ExecutionAndPublication>)|Yes|Yes|  
|Lazy(T)(Boolean)|`True` (<xref:System.Threading.LazyThreadSafetyMode.ExecutionAndPublication>) or `false` (<xref:System.Threading.LazyThreadSafetyMode.None>)|No|No|  
|Lazy(T)(Func(T), Boolean)|`True` (<xref:System.Threading.LazyThreadSafetyMode.ExecutionAndPublication>) or `false` (<xref:System.Threading.LazyThreadSafetyMode.None>)|Yes|Yes|  
|Lazy(T)(LazyThreadSafetyMode)|User-specified|No|No|  
|Lazy(T)(Func(T), LazyThreadSafetyMode)|User-specified|Yes|No if user specifies <xref:System.Threading.LazyThreadSafetyMode.PublicationOnly>; otherwise, yes.|  
  
## Implementing a Lazy-Initialized Property  
 To implement a public property by using lazy initialization, define the backing field of the property as a <xref:System.Lazy%601>, and return the <xref:System.Lazy%601.Value%2A> property from the `get` accessor of the property.  
  
 [!code-csharp[Lazy#5](../../../samples/snippets/csharp/VS_Snippets_Misc/lazy/cs/cs_lazycodefile.cs#5)]
 [!code-vb[Lazy#5](../../../samples/snippets/visualbasic/VS_Snippets_Misc/lazy/vb/lazy_vb.vb#5)]  
  
 The <xref:System.Lazy%601.Value%2A> property is read-only; therefore, the property that exposes it has no `set` accessor. If you require a read/write property backed by a <xref:System.Lazy%601> object, the `set` accessor must create a new <xref:System.Lazy%601> object and assign it to the backing store. The `set` accessor must create a lambda expression that returns the new property value that was passed to the `set` accessor, and pass that lambda expression to the constructor for the new <xref:System.Lazy%601> object. The next access of the <xref:System.Lazy%601.Value%2A> property will cause initialization of the new <xref:System.Lazy%601>, and its <xref:System.Lazy%601.Value%2A> property will thereafter return the new value that was assigned to the property. The reason for this convoluted arrangement is to preserve the multithreading protections built into <xref:System.Lazy%601>. Otherwise, the property accessors would have to cache the first value returned by the <xref:System.Lazy%601.Value%2A> property and only modify the cached value, and you would have to write your own thread-safe code to do that. Because of the additional initializations required by a read/write property backed by a <xref:System.Lazy%601> object, the performance might not be acceptable. Furthermore, depending on the specific scenario, additional coordination might be required to avoid race conditions between setters and getters.  
  
## Thread-Local Lazy Initialization  
 In some multithreaded scenarios, you might want to give each thread its own private data. Such data is called *thread-local data*. In the .NET Framework version 3.5 and earlier, you could apply the `ThreadStatic` attribute to a static variable to make it thread-local. However, using the `ThreadStatic` attribute can lead to subtle errors. For example, even basic initialization statements will cause the variable to be initialized only on the first thread that accesses it, as shown in the following example.  
  
 [!code-csharp[Lazy#6](../../../samples/snippets/csharp/VS_Snippets_Misc/lazy/cs/cs_lazycodefile.cs#6)]
 [!code-vb[Lazy#6](../../../samples/snippets/visualbasic/VS_Snippets_Misc/lazy/vb/lazy_vb.vb#6)]  
  
 On all other threads, the variable will be initialized by using its default value (zero). As an alternative in the .NET Framework version 4, you can use the <xref:System.Threading.ThreadLocal%601?displayProperty=nameWithType> type to create an instance-based, thread-local variable that is initialized on all threads by the <xref:System.Action%601> delegate that you provide. In the following example, all threads that access `counter` will see its starting value as 1.  
  
 [!code-csharp[Lazy#7](../../../samples/snippets/csharp/VS_Snippets_Misc/lazy/cs/cs_lazycodefile.cs#7)]
 [!code-vb[Lazy#7](../../../samples/snippets/visualbasic/VS_Snippets_Misc/lazy/vb/lazy_vb.vb#7)]  
  
 <xref:System.Threading.ThreadLocal%601> wraps its object in much the same way as <xref:System.Lazy%601>, with these essential differences:  
  
-   Each thread initializes the thread-local variable by using its own private data that is not accessible from other threads.  
  
-   The <xref:System.Threading.ThreadLocal%601.Value%2A?displayProperty=nameWithType> property is read-write, and can be modified any number of times. This can affect exception propagation, for example, one `get` operation can raise an exception but the next one can successfully initialize the value.  
  
-   If no initialization delegate is provided, <xref:System.Threading.ThreadLocal%601> will initialize its wrapped type by using the default value of the type. In this regard, <xref:System.Threading.ThreadLocal%601> is consistent with the <xref:System.ThreadStaticAttribute> attribute.  
  
 The following example demonstrates that every thread that accesses the `ThreadLocal<int>` instance gets its own unique copy of the data.  
  
 [!code-csharp[Lazy#9](../../../samples/snippets/csharp/VS_Snippets_Misc/lazy/cs/cs_lazycodefile.cs#9)]
 [!code-vb[Lazy#9](../../../samples/snippets/visualbasic/VS_Snippets_Misc/lazy/vb/lazy_vb.vb#9)]  
  
## Thread-Local Variables in Parallel.For and ForEach  
 When you use the <xref:System.Threading.Tasks.Parallel.For%2A?displayProperty=nameWithType> method or <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType> method to iterate over data sources in parallel, you can use the overloads that have built-in support for thread-local data. In these methods, the thread-locality is achieved by using local delegates to create, access, and clean up the data. For more information, see [How to: Write a Parallel.For Loop with Thread-Local Variables](../../../docs/standard/parallel-programming/how-to-write-a-parallel-for-loop-with-thread-local-variables.md) and [How to: Write a Parallel.ForEach Loop with Thread-Local Variables](../../../docs/standard/parallel-programming/how-to-write-a-parallel-foreach-loop-with-thread-local-variables.md).  
  
## Using Lazy Initialization for Low-Overhead Scenarios  
 In scenarios where you have to lazy-initialize a large number of objects, you might decide that wrapping each object in a <xref:System.Lazy%601> requires too much memory or too many computing resources. Or, you might have stringent requirements about how lazy initialization is exposed. In such cases, you can use the `static` (`Shared` in Visual Basic) methods of the <xref:System.Threading.LazyInitializer?displayProperty=nameWithType> class to lazy-initialize each object without wrapping it in an instance of <xref:System.Lazy%601>.  
  
 In the following example, assume that, instead of wrapping an entire `Orders` object in one <xref:System.Lazy%601> object, you have lazy-initialized individual `Order` objects only if they are required.  
  
 [!code-csharp[Lazy#10](../../../samples/snippets/csharp/VS_Snippets_Misc/lazy/cs/cs_lazycodefile.cs#10)]
 [!code-vb[Lazy#10](../../../samples/snippets/visualbasic/VS_Snippets_Misc/lazy/vb/lazy_vb.vb#10)]  
  
 In this example, notice that the initialization procedure is invoked on every iteration of the loop. In multi-threaded scenarios, the first thread to invoke the initialization procedure is the one whose value is seen by all threads. Later threads also invoke the initialization procedure, but their results are not used. If this kind of potential race condition is not acceptable, use the overload of <xref:System.Threading.LazyInitializer.EnsureInitialized%2A?displayProperty=nameWithType> that takes a Boolean argument and a synchronization object.  
  
## See Also  
 [Managed Threading Basics](../../../docs/standard/threading/managed-threading-basics.md)  
 [Threads and Threading](../../../docs/standard/threading/threads-and-threading.md)  
 [Task Parallel Library (TPL)](../../../docs/standard/parallel-programming/task-parallel-library-tpl.md)  
 [How to: Perform Lazy Initialization of Objects](../../../docs/framework/performance/how-to-perform-lazy-initialization-of-objects.md)
