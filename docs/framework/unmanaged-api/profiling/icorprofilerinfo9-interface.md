---
title: "ICorProfilerInfo9 Interface"
ms.date: "08/DD/YYYY"
ms.assetid: 232a246e-07ce-460f-a48a-b567e3f41d46
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo9 Interface

A subclass of [ICorProfilerInfo8](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo8-interface.md) that provides ***TODO: Placeholder***  

## Methods  

| Method|Description|  
| ------------|-----------------|  
|[GetNativeCodeStartAddresses Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo9-getnativecodestartaddresses-method.md)|Given functionId + rejitId, enumerate the native code start address of all jitted versions of this code that currently exist |
|[GetILToNativeMapping3 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo9-getiltonativemapping3-method.md)|Given the native code start address, return the native->IL mapping information for this jitted version of the code |

## Requirements  
**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** CorProf.idl, CorProf.h  
**.NET Framework Versions:** [!INCLUDE[net_core](../../../../includes/net-core.md)]  
## See also
- [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
