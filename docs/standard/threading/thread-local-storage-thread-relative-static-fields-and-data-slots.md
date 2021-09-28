---
description: "Learn more about: Thread Local Storage: Thread-Relative Static Fields and Data Slots"
title: "Thread Local Storage: Thread-Relative Static Fields and Data Slots"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "threading [.NET], local storage"
  - "threading [.NET], thread-relative static fields"
  - "local thread storage"
  - "TLS"
ms.assetid: c633a4dc-a790-4ed1-96b5-f72bd968b284
---
# Thread Local Storage: Thread-Relative Static Fields and Data Slots

You can use managed thread local storage (TLS) to store data that's unique to a thread and application domain. .NET provides two ways to use managed TLS: thread-relative static fields and data slots.  
  
- Use thread-relative static fields (thread-relative `Shared` fields in Visual Basic) if you can anticipate your exact needs at compile time. Thread-relative static fields provide the best performance. They also give you the benefits of compile-time type checking.  
  
- Use data slots when your actual requirements might be discovered only at run time. Data slots are slower and more awkward to use than thread-relative static fields, and data is stored as type <xref:System.Object>, so you must cast it to the correct type before you use it.  
  
 In unmanaged C++, you use `TlsAlloc` to allocate slots dynamically and `__declspec(thread)` to declare that a variable should be allocated in thread-relative storage. Thread-relative static fields and data slots provide the managed version of this behavior.  
  
You can use the <xref:System.Threading.ThreadLocal%601?displayProperty=nameWithType> class to create thread-local objects that are initialized lazily when the object is first consumed. For more information, see [Lazy Initialization](../../framework/performance/lazy-initialization.md).  
  
## Uniqueness of Data in Managed TLS  

 Whether you use thread-relative static fields or data slots, data in managed TLS is unique to the combination of thread and application domain.  
  
- Within an application domain, one thread cannot modify data from another thread, even when both threads use the same field or slot.  
  
- When a thread accesses the same field or slot from multiple application domains, a separate value is maintained in each application domain.  
  
 For example, if a thread sets the value of a thread-relative static field, enters another application domain, and then retrieves the value of the field, the value retrieved in the second application domain differs from the value in the first application domain. Setting a new value for the field in the second application domain does not affect the field's value in the first application domain.  
  
 Similarly, when a thread gets the same named data slot in two different application domains, the data in the first application domain remains independent of the data in the second application domain.  
  
## Thread-Relative Static Fields  

 If you know that a piece of data is always unique to a thread and application-domain combination, apply the <xref:System.ThreadStaticAttribute> attribute to the static field. Use the field as you would use any other static field. The data in the field is unique to each thread that uses it.  
  
 Thread-relative static fields provide better performance than data slots and have the benefit of compile-time type checking.  
  
 Be aware that any class constructor code will run on the first thread in the first context that accesses the field. In all other threads or contexts in the same application domain, the fields will be initialized to `null` (`Nothing` in Visual Basic) if they are reference types, or to their default values if they are value types. Therefore, you should not rely on class constructors to initialize thread-relative static fields. Instead, avoid initializing thread-relative static fields and assume that they are initialized to `null` (`Nothing`) or to their default values.  
  
## Data Slots  

.NET provides dynamic data slots that are unique to a combination of thread and application domain. There are two types of data slots: named slots and unnamed slots. Both are implemented by using the <xref:System.LocalDataStoreSlot> structure.  
  
- To create a named data slot, use the <xref:System.Threading.Thread.AllocateNamedDataSlot%2A?displayProperty=nameWithType> or <xref:System.Threading.Thread.GetNamedDataSlot%2A?displayProperty=nameWithType> method. To get a reference to an existing named slot, pass its name to the <xref:System.Threading.Thread.GetNamedDataSlot%2A> method.  
  
- To create an unnamed data slot, use the <xref:System.Threading.Thread.AllocateDataSlot%2A?displayProperty=nameWithType> method.  
  
 For both named and unnamed slots, use the <xref:System.Threading.Thread.SetData%2A?displayProperty=nameWithType> and <xref:System.Threading.Thread.GetData%2A?displayProperty=nameWithType> methods to set and retrieve the information in the slot. These are static methods that always act on the data for the thread that is currently executing them.  
  
 Named slots can be convenient, because you can retrieve the slot when you need it by passing its name to the <xref:System.Threading.Thread.GetNamedDataSlot%2A> method, instead of maintaining a reference to an unnamed slot. However, if another component uses the same name for its thread-relative storage and a thread executes code from both your component and the other component, the two components might corrupt each other's data. (This scenario assumes that both components are running in the same application domain, and that they are not designed to share the same data.)  
  
## See also

- <xref:System.ContextStaticAttribute>
- <xref:System.Threading.Thread.GetNamedDataSlot%2A?displayProperty=nameWithType>
- <xref:System.ThreadStaticAttribute>
- <xref:System.Runtime.Remoting.Messaging.CallContext>
- [Threading](index.md)
