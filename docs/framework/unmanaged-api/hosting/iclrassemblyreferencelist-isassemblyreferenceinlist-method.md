---
title: "ICLRAssemblyReferenceList::IsAssemblyReferenceInList Method"
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
  - "ICLRAssemblyReferenceList.IsAssemblyReferenceInList"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRAssemblyReferenceList::IsAssemblyReferenceInList"
helpviewer_keywords: 
  - "ICLRAssemblyReferenceList::IsAssemblyReferenceInList method [.NET Framework hosting]"
  - "IsAssemblyReferenceInList method [.NET Framework hosting]"
ms.assetid: 8a570813-21be-407e-92a6-7ae8de3bc728
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRAssemblyReferenceList::IsAssemblyReferenceInList Method
Gets a value that indicates whether the supplied pointer refers to an assembly in the list.  
  
## Syntax  
  
```  
HRESULT IsAssemblyReferenceInList (  
    [in] IUnknown *pName  
);  
```  
  
#### Parameters  
 `pName`  
 [in] An interface pointer to the assembly for which to search. Valid values are of type `IAssemblyName` or `IReferenceIdentity`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The string appears in the list.|  
|S_FALSE|The string does not appear in the list.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the common language runtime is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRAssemblyIdentityManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrassemblyidentitymanager-interface.md)  
 [ICLRAssemblyReferenceList Interface](../../../../docs/framework/unmanaged-api/hosting/iclrassemblyreferencelist-interface.md)  
 [IHostAssemblyManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostassemblymanager-interface.md)  
 [IHostAssemblyStore Interface](../../../../docs/framework/unmanaged-api/hosting/ihostassemblystore-interface.md)
