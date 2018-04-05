---
title: "Managed and Unmanaged Threading in Windows"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "threading [.NET Framework], unmanaged"
  - "threading [.NET Framework], managed"
  - "managed threading"
ms.assetid: 4fb6452f-c071-420d-9e71-da16dee7a1eb
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Managed and Unmanaged Threading in Windows
Management of all threads is done through the <xref:System.Threading.Thread> class, including threads created by the common language runtime and those created outside the runtime that enter the managed environment to execute code. The runtime monitors all the threads in its process that have ever executed code within the managed execution environment. It does not track any other threads. Threads can enter the managed execution environment through COM interop (because the runtime exposes managed objects as COM objects to the unmanaged world), the COM [DllGetClassObject](https://msdn.microsoft.com/library/ms680760.aspx) function, and platform invoke.  
  
 When an unmanaged thread enters the runtime through, for example, a COM callable wrapper, the system checks the thread-local store of that thread to look for an internal managed <xref:System.Threading.Thread> object. If one is found, the runtime is already aware of this thread. If it cannot find one, however, the runtime builds a new <xref:System.Threading.Thread> object and installs it in the thread-local store of that thread.  
  
 In managed threading, <xref:System.Threading.Thread.GetHashCode%2A?displayProperty=nameWithType> is the stable managed thread identification. For the lifetime of your thread, it will not collide with the value from any other thread, regardless of the application domain from which you obtain this value.  
  
> [!NOTE]
>  An operating-system **ThreadId** has no fixed relationship to a managed thread, because an unmanaged host can control the relationship between managed and unmanaged threads. Specifically, a sophisticated host can use the Fiber API to schedule many managed threads against the same operating system thread, or to move a managed thread among different operating system threads.  
  
## Mapping from Win32 Threading to Managed Threading  
 The following table maps Win32 threading elements to their approximate runtime equivalent. Note that this mapping does not represent identical functionality. For example, **TerminateThread** does not execute **finally** clauses or free up resources, and cannot be prevented. However, <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> executes all your rollback code, reclaims all the resources, and can be denied using <xref:System.Threading.Thread.ResetAbort%2A>. Be sure to read the documentation closely before making assumptions about functionality.  
  
|In Win32|In the common language runtime|  
|--------------|------------------------------------|  
|**CreateThread**|Combination of **Thread** and <xref:System.Threading.ThreadStart>|  
|**TerminateThread**|<xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType>|  
|**SuspendThread**|<xref:System.Threading.Thread.Suspend%2A?displayProperty=nameWithType>|  
|**ResumeThread**|<xref:System.Threading.Thread.Resume%2A?displayProperty=nameWithType>|  
|**Sleep**|<xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType>|  
|**WaitForSingleObject** on the thread handle|<xref:System.Threading.Thread.Join%2A?displayProperty=nameWithType>|  
|**ExitThread**|No equivalent|  
|**GetCurrentThread**|<xref:System.Threading.Thread.CurrentThread%2A?displayProperty=nameWithType>|  
|**SetThreadPriority**|<xref:System.Threading.Thread.Priority%2A?displayProperty=nameWithType>|  
|No equivalent|<xref:System.Threading.Thread.Name%2A?displayProperty=nameWithType>|  
|No equivalent|<xref:System.Threading.Thread.IsBackground%2A?displayProperty=nameWithType>|  
|Close to **CoInitializeEx** (OLE32.DLL)|<xref:System.Threading.Thread.ApartmentState%2A?displayProperty=nameWithType>|  
  
## Managed Threads and COM Apartments  
 A managed thread can be marked to indicate that it will host a [single-threaded](https://msdn.microsoft.com/library/windows/desktop/ms680112.aspx) or [multithreaded](https://msdn.microsoft.com/library/windows/desktop/ms693421.aspx) apartment. (For more information on the COM threading architecture, see [Processes, threads, and Apartments](https://msdn.microsoft.com/library/windows/desktop/ms693344.aspx).) The <xref:System.Threading.Thread.GetApartmentState%2A>, <xref:System.Threading.Thread.SetApartmentState%2A>, and <xref:System.Threading.Thread.TrySetApartmentState%2A> methods of the <xref:System.Threading.Thread> class return and assign the apartment state of a thread. If the state has not been set, <xref:System.Threading.Thread.GetApartmentState%2A> returns <xref:System.Threading.ApartmentState.Unknown?displayProperty=nameWithType>.  
  
 The property can be set only when the thread is in the <xref:System.Threading.ThreadState.Unstarted?displayProperty=nameWithType> state; it can be set only once for a thread.  
  
 If the apartment state is not set before the thread is started, the thread is initialized as a multithreaded apartment (MTA). The finalizer thread and all threads controlled by <xref:System.Threading.ThreadPool> are MTA.  
  
> [!IMPORTANT]
>  For application startup code, the only way to control apartment state is to apply the <xref:System.MTAThreadAttribute> or the <xref:System.STAThreadAttribute> to the entry point procedure. In the .NET Framework 1.0 and 1.1, the <xref:System.Threading.Thread.ApartmentState%2A> property can be set as the first line of code. This is not permitted in the .NET Framework 2.0.  
  
 Managed objects that are exposed to COM behave as if they had aggregated the free-threaded marshaler. In other words, they can be called from any COM apartment in a free-threaded manner. The only managed objects that do not exhibit this free-threaded behavior are those objects that derive from <xref:System.EnterpriseServices.ServicedComponent> or <xref:System.Runtime.InteropServices.StandardOleMarshalObject>.  
  
 In the managed world, there is no support for the <xref:System.Runtime.Remoting.Contexts.SynchronizationAttribute> unless you use contexts and context-bound managed instances. If you are using Enterprise Services, then your object must derive from <xref:System.EnterpriseServices.ServicedComponent> (which is itself derived from <xref:System.ContextBoundObject>).  
  
 When managed code calls out to COM objects, it always follows COM rules. In other words, it calls through COM apartment proxies and COM+ 1.0 context wrappers as dictated by OLE32.  
  
## Blocking Issues  
 If a thread makes an unmanaged call into the operating system that has blocked the thread in unmanaged code, the runtime will not take control of it for <xref:System.Threading.Thread.Interrupt%2A?displayProperty=nameWithType> or <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType>. In the case of <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType>, the runtime marks the thread for **Abort** and takes control of it when it re-enters managed code. It is preferable for you to use managed blocking rather than unmanaged blocking. <xref:System.Threading.WaitHandle.WaitOne%2A?displayProperty=nameWithType>,<xref:System.Threading.WaitHandle.WaitAny%2A?displayProperty=nameWithType>, <xref:System.Threading.WaitHandle.WaitAll%2A?displayProperty=nameWithType>, <xref:System.Threading.Monitor.Enter%2A?displayProperty=nameWithType>, <xref:System.Threading.Monitor.TryEnter%2A?displayProperty=nameWithType>, <xref:System.Threading.Thread.Join%2A?displayProperty=nameWithType>, <xref:System.GC.WaitForPendingFinalizers%2A?displayProperty=nameWithType>, and so on are all responsive to <xref:System.Threading.Thread.Interrupt%2A?displayProperty=nameWithType> and to <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType>. Also, if your thread is in a single-threaded apartment, all these managed blocking operations will correctly pump messages in your apartment while your thread is blocked.  
  
## See Also  
 <xref:System.Threading.Thread.ApartmentState%2A?displayProperty=nameWithType>  
 <xref:System.Threading.ThreadState>  
 <xref:System.EnterpriseServices.ServicedComponent>  
 <xref:System.Threading.Thread>  
 <xref:System.Threading.Monitor>
