---
title: "ICorDebugComObjectValue::GetCachedInterfacePointers Method"
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
  - "ICorDebugComObjectValue::GetCachedInterfacePointers"
api_location: 
  - "mscordbi.dll"
f1_keywords: 
  - "ICorDebugComObjectValue::GetCachedInterfacePointers"
helpviewer_keywords: 
  - "ICorDebugComObjectValue::GetCachedInterfacePointers method [.NET Framework debugging]"
  - "GetCachedInterfacePointers method, ICorDebugComObjectValue interface [.NET Framework debugging]"
ms.assetid: 08dbd558-bd39-4263-94c2-71e70687aaf0
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugComObjectValue::GetCachedInterfacePointers Method
Gets the raw interface pointers cached on the current runtime callable wrapper (RCW).  
  
## Syntax  
  
```  
HRESULT GetCachedInterfacePointers(  
    [in] BOOL bIInspectableOnly,  
    [in] ULONG32 celt,  
    [out] ULONG32 *pceltFetched,  
    [out, size_is(celt), length_is(*pceltFetched) CORDB_ADDRESS *ptrs);  
```  
  
#### Parameters  
 `bIInspectableOnly`  
 [in] A value that indicates whether the method will return only [!INCLUDE[wrt](../../../../includes/wrt-md.md)] interfaces (`IInspectable` interfaces) or all COM interfaces that are cached by the runtime callable wrapper (RCW).  
  
 `celt`  
 [in] The number of objects whose addresses are to be retrieved.  
  
 `pceltFetched`  
 [out] A pointer to the number of `CORDB_ADDRESS` values actually returned in `ptrs`.  
  
 `ptrs`  
 A pointer to the starting address of an array of `CORDB_ADDRESS` values that contain the addresses of cached interface objects.  
  
## Remarks  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorDebugComObjectValue Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugcomobjectvalue-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
