---
title: "Application Domain Resource Monitoring"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "monitoring managed memory use by application domain"
  - "application domains, memory use"
  - "memory use, monitoring"
  - "application domains, resource monitoring"
ms.assetid: 318bedf8-7f35-4f00-b34a-2b7b8e3fa315
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Application Domain Resource Monitoring
Application domain resource monitoring (ARM) enables hosts to monitor CPU and memory usage by application domain. This is useful for hosts such as ASP.NET that use many application domains in a long-running process. The host can unload the application domain of an application that is adversely affecting the performance of the entire process, but only if it can identify the problematic application. ARM provides information that can be used to assist in making such decisions.  
  
 For example, a hosting service might have many applications running on an ASP.NET server. If one application in the process begins consuming too much memory or too much processor time, the hosting service can use ARM to identify the application domain that is causing the problem.  
  
 ARM is sufficiently lightweight to use in live applications. You can access the information by using event tracing for Windows (ETW) or directly through managed or native APIs.  
  
## Enabling Resource Monitoring  
 ARM can be enabled in four ways: by supplying a configuration file when the common language runtime (CLR) is started, by using an unmanaged hosting API, by using managed code, or by listening to ARM ETW events.  
  
 As soon as ARM is enabled, it begins collecting data on all application domains in the process.If an application domain was created before ARM is enabled, cumulative data starts when ARM is enabled, not when the application domain was created.Once it is enabled, ARM cannot be disabled.  
  
-   You can enable ARM at CLR startup by adding the [\<appDomainResourceMonitoring>](../../../docs/framework/configure-apps/file-schema/runtime/appdomainresourcemonitoring-element.md) element to the configuration file, and setting the `enabled` attribute to `true`. A value of `false` (the default) means only that ARM is not enabled at startup; you can activate it later by using one of the other activation mechanisms.  
  
-   The host can enable ARM by requesting the [ICLRAppDomainResourceMonitor](../../../docs/framework/unmanaged-api/hosting/iclrappdomainresourcemonitor-interface.md) hosting interface. Once this interface is successfully obtained, ARM is enabled.  
  
-   Managed code can enable ARM by setting the static (`Shared` in Visual Basic) <xref:System.AppDomain.MonitoringIsEnabled%2A?displayProperty=nameWithType> property to `true`. As soon as the property is set, ARM is enabled.  
  
-   You can enable ARM after startup by listening to ETW events. ARM is enabled and begins raising events for all application domains when you enable the public provider `Microsoft-Windows-DotNETRuntime` by using the `AppDomainResourceManagementKeyword` keyword. To correlate data with application domains and threads, you must also enable the `Microsoft-Windows-DotNETRuntimeRundown` provider with the `ThreadingKeyword` keyword.  
  
## Using ARM  
 ARM provides the total processor time that is used by an application domain and three kinds of information about memory use.  
  
-   **Total processor time for an application domain, in seconds**: This is calculated by adding up the thread times reported by the operating system for all threads that spent time executing in the application domain during its lifetime. Blocked or sleeping threads do not use processor time. When a thread calls into native code, the time that the thread spends in native code is included in the count for the application domain where the call was made.  
  
    -   Managed API: <xref:System.AppDomain.MonitoringTotalProcessorTime%2A?displayProperty=nameWithType> property.  
  
    -   Hosting API: [ICLRAppDomainResourceMonitor::GetCurrentCpuTime](../../../docs/framework/unmanaged-api/hosting/iclrappdomainresourcemonitor-getcurrentcputime-method.md) method.  
  
    -   ETW events: `ThreadCreated`, `ThreadAppDomainEnter`, and `ThreadTerminated` events. For information about providers and keywords, see "AppDomain Resource Monitoring Events" in [CLR ETW Events](../../../docs/framework/performance/clr-etw-events.md).  
  
-   **Total managed allocations made by an application domain during its lifetime, in bytes**: Total allocations do not always reflect memory use by an application domain, because the allocated objects might be short-lived. However, if an application allocates and frees huge numbers of objects, the cost of the allocations could be significant.  
  
    -   Managed API: <xref:System.AppDomain.MonitoringTotalAllocatedMemorySize%2A?displayProperty=nameWithType> property.  
  
    -   Hosting API: [ICLRAppDomainResourceMonitor::GetCurrentAllocated](../../../docs/framework/unmanaged-api/hosting/iclrappdomainresourcemonitor-getcurrentallocated-method.md) method.  
  
    -   ETW events: `AppDomainMemAllocated` event, `Allocated` field.  
  
-   **Managed memory, in bytes, that is referenced by an application domain and that survived the most recent full, blocking collection**: This number is accurate only after a full, blocking collection. (This is in contrast to concurrent collections, which occur in the background and do not block the application.) For example, the <xref:System.GC.Collect?displayProperty=nameWithType> method overload causes a full, blocking collection.  
  
    -   Managed API: <xref:System.AppDomain.MonitoringSurvivedMemorySize%2A?displayProperty=nameWithType> property.  
  
    -   Hosting API: [ICLRAppDomainResourceMonitor::GetCurrentSurvived](../../../docs/framework/unmanaged-api/hosting/iclrappdomainresourcemonitor-getcurrentsurvived-method.md) method, `pAppDomainBytesSurvived` parameter.  
  
    -   ETW events: `AppDomainMemSurvived` event, `Survived` field.  
  
-   **Total managed memory, in bytes, that is referenced by the process and that survived the most recent full, blocking collection**: The survived memory for individual application domains can be compared to this number.  
  
    -   Managed API: <xref:System.AppDomain.MonitoringSurvivedProcessMemorySize%2A?displayProperty=nameWithType> property.  
  
    -   Hosting API: [ICLRAppDomainResourceMonitor::GetCurrentSurvived](../../../docs/framework/unmanaged-api/hosting/iclrappdomainresourcemonitor-getcurrentsurvived-method.md) method, `pTotalBytesSurvived` parameter.  
  
    -   ETW events: `AppDomainMemSurvived` event, `ProcessSurvived` field.  
  
### Determining When a Full, Blocking Collection Occurs  
 To determine when counts of survived memory are accurate, you need to know when a full, blocking collection has just occurred. The method for doing this depends on the API you use to examine ARM statistics.  
  
#### Managed API  
 If you use the properties of the <xref:System.AppDomain> class, you can use the <xref:System.GC.RegisterForFullGCNotification%2A?displayProperty=nameWithType> method to register for notification of full collections. The threshold you use is not important, because you are waiting for the completion of a collection rather than the approach of a collection. You can then call the <xref:System.GC.WaitForFullGCComplete%2A?displayProperty=nameWithType> method, which blocks until a full collection has completed. You can create a thread that calls the method in a loop and does any necessary analysis whenever the method returns.  
  
 Alternatively, you can call the <xref:System.GC.CollectionCount%2A?displayProperty=nameWithType> method periodically to see if the count of generation 2 collections has increased. Depending on the polling frequency, this technique might not provide as accurate an indication of the occurrence of a full collection.  
  
#### Hosting API  
 If you use the unmanaged hosting API, your host must pass the CLR an implementation of the [IHostGCManager](../../../docs/framework/unmanaged-api/hosting/ihostgcmanager-interface.md) interface. The CLR calls the [IHostGCManager::SuspensionEnding](../../../docs/framework/unmanaged-api/hosting/ihostgcmanager-suspensionending-method.md) method when it resumes execution of threads that have been suspended while a collection occurs. The CLR passes the generation of the completed collection as a parameter of the method, so the host can determine whether the collection was full or partial. Your implementation of the [IHostGCManager::SuspensionEnding](../../../docs/framework/unmanaged-api/hosting/ihostgcmanager-suspensionending-method.md) method can query for survived memory, to ensure that the counts are retrieved as soon as they are updated.  
  
## See Also  
 <xref:System.AppDomain.MonitoringIsEnabled%2A?displayProperty=nameWithType>  
 [ICLRAppDomainResourceMonitor Interface](../../../docs/framework/unmanaged-api/hosting/iclrappdomainresourcemonitor-interface.md)  
 [\<appDomainResourceMonitoring>](../../../docs/framework/configure-apps/file-schema/runtime/appdomainresourcemonitoring-element.md)  
 [CLR ETW Events](../../../docs/framework/performance/clr-etw-events.md)
