---
description: "Learn more about: ICLRAppDomainResourceMonitor::GetCurrentAllocated Method"
title: "ICLRAppDomainResourceMonitor::GetCurrentAllocated Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRAppDomainResourceMonitor.GetCurrentAllocated"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRAppDomainResourceMonitor::GetCurrentAllocated"
helpviewer_keywords: 
  - "GetCurrentAllocated method [.NET Framework hosting]"
  - "ICLRAppDomainResourceMonitor::GetCurrentAllocated method [.NET Framework hosting]"
ms.assetid: 7bab209c-efd4-44c2-af30-61abab0ae2fc
topic_type: 
  - "apiref"
---
# ICLRAppDomainResourceMonitor::GetCurrentAllocated Method

Gets the total size, in bytes, of all memory allocations that have been made by the application domain since it was created, without subtracting memory that has been garbage-collected.  
  
## Syntax  
  
```cpp  
HRESULT GetCurrentAllocated([in]  DWORD dwAppDomainId,  
                            [out] ULONGLONG* pBytesAllocated);  
```  
  
## Parameters  

 `dwAppDomainId`  
 [in] The ID of the requested application domain.  
  
 `pBytesAllocated`  
 [out] A pointer to the total size of all memory allocations.  
  
## Return Value  

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|COR_E_APPDOMAINUNLOADED|The application domain has been unloaded or does not exist.|  
  
## Remarks  

 This method is the unmanaged equivalent of the managed <xref:System.AppDomain.MonitoringTotalAllocatedMemorySize%2A?displayProperty=nameWithType> property.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRAppDomainResourceMonitor Interface](iclrappdomainresourcemonitor-interface.md)
- [Application Domain Resource Monitoring](../../../standard/garbage-collection/app-domain-resource-monitoring.md)
- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
