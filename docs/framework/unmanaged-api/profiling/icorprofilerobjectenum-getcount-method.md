---
title: "ICorProfilerObjectEnum::GetCount Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerObjectEnum.GetCount"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerObjectEnum::GetCount"
helpviewer_keywords: 
  - "ICorProfilerObjectEnum::GetCount method [.NET Framework profiling]"
  - "GetCount method, ICorProfilerObjectEnum interface [.NET Framework profiling]"
ms.assetid: 166b0761-ed80-4ccd-9973-dc20e61bf8fa
topic_type: 
  - "apiref"
---
# ICorProfilerObjectEnum::GetCount Method
Gets the total number of frozen objects in the collection.  
  
## Syntax  
  
```cpp  
HRESULT GetCount (  
    [out] ULONG   *pcelt  
);  
```  
  
## Parameters  
 `pcelt`  
 [out] A pointer to the number of frozen objects in the collection.  
  
 This method will always return zero in the .NET Framework version 3.5 Service Pack 1 (SP1) and later versions.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerObjectEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerobjectenum-interface.md)
