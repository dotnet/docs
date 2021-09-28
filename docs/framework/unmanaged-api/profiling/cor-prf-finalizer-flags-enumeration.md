---
description: "Learn more about: COR_PRF_FINALIZER_FLAGS Enumeration"
title: "COR_PRF_FINALIZER_FLAGS Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "COR_PRF_FINALIZER_FLAGS"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_FINALIZER_FLAGS"
helpviewer_keywords: 
  - "COR_PRF_FINALIZER_FLAGS enumeration [.NET Framework profiling]"
ms.assetid: 297d7721-3911-4f36-9e34-d9da0c33e22a
topic_type: 
  - "apiref"
---
# COR_PRF_FINALIZER_FLAGS Enumeration

Describes the finalizer for an object.  
  
## Syntax  
  
```cpp  
typedef enum {  
    COR_PRF_FINALIZER_CRITICAL = 0x1  
} COR_PRF_FINALIZER_FLAGS;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COR_PRF_FINALIZER_CRITICAL`|The finalizer is critical.|  
  
## Remarks  

 The `COR_PRF_FINALIZER_FLAGS` enumeration is used by the [ICorProfilerCallback2::FinalizeableObjectQueued](icorprofilercallback2-finalizeableobjectqueued-method.md) method to describe the finalizer for an object.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Profiling Enumerations](profiling-enumerations.md)
