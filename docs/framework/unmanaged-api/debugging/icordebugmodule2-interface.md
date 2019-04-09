---
title: "ICorDebugModule2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugModule2"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModule2"
helpviewer_keywords: 
  - "ICorDebugModule2 interface [.NET Framework debugging]"
ms.assetid: 0847e64f-fdbe-4c96-8168-da20fdc84d80
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugModule2 Interface

Serves as a logical extension to the ICorDebugModule interface.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ApplyChanges Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule2-applychanges-method.md)|Applies the changes in the metadata and the changes in the Microsoft intermediate language (MSIL) code to the running process.|  
|[GetJITCompilerFlags Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule2-getjitcompilerflags-method.md)|Gets the flags that control the just-in-time (JIT) compilation for this `ICorDebugModule2`.|  
|[ResolveAssembly Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule2-resolveassembly-method.md)|Resolves the assembly referenced by the specified metadata token.|  
|[SetJITCompilerFlags Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule2-setjitcompilerflags-method.md)|Sets the flags that control the JIT compilation for this `ICorDebugModule2`.|  
|[SetJMCStatus Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule2-setjmcstatus-method.md)|Sets the Just My Code (JMC) status of all methods of all the classes in this `ICorDebugModule2` to the specified value, except those in the `pTokens` array, which it sets to the opposite value.|  
  
## Remarks  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
