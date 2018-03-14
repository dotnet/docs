---
title: "Exceptions in Managed Threads"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "unhandled exceptions,in managed threads"
  - "threading [.NET Framework],unhandled exceptions"
  - "threading [.NET Framework],exceptions in managed threads"
  - "managed threading"
ms.assetid: 11294769-2e89-43cb-890e-ad4ad79cfbee
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Exceptions in Managed Threads
Starting with the .NET Framework version 2.0, the common language runtime allows most unhandled exceptions in threads to proceed naturally. In most cases this means that the unhandled exception causes the application to terminate.  
  
> [!NOTE]
>  This is a significant change from the .NET Framework versions 1.0 and 1.1, which provide a backstop for many unhandled exceptions — for example, unhandled exceptions in thread pool threads. See [Change from Previous Versions](#ChangeFromPreviousVersions) later in this topic.  
  
 The common language runtime provides a backstop for certain unhandled exceptions that are used for controlling program flow:  
  
-   A <xref:System.Threading.ThreadAbortException> is thrown in a thread because <xref:System.Threading.Thread.Abort%2A> was called.  
  
-   An <xref:System.AppDomainUnloadedException> is thrown in a thread because the application domain in which the thread is executing is being unloaded.  
  
-   The common language runtime or a host process terminates the thread by throwing an internal exception.  
  
 If any of these exceptions are unhandled in threads created by the common language runtime, the exception terminates the thread, but the common language runtime does not allow the exception to proceed further.  
  
 If these exceptions are unhandled in the main thread, or in threads that entered the runtime from unmanaged code, they proceed normally, resulting in termination of the application.  
  
> [!NOTE]
>  It is possible for the runtime to throw an unhandled exception before any managed code has had a chance to install an exception handler. Even though managed code had no chance to handle such an exception, the exception is allowed to proceed naturally.  
  
## Exposing Threading Problems During Development  
 When threads are allowed to fail silently, without terminating the application, serious programming problems can go undetected. This is a particular problem for services and other applications which run for extended periods. As threads fail, program state gradually becomes corrupted. Application performance may degrade, or the application might hang.  
  
 Allowing unhandled exceptions in threads to proceed naturally, until the operating system terminates the program, exposes such problems during development and testing. Error reports on program terminations support debugging.  
  
<a name="ChangeFromPreviousVersions"></a>   
## Change from Previous Versions  
 The most significant change pertains to managed threads. In the .NET Framework versions 1.0 and 1.1, the common language runtime provides a backstop for unhandled exceptions in the following situations:  
  
-   There is no such thing as an unhandled exception on a thread pool thread. When a task throws an exception that it does not handle, the runtime prints the exception stack trace to the console and then returns the thread to the thread pool.  
  
-   There is no such thing as an unhandled exception on a thread created with the <xref:System.Threading.Thread.Start%2A> method of the <xref:System.Threading.Thread> class. When code running on such a thread throws an exception that it does not handle, the runtime prints the exception stack trace to the console and then gracefully terminates the thread.  
  
-   There is no such thing as an unhandled exception on the finalizer thread. When a finalizer throws an exception that it does not handle, the runtime prints the exception stack trace to the console and then allows the finalizer thread to resume running finalizers.  
  
 The foreground or background status of a managed thread does not affect this behavior.  
  
 For unhandled exceptions on threads originating in unmanaged code, the difference is more subtle. The runtime JIT-attach dialog preempts the operating system dialog for managed exceptions or native exceptions on threads that have passed through native code. The process terminates in all cases.  
  
### Migrating Code  
 In general, the change will expose previously unrecognized programming problems so that they can be fixed. In some cases, however, programmers might have taken advantage of the runtime backstop, for example to terminate threads. Depending on the situation, they should consider one of the following migration strategies:  
  
-   Restructure the code so the thread exits gracefully when a signal is received.  
  
-   Use the <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> method to abort the thread.  
  
-   If a thread must be stopped so that process termination can proceed, make the thread a background thread so that it is automatically terminated on process exit.  
  
 In all cases, the strategy should follow the design guidelines for exceptions. See [Design Guidelines for Exceptions](../../../docs/standard/design-guidelines/exceptions.md).  
  
### Application Compatibility Flag  
 As a temporary compatibility measure, administrators can place a compatibility flag in the `<runtime>` section of the application configuration file. This causes the common language runtime to revert to the behavior of versions 1.0 and 1.1.  
  
```xml  
<legacyUnhandledExceptionPolicy enabled="1"/>  
```  
  
## Host Override  
 In the .NET Framework version 2.0, an unmanaged host can use the [ICLRPolicyManager](../../../docs/framework/unmanaged-api/hosting/iclrpolicymanager-interface.md) interface in the Hosting API to override the default unhandled exception policy of the common language runtime. The [ICLRPolicyManager::SetUnhandledExceptionPolicy](../../../docs/framework/unmanaged-api/hosting/iclrpolicymanager-setunhandledexceptionpolicy-method.md) function is used to set the policy for unhandled exceptions.  
  
## See Also  
 [Managed Threading Basics](../../../docs/standard/threading/managed-threading-basics.md)
