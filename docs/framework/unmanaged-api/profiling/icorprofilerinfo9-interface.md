---
description: "Learn more about: ICorProfilerInfo9 Interface"
title: "ICorProfilerInfo9 Interface"
ms.date: "08/06/2019"
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo9 Interface

A subclass of [ICorProfilerInfo8](icorprofilerinfo8-interface.md) that provides methods to query information about functions with multiple native code versions.

## Methods  

| Method|Description|  
| ------------|-----------------|  
|[GetNativeCodeStartAddresses Method](icorprofilerinfo9-getnativecodestartaddresses-method.md)| Given a functionId and rejitId, enumerates the native code start address of all jitted versions of this code that currently exist. |
|[GetILToNativeMapping3 Method](icorprofilerinfo9-getiltonativemapping3-method.md)| Given the native code start address, returns the native to IL mapping information for this jitted version of the code. |
|[GetCodeInfo4 Method](icorprofilerinfo9-getcodeinfo4-method.md)| Given the native code start address, returns the blocks of virtual memory that store this code. |

## Requirements  

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).  
**Header:** CorProf.idl, CorProf.h  
**.NET Versions:** [!INCLUDE[net_core](../../../../includes/net-core-21-md.md)]  

## See also

- [Profiling Interfaces](profiling-interfaces.md)
