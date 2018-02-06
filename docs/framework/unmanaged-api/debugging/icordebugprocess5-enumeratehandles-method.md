---
title: "ICorDebugProcess5::EnumerateHandles Method"
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
  - "ICorDebugProcess5.EnumerateHandles"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess5::EnumerateHandles"
helpviewer_keywords: 
  - "EnumerateHandles method, ICorDebugProcess5 interface [.NET Framework debugging]"
  - "ICorDebugProcess5::EnumerateHandles method [.NET Framework debugging]"
ms.assetid: 7d7fa796-0dc6-4ee8-9d56-40166246d91d
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess5::EnumerateHandles Method
Gets an enumerator for object handles in a process.  
  
## Syntax  
  
```  
HRESULT EnumerateHandles(     [in] CorGCReferenceType types,  
    [out] ICorDebugGCReferenceEnum **ppEnum);  
```  
  
#### Parameters  
 `types`  
 [in] A bitwise combination of [CorGCReferenceType](../../../../docs/framework/unmanaged-api/debugging/corgcreferencetype-enumeration.md) values that specifies the type of handles to include in the collection.  
  
 `ppENum`  
 [out] A pointer to the address of an [ICorDebugGCReferenceEnum](../../../../docs/framework/unmanaged-api/debugging/icordebuggcreferenceenum-interface.md) that is an enumerator for the objects to be garbage-collected.  
  
## Remarks  
 `EnumerateHandles` is a helper function that supports inspection of the handle table. It is similar to the [ICorDebugProcess5::EnumerateGCReferences](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-enumerategcreferences-method.md) method, except that rather than populating an [ICorDebugGCReferenceEnum](../../../../docs/framework/unmanaged-api/debugging/icordebuggcreferenceenum-interface.md) collection with all objects to be garbage-collected, it includes only objects that have handles from the handle table.  
  
 The `types` parameter specifies the handle types to include in the collection. `types` can be any of the following three members of the [CorGCReferenceType](../../../../docs/framework/unmanaged-api/debugging/corgcreferencetype-enumeration.md) enumeration:  
  
-   `CorHandleStrongOnly` (handles to strong references only).  
  
-   `CorHandleWeakOnly` (handles to weak references only).  
  
-   `CorHandleAll` (all handles).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
