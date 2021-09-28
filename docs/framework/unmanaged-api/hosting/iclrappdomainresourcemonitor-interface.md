---
description: "Learn more about: ICLRAppDomainResourceMonitor Interface"
title: "ICLRAppDomainResourceMonitor Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICLRAppDomainResourceMonitor"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRAppDomainResourceMonitor"
helpviewer_keywords: 
  - "ICLRAppDomainResourceMonitor interface [.NET Framework hosting]"
ms.assetid: 72fa83a1-8997-41d7-b355-ab177a24a303
topic_type: 
  - "apiref"
---
# ICLRAppDomainResourceMonitor Interface

Provides methods that inspect an application domain's memory and CPU usage.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetCurrentAllocated Method](iclrappdomainresourcemonitor-getcurrentallocated-method.md)|Gets the total size, in bytes, of all memory allocations that have been made by the application domain since it was created, without subtracting memory that has been garbage-collected.|  
|[GetCurrentSurvived Method](iclrappdomainresourcemonitor-getcurrentsurvived-method.md)|Gets the number of bytes that survived the last full, blocking garbage collection and that are referenced by the current application domain.|  
|[GetCurrentCpuTime Method](iclrappdomainresourcemonitor-getcurrentcputime-method.md)|Gets the total processor time that has been used by all threads while executing in the current application domain, since the application domain was created.|  
  
## Remarks  

 The `ICLRAppDomainResourceMonitor` interface provides functionality that is similar to the following managed properties:  
  
- <xref:System.AppDomain.MonitoringIsEnabled%2A?displayProperty=nameWithType>  
  
- <xref:System.AppDomain.MonitoringTotalProcessorTime%2A?displayProperty=nameWithType>  
  
- <xref:System.AppDomain.MonitoringTotalAllocatedMemorySize%2A?displayProperty=nameWithType>  
  
- <xref:System.AppDomain.MonitoringSurvivedProcessMemorySize%2A?displayProperty=nameWithType>  
  
- <xref:System.AppDomain.MonitoringSurvivedMemorySize%2A?displayProperty=nameWithType>  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [\<appDomainResourceMonitoring> Element](../../configure-apps/file-schema/runtime/appdomainresourcemonitoring-element.md)
- [Application Domain Resource Monitoring](../../../standard/garbage-collection/app-domain-resource-monitoring.md)
- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
