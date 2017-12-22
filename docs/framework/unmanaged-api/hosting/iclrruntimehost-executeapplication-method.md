---
title: "ICLRRuntimeHost::ExecuteApplication Method"
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
  - "ICLRRuntimeHost.ExecuteApplication"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeHost::ExecuteApplication"
helpviewer_keywords: 
  - "ICLRRuntimeHost::ExecuteApplication method [.NET Framework hosting]"
  - "ExecuteApplication method [.NET Framework hosting]"
ms.assetid: 5f28cc4e-7176-4e00-aa1f-58ae6ee52fe4
topic_type: 
  - "apiref"
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRRuntimeHost::ExecuteApplication Method
Used in manifest-based ClickOnce deployment scenarios to specify the application to be activated in a new domain. For more information about these scenarios, see [ClickOnce Security and Deployment](/visualstudio/deployment/clickonce-security-and-deployment).  
  
## Syntax  
  
```  
HRESULT ExecuteApplication(  
    [in] LPCWSTR   pwzAppFullName,  
    [in] DWORD     dwManifestPaths,  
    [in] LPCWSTR   *ppwzManifestPaths,  
    [in] DWORD     dwActivationData,  
    [in] LPCWSTR   *ppwzActivationData,  
    [out] int      *pReturnValue  
);  
```  
  
#### Parameters  
 `pwzAppFullName`  
 [in] The full name of the application, as defined for <xref:System.ApplicationIdentity>.  
  
 `dwManifestPaths`  
 [in] The number of strings contained in the `ppwzManifestPaths` array.  
  
 `ppwzManifestPaths`  
 [in] Optional. A string array that contains manifest paths for the application.  
  
 `dwActivationData`  
 [in] The number of strings contained in the `ppwzActivationData` array.  
  
 `ppwzActivationData`  
 [in] Optional. A string array that contains the application's activation data, such as the query string portion of the URL for applications deployed over the Web.  
  
 `pReturnValue`  
 [out] The value returned from the entry point of the application.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`ExecuteApplication` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 `ExecuteApplication` is used to activate ClickOnce applications in a newly created application domain.  
  
 The `pReturnValue` output parameter is set to the value returned by the application. If you supply a value of null for `pReturnValue`, `ExecuteApplication` does not fail, but it does not return a value.  
  
> [!IMPORTANT]
>  Do not call the [Start Method](../../../../docs/framework/unmanaged-api/hosting/iclrruntimehost-start-method.md) method before calling the `ExecuteApplication` method to activate a manifest-based application. If the `Start` method is called first, the `ExecuteApplication` method call will fail.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 <xref:System.ActivationContext>  
 <xref:System.AppDomainManager>  
 <xref:System.ApplicationIdentity>  
 [ICLRRuntimeHost Interface](../../../../docs/framework/unmanaged-api/hosting/iclrruntimehost-interface.md)  
 [SetAppDomainManager Method](../../../../docs/framework/unmanaged-api/hosting/ihostcontrol-setappdomainmanager-method.md)  
 [Walkthrough: Downloading Assemblies on Demand with the ClickOnce Deployment API Using the Designer](/visualstudio/deployment/walkthrough-downloading-assemblies-on-demand-with-the-clickonce-deployment-api-using-the-designer)
