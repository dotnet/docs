---
title: "ICorProfilerInfo7::GetInMemorySymbolsLength Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
api_name: 
  - "ICorProfilerInfo7.GetInMemorySymbolsLength"
api_location: 
  - "mscorwks.dll"
  - "icorprof.idl"
api_type: 
  - "COM"
ms.assetid: d62c4a4c-8a62-45aa-8f01-a8387cf36159
caps.latest.revision: 3
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo7::GetInMemorySymbolsLength Method
[Supported in the .NET Framework 4.6.1 and later versions]  
  
 Returns the length of an in-memory symbol stream.  
  
## Syntax  
  
```  
HRESULT GetInMemorySymbolsLength(  
        [in] ModuleID moduleId,  
        [out] DWORD* pCountSymbolBytes  
);  
```  
  
#### Parameters  
 `moduleId`  
 [in] The identifier of the module containing the in-memory stream.  
  
 pCountSymbolBytes  
 [out] A pointer to a `DWORD` value that, when the method returns, contains the length of the stream in bytes.  
  
## Return Value  
 The method returns `S_OK` if the length of the memory stream can be determined, even if it is zero (0).  
  
 The method returns `CORPROF_E_MODULE_IS_DYNAMIC` if the method was created using <xref:System.Reflection.Emit?displayProperty=nameWithType>.  
  
## Remarks  
 If the module has in-memory symbols, the length of the stream is placed in `pCountSymbolBytes`. If the module doesn't have in-memory     symbols, `*pCountSymbolBytes = 0`.  
  
> [!NOTE]
>  The current implementation does not support Reflection.Emit. If the module was created by using Reflection.Emit, the method returns `CORPROF_E_MODULE_IS_DYNAMIC`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v461plus](../../../../includes/net-current-v461plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo7 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo7-interface.md)
