---
description: "Learn more about: ICorDebugClass Interface"
title: "ICorDebugClass Interface"
ms.date: "03/30/2017"
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
---
# ICorDebugClass Interface

Represents a type, which can be either basic or complex (that is, user-defined). If the type is generic, `ICorDebugClass` represents the uninstantiated generic type.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetModule Method](icordebugclass-getmodule-method.md)|Gets the module that defines this class.|  
|[GetStaticFieldValue Method](icordebugclass-getstaticfieldvalue-method.md)|Gets the value of the specified static field.|  
|[GetToken Method](icordebugclass-gettoken-method.md)|Gets the `TypeDef` metadata token for this class.|  
  
## Remarks  

 The `ICorDebugClass` interface represents an uninstantiated generic type. The ICorDebugType interface represents an instantiated generic type. For example, `Hashtable<K, V>` would be represented by `ICorDebugClass`, whereas `Hashtable<Int32, String>` would be represented by `ICorDebugType`.  
  
 Non-generic types are represented by both `ICorDebugClass` and `ICorDebugType`. The latter interface was introduced in the .NET Framework version 2.0 to deal with type instantiation.  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
