---
title: "Synchronizing Data for Multithreading"
description: Learn how to synchronize data for multithreading in .NET. Choose strategies such as synchronized code regions, manual synchronization, or synchronized contexts.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "synchronization, threads"
  - "threading [.NET], synchronizing threads"
  - "managed threading"
ms.topic: how-to
---
# Synchronizing data for multithreading

When multiple threads can make calls to the properties and methods of a single object, it is critical that those calls be synchronized. Otherwise one thread might interrupt what another thread is doing, and the object could be left in an invalid state. A class whose members are protected from such interruptions is called thread-safe.  
  
.NET provides several strategies to synchronize access to instance and static members:  
  
- Synchronized code regions. You can use the <xref:System.Threading.Monitor> class or compiler support for this class to synchronize only the code block that needs it, improving performance.  
  
- Manual synchronization. You can use the synchronization objects provided by the .NET class library. See [Overview of Synchronization Primitives](overview-of-synchronization-primitives.md), which includes a discussion of the <xref:System.Threading.Monitor> class.  
  
- Synchronized contexts. For .NET Framework and Xamarin applications only, you can use the <xref:System.Runtime.Remoting.Contexts.SynchronizationAttribute> to enable simple, automatic synchronization for <xref:System.ContextBoundObject> objects.  
  
- Collection classes in the <xref:System.Collections.Concurrent?displayProperty=nameWithType> namespace. These classes provide built-in synchronized add and remove operations. For more information, see [Thread-Safe Collections](../collections/thread-safe/index.md).  
  
 The common language runtime provides a thread model in which classes fall into a number of categories that can be synchronized in a variety of different ways depending on the requirements. The following table shows what synchronization support is provided for fields and methods with a given synchronization category.  
  
|Category|Global fields|Static fields|Static methods|Instance fields|Instance methods|Specific code blocks|  
|--------------|-------------------|-------------------|--------------------|---------------------|----------------------|--------------------------|  
|No Synchronization|No|No|No|No|No|No|  
|Synchronized Context|No|No|No|Yes|Yes|No|  
|Synchronized Code Regions|No|No|Only if marked|No|Only if marked|Only if marked|  
|Manual Synchronization|Manual|Manual|Manual|Manual|Manual|Manual|  
  
## No synchronization  

 This is the default for objects. Any thread can access any method or field at any time. Only one thread at a time should access these objects.  
  
## Manual synchronization  

 The .NET class library provides a number of classes for synchronizing threads. See [Overview of Synchronization Primitives](overview-of-synchronization-primitives.md).  
  
## Synchronized code regions  

 You can use the <xref:System.Threading.Monitor> class or a compiler keyword to synchronize blocks of code, instance methods, and static methods. There is no support for synchronized static fields.  
  
 Both Visual Basic and C# support the marking of blocks of code with a particular language keyword, the `lock` statement in C# or the `SyncLock` statement in Visual Basic. When the code is executed by a thread, an attempt is made to acquire the lock. If the lock has already been acquired by another thread, the thread blocks until the lock becomes available. When the thread exits the synchronized block of code, the lock is released, no matter how the thread exits the block.  
  
> [!NOTE]
> The `lock` and `SyncLock` statements are implemented using <xref:System.Threading.Monitor.Enter%2A?displayProperty=nameWithType> and <xref:System.Threading.Monitor.Exit%2A?displayProperty=nameWithType>, so other methods of <xref:System.Threading.Monitor> can be used in conjunction with them within the synchronized region.  
  
 You can also decorate a method with a <xref:System.Runtime.CompilerServices.MethodImplAttribute> with a value of <xref:System.Runtime.CompilerServices.MethodImplOptions.Synchronized?displayProperty=nameWithType>, which has the same effect as using <xref:System.Threading.Monitor> or one of the compiler keywords to lock the entire body of the method.  
  
 <xref:System.Threading.Thread.Interrupt%2A?displayProperty=nameWithType> can be used to break a thread out of blocking operations such as waiting for access to a synchronized region of code. **Thread.Interrupt** is also used to break threads out of operations like <xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType>.  
  
> [!IMPORTANT]
> Do not lock the type — that is, `typeof(MyType)` in C#, `GetType(MyType)` in Visual Basic, or `MyType::typeid` in C++ — in order to protect `static` methods (`Shared` methods in Visual Basic). Use a private static object instead. Similarly, do not use `this` in C# (`Me` in Visual Basic) to lock instance methods. Use a private object instead. A class or instance can be locked by code other than your own, potentially causing deadlocks or performance problems.  
  
### Compiler support  

 Both Visual Basic and C# support a language keyword that uses <xref:System.Threading.Monitor.Enter%2A?displayProperty=nameWithType> and <xref:System.Threading.Monitor.Exit%2A?displayProperty=nameWithType> to lock the object. Visual Basic supports the [SyncLock](../../visual-basic/language-reference/statements/synclock-statement.md) statement; C# supports the [lock](../../csharp/language-reference/statements/lock.md) statement.  
  
 In both cases, if an exception is thrown in the code block, the lock acquired by the **lock** or **SyncLock** is released automatically. The C# and Visual Basic compilers emit a **try**/**finally** block with **Monitor.Enter** at the beginning of the try, and **Monitor.Exit** in the **finally** block. If an exception is thrown inside the **lock** or **SyncLock** block, the **finally** handler runs to allow you to do any clean-up work.  
  
## Synchronized Context  

In .NET Framework and Xamarin applications only, you can use the <xref:System.Runtime.Remoting.Contexts.SynchronizationAttribute> on any <xref:System.ContextBoundObject> to synchronize all instance methods and fields. All objects in the same context domain share the same lock. Multiple threads are allowed to access the methods and fields, but only a single thread is allowed at any one time.  
  
## See also

- <xref:System.Runtime.Remoting.Contexts.SynchronizationAttribute>
- [Threads and Threading](threads-and-threading.md)
- [Overview of Synchronization Primitives](overview-of-synchronization-primitives.md)
- [SyncLock Statement](../../visual-basic/language-reference/statements/synclock-statement.md)
- [lock Statement](../../csharp/language-reference/statements/lock.md)
