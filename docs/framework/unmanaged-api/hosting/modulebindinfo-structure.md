---
title: "ModuleBindInfo Structure"
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
  - "ModuleBindInfo"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ModuleBindInfo"
helpviewer_keywords: 
  - "ModuleBindInfo structure [.NET Framework hosting]"
ms.assetid: 632d4adc-dbc9-4ce8-9397-abc3285c1c69
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ModuleBindInfo Structure
Provides detailed information about the referenced module and the assembly that contains it.  
  
## Syntax  
  
```  
typedef struct _ModuleBindInfo {  
    DWORD    dwAppDomainId;  
    LPCWSTR  lpAssemblyIdentity;  
    LPCWSTR  lpModuleName  
} ModuleBindInfo;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`dwAppDomainId`|A unique identifier for the `IStream` that is returned by a call to the [IHostAssemblyStore::ProvideModule](../../../../docs/framework/unmanaged-api/hosting/ihostassemblystore-providemodule-method.md) method from which the referenced module is to be loaded.|  
|`lpAssemblyIdentity`|A unique identifier for the assembly that contains the referenced module.|  
|`lpModuleName`|The name of the referenced module.|  
  
## Remarks  
 `ModuleBindInfo` is passed as a parameter to `IHostAssemblyStore::ProvideModule`. The host supplies the unique identifier `dwAppDomainId` to the common language runtime (CLR). After a call to the [IHostAssemblyStore::ProvideAssembly](../../../../docs/framework/unmanaged-api/hosting/ihostassemblystore-provideassembly-method.md) method returns, the runtime uses the identifier to determine whether the contents of the `IStream` have been mapped. If so, the runtime loads the existing copy rather than remapping the stream. The runtime also uses this identifier as a lookup key for streams that are returned from calls to the `IHostAssemblyStore::ProvideAssembly` method. Therefore, the identifier must be unique for module requests as well as for assembly requests.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.idl  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Hosting Structures](../../../../docs/framework/unmanaged-api/hosting/hosting-structures.md)  
 [AssemblyBindInfo Structure](../../../../docs/framework/unmanaged-api/hosting/assemblybindinfo-structure.md)  
 [ICLRAssemblyIdentityManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrassemblyidentitymanager-interface.md)  
 [ICLRAssemblyReferenceList Interface](../../../../docs/framework/unmanaged-api/hosting/iclrassemblyreferencelist-interface.md)  
 [IHostAssemblyManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostassemblymanager-interface.md)
