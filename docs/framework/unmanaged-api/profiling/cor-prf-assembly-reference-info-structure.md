---
title: "COR_PRF_ASSEMBLY_REFERENCE_INFO Structure"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
dev_langs: 
  - "cpp"
ms.assetid: c8c1d916-8d1a-4f82-8128-9fd3732383fc
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_PRF_ASSEMBLY_REFERENCE_INFO Structure
[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Provides the common language runtime with information about an assembly reference that it should consider when performing an assembly reference closure walk.  
  
## Syntax  
  
```cpp  
typedef struct _COR_PRF_ASSEMBLY_REFERENCE_INFO {  
    void* pbPublicKeyOrToken;  
    ULONG cbPublicKeyOrToken;  
    LPCWSTR szName;  
    ASSEMBLYMETADATA* pMetaData;  
    void* pbHashValue;  
    ULONG cbHashValue;  
    DWORD dwAssemblyRefFlags;  
} COR_PRF_EX_CLAUSE_INFO;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`pbPublicKeyOrToken`|A pointer to the public key or token of the assembly.|  
|`cbPublicKeyOrToken`|The number of bytes in the public key or token.|  
|`szName`|The name of the assembly that is referenced.|  
|`pMetaData`|A pointer to the assembly's metadata.|  
|`pbHashValue`|A pointer to a hash binary large object (BLOB).|  
|`cbHashValue`|The number of bytes in the hash BLOB.|  
|`dwAssemblyRefFlags`|The assembly's flags.|  
  
## Remarks  
 The `COR_PRF_EX_CLAUSE_INFO` structure is populated by the profiler when it declares additional assembly references that the common language runtime should consider when performing an assembly reference closure walk.  
  
 If the profiler registers for the [ICorProfilerCallback6::GetAssemblyReferences](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback6-getassemblyreferences-method.md) callback method, the runtime passes the path and name of the assembly to be loaded, along with a pointer to an [ICorProfilerAssemblyReferenceProvider](../../../../docs/framework/unmanaged-api/profiling/icorprofilerassemblyreferenceprovider-interface.md) interface object to that method. The profiler can then call the [ICorProfilerAssemblyReferenceProvider::AddAssemblyReference](../../../../docs/framework/unmanaged-api/profiling/icorprofilerassemblyreferenceprovider-addassemblyreference-method.md) method with a `COR_PRF_ASSEMBLY_REFERENCE_INFO` object for each target assembly it plans to reference from the assembly specified in the [ICorProfilerCallback6::GetAssemblyReferences](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback6-getassemblyreferences-method.md) callback.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See Also  
 [Profiling Structures](../../../../docs/framework/unmanaged-api/profiling/profiling-structures.md)  
 [GetAssemblyReferences Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback6-getassemblyreferences-method.md)  
 [AddAssemblyReference Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerassemblyreferenceprovider-addassemblyreference-method.md)
