---
title: "ICorDebugGenericValue Interface1"
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
  - "ICorDebugGenericValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugGenericValue"
helpviewer_keywords: 
  - "ICorDebugGenericValue interface [.NET Framework debugging]"
ms.assetid: bc14f408-b359-4c8c-ade2-888ccdf7261b
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugGenericValue Interface1
A subclass of "ICorDebugValue" that applies to all values. This interface provides Get and Set methods for the value.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetValue Method](../../../../docs/framework/unmanaged-api/debugging/icordebuggenericvalue-getvalue-method.md)|Copies the value into the specified buffer.|  
|[SetValue Method](../../../../docs/framework/unmanaged-api/debugging/icordebuggenericvalue-setvalue-method.md)|Copies a new value from the specified buffer.|  
  
## Remarks  
 `ICorDebugGenericValue` is a sub-interface because it is non-remotable.  
  
 For reference types, the value is the reference rather than the contents of the reference.  
  
 This interface does not support being called remotely, either cross-machine or cross-process.  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
    
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
