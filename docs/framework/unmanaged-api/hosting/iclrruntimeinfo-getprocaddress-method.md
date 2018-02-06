---
title: "ICLRRuntimeInfo::GetProcAddress Method"
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
  - "ICLRRuntimeInfo.GetProcAddress"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeInfo::GetProcAddress"
helpviewer_keywords: 
  - "GetProcAddress method [.NET Framework hosting]"
  - "ICLRRuntimeInfo::GetProcAddress method [.NET Framework hosting]"
ms.assetid: a7732bfc-689a-4926-88fd-4f81e6f9ed78
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRRuntimeInfo::GetProcAddress Method
Gets the address of a specified function that was exported from the common language runtime (CLR) associated with this interface.  
  
 This method supersedes the [GetRealProcAddress](../../../../docs/framework/unmanaged-api/hosting/getrealprocaddress-function.md) function.  
  
## Syntax  
  
```  
HRESULT GetProcAddress(  
     [in]  LPCSTR pszProcName,  
     [out, retval] LPVOID *ppProc);  
```  
  
#### Parameters  
 `pszProcName`  
 [in] The name of the exported function.  
  
 `ppProc`  
 [out] The address of the exported function.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_POINTER|`pszProcName` or `ppProc` is null.|  
|CLR_E_SHIM_RUNTIMEEXPORT|The specified function is not an exported function.|  
  
## Remarks  
 This method causes the CLR to be loaded but not initialized.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICLRRuntimeInfo Interface](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)
