---
title: "ICorDebugILCode2::GetInstrumentedILMap Method"
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
api_name: 
  - "ICorDebugILCode2.GetInstrumentedILMap"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: 7a4e3085-8f95-40ef-a4be-7d6146f47ce2
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILCode2::GetInstrumentedILMap Method
[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Returns a map from profiler-instrumented intermediate language (IL) offsets to original method IL offsets for this instance.  
  
## Syntax  
  
```cpp
HRESULT GetInstrumentedILMap(  
   [in] ULONG32 cMap,  
   [out] ULONG32 *pcMap,  
   [out, size_is(cMap), length_is(*pcMap)] COR_IL_MAP map[]  
);  
```  
  
#### Parameters  
 cMap  
 [in] The storage capacity of the `map` array. See the Remarks section for more information.  
  
 pcMap  
 [out] The number of COR_IL_MAP values written to the map array.  
  
 map  
 [out] An array of COR_IL_MAP values that provide information on mappings from profiler-instrumented IL to the IL of the original method.  
  
## Remarks  
 If the profiler sets the mapping by calling the [ICorProfilerInfo::SetILInstrumentedCodeMap](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-setilinstrumentedcodemap-method.md) method, the debugger can call this method to retrieve the mapping and to use the mapping internally when calculating IL offsets for stack traces and variable lifetimes.  
  
 If `cMap` is 0 and `pcMap` is non-**null**, `pcMap` is set to the number of available COR_IL_MAP values. If `cMap` is non-zero, it represents the storage capacity of the `map` array. When the method returns, `map` contains a maximum of `cMap` items, and `pcMap` is set to the number of COR_IL_MAP values actually written to the `map` array.  
  
 If the IL hasn't been instrumented or the mapping wasn't provided by a profiler, this method returns `S_OK` and sets `pcMap` to 0.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo::SetILInstrumentedCodeMap](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-setilinstrumentedcodemap-method.md)  
 [ICorDebugILCode2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugilcode2-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
