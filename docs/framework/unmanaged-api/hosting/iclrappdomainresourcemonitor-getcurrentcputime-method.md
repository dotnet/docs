---
title: "ICLRAppDomainResourceMonitor::GetCurrentCpuTime Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRAppDomainResourceMonitor.GetCurrentCpuTime"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRAppDomainResourceMonitor::GetCurrentCpuTime"
helpviewer_keywords: 
  - "ICLRAppDomainResourceMonitor::GetCurrentCpuTime method [.NET Framework hosting]"
  - "GetCurrentCpuTime method [.NET Framework hosting]"
ms.assetid: ebc9cc33-fcd6-4cae-9ecb-ea21c51874e6
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICLRAppDomainResourceMonitor::GetCurrentCpuTime Method
Gets the total processor time that has been used by all threads while executing in the current application domain, since the application domain was created.  
  
## Syntax  
  
```  
HRESULT GetCurrentCpuTime([in]  DWORD dwAppDomainId,  
                          [out] ULONGLONG* pMilliseconds);  
```  
  
## Parameters  
 `dwAppDomainId`  
 [in] The ID of the requested application domain.  
  
 `pMilliseconds`  
 [out] A pointer to the total processor time that has been used by all threads while executing in the current application domain since the application domain was created. This parameter can be `null`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|COR_E_APPDOMAINUNLOADED|The application domain has been unloaded or does not exist.|  
|E_FAIL|Application domain resource monitoring is not enabled.<br /><br /> -or-<br /><br /> All other failures.|  
  
## Remarks  
 This method is the unmanaged equivalent of the managed <xref:System.AppDomain.MonitoringTotalProcessorTime%2A?displayProperty=nameWithType> property.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRAppDomainResourceMonitor Interface](../../../../docs/framework/unmanaged-api/hosting/iclrappdomainresourcemonitor-interface.md)
- [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
- [Application Domain Resource Monitoring](../../../../docs/standard/garbage-collection/app-domain-resource-monitoring.md)
- [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)
