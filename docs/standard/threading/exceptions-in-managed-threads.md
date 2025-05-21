---
title: "Exceptions in Managed Threads"
description: See how unhandled exceptions are handled in .NET. Most unhandled thread exceptions proceed naturally and lead to application termination.
ms.date: 05/26/2022
helpviewer_keywords: 
  - "unhandled exceptions,in managed threads"
  - "threading [.NET],unhandled exceptions"
  - "threading [.NET],exceptions in managed threads"
  - "managed threading"
ms.assetid: 11294769-2e89-43cb-890e-ad4ad79cfbee
ms.topic: article
---
# Exceptions in managed threads

The common language runtime allows most unhandled exceptions in threads to proceed naturally. In most cases, this means that the unhandled exception causes the application to terminate. However, the common language runtime provides a backstop for certain unhandled exceptions that are used for controlling program flow:  
  
- A <xref:System.Threading.ThreadAbortException> is thrown in a thread because <xref:System.Threading.Thread.Abort%2A> was called. This only applies to .NET Framework apps.
  
- An <xref:System.AppDomainUnloadedException> is thrown in a thread because the application domain in which the thread is executing is being unloaded.  
  
- The common language runtime or a host process terminates the thread by throwing an internal exception.  
  
If any of these exceptions are unhandled in threads created by the common language runtime, the exception terminates the thread, but the common language runtime does not allow the exception to proceed further.  
  
If these exceptions are unhandled in the main thread, or in threads that entered the runtime from unmanaged code, they proceed normally, resulting in termination of the application.  
  
> [!NOTE]
> It's possible for the runtime to throw an unhandled exception before any managed code has had a chance to install an exception handler. Even though managed code had no chance to handle such an exception, the exception is allowed to proceed naturally.  
  
## Expose threading problems during development  

 When threads are allowed to fail silently, without terminating the application, serious programming problems can go undetected. This is a particular problem for services and other applications that run for extended periods. As threads fail, program state gradually becomes corrupted. Application performance may degrade, or the application might become unresponsive.  
  
 Allowing unhandled exceptions in threads to proceed naturally, until the operating system terminates the program, exposes such problems during development and testing. Error reports on program terminations support debugging.
  
## Host override

An unmanaged host can use the [ICLRPolicyManager](../../framework/unmanaged-api/hosting/iclrpolicymanager-interface.md) interface in the Hosting API to override the default unhandled exception policy of the common language runtime. The [ICLRPolicyManager::SetUnhandledExceptionPolicy](../../framework/unmanaged-api/hosting/iclrpolicymanager-setunhandledexceptionpolicy-method.md) function is used to set the policy for unhandled exceptions.  
  
## See also

- [Managed Threading Basics](managed-threading-basics.md)
