---
title: "ICLRAppDomainResourceMonitor::GetCurrentSurvived Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICLRAppDomainResourceMonitor.GetCurrentSurvived"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRAppDomainResourceMonitor::GetCurrentSurvived"
helpviewer_keywords: 
  - "ICLRAppDomainResourceMonitor::GetCurrentSurvived method [.NET Framework hosting]"
  - "GetCurrentSurvived method [.NET Framework hosting]"
ms.assetid: 392e9009-40ef-40e3-ad4d-7ce93a989e78
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRAppDomainResourceMonitor::GetCurrentSurvived Method
Gets the number of bytes that survived the last full, blocking garbage collection and that are referenced by the current application domain.  
  
## Syntax  
  
```  
HRESULT STDMETHODCALLTYPE GetCurrentSurvived(  
             [in]  DWORD dwAppDomainId,  
             [out] ULONGLONG *pAppDomainBytesSurvived,  
             [out] ULONGLONG *pTotalBytesSurvived);  
```  
  
#### Parameters  
 `dwAppDomainId`  
 [in] The ID of the requested application domain.  
  
 `pAppDomainBytesSurvived`  
 [out] A pointer to the number of bytes that survived after the last garbage collection that are held by this application domain. After a full collection, this number is accurate and complete. After an ephemeral collection, this number is potentially incomplete. This parameter can be `null`.  
  
 `pRuntimeBytesSurvived`  
 [out] A pointer to the total number of bytes that survived from the last garbage collection. After a full collection, this number represents the number of the bytes that are held in managed heaps. After an ephemeral collection, this number represents the number of bytes that are held live in ephemeral generations. This parameter can be `null`.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|COR_E_APPDOMAINUNLOADED|The application domain has been unloaded or does not exist.|  
  
## Remarks  
 Statistics are updated only after a full, blocking garbage collection; that is, a collection that includes all generations and that stops the application while collection occurs. For example, the <xref:System.GC.Collect?displayProperty=nameWithType> method overload performs a full, blocking collection. Concurrent garbage collection occurs in the background and does not block the application.  
  
 The `GetCurrentSurvived` method is the unmanaged equivalent of the managed <xref:System.AppDomain.MonitoringSurvivedMemorySize%2A?displayProperty=nameWithType> property.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICLRAppDomainResourceMonitor Interface](../../../../docs/framework/unmanaged-api/hosting/iclrappdomainresourcemonitor-interface.md)  
 [Application Domain Resource Monitoring](../../../../docs/standard/garbage-collection/app-domain-resource-monitoring.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)
