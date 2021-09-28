---
description: "Learn more about: ICorProfilerInfo4::GetFunctionFromIP2 Method"
title: "ICorProfilerInfo4::GetFunctionFromIP2 Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo4.GetFunctionFromIP2"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo4::GetFunctionFromIP2"
helpviewer_keywords: 
  - "ICorProfilerInfo4::GetFunctionFromIP2 method [.NET Framework profiling]"
  - "GetFunctionFromIP2 method, ICorProfilerInfo4 interface [.NET Framework profiling]"
ms.assetid: 46ff70f4-13e9-40a0-802a-0a40abcfc6a0
topic_type: 
  - "apiref"
---
# ICorProfilerInfo4::GetFunctionFromIP2 Method

Maps a managed code instruction pointer to the JIT-recompiled version of a function.  
  
## Syntax  
  
```cpp  
HRESULT GetFunctionFromIP2(  
    [in]  LPCBYTE    ip,  
    [out] FunctionID *pFunctionId,  
    [out] ReJITID *pReJitId);  
```  
  
## Parameters  

 `ip`  
 [in] The instruction pointer in managed code.  
  
 `pFunctionId`  
 [out] The function ID.  
  
 `pReJitId`  
 [out] The identity of the JIT-recompiled version of the function.  
  
## Remarks  

 `GetFunctionFromIP2` is similar to `GetFunctionFromIP`, except that it gets the JIT-recompiled ID instead of the function ID of the function that contains the specified IP address.  
  
> [!NOTE]
> `GetFunctionFromIP2` can trigger a garbage collection, whereas `GetFunctionFromIP` will not.  For more information, see [CORPROF_E_UNSUPPORTED_CALL_SEQUENCE HRESULT](corprof-e-unsupported-call-sequence-hresult.md).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
