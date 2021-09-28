---
description: "Learn more about: ICorDebugType Interface"
title: "ICorDebugType Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugType"
helpviewer_keywords: 
  - "ICorDebugType interface [.NET Framework debugging]"
ms.assetid: 94e02e31-67ea-4b00-8148-a46740a4571d
topic_type: 
  - "apiref"
---
# ICorDebugType Interface

Represents a type, either basic or complex (that is, user-defined). If the type is generic, `ICorDebugType` represents the instantiated generic type.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumerateTypeParameters Method](icordebugtype-enumeratetypeparameters-method.md)|Gets an interface pointer to an ICorDebugTypeEnum that references the generic <xref:System.Type> parameters of the class referenced by this `ICorDebugType`.|  
|[GetBase Method](icordebugtype-getbase-method.md)|Gets an interface pointer to an `ICorDebugType` that references the base class of the class referenced by this `ICorDebugType`, if one exists.|  
|[GetClass Method](icordebugtype-getclass-method.md)|Gets an interface pointer to an ICorDebugClass that references the typed constructor of this `ICorDebugType`.|  
|[GetFirstTypeParameter Method](icordebugtype-getfirsttypeparameter-method.md)|Gets an interface pointer to an `ICorDebugType` that references the first generic <xref:System.Type> parameter for the constructor of the class referenced by this `ICorDebugType`.|  
|[GetRank Method](icordebugtype-getrank-method.md)|Gets the number of dimensions in an array type.|  
|[GetStaticFieldValue Method](icordebugtype-getstaticfieldvalue-method.md)|Gets an interface pointer to an ICorDebugValue that contains the value of the static field referenced by the specified field token in the specified stack frame.|  
|[GetType Method](icordebugtype-gettype-method.md)|Gets a CorElementType value that describes the native type of the common language runtime <xref:System.Type> referenced by this `ICorDebugType`.|  
  
## Remarks  

 If the type is generic, `ICorDebugClass` represents the uninstantiated type. The `ICorDebugType` interface represents an instantiated generic type. For example, Hashtable\<K, V> would be represented by `ICorDebugClass`, whereas Hashtable\<Int32, String> would be represented by `ICorDebugType`.  
  
 Non-generic types are represented by both `ICorDebugClass` and `ICorDebugType`. The latter interface was introduced in the .NET Framework version 2.0 to deal with type instantiation.  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
