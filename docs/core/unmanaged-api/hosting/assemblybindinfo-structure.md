---
description: "Learn more about: AssemblyBindInfo Structure"
title: "AssemblyBindInfo Structure"
ms.date: "03/30/2017"
api_name: 
  - "AssemblyBindInfo"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "AssemblyBindInfo"
helpviewer_keywords: 
  - "AssemblyBindInfo structure [.NET Framework hosting]"
ms.assetid: 6fc01e98-c2e7-49de-ab9f-95937cc89017
topic_type: 
  - "apiref"
---
# AssemblyBindInfo Structure

Provides detailed information about the referenced assembly.  
  
## Syntax  
  
```cpp  
typedef struct _AssemblyBindInfo {  
    DWORD       dwAppDomainId;  
    LPCWSTR     lpReferencedIdentity;  
    LPCWSTR     lpPostPolicyIdentity;  
    DWORD       ePolicyLevel;  
} AssemblyBindInfo;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`dwAppDomainId`|A unique identifier for the `IStream` returned by a call to [IHostAssemblyStore::ProvideAssembly](ihostassemblystore-provideassembly-method.md), from which the referenced assembly is to be loaded.|  
|`lpReferencedIdentity`|A unique identifier for the referenced assembly.|  
|`lpPostPolicyIdentity`|The identifier for the referenced assembly after the application of any binding policy values.|  
|`ePolicyLevel`|One of the [EPolicyAction](epolicyaction-enumeration.md) values that indicate which versioning policies, if any, should be applied to the referenced assembly.|  
  
## Remarks  

 The host supplies the unique identifier `dwAppDomainId` to the common language runtime (CLR). After a call to `IHostAssemblyStore::ProvideAssembly` returns, the runtime uses the identifier to determine whether the contents of the `IStream` have been mapped. If so, the runtime loads the existing copy rather than remapping the stream. The runtime also uses this identifier as a lookup key for streams returned from calls to [IHostAssemblyStore::ProvideModule](ihostassemblystore-providemodule-method.md). Therefore, the identifier must be unique for module requests and for assembly requests.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.idl  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Hosting Structures](hosting-structures.md)
- [ICLRAssemblyIdentityManager Interface](iclrassemblyidentitymanager-interface.md)
- [ICLRAssemblyReferenceList Interface](iclrassemblyreferencelist-interface.md)
- [IHostAssemblyManager Interface](ihostassemblymanager-interface.md)
- [IHostAssemblyStore Interface](ihostassemblystore-interface.md)
- [ModuleBindInfo Structure](modulebindinfo-structure.md)
