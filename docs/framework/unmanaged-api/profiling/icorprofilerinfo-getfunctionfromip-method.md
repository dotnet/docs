---
description: "Learn more about: ICorProfilerInfo::GetFunctionFromIP Method"
title: "ICorProfilerInfo::GetFunctionFromIP Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.GetFunctionFromIP"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetFunctionFromIP"
helpviewer_keywords: 
  - "GetFunctionFromIP method [.NET Framework profiling]"
  - "ICorProfilerInfo::GetFunctionFromIP method [.NET Framework profiling]"
ms.assetid: f069802a-198f-46dd-9f09-4f77adffc9ba
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::GetFunctionFromIP Method

Maps a managed code instruction pointer to a `FunctionID`.  
  
## Syntax  
  
```cpp  
HRESULT GetFunctionFromIP(  
    [in]  LPCBYTE    ip,  
    [out] FunctionID *pFunctionId);  
```  
  
## Parameters

`ip`
[in] The instruction pointer in managed code.

`pFunctionId`
[out] The returned function ID.

## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
