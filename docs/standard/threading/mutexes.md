---
description: "Learn how to use a Mutex from the System.Threading namespace."
title: "Mutexes"
ms.date: 07/19/2021
helpviewer_keywords: 
  - "wait handles"
  - "threading [.NET], Mutex class"
  - "Mutex class, about Mutex class"
  - "threading [.NET], cross-process synchronization"
ms.assetid: 9dd06e25-12c0-4a9e-855a-452dc83803e2
---

# Mutexes

You can use a <xref:System.Threading.Mutex> object to provide exclusive access to a resource. The <xref:System.Threading.Mutex> class uses more system resources than the <xref:System.Threading.Monitor> class, but it can be marshaled across application domain boundaries, it can be used with multiple waits, and it can be used to synchronize threads in different processes. For a comparison of managed synchronization mechanisms, see [Overview of Synchronization Primitives](overview-of-synchronization-primitives.md).

For code examples, see the reference documentation for the <xref:System.Threading.Mutex.%23ctor%2A> constructors.

## Use mutexes

A thread calls the <xref:System.Threading.WaitHandle.WaitOne%2A> method of a mutex to request ownership. The call blocks until the mutex is available, or until the optional timeout interval elapses. The state of a mutex is signaled if no thread owns it.

A thread releases a mutex by calling its <xref:System.Threading.Mutex.ReleaseMutex%2A> method. Mutexes have thread affinity; that is, the mutex can be released only by the thread that owns it. If a thread releases a mutex it does not own, an <xref:System.ApplicationException> is thrown in the thread.

Because the <xref:System.Threading.Mutex> class derives from <xref:System.Threading.WaitHandle>, you can also call the static <xref:System.Threading.WaitHandle.WaitAll%2A> or <xref:System.Threading.WaitHandle.WaitAny%2A> methods of <xref:System.Threading.WaitHandle> to request ownership of a <xref:System.Threading.Mutex> in combination with other wait handles.
  
If a thread owns a <xref:System.Threading.Mutex>, that thread can specify the same <xref:System.Threading.Mutex> in repeated wait-request calls without blocking its execution; however, it must release the <xref:System.Threading.Mutex> as many times to release ownership.  

## Abandoned mutexes

If a thread terminates without releasing a <xref:System.Threading.Mutex>, the mutex is said to be abandoned. This often indicates a serious programming error because the resource the mutex is protecting might be left in an inconsistent state. An <xref:System.Threading.AbandonedMutexException> is thrown in the next thread that acquires the mutex.
  
In the case of a system-wide mutex, an abandoned mutex might indicate that an application has been terminated abruptly (for example, by using Windows Task Manager).
  
## Local and system mutexes

Mutexes are of two types: local mutexes and named system mutexes. If you create a <xref:System.Threading.Mutex> object using a constructor that accepts a name, it is associated with an operating-system object of that name. Named system mutexes are visible throughout the operating system and can be used to synchronize the activities of processes. You can create multiple <xref:System.Threading.Mutex> objects that represent the same named system mutex, and you can use the <xref:System.Threading.Mutex.OpenExisting%2A> method to open an existing named system mutex.

A local mutex exists only within your process. It can be used by any thread in your process that has a reference to the local <xref:System.Threading.Mutex> object. Each <xref:System.Threading.Mutex> object is a separate local mutex.

### Access control security for system mutexes

.NET Framework provides the ability to query and set Windows access control security for named system objects. Protecting system mutexes from the moment of creation is recommended because system objects are global and therefore can be locked by code other than your own.

For information on access control security for mutexes, see the <xref:System.Security.AccessControl.MutexSecurity> and <xref:System.Security.AccessControl.MutexAccessRule> classes, the <xref:System.Security.AccessControl.MutexRights> enumeration, the <xref:System.Threading.Mutex.GetAccessControl%2A?view=netframework-4.8>, <xref:System.Threading.Mutex.SetAccessControl%2A?view=netframework-4.8>, and <xref:System.Threading.Mutex.OpenExisting%2A> methods of the <xref:System.Threading.Mutex> class, and the <xref:System.Threading.Mutex.%23ctor%28System.Boolean%2CSystem.String%2CSystem.Boolean%40%2CSystem.Security.AccessControl.MutexSecurity%29?view=netframework-4.8> constructor.

> [!NOTE]
> Access control security for system mutexes is only available with .NET Framework, it's not available with .NET Core or .NET 5+.

## See also

- <xref:System.Threading.Mutex?displayProperty=nameWithType>
- <xref:System.Threading.Mutex.%23ctor%2A>
- <xref:System.Security.AccessControl.MutexSecurity?displayProperty=nameWithType>
- <xref:System.Security.AccessControl.MutexAccessRule?displayProperty=nameWithType>
- <xref:System.Threading.Monitor?displayProperty=nameWithType>
- [Threading objects and features](threading-objects-and-features.md)
- [Threads and threading](threads-and-threading.md)
- [Threading](index.md)
