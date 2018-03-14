---
title: "ICorDebugObjectValue Interface1"
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
  - "ICorDebugObjectValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugObjectValue"
helpviewer_keywords: 
  - "ICorDebugObjectValue interface [.NET Framework debugging]"
ms.assetid: 937de6a0-6fbf-4ddc-80ea-a6217b73e62b
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugObjectValue Interface1
A subclass of "ICorDebugValue" that represents a value that contains an object.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetClass Method](../../../../docs/framework/unmanaged-api/debugging/icordebugobjectvalue-getclass-method.md)|Gets an interface pointer to the common language runtime (CLR) <xref:System.Type> of the object that this `ICorDebugObjectValue` references.|  
|[GetContext Method](../../../../docs/framework/unmanaged-api/debugging/icordebugobjectvalue-getcontext-method.md)|Not implemented.|  
|[GetFieldValue Method](../../../../docs/framework/unmanaged-api/debugging/icordebugobjectvalue-getfieldvalue-method.md)|Gets an interface pointer to an [ICorDebugValue](../../../../docs/framework/unmanaged-api/debugging/icordebugvalue-interface.md) that represents the value of the specified field of the specified class.|  
|[GetManagedCopy Method](../../../../docs/framework/unmanaged-api/debugging/icordebugobjectvalue-getmanagedcopy-method.md)|Obsolete. Do not call this method.|  
|[GetVirtualMethod Method](../../../../docs/framework/unmanaged-api/debugging/icordebugobjectvalue-getvirtualmethod-method.md)|Not implemented.|  
|[IsValueClass Method](../../../../docs/framework/unmanaged-api/debugging/icordebugobjectvalue-isvalueclass-method.md)|Gets a value that indicates whether the object referenced by this `ICorDebugObjectValue` is a value type.|  
|[SetFromManagedCopy Method](../../../../docs/framework/unmanaged-api/debugging/icordebugobjectvalue-setfrommanagedcopy-method.md)|Obsolete. Do not call this method.|  
  
## Remarks  
 An `ICorDebugObjectValue` remains valid until the process being debugged is continued.  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 
