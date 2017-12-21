---
title: "ICLRRuntimeHost::ExecuteInDefaultAppDomain Method"
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
  - "ICLRRuntimeHost.ExecuteInDefaultAppDomain"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeHost::ExecuteInDefaultAppDomain"
helpviewer_keywords: 
  - "ICLRRuntimeHost::ExecuteInDefaultAppDomain method [.NET Framework hosting]"
  - "ExecuteInDefaultAppDomain method [.NET Framework hosting]"
ms.assetid: 30b5cf9a-a762-4bd4-be12-d6c1442b78b1
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRRuntimeHost::ExecuteInDefaultAppDomain Method
Calls the specified method of the specified type in the specified managed assembly.  
  
## Syntax  
  
```  
HRESULT ExecuteInDefaultAppDomain (  
    [in] LPCWSTR pwzAssemblyPath,  
    [in] LPCWSTR pwzTypeName,   
    [in] LPCWSTR pwzMethodName,  
    [in] LPCWSTR pwzArgument,  
    [out] DWORD *pReturnValue  
);  
```  
  
#### Parameters  
 `pwzAssemblyPath`  
 [in] The path to the <xref:System.Reflection.Assembly> that defines the <xref:System.Type> whose method is to be invoked.  
  
 `pwzTypeName`  
 [in] The name of the <xref:System.Type> that defines the method to invoke.  
  
 `pwzMethodName`  
 [in] The name of the method to invoke.  
  
 `pwzArgument`  
 [in] The string parameter to pass to the method.  
  
 `pReturnValue`  
 [out] The integer value returned by the invoked method.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`ExecuteInDefaultAppDomain` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. If a method returns E_FAIL, the CRL is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 The invoked method must have the following signature:  
  
```  
static int pwzMethodName (String pwzArgument)  
```  
  
 where `pwzMethodName` represents the name of the invoked method, and `pwzArgument` represents the string value passed as a parameter to that method. If the HRESULT value is set to S_OK, `pReturnValue` is set to the integer value returned by the invoked method. Otherwise, `pReturnValue` is not set.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRRuntimeHost Interface](../../../../docs/framework/unmanaged-api/hosting/iclrruntimehost-interface.md)
