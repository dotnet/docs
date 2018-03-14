---
title: "ICorDebugProcess5 Interface"
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
  - "ICorDebugProcess5"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess5"
helpviewer_keywords: 
  - "ICorDebugProcess5 interface [.NET Framework debugging]"
ms.assetid: 30a39d79-1f10-4328-9c5d-094ed824e2ba
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess5 Interface
Extends the ICorDebugProcess interface to support access to the managed heap, to provide information about garbage collection of managed objects, and to determine whether a debugger loads images from the application local native image cache.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnableNGenPolicy Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-enablengenpolicy-method.md)|Sets a value that determines how an application loads native images while running under a managed debugger.|  
|[EnumerateGCReferences Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-enumerategcreferences-method.md)|Gets an enumerator for all objects that are to be garbage-collected in a process.|  
|[EnumerateHandles Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-enumeratehandles-method.md)|Gets an enumerator for object handles in a process.|  
|[EnumerateHeap Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-enumerateheap-method.md)|Gets an enumerator for objects on the managed heap.|  
|[EnumerateHeapRegions Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-enumerateheapregions-method.md)|Gets an enumerator for regions of the managed heap.|  
|[GetArrayLayout Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-getarraylayout-method.md)|Gets information about the layout of an array in memory.|  
|[GetGCHeapInformation Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-getgcheapinformation-method.md)|Gets a pointer to a [COR_HEAPINFO](../../../../docs/framework/unmanaged-api/debugging/cor-heapinfo-structure.md) structure that contains information about objects that are to be garbage-collected on the managed heap.|  
|[GetObject Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-getobject-method.md)|Gets a pointer to an object on the managed heap.|  
|[GetTypeFields Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-gettypefields-method.md)|Gets a pointer to an array that contains field information for a type based on its type identifier.|  
|[GetTypeForTypeID Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-gettypefortypeid-method.md)|Gets a type object that provides information about an object based on its type identifiers.|  
|[GetTypeID Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-gettypeid-method.md)|Gets the type identifier for the object at a specified address.|  
|[GetTypeLayout Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-gettypelayout-method.md)|Gets information about the layout of an object in memory based on its type identifier.|  
  
## Remarks  
 This interface logically extends the ICorDebugProcess, ICorDebugProcess2, and [ICorDebugProcess3](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess3-interface.md) interfaces.  
  
> [!NOTE]
>  This interface does not support being called remotely, either from another machine or from another process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
