---
title: "ICorDebugClass Interface1"
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
  - "ICorDebugClass"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugClass"
helpviewer_keywords: 
  - "ICorDebugClass interface [.NET Framework debugging]"
ms.assetid: 03a6facb-f12f-49be-9839-e73b9c791cd5
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugClass Interface1
Represents a type, which can be either basic or complex (that is, user-defined). If the type is generic, `ICorDebugClass` represents the uninstantiated generic type.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetModule Method](../../../../docs/framework/unmanaged-api/debugging/icordebugclass-getmodule-method.md)|Gets the module that defines this class.|  
|[GetStaticFieldValue Method](../../../../docs/framework/unmanaged-api/debugging/icordebugclass-getstaticfieldvalue-method.md)|Gets the value of the specified static field.|  
|[GetToken Method](../../../../docs/framework/unmanaged-api/debugging/icordebugclass-gettoken-method.md)|Gets the `TypeDef` metadata token for this class.|  
  
## Remarks  
 The `ICorDebugClass` interface represents an uninstantiated generic type. The ICorDebugType interface represents an instantiated generic type. For example, `Hashtable<K, V>` would be represented by `ICorDebugClass`, whereas `Hashtable<Int32, String>` would be represented by `ICorDebugType`.  
  
 Non-generic types are represented by both `ICorDebugClass` and `ICorDebugType`. The latter interface was introduced in the .NET Framework version 2.0 to deal with type instantiation.  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
