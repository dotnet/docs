---
title: "ICorProfilerInfo8::IsFunctionDynamic"
ms.date: "08/DD/YYYY"
dev_langs: 
  - "cpp"
api_name: 
  - "ICorProfilerInfo8.IsFunctionDynamic"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
ms.assetid: 9cb66b70-b00a-4809-abc3-28c0a26faf64
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo8::IsFunctionDynamic Method
  
  Determines if a function has associated metadata  Certain methods like IL Stubs or LCG Methods do not have associated metadata that can be retrieved using the IMetaDataImport APIs.  Such methods can be encountered by profilers through instruction pointers or by listening to ICorProfilerCallback::DynamicMethodJITCompilationStarted  This API can be used to determine whether a FunctionID is dynamic.    
  
## Syntax  
  
```cpp
TODO: Method Signature
```  
  
#### Parameters  
 `TODO: param name`  
 TODO: param description  
  
## Remarks  
 TODO: Remarks  

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)  
  
## See also
- [ICorProfilerInfo8 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo8-interface.md)

