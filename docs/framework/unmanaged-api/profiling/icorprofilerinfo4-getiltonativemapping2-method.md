---
description: "Learn more about: ICorProfilerInfo4::GetILToNativeMapping2 Method"
title: "ICorProfilerInfo4::GetILToNativeMapping2 Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo4.GetILToNativeMapping2"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo4::GetILToNativeMapping2"
helpviewer_keywords: 
  - "ICorProfilerInfo4::GetILToNativeMapping2 method [.NET Framework profiling]"
  - "GetILToNativeMapping2 method, ICorProfilerInfo4 interface [.NET Framework profiling]"
ms.assetid: 756c1c25-08a7-4060-9798-dbeaa2f3bee5
topic_type: 
  - "apiref"
---
# ICorProfilerInfo4::GetILToNativeMapping2 Method

Gets a map from Microsoft intermediate language (MSIL) offsets to native offsets for the code contained in the JIT-recompiled version of the specified function.  
  
## Syntax  
  
```cpp  
HRESULT GetILToNativeMapping(  
    [in] FunctionID functionId,  
    [in] ReJITID reJitId,  
    [in] ULONG32 cMap,  
    [out] ULONG32 *pcMap,  
    [out, size_is(cMap), length_is(*pcMap)]  
        COR_DEBUG_IL_TO_NATIVE_MAP map[]);  
```  
  
## Parameters  

 `functionId`  
 [in] The ID of the function that contains the code.  
  
 `pReJitId`  
 [in] The identity of the JIT-recompiled function. The identity must be zero in the .NET Framework 4.5.  
  
 `cMap`  
 [in] The maximum size of the `map` array.  
  
 `pcMap`  
 [out] The total number of available COR_DEBUG_IL_TO_NATIVE_MAP structures.  
  
 `map`  
 [out] An array of `COR_DEBUG_IL_TO_NATIVE_MAP` structures, each of which specifies the offsets. After the `GetILToNativeMapping2` method returns, `map` will contain some or all of the `COR_DEBUG_IL_TO_NATIVE_MAP` structures.  
  
## Remarks  

 `GetILToNativeMapping2` is similar to the [ICorProfilerInfo::GetILToNativeMapping](icorprofilerinfo-getiltonativemapping-method.md) method, except that it will allow the profiler to specify the ID of the recompiled function in future releases.  
  
> [!NOTE]
> The [ICorProfilerFunctionControl::SetILInstrumentedCodeMap](icorprofilerfunctioncontrol-setilinstrumentedcodemap-method.md) method is not implemented in the .NET Framework 4.5, so functions that have been JIT-recompiled cannot have an IL-to-native mapping that differs from the originally compiled function. As such, `GetILToNativeMapping2` cannot be called with a nonzero JIT-recompiled ID in the .NET Framework 4.5.  
  
 The `GetILToNativeMapping2` method returns an array of `COR_DEBUG_IL_TO_NATIVE_MAP` structures. To convey that certain ranges of native instructions correspond to special regions of code (for example, the prolog), an entry in the array can have its `ilOffset` field set to a value of the [CorDebugIlToNativeMappingTypes](../debugging/cordebugiltonativemappingtypes-enumeration.md) enumeration.  
  
 After `GetILToNativeMapping2` returns, you must verify that the `map` buffer was large enough to contain all the `COR_DEBUG_IL_TO_NATIVE_MAP` structures. To do this, compare the value of `cMap` with the value of the `pcMap` parameter. If the `pcMap` value, when it is multiplied by the size of a `COR_DEBUG_IL_TO_NATIVE_MAP` structure, is larger than `cMap`, allocate a larger `map` buffer, update `cMap` with the new, larger size, and call `GetILToNativeMapping2` again.  
  
 Alternatively, you can first call `GetILToNativeMapping2` with a zero-length `map` buffer to obtain the correct buffer size. You can then set the buffer size to the value returned in `pcMap` and call `GetILToNativeMapping2` again.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [GetILToNativeMapping Method](icorprofilerinfo-getiltonativemapping-method.md)
- [ICorProfilerInfo4 Interface](icorprofilerinfo4-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [Profiling](index.md)
