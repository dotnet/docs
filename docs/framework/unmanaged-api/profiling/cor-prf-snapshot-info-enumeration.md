---
description: "Learn more about: COR_PRF_SNAPSHOT_INFO Enumeration"
title: "COR_PRF_SNAPSHOT_INFO Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "COR_PRF_SNAPSHOT_INFO"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_SNAPSHOT_INFO"
helpviewer_keywords: 
  - "COR_PRF_SNAPSHOT_INFO enumeration [.NET Framework profiling]"
ms.assetid: a5906b2a-ad4a-4cc6-a421-2d7d8adf7468
topic_type: 
  - "apiref"
---
# COR_PRF_SNAPSHOT_INFO Enumeration

Specifies how much data to pass back with a stack snapshot in each call to the profiler's [StackSnapshotCallback](stacksnapshotcallback-function.md) function.  
  
## Syntax  
  
```cpp  
typedef enum _COR_PRF_SNAPSHOT_INFO {  
    COR_PRF_SNAPSHOT_DEFAULT = 0x0,  
    COR_PRF_SNAPSHOT_REGISTER_CONTEXT = 0x1,  
    COR_PRF_SNAPSHOT_X86_OPTIMIZED = 0X2  
} COR_PRF_SNAPSHOT_INFO;  
```  
  
## Members  
  
|Members|Description|  
|-------------|-----------------|  
|`COR_PRF_SNAPSHOT_DEFAULT`|Indicates that values must be passed for all `StackSnapshotCallback` parameters, except the `context` parameter.|  
|`COR_PRF_SNAPSHOT_REGISTER_CONTEXT`|Indicates that values must be passed for all `StackSnapshotCallback` parameters, including the `context` parameter.|  
|`COR_PRF_SNAPSHOT_X86_OPTIMIZED`|Indicates that a simpler, alternative stack-walking algorithm will be used.|  
  
## Remarks  

 Values that are provided by the `COR_PRF_SNAPSHOT_INFO` enumeration are passed as parameters to the [DoStackSnapshot](icorprofilerinfo2-dostacksnapshot-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [DoStackSnapshot Method](icorprofilerinfo2-dostacksnapshot-method.md)
- [Profiling Enumerations](profiling-enumerations.md)
