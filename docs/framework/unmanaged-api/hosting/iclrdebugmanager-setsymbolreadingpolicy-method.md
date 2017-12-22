---
title: "ICLRDebugManager::SetSymbolReadingPolicy Method"
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
  - "ICLRDebugManager.SetSymbolReadingPolicy"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDebugManager::SetSymbolReadingPolicy"
helpviewer_keywords: 
  - "ICLRDebugManager, SetSymbolREadingPolicy method"
  - "SetSymbolReadingPolicy method [.NET Framework hosting]"
  - "ICLRDebugManager::SetSymbolReadingPolicy method [.NET Framework hosting]"
ms.assetid: bd921fa2-d377-4d79-acfc-64c38d4dcae9
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDebugManager::SetSymbolReadingPolicy Method
Sets the policy for reading program database (PDB) files. The policy determines whether information about line numbers and files is included in call stacks.  
  
## Syntax  
  
```  
HRESULT SetSymbolReadingPolicy (  
    [in] ESymbolReadingPolicy policy  
);  
```  
  
#### Parameters  
 `policy`  
 [in] A member of the [ESymbolReadingPolicy](../../../../docs/framework/unmanaged-api/hosting/esymbolreadingpolicy-enumeration.md) enumeration.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetSymbolReadingPolicy` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRDebugManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrdebugmanager-interface.md)
