---
description: "Learn more about: CLR Hosting Interfaces"
title: "CLR Hosting Interfaces"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "interfaces [.NET Framework hosting], version 2.0"
  - "hosting interfaces [.NET Framework], version 2.0"
  - ".NET Framework 2.0, hosting interfaces"
ms.assetid: 703b8381-43db-4a4d-9faa-cca39302d922
---
# CLR Hosting Interfaces

This section describes the interfaces that unmanaged hosts can use to integrate the common language runtime (CLR) into their applications. The information pertains to the .NET Framework version 2.0 and later versions. These interfaces enable the host to control many more aspects of the runtime than was possible in versions 1.0 and 1.1, and provide much tighter integration between the CLR and the host's execution model.  
  
 In the .NET Framework version 1.0 and 1.1, the hosting model enabled an unmanaged host to load the CLR into a process, to configure certain settings, and to receive event notifications. However, in general, the host and the CLR ran independently in that process. In the .NET Framework version 2.0 and later versions, new layers of abstraction let the host provide many of the resources currently provided by the types in the Win32 assembly, and extend the set of capabilities that the host can configure.  
  
## In This Section  

 [IActionOnCLREvent Interface](iactiononclrevent-interface.md)  
 Provides a method that performs a callback for a registered event.  
  
 [IApartmentCallback Interface](iapartmentcallback-interface.md)  
 Provides methods for making callbacks within an apartment.  
  
 [IAppDomainBinding Interface](iappdomainbinding-interface.md)  
 Provides methods for setting run-time configuration.  
  
 [ICatalogServices Interface](icatalogservices-interface.md)  
 Provides methods for cataloging services. (This interface supports the .NET Framework infrastructure and is not intended to be used directly from your code.)  
  
 [ICLRAssemblyIdentityManager Interface](iclrassemblyidentitymanager-interface.md)  
 Provides methods that support communication between the host and the CLR about assemblies.  
  
 [ICLRAssemblyReferenceList Interface](iclrassemblyreferencelist-interface.md)  
 Manages a list of assemblies that are loaded by the CLR and not by the host.  
  
 [ICLRControl Interface](iclrcontrol-interface.md)  
 Provides methods for the host to gain access to, and configure various aspects of, the CLR.  
  
 [ICLRDebugManager Interface](iclrdebugmanager-interface.md)  
 Provides methods that enable a host to associate a set of tasks with an identifier and a friendly name.  
  
 [ICLRErrorReportingManager Interface](iclrerrorreportingmanager-interface.md)  
 Provides methods that enable the host to configure custom heap dumps for error reporting.  
  
 [ICLRGCManager Interface](iclrgcmanager-interface.md)  
 Provides methods that enable a host to interact with the CLR's garbage collection system.  
  
 [ICLRHostBindingPolicyManager Interface](iclrhostbindingpolicymanager-interface.md)  
 Provides methods for the host to evaluate and communicate changes in policy information for assemblies.  
  
 [ICLRHostProtectionManager Interface](iclrhostprotectionmanager-interface.md)  
 Enables the host to block specific managed classes, methods, properties, and fields from running in partially trusted code.  
  
 [ICLRIoCompletionManager Interface](iclriocompletionmanager-interface.md)  
 Implements a callback method that enables the host to notify the CLR of the status of specified I/O requests.  
  
 [ICLRMemoryNotificationCallback Interface](iclrmemorynotificationcallback-interface.md)  
 Enables the host to report memory pressure conditions using an approach similar to that of the Win32 `CreateMemoryResourceNotification` function.  
  
 [ICLROnEventManager Interface](iclroneventmanager-interface.md)  
 Provides methods that enable the host to register and unregister callbacks for CLR events.  
  
 [ICLRPolicyManager Interface](iclrpolicymanager-interface.md)  
 Provides methods that enable the host to specify policy actions to be taken in the event of failures and timeouts.  
  
 [ICLRProbingAssemblyEnum Interface](iclrprobingassemblyenum-interface.md)  
 Provides methods that enable the host to get the probing identities of an assembly by using the assembly's identity information that is internal to the CLR, without needing to create or understand that identity.  
  
 [ICLRReferenceAssemblyEnum Interface](iclrreferenceassemblyenum-interface.md)  
 Provides methods that enable the host to manipulate the set of assemblies referenced by a file or stream using assembly identity data that is internal to the CLR, without needing to create or understand those identities.  
  
 [ICLRRuntimeHost Interface](iclrruntimehost-interface.md)  
 Provides capabilities similar to [ICorRuntimeHost](icorruntimehost-interface.md), with an additional method to set the host control interface.  
  
 [ICLRSyncManager Interface](iclrsyncmanager-interface.md)  
 Provides methods for the host to get information about requested tasks and to detect deadlocks in its synchronization implementation.  
  
 [ICLRTask Interface](iclrtask-interface.md)  
 Provides methods that enable the host to make requests of the CLR, or to provide notification to the CLR about the associated task.  
  
 [ICLRTaskManager Interface](iclrtaskmanager-interface.md)  
 Provides methods that enable the host to request explicitly that the CLR create a new task, get the currently executing task, and set the geographic language and culture for the task.  
  
 [ICLRValidator Interface](iclrvalidator-interface.md)  
 Provides methods for validating portable executable (PE) images and reporting validation errors.  
  
 [ICorConfiguration Interface](icorconfiguration-interface.md)  
 Provides methods for configuring the CLR.  
  
 [ICorThreadpool Interface](icorthreadpool-interface.md)  
 Provides methods for accessing the thread pool.  
  
 [IDebuggerInfo Interface](idebuggerinfo-interface.md)  
 Provides methods for obtaining information about the state of the debugging services.  
  
 [IDebuggerThreadControl Interface](idebuggerthreadcontrol-interface.md)  
 Provides methods for notifying the host about the blocking and unblocking of threads by the debugging services.  
  
 [IGCHost Interface](igchost-interface.md)  
 Provides methods for obtaining information about the garbage collection system and for controlling some aspects of garbage collection.  
  
 [IGCHost2 Interface](igchost2-interface.md)  
 Provides the [SetGCStartupLimitsEx](igchost2-setgcstartuplimitsex-method.md) method that enables a host to set the size of the garbage collection segment and the maximum size of the garbage collection system's generation zero to values greater than `DWORD`.  
  
 [IGCHostControl Interface](igchostcontrol-interface.md)  
 Provides a method that enables the garbage collector to request the host to change the limits of virtual memory.  
  
 [IGCThreadControl Interface](igcthreadcontrol-interface.md)  
 Provides methods for participating in the scheduling of threads that would otherwise be blocked for garbage collection.  
  
 [IHostAssemblyManager Interface](ihostassemblymanager-interface.md)  
 Provides methods that enable a host to specify sets of assemblies that should be loaded by the CLR or by the host.  
  
 [IHostAssemblyStore Interface](ihostassemblystore-interface.md)  
 Provides methods that enable a host to load assemblies and modules independently of the CLR.  
  
 [IHostAutoEvent Interface](ihostautoevent-interface.md)  
 Provides a representation of an auto-reset event implemented by the host.  
  
 [IHostControl Interface](ihostcontrol-interface.md)  
 Provides methods for configuring the loading of assemblies, and for determining which hosting interfaces the host supports.  
  
 [IHostCrst Interface](ihostcrst-interface.md)  
 Serves as the host's representation of a critical section for threading.  
  
 [IHostGCManager Interface](ihostgcmanager-interface.md)  
 Provides methods that notify the host of events in the garbage collection mechanism implemented by the CLR.  
  
 [IHostIoCompletionManager Interface](ihostiocompletionmanager-interface.md)  
 Provides methods that enable the CLR to interact with I/O completion ports provided by the host.  
  
 [IHostMalloc Interface](ihostmalloc-interface.md)  
 Provides methods for the CLR to request fine-grained allocations from the heap through the host.  
  
 [IHostManualEvent Interface](ihostmanualevent-interface.md)  
 Provides the host's implementation of a representation of a manual reset event.  
  
 [IHostMemoryManager Interface](ihostmemorymanager-interface.md)  
 Provides methods for the CLR to make virtual memory requests through the host, instead of using the standard Win32 virtual memory functions.  
  
 [IHostPolicyManager Interface](ihostpolicymanager-interface.md)  
 Provides methods that notify the host of the actions the CLR performs in case of aborts, timeouts, or failures.  
  
 [IHostSecurityContext Interface](ihostsecuritycontext-interface.md)  
 Enables the CLR to maintain security context information implemented by the host.  
  
 [IHostSecurityManager Interface](ihostsecuritymanager-interface.md)  
 Provides methods that enable access to, and control over, the security context of the currently executing thread.  
  
 [IHostSemaphore Interface](ihostsemaphore-interface.md)  
 Provides a representation of a semaphore implemented by the host.  
  
 [IHostSyncManager Interface](ihostsyncmanager-interface.md)  
 Provides methods for the CLR to create synchronization primitives by calling the host, instead of using the Win32 synchronization functions.  
  
 [IHostTask Interface](ihosttask-interface.md)  
 Provides methods that enable the CLR to communicate with the host to manage tasks.  
  
 [IHostTaskManager Interface](ihosttaskmanager-interface.md)  
 Provides methods that enable the CLR to work with tasks through the host instead of using the standard operating system threading or fiber functions.  
  
 [IHostThreadPoolManager Interface](ihostthreadpoolmanager-interface.md)  
 Provides methods for the CLR to configure the thread pool and to queue work items to the thread pool.  
  
 [IManagedObject Interface](imanagedobject-interface.md)  
 Provides methods for controlling a managed object.  
  
 "IObjectHandle"  
 Provides a method for unwrapping marshal-by-value objects from indirection.  
  
 [ITypeName Interface](itypename-interface.md)  
 Provides methods for obtaining type name information. (This interface supports the .NET Framework infrastructure and is not intended to be used directly from your code.)  
  
 [ITypeNameBuilder Interface](itypenamebuilder-interface.md)  
 Provides methods for building a type name. (This interface supports the .NET Framework infrastructure and is not intended to be used directly from your code.)  
  
 [ITypeNameFactory Interface](itypenamefactory-interface.md)  
 Provides methods for deconstructing a type name. (This interface supports the .NET Framework infrastructure and is not intended to be used directly from your code.)  
  
 "IValidator"  
 Provides methods for validating portable executable (PE) images and reporting validation errors.  
  
## Related Sections  

 [Deprecated CLR Hosting Interfaces and Coclasses](deprecated-clr-hosting-interfaces-and-coclasses.md)  
 Contains topics that describe the hosting interfaces provided in the .NET Framework version 1.0 and 1.1.  
  
 [CLR Hosting Interfaces Added in the .NET Framework 4 and 4.5](clr-hosting-interfaces-added-in-the-net-framework-4-and-4-5.md)  
 Contains topics that describe the hosting interfaces provided in the .NET Framework 4.
