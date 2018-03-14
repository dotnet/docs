---
title: "IHostAssemblyStore::ProvideAssembly Method"
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
  - "IHostAssemblyStore.ProvideAssembly"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostAssemblyStore::ProvideAssembly"
helpviewer_keywords: 
  - "ProvideAssembly method [.NET Framework hosting]"
  - "IHostAssemblyStore::ProvideAssembly method [.NET Framework hosting]"
ms.assetid: 625c3dd5-a3f0-442c-adde-310dadbb5054
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostAssemblyStore::ProvideAssembly Method
Gets a reference to an assembly that is not referenced by the [ICLRAssemblyReferenceList](../../../../docs/framework/unmanaged-api/hosting/iclrassemblyreferencelist-interface.md) that is returned from [IHostAssemblyManager::GetNonHostStoreAssemblies](../../../../docs/framework/unmanaged-api/hosting/ihostassemblymanager-getnonhoststoreassemblies-method.md). The common language runtime (CLR) calls `ProvideAssembly` for each assembly that does not appear in the list.  
  
## Syntax  
  
```  
HRESULT ProvideAssembly (  
    [in]  AssemblyBindInfo *pBindInfo,  
    [out] UINT64           *pAssemblyId,  
    [out] UINT64           *pHostContext,  
    [out] IStream          **ppStmAssemblyImage,  
    [out] IStream          **ppStmPDB  
);  
```  
  
#### Parameters  
 `pBindInfo`  
 [in] A pointer to an [AssemblyBindInfo](../../../../docs/framework/unmanaged-api/hosting/assemblybindinfo-structure.md) instance that the host uses to determine certain bind characteristics, including the presence or absence of any versioning policy, and which assembly to bind to.  
  
 `pAssemblyId`  
 [out] A pointer to a unique identifier for the requested assembly for this `IStream`.  
  
 `pHostContext`  
 [out] A pointer to host-specific data that is used to determine the evidence of the requested assembly without the need of a platform invoke call. `pHostContext` corresponds to the <xref:System.Reflection.Assembly.HostContext%2A> property of the managed <xref:System.Reflection.Assembly> class.  
  
 `ppStmAssemblyImage`  
 [out] A pointer to the address of an `IStream` that contains the portable executable (PE) image to be loaded, or null if the assembly could not be found.  
  
 `ppStmPDB`  
 [out] A pointer to the address of an `IStream` that contains the program debug (PDB) information, or null if the .pdb file could not be found.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`ProvideAssembly` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|COR_E_FILENOTFOUND (0x80070002)|The requested assembly could not be located.|  
|E_NOT_SUFFICIENT_BUFFER|The buffer size specified by `pAssemblyId` is not large enough to hold the identifier that the host wants to return.|  
  
## Remarks  
 The identity value returned for `pAssemblyId` is specified by the host. Identifiers must be unique within the lifetime of a process. The CLR uses this value as a unique identifier for the stream. It checks each value against the values for `pAssemblyId` returned by other calls to `ProvideAssembly`. If the host returns the same `pAssemblyId` value for another `IStream`, the CLR checks whether the contents of that stream have already been mapped. If so, the runtime loads the existing copy of the image instead of mapping a new one.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRAssemblyReferenceList Interface](../../../../docs/framework/unmanaged-api/hosting/iclrassemblyreferencelist-interface.md)  
 [IHostAssemblyManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostassemblymanager-interface.md)  
 [IHostAssemblyStore Interface](../../../../docs/framework/unmanaged-api/hosting/ihostassemblystore-interface.md)
