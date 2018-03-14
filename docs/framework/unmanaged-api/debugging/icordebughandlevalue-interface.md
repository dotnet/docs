---
title: "ICorDebugHandleValue Interface1"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugHandleValue Interface1
A subclass of ICorDebugReferenceValue that represents a reference value to which the debugger has created a handle for garbage collection.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Dispose Method](../../../../docs/framework/unmanaged-api/debugging/icordebughandlevalue-dispose-method.md)|Releases the handle referenced by this `ICorDebugHandleValue` object without explicitly releasing the interface pointer.|  
|[GetHandleType Method](../../../../docs/framework/unmanaged-api/debugging/icordebughandlevalue-gethandletype-method.md)|Gets a CorDebugHandleType value that describes the kind of handle referenced by this `ICorDebugHandleValue`.|  
  
## Remarks  
 An `ICorDebugReferenceValue` object is invalidated by a break in the execution of debugged code. An `ICorDebugHandleValue` maintains its reference through breaks and continuations, until it is explicitly released.  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
