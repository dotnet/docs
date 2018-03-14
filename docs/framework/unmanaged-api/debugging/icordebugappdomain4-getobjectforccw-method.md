---
title: "ICorDebugAppDomain4::GetObjectForCCW Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 2cacdb85-e7b8-42e7-b310-c3e8c22e5d33
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugAppDomain4::GetObjectForCCW Method
Gets a managed object from a COM callable wrapper (CCW) pointer.  
  
## Syntax  
  
```  
HRESULT GetObjectForCCW(  
   [in]CORDB_ADDRESS ccwPointer,   
   [out]ICorDebugValue **ppManagedObject  
);  
```  
  
#### Parameters  
 `ccwPointer`  
 [in] A COM callable wrapper (CCW) pointer.  
  
 `ppManagedObject`  
 [out] A pointer to the address of an "ICorDebugValue" object that represents the managed object that corresponds to the given CCW pointer.  
  
## Remarks  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v46plus](../../../../includes/net-current-v46plus-md.md)]  
  
## See Also  
 [ICorDebugAppDomain4 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugappdomain4-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
