---
description: "Learn more about: ICorDebugHandleValue Interface"
title: "ICorDebugHandleValue Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugHandleValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugHandleValue"
helpviewer_keywords: 
  - "ICorDebugHandleValue interface [.NET Framework debugging]"
ms.assetid: 66fcd2b8-ac66-414b-83a8-75a925e17772
topic_type: 
  - "apiref"
---
# ICorDebugHandleValue Interface

A subclass of ICorDebugReferenceValue that represents a reference value to which the debugger has created a handle for garbage collection.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Dispose Method](icordebughandlevalue-dispose-method.md)|Releases the handle referenced by this `ICorDebugHandleValue` object without explicitly releasing the interface pointer.|  
|[GetHandleType Method](icordebughandlevalue-gethandletype-method.md)|Gets a CorDebugHandleType value that describes the kind of handle referenced by this `ICorDebugHandleValue`.|  
  
## Remarks  

 An `ICorDebugReferenceValue` object is invalidated by a break in the execution of debugged code. An `ICorDebugHandleValue` maintains its reference through breaks and continuations, until it is explicitly released.  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
