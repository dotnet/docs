---
title: "ICorDebugReferenceValue Interface1"
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
  - "ICorDebugReferenceValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugReferenceValue"
helpviewer_keywords: 
  - "ICorDebugReferenceValue interface [.NET Framework debugging]"
ms.assetid: 2040e2be-119a-4cfb-ae52-b0b6f052665c
topic_type: 
  - "apiref"
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugReferenceValue Interface1
Provides methods that manage a value that is a reference to an object. (That is, this interface provides methods that manage a pointer.) This interface implements "ICorDebugValue".  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Dereference Method](../../../../docs/framework/unmanaged-api/debugging/icordebugreferencevalue-dereference-method.md)|Gets the object that is referenced.|  
|[DereferenceStrong Method](../../../../docs/framework/unmanaged-api/debugging/icordebugreferencevalue-dereferencestrong-method.md)|Not implemented. Do not call this method.|  
|[GetValue Method](../../../../docs/framework/unmanaged-api/debugging/icordebugreferencevalue-getvalue-method.md)|Gets the current memory address of the referenced object.|  
|[IsNull Method](../../../../docs/framework/unmanaged-api/debugging/icordebugreferencevalue-isnull-method.md)|Gets a value that indicates whether this `ICorDebugReferenceValue` is a null value, in which case the `ICorDebugReferenceValue` does not point to an object.|  
|[SetValue Method](../../../../docs/framework/unmanaged-api/debugging/icordebugreferencevalue-setvalue-method.md)|Sets the current memory address. That is, this method sets this `ICorDebugReferenceValue` to point to an object.|  
  
## Remarks  
 The common language runtime (CLR) may do a garbage collection on objects when the debugged process is continued. The garbage collection may move objects around in memory. An `ICorDebugReferenceValue` will either cooperate with the garbage collection so that its information is updated after the garbage collection, or it will be invalidated implicitly before the garbage collection.  
  
 The `ICorDebugReferenceValue` object may be implicitly invalidated after the debugged process has been continued. The derived "ICorDebugHandleValue" is not invalidated until it is explicitly released or exposed.  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
    
    
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
