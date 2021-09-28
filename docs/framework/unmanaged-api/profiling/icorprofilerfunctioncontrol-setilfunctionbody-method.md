---
description: "Learn more about: ICorProfilerFunctionControl::SetILFunctionBody Method"
title: "ICorProfilerFunctionControl::SetILFunctionBody Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerFunctionControl.SetILFunctionBody"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerFunctionControl::SetILFunctionBody"
helpviewer_keywords: 
  - "ICorProfilerFunctionControl::SetILFunctionBody method [.NET Framework profiling]"
  - "SetILFunctionBody method, ICorProfilerFunctionControl interface [.NET Framework profiling]"
ms.assetid: 2c33f0f7-75b2-4c19-b2c7-c94b54997576
topic_type: 
  - "apiref"
---
# ICorProfilerFunctionControl::SetILFunctionBody Method

Replaces the Common Intermediate Language (CIL) body of the method.  
  
## Syntax  
  
```cpp  
HRESULT SetILFunctionBody(  
    [in]  ULONG   cbNewILMethodHeader,  
    [in, size_is(cbNewILMethodHeader)] LPCBYTE pbNewILMethodHeader);  
```  
  
## Parameters  

 `cbNewILMethodHeader`  
 [in] The total size of the new CIL, including the header and any structures that come after the body.  
  
 `pbNewILMethodHeader`  
 [in] A pointer to the new CIL header.  
  
## Return Value  

 This method returns the following specific HRESULTs.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The replacement was successful.|  
  
## Remarks  

 Unlike the [ICorProfilerInfo::SetILFunctionBody](icorprofilerinfo-setilfunctionbody-method.md) method, the `SetILFunctionBody` method manages the memory required for the new CIL body. This means that the CIL body provided by the profiler does not have to be allocated by using the [IMethodMalloc](imethodmalloc-interface.md) interface or allocated within a particular range. It can be allocated on any heap. The profiler can free the memory used for its CIL body after `SetILFunctionBody` returns.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorProfilerFunctionControl Interface](icorprofilerfunctioncontrol-interface.md)
