---
description: "Learn more about: ICorProfilerObjectEnum::Skip Method"
title: "ICorProfilerObjectEnum::Skip Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerObjectEnum.Skip"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerObjectEnum::Skip"
helpviewer_keywords: 
  - "ICorProfilerObjectEnum::Skip method [.NET Framework profiling]"
  - "Skip method, ICorProfilerObjectEnum interface [.NET Framework profiling]"
ms.assetid: f8e498f8-f93a-4b82-bd22-55bdbf5e8d45
topic_type: 
  - "apiref"
---
# ICorProfilerObjectEnum::Skip Method

Advances the cursor of this enumerator from its current position so that the specified number of elements are skipped.  
  
## Syntax  
  
```cpp  
HRESULT Skip (  
    [in] ULONG   celt  
);  
```  
  
## Parameters  

 `celt`  
 [in] The number of elements to be skipped.  
  
## Remarks  

 The new position of this enumerator's cursor is: (current position) + `celt` .  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerObjectEnum Interface](icorprofilerobjectenum-interface.md)
