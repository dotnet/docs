---
title: "ICorDebugProcess5::EnumerateGCReferences Method"
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
  - "ICorDebugProcess5.EnumerateGCReferences"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess5::EnumerateGCReferences"
helpviewer_keywords: 
  - "EnumerateGCReferences method, ICorDebugProcess5 interface [.NET Framework debugging]"
  - "ICorDebugProcess5::EnumerateGCReferences method [.NET Framework debugging]"
ms.assetid: 86c397c3-81d8-463e-a248-3cbe06c44d9d
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess5::EnumerateGCReferences Method
Gets an enumerator for all objects that are to be garbage-collected in a process.  
  
## Syntax  
  
```  
HRESULT EnumerateGCReferences(  
    [in] Bool enumerateWeakReferences,   
    [out] ICorDebugGCReferenceEnum **ppEnum  
);  
```  
  
#### Parameters  
 `enumerateWeakReferences`  
 [in] A Boolean value that indicates whether weak references are also to be enumerated. If `enumerateWeakReferences` is `true`, the `ppEnum` enumerator includes both strong references and weak references. If `enumerateWeakReferences` is `false`, the enumerator includes only strong references.  
  
 `ppEnum`  
 [out] A pointer to the address of an [ICorDebugGCReferenceEnum](../../../../docs/framework/unmanaged-api/debugging/icordebuggcreferenceenum-interface.md) that is an enumerator for the objects to be garbage-collected.  
  
## Remarks  
 This method provides a way to determine the full rooting chain for any managed object in a process and can be used to determine why an object is still alive.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorDebugProcess5 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
