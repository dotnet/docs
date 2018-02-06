---
title: "ICorProfilerInfo::GetILToNativeMapping Method"
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
  - "ICorProfilerInfo.GetILToNativeMapping"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetILToNativeMapping"
helpviewer_keywords: 
  - "GetILToNativeMapping method, ICorProfilerInfo interface [.NET Framework profiling]"
  - "ICorProfilerInfo::GetILToNativeMapping method [.NET Framework profiling]"
ms.assetid: 6a5431ef-22fb-4e53-bac5-703986297eb1
topic_type: 
  - "apiref"
caps.latest.revision: 20
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo::GetILToNativeMapping Method
Gets a map from Microsoft intermediate language (MSIL) offsets to native offsets for the code contained in the specified function.  
  
## Syntax  
  
```  
HRESULT GetILToNativeMapping(  
    [in] FunctionID functionId,  
    [in] ULONG32 cMap,  
    [out] ULONG32 *pcMap,  
    [out, size_is(cMap), length_is(*pcMap)]  
        COR_DEBUG_IL_TO_NATIVE_MAP map[]);  
```  
  
#### Parameters  
 `functionId`  
 [in] The ID of the function that contains the code.  
  
 `cMap`  
 [in] The maximum size of the `map` array.  
  
 `pcMap`  
 [out] The total number of available COR_DEBUG_IL_TO_NATIVE_MAP structures.  
  
 `map`  
 [out] An array of `COR_DEBUG_IL_TO_NATIVE_MAP` structures, each of which specifies the offsets. After the `GetILToNativeMapping` method returns, `map` will contain some or all of the `COR_DEBUG_IL_TO_NATIVE_MAP` structures.  
  
## Remarks  
 The `GetILToNativeMapping` method returns an array of `COR_DEBUG_IL_TO_NATIVE_MAP` structures. To convey that certain ranges of native instructions correspond to special regions of code (for example, the prolog), an entry in the array can have its `ilOffset` field set to a value of the [CorDebugIlToNativeMappingTypes](../../../../docs/framework/unmanaged-api/debugging/cordebugiltonativemappingtypes-enumeration.md) enumeration.  
  
 After `GetILToNativeMapping` returns, you must verify that the `map` buffer was large enough to contain all the `COR_DEBUG_IL_TO_NATIVE_MAP` structures. To do this, compare the value of `cMap` with the value of the `pcMap` parameter. If the `pcMap` value, when it is multiplied by the size of a `COR_DEBUG_IL_TO_NATIVE_MAP` structure, is larger than `cMap`, allocate a larger `map` buffer, update `cMap` with the new, larger size, and call `GetILToNativeMapping` again.  
  
 Alternatively, you can first call `GetILToNativeMapping` with a zero-length `map` buffer to obtain the correct buffer size. You can then set the buffer size to the value returned in `pcMap` and call `GetILToNativeMapping` again.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)  
 [GetILToNativeMapping2 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo4-getiltonativemapping2-method.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [Profiling](../../../../docs/framework/unmanaged-api/profiling/index.md)
