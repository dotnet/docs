---
description: "Learn more about: ICorDebugCode2 Interface"
title: "ICorDebugCode2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugCode2"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugCode2"
helpviewer_keywords: 
  - "ICorDebugCode2 interface [.NET Framework debugging]"
ms.assetid: 9321903b-7dea-40d8-ba32-99016c00cc46
topic_type: 
  - "apiref"
---
# ICorDebugCode2 Interface

Provides methods that extend the capabilities of "ICorDebugCode".  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetCodeChunks Method](icordebugcode2-getcodechunks-method.md)|Gets the chunks of code that this code object is composed of.|  
|[GetCompilerFlags Method](icordebugcode2-getcompilerflags-method.md)|Gets the flags that specify the conditions under which this code object was either just-in-time (JIT) compiled or generated using the native image generator (Ngen.exe).|  
  
## Remarks  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorDebugCode3 Interface](icordebugcode3-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
