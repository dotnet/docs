---
title: "ICorProfilerInfo9 Interface"
ms.date: "08/06/2019"
ms.assetid: 232a246e-07ce-460f-a48a-b567e3f41d46
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo9 Interface

A subclass of [ICorProfilerInfo8](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo8-interface.md) that provides methods to query information about functions with multiple native code versions.  

## Methods  

| Method|Description|  
| ------------|-----------------|  
|[GetNativeCodeStartAddresses Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo9-getnativecodestartaddresses-method.md)| Given a functionId and rejitId, enumerates the native code start address of all jitted versions of this code that currently exist. |
|[GetILToNativeMapping3 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo9-getiltonativemapping3-method.md)| Given the native code start address, returns the native to IL mapping information for this jitted version of the code. |
|[GetCodeInfo4 Method](icorprofilerinfo9-getcodeinfo4-method.md)| Given the native code start address, returns the blocks of virtual memory that store this code. |

## Requirements  
**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** CorProf.idl, CorProf.h  
**.NET Framework Versions:** [!INCLUDE[net_core](../../../../includes/net-core-22-md.md)]  
## See also
- [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
